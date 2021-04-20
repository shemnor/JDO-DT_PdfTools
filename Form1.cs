using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static PdfParser.PdfParser;
using static ExcelTools.ExcelTools;

namespace JDO_DT_PdfTools
{
    /// <summary>
    ///  knows errors:::
    /// name format "HPC-UK1226-U1-HNX-DRR-020214-A " causes an unhadled error!!
    /// 
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //GLOBAL VARS
        List<string> files;
        List<string> filesToCopy;

        //STANDARD ERROR MESSAGES

        private static class RegexPattern
        {
            public static String numericalRev { get { return @"[A-Z]\.[0-9][0-9]"; } }
            public static String letterRev { get { return @"(?<=\d\d\d\d\d\d[-_ .])[A-Z]$"; } }
            public static String correctRev { get { return @"([A-Z]\.[0-9][0-9])|(?<=\d\d\d\d\d\d-)[A-Z]"; } }
            public static String messyNnbName { get { return @"HPC[-_ .]UK1226[-_ .]U\d[-_ .]\w\w\w[-_ .]\w\w\w[-_ .]\d\d\d\d\d\d"; } }
            public static String messyNnbNameWithRev { get { return @"HPC[-_ .]UK1226[-_ .]U\d[-_ .]\w\w\w[-_ .]\w\w\w[-_ .]\d\d\d\d\d\d(([-_ .][A-Z]\.\d\d)|([-_ .][A-Z]))"; } }
            public static String correctNnbName { get { return @"HPC-UK1226-U\d-\w\w\w-\w\w\w-\d\d\d\d\d\d-(\w\.\d\d$|[A-Z]$)"; } }
            public static String errorMessage { get { return @" - Error.(.*)$"; } }
            public static String sketchPrefix { get { return @"[Ss][Kk][Ee][Tt][Cc][Hh][-_.](\d|\d\d|\d\d\d)[-_.]"; } }
            public static String building { get { return @"(?<=-U[1-9]-)((\w\w\d)|(\w\w\w))"; } }
            public static String unit { get { return @"(?<=-UK1226-)(\w\d)"; } }
            public static String refNumber { get { return @"(?<=[-_.])\d\d\d\d\d\d(?=[-_.])"; } }
          
        }

