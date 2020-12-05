using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using static PdfParser.PdfParser;

namespace JDO_DT_PdfTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //GLOBAL VARS
        string[] files;

        //STANDARD ERROR MESSAGES
        private static class ErrorMessages
        {
            public static String changingColors { get { return "An error occured when changing colors. It wont be possible to use the {0} drawing and it will be skipped. \nWould you like to resume the process for the remaining drawings?"; } }
            public static String addingRevisionBlock { get { return "An error occured when adding the revision title block. \nWould you like to resume the process for the remaining drawings?"; } }
            public static String fileNotFound { get { return "Drawing you want to edit was not found. \nWould you like to resume the process for the remaining drawings?"; } }
            public static String noFilesSelected { get { return "File selection was lost. \nPlease re-select the files you wish to edit"; } }
            public static String processRunning { get { return "Editing in progress. \nPlease wait for the previous edit request to finish."; } }
        }

        //BUTTONS
        private void btn_selectFiles_Click(object sender, EventArgs e)
        {
            files = getPdfFilesFromUser();

            if (files != null)
            {
                //empty list of files
                richTextBox1.Text = "";

                //reset progressbar
                _setupProgressbar();

                //append new file list
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    richTextBox1.AppendText(fileName + "\r\n");
                }
            }
        }
        private void btn_modify_Click(object sender, EventArgs e)
        {
            //if already running exit
            if (modifyPdfs.IsBusy) { MessageBox.Show(String.Format(ErrorMessages.processRunning, ""), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            //if not files selected exit
            if (files == null){ MessageBox.Show(String.Format(ErrorMessages.noFilesSelected, ""), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);return; }

            //setup progressbar
            _setupProgressbar();

            //modify pdfs in background
            modifyPdfs.RunWorkerAsync();
        }

        //WORK
        private void modifyPDFs_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 0; i < files.Length; i++)
            {
                //increment progress
                worker.ReportProgress((i+1) * (100 / files.Length)-1);

                //get source drawing path if exists, otherwise skip file
                string sourcePath = "";
                if (File.Exists(files[i]))
                {
                    sourcePath = files[i];
                }
                else
                {
                    DialogResult result = MessageBox.Show(String.Format(ErrorMessages.fileNotFound, ""), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    worker.ReportProgress(0);
                    if (result.Equals(DialogResult.No)) { e.Cancel = true; break; }
                    continue;
                }

                // create working documents
                string destPath = generateDestFile(sourcePath, i);
                string tempDestPath = generateTempFileName(destPath);

                //change Annot colors and handle errors
                if (ckbx_blackenAnnots.Checked)
                {
                    bool colorChangeComplete = changeColorOfAnnotsByColor(destPath, tempDestPath, Color.Red, Color.Black);
                    if (colorChangeComplete)
                    {
                        cleanupTempFiles(destPath, tempDestPath);
                    }
                    else
                    {
                        if (File.Exists(destPath)) { File.Delete(destPath); }
                        if (File.Exists(tempDestPath)) { File.Delete(tempDestPath); }
                        DialogResult result = MessageBox.Show(String.Format(ErrorMessages.changingColors, ""), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result.Equals(DialogResult.No)) { e.Cancel = true; break; }
                        continue;
                    }
                }

                //add revision title block
                if (ckbc_addRevisionBlock.Checked)
                {
                    string revision = destPath.Substring(destPath.LastIndexOf('.') - 4, 4);
                    bool revTitleAdded = addRevisionTitleblock(destPath, tempDestPath, revision, tb_author.Text, tb_checker.Text);
                    if (revTitleAdded)
                    {
                        cleanupTempFiles(destPath, tempDestPath);
                    }
                    else
                    {
                        if (File.Exists(tempDestPath)) { File.Delete(tempDestPath); }
                        DialogResult result = MessageBox.Show(String.Format(ErrorMessages.addingRevisionBlock, ""), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result.Equals(DialogResult.No)) { e.Cancel = true; break; }
                        continue;
                    }
                }

                //delete old files if requested
                if (ckbx_deleteOldFile.Checked)
                {
                    File.Delete(sourcePath);
                }
            }
        }
        private void modifyPDFs_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _updateProgressbar(e.ProgressPercentage);
        }
        private void modifyPDFs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if cancelled update bar to say cancelled
            if (e.Cancelled) { _updateProgressbar(0); return; }

            //else wait for explorer to update and finalise
            Thread.Sleep(1000);
            _finaliseProgressbar();
        }

        //USER INTERFACE
        private bool validateUserFileSelection(string[] files, string extension)
        {
            foreach (string file in files)
            {
                if (!file.Contains(extension))
                {
                    return false;
                }
            }
            return true;
        }
        private bool validateUserFileSelection(string file, string extension)
        {
            if (!file.Contains(extension))
            {
                return false;
            }
            return true;
        }
        private void _setupProgressbar()
        {
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            lbl_progress.Text = "Progress 0%";
        }
        private void _updateProgressbar(int currentPercentage)
        {
            // if returned by 0 means interrupted
            if(currentPercentage == 0)
            {
                lbl_progress.Text = "User Interrupted";
                progressBar1.Value = 0;
                return;
            }
            //else update normally
            lbl_progress.Text = String.Format("Progress {0}%", currentPercentage);
            progressBar1.Value = currentPercentage;
        }
        private void _finaliseProgressbar()
        {
            progressBar1.Value = progressBar1.Maximum;
            lbl_progress.Text = "Progress 100% - Complete";
        }

        //HELPER METHODS
        private static string[] getPdfFilesFromUser()
        {
            OpenFileDialog fileDialog = new OpenFileDialog 
            {
                Title = "Please select .pdf files to edit",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\OneDrive Corp\\Atkins Ltd\\UK1226_SDLT - Documents",
                Filter = "Pdf Files|*.pdf",
                FilterIndex = 1,
                Multiselect = true,
                RestoreDirectory = true
            };

            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return fileDialog.FileNames;
            }
            return null;
        }
        private static void cleanupTempFiles(string destinationFile, string tempFile)
        {
            //delete destinaton file
            File.Delete(destinationFile);
            //replace files
            File.Move(tempFile, destinationFile);
        }
        private static string generateDestFile(string sourcePath, int fileIndex)
        {
            //create temp drawing name for editing
            string sourceDir = Path.GetDirectoryName(sourcePath);
            string sourceFileName = Path.GetFileNameWithoutExtension(sourcePath);

            string sketch = String.Format("SKETCH {0,2:D2}", fileIndex + 1);
            string name = sourceFileName.Substring(
                sourceFileName.IndexOf("HPC"),
                sourceFileName.LastIndexOf("-") - sourceFileName.IndexOf("HPC"));
            string rev = getNextRevisionFromAnnotations(sourcePath);
            string destPath = String.Format("{0}\\{1} {2}-{3}.pdf", sourceDir, sketch, name, rev);

            //generate stream
            File.Copy(sourcePath, destPath);
            
            return destPath;
        }
        private static string generateTempFileName(string destPath)
        {
            //create temp drawing name for editing
            string sourceDir = Path.GetDirectoryName(destPath);
            string sourceFileName = Path.GetFileNameWithoutExtension(destPath);
            string tempPath = Path.Combine(sourceDir, sourceFileName) + "(1).pdf";

            return tempPath;
        }
    }
}
