using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
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
            public static String changingColors { get { return "An error occured when changing colors. It wont be possible to use the {0} drawing and it will be skipped. \n Would you like to resume the process for the remaining drawings?"; } }
            public static String addingRevisionBlock { get { return "An error occured when adding the revision title block. \n Would you like to resume the process for the remaining drawings?"; } }
            public static String fileNotFound { get { return "Drawing you want to edit was not found. \n Would you like to resume the process for the remaining drawings?"; } }
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
            if (modifyPdfs.IsBusy) { return; }
            
            //if not files selected exit
            if(files == null) { return; }

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
                worker.ReportProgress((i+1) * (100 / files.Length));

                //get source drawing path
                if (!File.Exists(files[i]))
                {
                    DialogResult result = MessageBox.Show(String.Format(ErrorMessages.fileNotFound, ""), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    worker.ReportProgress(0);
                    if (result.Equals(DialogResult.No)) {e.Cancel = true; break;}
                    continue;
                }
                string sourcePath = files[i];

                //change Annot colors
                string destPath = generateTempFileName(sourcePath, ckbx_createNewNames.Checked, i);
                bool colorChangeComplete = changeColorOfAnnotsByColor(sourcePath, destPath, Color.Red, Color.Black);

                //handle errors
                if (!colorChangeComplete)
                {
                    if (File.Exists(destPath)) { File.Delete(destPath); }
                    DialogResult result = MessageBox.Show(String.Format(ErrorMessages.changingColors, ""), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result.Equals(DialogResult.No)) { e.Cancel = true; break; }
                    continue;
                }
                cleanupFiles(sourcePath, destPath, ckbx_createNewNames.Checked);

                //add revision title block
                if (ckbc_revisionBlock.Checked)
                {
                    //check which filename was used
                    string tempPath = "";
                    if (ckbx_createNewNames.Checked)
                    {tempPath = generateTempFileName(destPath, false, i);}
                    else
                    {tempPath = generateTempFileName(sourcePath, false, i);}

                    string revision = destPath.Substring(destPath.LastIndexOf('.') - 4, 4);
                    bool revTitleAdded = addRevisionTitleblock(destPath, tempPath, revision, tb_author.Text);

                    // handle errors
                    if (!revTitleAdded)
                    {
                        if (File.Exists(tempPath)) { File.Delete(tempPath); }
                        DialogResult result = MessageBox.Show(String.Format(ErrorMessages.addingRevisionBlock, ""), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result.Equals(DialogResult.No)) { e.Cancel = true; break; }
                        continue;
                    }
                    cleanupFiles(destPath, tempPath, false);
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
            Thread.Sleep(500);
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
        private void _setupProgressbar ()
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
        private static void cleanupFiles(string originalFile, string tempFile, bool keepNewName)
        {
            //replace or delete files
            if (keepNewName)
            {
                File.Delete(originalFile);
            }
            else
            {
                File.Delete(originalFile);
                File.Move(tempFile, originalFile);
            }
        }
        private static string generateTempFileName(string sourcePath, bool createNewName, int fileIndex)
        {
            //create temp drawing name for editing
            string sourceDir = Path.GetDirectoryName(sourcePath);
            string sourceFileName = Path.GetFileNameWithoutExtension(sourcePath);
            string tempPath = Path.Combine(sourceDir, sourceFileName) + "(1).pdf";

            // if user requests renaming the file generate new fileName
            if (createNewName)
            {
                string sketch = String.Format("SKETCH {0,2:D2}", fileIndex + 1);
                string name = sourceFileName.Substring(
                    sourceFileName.IndexOf("HPC"),
                    sourceFileName.LastIndexOf("-") - sourceFileName.IndexOf("HPC"));
                string rev = getNextRevisionFromDocument(sourcePath);
                tempPath = String.Format("{0}\\{1} {2}-{3}.pdf", sourceDir, sketch, name, rev);
            }

            //generate stream
            FileInfo fileInfo = new FileInfo(tempPath);
            fileInfo.Directory.Create();
            File.Copy(sourcePath, tempPath);
            
            return tempPath;
        }
    }
}