        private static class Directories
        {
            public static String signatures { get { return @"C:\Users\SZCZ1360\OneDrive Corp\Atkins Ltd\UK1226_SDLT - Documents\General\10 Misc\Signatures"; } }
            public static String HDU1Tracker { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive Corp\Atkins Ltd\UK1226_SDLT - Documents\04_HD\01 Unit 1\HD Redline-Model tracker.xlsm"; } }
            public static String HDU2Tracker { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive Corp\Atkins Ltd\UK1226_SDLT - Documents\04_HD\01 Unit 2\HD Redline-Model tracker.xlsm"; } }
            public static String HNU1Tracker { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive Corp\Atkins Ltd\UK1226_SDLT - Documents\08_HN\HN Redline-Model tracker.xlsm"; } }
            public static String HNU2Tracker { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive Corp\Atkins Ltd\UK1226_SDLT - Documents\08_HN\07 Unit 2\HN U2 Redline-Model tracker.xlsm"; } }
            public static String HQATracker { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive Corp\Atkins Ltd\UK1226_SDLT - Documents\05_HQA\HQA Redline-Model tracker.xlsx"; } }
            public static String HQBTracker { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive Corp\Atkins Ltd\UK1226_SDLT - Documents\06_HQB\HQB Redline-Model tracker.xlsm"; } }
            public static String HQCTracker { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive Corp\Atkins Ltd\UK1226_SDLT - Documents\07_HQC\HQC Redline-Model tracker.xlsx"; } }

        }

        private class RevCellDims
        {
            public int rowCount { get; }
            //rev box
            public float revBoxX { get; }
            public float revBoxWidth { get; }
            public float revBoxY { get; }
            public float rowHeight { get; }
            public float rowSpacing { get; }

            public float cellMargin { get; }
            public float authCellX { get; }
            public float authCellWidth { get; }
            public float chckCellX { get; }
            public float chckCellWidth { get; }
            public float apprCellX { get; }
            public float apprCellWidth { get; }

            public RevCellDims(int rowCount, float revBoxX, float revBoxWidth, float revBoxY, float rowHeight, float rowSpacing,
                                float cellMargin, float authCellX, float authCellWidth, float chckCellX, float chckCellWidth,
                                float apprCellX, float apprCellWidth)
            {
                this.rowCount = rowCount;
                this.revBoxX = revBoxX;
                this.revBoxWidth = revBoxWidth;
                this.revBoxY = revBoxY;
                this.rowHeight = rowHeight;
                this.rowSpacing = rowSpacing;
                this.cellMargin = cellMargin;
                this.authCellX = authCellX;
                this.authCellWidth = authCellWidth;
                this.chckCellX = chckCellX;
                this.chckCellWidth = chckCellWidth;
                this.apprCellX = apprCellX;
                this.apprCellWidth = apprCellWidth;
            }
        }

        #region ##############################  BUTTONS  #######################################
        private void btn_preview_Click(object sender, EventArgs e)
        {
            //check if files loaded
            if (files == null) { tb_existingFiles.Text = "Please select files first!"; return; }

            //clean preview window
            tb_editedFiles.Text = "";

            //generate valid names for destination files
            List<string> validatedDestNamePreviews = generateValidDestNamePreviews(files);

            //display new names
            updateNewFilesDisplay(validatedDestNamePreviews);

        }
        private void btn_ModifyName_Click(object sender, EventArgs e)
        {
            //check if files loaded
            if (files == null) { tb_existingFiles.Text = "Please select files first!"; return; }

            //check if files are open
            bool filesAreOpen = checkIfFilesAreOpen(files);
            if (filesAreOpen) { updateNewFilesDisplay(new List<string>() { "Error. Some files are open, please close all files and try again." }); return; }

            //backup files if requested
            if (ckbx_backupFiles.Checked) { backupFiles(files); }

            //save new names
            List<string> validatedDestFilePaths = generateValidDestPaths(files);

            //rename files
            for (int i = 0; i < files.Count; i++)
            {
                if (!validatedDestFilePaths[i].Contains("Error"))
                {
                    File.Move(files[i], validatedDestFilePaths[i]);
                }
            }

            //update source file paths
            removeMessagesFromPaths(ref validatedDestFilePaths);
            files = validatedDestFilePaths;

            //update displays
            updateSouceFilesDisplay(files);
            tb_editedFiles.Text = "";
        }
        private void btn_selectFiles_Click(object sender, EventArgs e)
        {
            //open UI for file selection
            files = getPdfFilesFromUser();

            if (files != null)
            {
                //sort files based on the file number only
                files = sortFiles(files);

                //display names
                updateSouceFilesDisplay(files);
            }
        }
        private void btn_selectCopyFiles_Click(object sender, EventArgs e)
        {
            //open UI for file selection
            filesToCopy = getPdfFilesFromUser();

            if (filesToCopy != null)
            {
                //sort files based on the file number only
                filesToCopy = sortFiles(filesToCopy);

                //dont display files we copy from
            }
        }
        private void btn_instertRevBlock_Click(object sender, EventArgs e)
        {
            //check if files loaded
            if (files == null) { tb_existingFiles.Text = "Please select files first!"; return; }

            //check if files are open
            bool filesAreOpen = checkIfFilesAreOpen(files);
            if (filesAreOpen) { updateNewFilesDisplay(new List<string>() { "Error. Some files are open, please close all files and try again." }); return; }

            //backup files if requested
            if (ckbx_backupFiles.Checked) { backupFiles(files); }

            //add block
            List<string> outputMessages = insertRevBlock(files, Directories.signatures, tb_author.Text, tb_checker.Text, tb_reviewer.Text, tb_reason.Text);

            //update preview
            tb_editedFiles.Text = "";
            updateNewFilesDisplay(outputMessages);
        }
        private void btn_editContent_Click(object sender, EventArgs e)
        {
            //check if files loaded
            if (files == null) { tb_existingFiles.Text = "Please select files first!"; return; }
            if(rb_copyRedAnnots.Checked && filesToCopy == null) { tb_existingFiles.Text = "Please select which files to copy from first!"; return; }

            //check if files are open
            bool filesAreOpen = checkIfFilesAreOpen(files);
            if (filesAreOpen) { updateNewFilesDisplay(new List<string>() { "Error. Some files are open, please close all files and try again." }); return; }
            if (rb_copyRedAnnots.Checked)
            {
                bool filesToCopyAreOpen = checkIfFilesAreOpen(filesToCopy);
                if (filesToCopyAreOpen) { updateNewFilesDisplay(new List<string>() { "Error. Some files we are copying from are open, please close all files and try again." }); return; }
            }

            //bnackup files if requested
            if (ckbx_backupFiles.Checked) { backupFiles(files); }
            if (ckbx_backupFiles.Checked && rb_copyRedAnnots.Checked) { backupFiles(filesToCopy); }

            //do selected work
            List<string> outputMessages = null;
            if (rb_blackenAnnots.Checked) { outputMessages = blackenAnnots(files); }
            if (rb_updateFcrBoxes.Checked) { outputMessages = updateRevAnnots(files); }
            if (rb_updateRevisionBoxes.Checked) { outputMessages = updateRevAnnots(files); }
            if (rb_copyRedAnnots.Checked) { outputMessages = copyRedAnnots(files, filesToCopy); }

            //update preview
            tb_editedFiles.Text = "";
            updateNewFilesDisplay(outputMessages);
        }

        private void btn_TEST_Click(object sender, EventArgs e)
        {
            //check if files loaded
            if (files == null) { tb_existingFiles.Text = "Please select files first!"; return; }

            //check if files are open
            bool filesAreOpen = checkIfFilesAreOpen(files);
            if (filesAreOpen) { updateNewFilesDisplay(new List<string>() { "Error. Some files are open, please close all files and try again." }); return; }

            string destPath = files[0];
            string tempPath = generateTempFilePath(destPath);
            loopthroughimages(destPath, "");
        }

        #endregion

        #region ######################## NAME MANAGEMENT ###############################
        // MAIN NAME MANAGEMENT
        private List<string> generateValidDestNamePreviews(List<string> sourceFiles)
        {
            //save new names
            List<string> destNames = generateDestNames(sourceFiles);

            //save new file paths
            List<string> destFilePaths = generateDestFilePaths(sourceFiles, destNames);

            //verify new paths
            List<string> destNamePreviews = getValidatedNamePreviews(destFilePaths);

            return destNamePreviews;
        }
        private List<string> generateValidDestPaths(List<string> sourceFiles)
        {
            //save new names
            List<string> newNames = generateDestNames(sourceFiles);
            //save new file paths
            List<string> newFilePaths = generateDestFilePaths(sourceFiles, newNames);
            //validate paths
            List<string> validatedDestFilePaths = getValidatedPaths(newFilePaths);

            return validatedDestFilePaths;
        }

        //NAME GENERATION
        private List<string> generateDestNames(List<string> sourceFilePaths)
        {

            // SPLIT THIS INTO GENERATING AND VALIDATING?!>!?!?!

            List<string> newNames = new List<string>();

            //reset counter
            int fileCounter = int.Parse(tb_sketchIndex.Text) - 1;

            foreach (string sourcePath in sourceFilePaths)
            {
                //count files
                fileCounter += 1;

                //get the source name 
                string sourceName = Path.GetFileNameWithoutExtension(sourcePath);
                string destName = sourceName;

                //if file doesnt exist, ignore it as mark as red
                if (!File.Exists(sourcePath)) { newNames.Add(sourceName + " - Error. File not found"); continue; }

                //clean up name option
                if (ckbx_cleanupNameAndRev.Checked)
                {
                    string extractedName = extractNameAndRev(destName);
                    //report error
                    if (extractedName == null) { newNames.Add(destName + " - Error. File name doesnt contain the minimum information."); continue; }
                    string correctedName = correctSpaceChars(extractedName);
                    destName = correctedName;
                }

                //increment revision option
                if (ckbx_incrementRevision.Checked)
                {
                    destName = incrementNumericalRevInName(destName);
                }

                //Add revision from tracker option
                if (ckbx_getRevisionFromTracker.Checked)
                {
                    string docName = Regex.Match(destName, RegexPattern.messyNnbName).Value;
                    string trackerPath = getTrackerPath(docName);
                    //report error
                    if (trackerPath == "") { newNames.Add(destName + " - Error. Could not get tracker location."); continue; }
                    destName = updateRevisionToLatestInTracker(trackerPath, docName);
                }

                //add sketch index option
                if (ckbx_addSketchIndex.Checked)
                {
                    destName = String.Format("SKETCH {0,2:D2} {1}", fileCounter, destName);
                }

                newNames.Add(destName);
            }
            return newNames;
        }
        private List<string> generateDestFilePaths(List<string> sourceFilePaths, List<string> newNames)
        {
            List<string> newFilePaths = new List<string>();

            for (int i = 0; i < sourceFilePaths.Count; i++)
            {
                string sourceName = Path.GetFileNameWithoutExtension(sourceFilePaths[i]);
                string newFilePath = sourceFilePaths[i].Replace(sourceName, newNames[i]);
                newFilePaths.Add(newFilePath);
            }

            return newFilePaths;
        }

        //VALIDATION
        private List<string> getValidatedNamePreviews(List<string> destFilePaths)
        {
            List<string> destNamePreviews = new List<string>();

            foreach (string destFilePath in destFilePaths)
            {
                string destName = Path.GetFileNameWithoutExtension(destFilePath);
                //check for error message? (would be great to encapsulate erros to one method, but dont know how to display errors from previous steps in this method only)
                if (destFilePath.Contains("Error")) { destNamePreviews.Add(destName); continue; }
                
                //check for duplicate
                if (File.Exists(destFilePath)) { destNamePreviews.Add(destName + " - Error. File name already exsits in folder and will be skipped"); continue; }

                //check for revision
                if (!Regex.IsMatch(destFilePath, RegexPattern.correctRev) && ckbx_incrementRevision.Checked) { destNamePreviews.Add(destName + " - Error. Rev not found and will be skipped."); continue; }

                //check if valid name
                if (!Regex.IsMatch(destName, RegexPattern.correctNnbName)) { destNamePreviews.Add(destName + " - Warning. Incorrect name, some information is missing."); continue; }

                //otherwise add without message
                destNamePreviews.Add(destName);
            }

            return destNamePreviews;
        }
        private List<string> getValidatedPaths(List<string> destFilePaths)
        {
            List<string> validatedDestFilePaths = new List<string>();

            foreach (string destFilePath in destFilePaths)
            {
                //check for duplicate
                if (File.Exists(destFilePath)) { validatedDestFilePaths.Add(destFilePath + " - Error. File name already exsits in folder"); continue; }

                //check for revision
                if (!Regex.IsMatch(destFilePath, RegexPattern.correctRev) && ckbx_incrementRevision.Checked) { validatedDestFilePaths.Add(destFilePath + " - Error. Rev not found."); continue; }

                //check if valid name - NOT NEEDED IN PATH VALIDATION AS WARNINGS ARE IGNORED. ERROR FILES SHOULD BE SKIPPED WHEN MODIFYING
                //if (!Regex.IsMatch(destFilePath, RegexPattern.correctNnbName)) { validatedDestFilePaths.Add(destFilePath + " - Warning. Incorrect name."); continue; }

                //otherwise add without message
                validatedDestFilePaths.Add(destFilePath);
            }

            return validatedDestFilePaths;
        }
        #endregion

        #region ##############################  WORK  #######################################
        //managing files
        private static void backupFiles(List<string> sourceFilePaths)
        {
            string sourceDir = Path.GetDirectoryName(sourceFilePaths[0]);
            string backupFolderName = DateTime.Now.ToString("yyyyMMddATHHmmss");
            string backupDir = String.Format("{0}\\{1}", sourceDir, backupFolderName);

            //crreate folder
            Directory.CreateDirectory(backupDir);

            //copy files
            foreach (string sourceFilePath in sourceFilePaths)
            {
                string destFilePath = sourceFilePath.Replace(sourceDir, backupDir);
                File.Copy(sourceFilePath, destFilePath);
            }
        }
        private static void cleanupTempFiles(string destinationFile, string tempFile)
        {
            //delete destinaton file
            File.Delete(destinationFile);
            //replace files
            File.Move(tempFile, destinationFile);
        }

        //add content
        private static List<string> insertRevBlock(List<string> filePaths, string sigPath, string auth, string checker, string reviewer, string reason)
        {
            List<string> messages = new List<string>();

            foreach (string filePath in filePaths)
            {
                //get revision
                string revision = getRevisionFromPath(filePath);
                if (revision.Equals(""))
                {
                    messages.Add(Path.GetFileNameWithoutExtension(filePath) + " - Error. No revision in name");
                    continue;
                }

                //get signatures;
                string authSigPath = getSignatureFilePath(sigPath, auth);
                string checkSigPath = getSignatureFilePath(sigPath, checker);
                string apprSigPath = getSignatureFilePath(sigPath, reviewer);

                //generate temp path
                string tempFilePath = generateTempFilePath(filePath);

                //add titleblocks
                bool revTitleAdded = addRevisionTitleblockOLD2(filePath, tempFilePath, revision, auth, checker, reason, authSigPath, checkSigPath, apprSigPath);
                if (true)
                {
                    cleanupTempFiles(filePath, tempFilePath);
                    messages.Add(Path.GetFileNameWithoutExtension(filePath)); ;
                }
                else
                {
                    messages.Add(Path.GetFileNameWithoutExtension(filePath) + " - Error. Adding title block unsuccessful"); ;
                }
            }
            return messages;
        }

        //edit contents
        private static List<string> updateRevAnnots(List<string> filePaths)
        {
            List<string> messages = new List<string>();

            foreach (string filePath in filePaths)
            {
                //get revision
                string revision = getRevisionFromPath(filePath);
                if (revision.Equals(""))
                {
                    messages.Add(Path.GetFileNameWithoutExtension(filePath) + " - Error. No revision in name");
                    continue;
                }

                //generate temp path
                string tempFilePath = generateTempFilePath(filePath);

                
                bool revBoxesUpdated = changeTextboxContentsByRegex(filePath, tempFilePath, revision);

                if (revBoxesUpdated)
                {
                    cleanupTempFiles(filePath, tempFilePath);
                    messages.Add(Path.GetFileNameWithoutExtension(filePath)); ;
                }
                else
                {
                    messages.Add(Path.GetFileNameWithoutExtension(filePath) + " - Error. Editing rev annots unsuccessful"); ;
                }
            }
            return messages;
        }
        private static List<string> blackenAnnots(List<string> filePaths)
        {
            List<string> messages = new List<string>();

            foreach (string filePath in filePaths)
            {
                //generate temp path
                string tempFilePath = generateTempFilePath(filePath);

                //add titleblocks
                bool colorChangeComplete = changeColorOfAnnotsByColor(filePath, tempFilePath, Color.Red, Color.Black);

                if (colorChangeComplete)
                {
                    cleanupTempFiles(filePath, tempFilePath);
                    messages.Add(Path.GetFileNameWithoutExtension(filePath)); ;
                }
                else
                {
                    messages.Add(Path.GetFileNameWithoutExtension(filePath) + " - Error. Blackening Annots unsuccessful"); ;
                }
            }
            return messages;
        }
        private static List<string> copyRedAnnots(List<string> filePaths, List<string> filePathsToCopy)
        {
            List<string> messages = new List<string>();

            foreach (string filePath in filePaths)
            {
                // find mathcing file to filePath
                //get U2 ref number
                string refNumber2 = Regex.Match(filePath, RegexPattern.refNumber).Value;
                string matchingFilePath = "";

                foreach (string filePathToCopy in filePathsToCopy)
                {
                    //get U1 ref number
                    string refNumber1 = Regex.Match(filePathToCopy, RegexPattern.refNumber).Value;
                    if (refNumber1 == refNumber2)
                    {
                        matchingFilePath = filePathToCopy;
                    }
                }
                if (matchingFilePath == "")
                {
                    messages.Add(Path.GetFileNameWithoutExtension(filePath) + " - Error. Matching file not found");
                    continue;
                }

                //generate temp path
                string tempFilePath = generateTempFilePath(filePath);

                //copy annots
                bool copyAnnotsComplete = copyAnnotsByColorRed(matchingFilePath, filePath, tempFilePath);

                if (copyAnnotsComplete)
                {
                    cleanupTempFiles(filePath, tempFilePath);
                    messages.Add(Path.GetFileNameWithoutExtension(filePath)); ;
                }
                else
                {
                    messages.Add(Path.GetFileNameWithoutExtension(filePath) + " - Error. Copying annots unsuccessful"); ;
                }
            }

            return messages;
        }
        #endregion

        #region ##############################  USER INTERFACE  #######################################
        private static List<string> getPdfFilesFromUser()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Please select .pdf files to edit",
                //InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\OneDrive Corp\\Atkins Ltd\\UK1226_SDLT - Documents",
                Filter = "Pdf Files|*.pdf|IFC Files|*.ifc",
                FilterIndex = 1,
                Multiselect = true,
                RestoreDirectory = true
            };

            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return new List<string>(fileDialog.FileNames);
            }
            return null;
        }
        private void updateNewFilesDisplay(List<string> newFileNames)
        {
            foreach (string newName in newFileNames)
            {
                //check if error
                if (newName.Contains("Error"))
                {
                    appendTextToTb(tb_editedFiles, newName, Color.Red);
                    continue;
                }

                //check if warning
                if (newName.Contains("Warning"))
                {
                    appendTextToTb(tb_editedFiles, newName, Color.Orange);
                    continue;
                }

                //otherwise green
                appendTextToTb(tb_editedFiles, newName, Color.Green);
            }
        }
        private void removeMessagesFromPaths(ref List<string> filePaths)
        {
            for (int i = 0; i < filePaths.Count; i++)
            {
                if(Regex.IsMatch(filePaths[i], RegexPattern.errorMessage))
                {
                    filePaths[i] = filePaths[i].Replace(Regex.Match(filePaths[i], RegexPattern.errorMessage).Value, "");
                }
            }
        }
        private void appendTextToTb(RichTextBox textBox, string text, Color color)
        {
            int selectionStart = textBox.TextLength;
            textBox.AppendText(text + "\n");
            textBox.SelectionStart = selectionStart;
            textBox.SelectionLength = text.Length;
            textBox.SelectionColor = color;
            textBox.SelectionStart = textBox.TextLength;
        }
        private void updateSouceFilesDisplay(List<string> sourceFilePaths)
        {
            tb_existingFiles.Text = "";

            foreach (string sourceFilePath in sourceFilePaths)
            {
                string fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
                tb_existingFiles.AppendText(fileName + "\r\n");
            }
        }
        private string getTrackerPath(string fileName)
        {
            //get unit and building
            string unit = Regex.Match(fileName, RegexPattern.unit).Value;
            string building = Regex.Match(fileName, RegexPattern.building).Value;


            //if not recieved then return nothing
            if(unit == ""| building == "")
            {
                return "";
            }

            //get path depending on unit and building
            switch (unit)
            {
                case "U1":
                    switch (building)
                    {
                        case "HD7":
                            return Directories.HDU1Tracker;
                        case "HNX":
                            return Directories.HNU1Tracker;
                        case "HQA":
                            return Directories.HQATracker;
                        case "HQB":
                            return Directories.HQBTracker;
                        case "HQC":
                            return Directories.HQCTracker;
                        default:
                            return "";
                    }
                case "U2":
                    switch (building)
                    {
                        case "HD7":
                            return Directories.HDU2Tracker;
                        case "HNX":
                            return Directories.HNU2Tracker;
                        default:
                            return "";
                    }
                default:
                    return "";
            }
        }
        private static string getSignatureFilePath(string signatureDirectory, string requestedSigName)
        {
            List<string> SignatureFiles = FolderTools.Class1.ListFiles(signatureDirectory);
            //Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            foreach (string signatureFile in SignatureFiles)
            {
                string sigName = Path.GetFileNameWithoutExtension(signatureFile);
                if (sigName.Equals(requestedSigName)) { return signatureFile; }
            }
            return "";
        }
        #endregion

        #region ##############################  HELPER METHODS  #######################################
        //EDITING PATHS AND ANALYSIS
        private static string generateTempFilePath(string destPath)
        {
            string sourceFileExtension = Path.GetExtension(destPath);
            string tempPath = destPath.Replace(sourceFileExtension, "(1)" + sourceFileExtension);
            return tempPath;
        }
        private static string getRevisionFromPath(string filePath)
        {
            if (Regex.IsMatch(filePath, RegexPattern.numericalRev)) { return Regex.Match(filePath, RegexPattern.numericalRev).Value; }
            return "";
        }
        private static string extractNameAndRev(string fileName)
        {
            string simpleName = null;
            string rev = null;

            if (Regex.IsMatch(fileName, RegexPattern.messyNnbName))
            {
                simpleName = Regex.Match(fileName, RegexPattern.messyNnbName).Value;
            }
            if (Regex.IsMatch(fileName, RegexPattern.numericalRev))
            {
                rev = Regex.Match(fileName, RegexPattern.numericalRev).Value;
            }
            else if (Regex.IsMatch(fileName, RegexPattern.letterRev))
            {
                rev = Regex.Match(fileName, RegexPattern.letterRev).Value;
            }
            if (rev != null)
            {
                return String.Format("{0}-{1}", simpleName, rev);
            }
            else
            {
                return simpleName;
            }
        }
        private static string correctSpaceChars(string fileName)
        {
            fileName = fileName.Replace("_", "-");
            fileName = fileName.Replace(" ", "-");
            return fileName;
        }
        private static string incrementNumericalRevInName(string fileName)
        {
            //options for revision naming
            //string nextRev = sourcePath.Substring(sourcePath.LastIndexOf('.') - 4, 4);
            //string nextRev = getNextRevisionFromAnnotations(sourcePath);

            string currentRev = Regex.Match(fileName, RegexPattern.correctRev).Value;
            string nextRev = getNextNumericalRev(currentRev);
            if (currentRev != "") { return Regex.Replace(fileName, RegexPattern.correctRev, nextRev); }
            else { return fileName; }
        }
        private static string updateRevisionToLatestInTracker(string trackerPath, string fileName)
        {
            string currentRev = Regex.Match(fileName, RegexPattern.correctRev).Value;
            string latestRev = getNewestRevisionFromTracker(trackerPath, fileName);
            if (currentRev != "") { return Regex.Replace(fileName, RegexPattern.correctRev, latestRev); }
            else { return fileName + "-" + latestRev; }
        }
        private static string removeSketchPrefix(string filePath)
        {
            if (Regex.IsMatch(filePath, RegexPattern.sketchPrefix))
            {
                return Regex.Replace(filePath, RegexPattern.sketchPrefix, "");
            }
            return filePath;
        }
        //MANIPULATING FILES
        private static List<string> sortFiles(List<string> files)
        {
            List<string> drawingNames = new List<string>();
            List<string> sortedFiles = new List<string>();
            foreach (string file in files)
            {
                string drawingName = removeSketchPrefix(file);
                drawingNames.Add(drawingName);
            }
            drawingNames.Sort();

            foreach (string drawingName in drawingNames)
            {
                foreach (string file in files)
                {
                    if (file.Contains(drawingName)) { sortedFiles.Add(file); }
                }
            }

            return sortedFiles;
        }
        private static bool checkIfFilesAreOpen(List<string> files)
        {
            foreach (string file in files)
            {
                try
                {
                    FileStream inputStream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None);
                    inputStream.Dispose();
                }
                catch (Exception)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}