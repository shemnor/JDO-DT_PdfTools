namespace JDO_DT_PdfTools
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_selectFiles = new System.Windows.Forms.Button();
            this.tb_existingFiles = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_author = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_checker = new System.Windows.Forms.TextBox();
            this.tb_reviewer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_instertRevBlock = new System.Windows.Forms.Button();
            this.tb_reason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_FileNames = new System.Windows.Forms.GroupBox();
            this.tb_sketchIndex = new System.Windows.Forms.MaskedTextBox();
            this.btn_preview = new System.Windows.Forms.Button();
            this.btn_ModifyName = new System.Windows.Forms.Button();
            this.ckbx_getRevisionFromTracker = new System.Windows.Forms.CheckBox();
            this.ckbx_addSketchIndex = new System.Windows.Forms.CheckBox();
            this.ckbx_incrementRevision = new System.Windows.Forms.CheckBox();
            this.ckbx_cleanupNameAndRev = new System.Windows.Forms.CheckBox();
            this.tb_editedFiles = new System.Windows.Forms.RichTextBox();
            this.tb_fcrNumber = new System.Windows.Forms.MaskedTextBox();
            this.btn_editContent = new System.Windows.Forms.Button();
            this.ckbx_backupFiles = new System.Windows.Forms.CheckBox();
            this.gb_addrevisionBlock = new System.Windows.Forms.GroupBox();
            this.gb_Modify = new System.Windows.Forms.GroupBox();
            this.btn_selectCopyFiles = new System.Windows.Forms.Button();
            this.rb_copyRedAnnots = new System.Windows.Forms.RadioButton();
            this.rb_updateFcrBoxes = new System.Windows.Forms.RadioButton();
            this.rb_updateRevisionBoxes = new System.Windows.Forms.RadioButton();
            this.rb_blackenAnnots = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_TEST = new System.Windows.Forms.Button();
            this.gb_Copy = new System.Windows.Forms.GroupBox();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_SelectSourceFiles = new System.Windows.Forms.Button();
            this.rb_copyAllAnnots = new System.Windows.Forms.RadioButton();
            this.rb_copyRedAnnots1 = new System.Windows.Forms.RadioButton();
            this.gb_FileNames.SuspendLayout();
            this.gb_addrevisionBlock.SuspendLayout();
            this.gb_Modify.SuspendLayout();
            this.gb_Copy.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_selectFiles
            // 
            this.btn_selectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_selectFiles.Location = new System.Drawing.Point(12, 612);
            this.btn_selectFiles.Name = "btn_selectFiles";
            this.btn_selectFiles.Size = new System.Drawing.Size(198, 23);
            this.btn_selectFiles.TabIndex = 0;
            this.btn_selectFiles.Text = "Select Files";
            this.btn_selectFiles.UseVisualStyleBackColor = true;
            this.btn_selectFiles.Click += new System.EventHandler(this.btn_selectFiles_Click);
            // 
            // tb_existingFiles
            // 
            this.tb_existingFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tb_existingFiles.Location = new System.Drawing.Point(12, 216);
            this.tb_existingFiles.MinimumSize = new System.Drawing.Size(316, 153);
            this.tb_existingFiles.Name = "tb_existingFiles";
            this.tb_existingFiles.Size = new System.Drawing.Size(372, 390);
            this.tb_existingFiles.TabIndex = 2;
            this.tb_existingFiles.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 640);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please send bugs and feedback to shem.noremberg@atkinsglobal.com";
            // 
            // tb_author
            // 
            this.tb_author.Location = new System.Drawing.Point(65, 19);
            this.tb_author.Name = "tb_author";
            this.tb_author.Size = new System.Drawing.Size(64, 20);
            this.tb_author.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Author:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Checker:";
            // 
            // tb_checker
            // 
            this.tb_checker.Location = new System.Drawing.Point(65, 45);
            this.tb_checker.Name = "tb_checker";
            this.tb_checker.Size = new System.Drawing.Size(64, 20);
            this.tb_checker.TabIndex = 2;
            // 
            // tb_reviewer
            // 
            this.tb_reviewer.Location = new System.Drawing.Point(65, 71);
            this.tb_reviewer.Name = "tb_reviewer";
            this.tb_reviewer.Size = new System.Drawing.Size(64, 20);
            this.tb_reviewer.TabIndex = 19;
            this.tb_reviewer.Text = "RR";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Reviewer:";
            // 
            // btn_instertRevBlock
            // 
            this.btn_instertRevBlock.Location = new System.Drawing.Point(9, 145);
            this.btn_instertRevBlock.Name = "btn_instertRevBlock";
            this.btn_instertRevBlock.Size = new System.Drawing.Size(202, 23);
            this.btn_instertRevBlock.TabIndex = 18;
            this.btn_instertRevBlock.Text = "Insert rev block";
            this.btn_instertRevBlock.UseVisualStyleBackColor = true;
            this.btn_instertRevBlock.Click += new System.EventHandler(this.btn_instertRevBlock_Click);
            // 
            // tb_reason
            // 
            this.tb_reason.Location = new System.Drawing.Point(65, 97);
            this.tb_reason.Name = "tb_reason";
            this.tb_reason.Size = new System.Drawing.Size(146, 20);
            this.tb_reason.TabIndex = 13;
            this.tb_reason.Text = "Updated for FCR ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Reason:";
            // 
            // gb_FileNames
            // 
            this.gb_FileNames.AutoSize = true;
            this.gb_FileNames.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_FileNames.Controls.Add(this.tb_sketchIndex);
            this.gb_FileNames.Controls.Add(this.btn_preview);
            this.gb_FileNames.Controls.Add(this.btn_ModifyName);
            this.gb_FileNames.Controls.Add(this.ckbx_getRevisionFromTracker);
            this.gb_FileNames.Controls.Add(this.ckbx_addSketchIndex);
            this.gb_FileNames.Controls.Add(this.ckbx_incrementRevision);
            this.gb_FileNames.Controls.Add(this.ckbx_cleanupNameAndRev);
            this.gb_FileNames.Location = new System.Drawing.Point(12, 10);
            this.gb_FileNames.Name = "gb_FileNames";
            this.gb_FileNames.Size = new System.Drawing.Size(205, 187);
            this.gb_FileNames.TabIndex = 16;
            this.gb_FileNames.TabStop = false;
            this.gb_FileNames.Text = "PDF File names";
            // 
            // tb_sketchIndex
            // 
            this.tb_sketchIndex.Location = new System.Drawing.Point(169, 86);
            this.tb_sketchIndex.Mask = "000";
            this.tb_sketchIndex.Name = "tb_sketchIndex";
            this.tb_sketchIndex.Size = new System.Drawing.Size(29, 20);
            this.tb_sketchIndex.TabIndex = 21;
            this.tb_sketchIndex.Text = "1";
            this.tb_sketchIndex.ValidatingType = typeof(int);
            // 
            // btn_preview
            // 
            this.btn_preview.Location = new System.Drawing.Point(6, 145);
            this.btn_preview.Margin = new System.Windows.Forms.Padding(1);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(94, 23);
            this.btn_preview.TabIndex = 20;
            this.btn_preview.Text = "Preview";
            this.btn_preview.UseVisualStyleBackColor = true;
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // btn_ModifyName
            // 
            this.btn_ModifyName.Location = new System.Drawing.Point(104, 145);
            this.btn_ModifyName.Name = "btn_ModifyName";
            this.btn_ModifyName.Size = new System.Drawing.Size(95, 23);
            this.btn_ModifyName.TabIndex = 18;
            this.btn_ModifyName.Text = "Modify";
            this.btn_ModifyName.UseVisualStyleBackColor = true;
            this.btn_ModifyName.Click += new System.EventHandler(this.btn_ModifyName_Click);
            // 
            // ckbx_getRevisionFromTracker
            // 
            this.ckbx_getRevisionFromTracker.AutoSize = true;
            this.ckbx_getRevisionFromTracker.Checked = true;
            this.ckbx_getRevisionFromTracker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbx_getRevisionFromTracker.Location = new System.Drawing.Point(6, 65);
            this.ckbx_getRevisionFromTracker.Name = "ckbx_getRevisionFromTracker";
            this.ckbx_getRevisionFromTracker.Size = new System.Drawing.Size(143, 17);
            this.ckbx_getRevisionFromTracker.TabIndex = 22;
            this.ckbx_getRevisionFromTracker.Text = "Add revision from tracker";
            this.ckbx_getRevisionFromTracker.UseVisualStyleBackColor = true;
            // 
            // ckbx_addSketchIndex
            // 
            this.ckbx_addSketchIndex.AutoSize = true;
            this.ckbx_addSketchIndex.Location = new System.Drawing.Point(6, 88);
            this.ckbx_addSketchIndex.Name = "ckbx_addSketchIndex";
            this.ckbx_addSketchIndex.Size = new System.Drawing.Size(157, 17);
            this.ckbx_addSketchIndex.TabIndex = 17;
            this.ckbx_addSketchIndex.Text = "Add sketch index starting at";
            this.ckbx_addSketchIndex.UseVisualStyleBackColor = true;
            // 
            // ckbx_incrementRevision
            // 
            this.ckbx_incrementRevision.AutoSize = true;
            this.ckbx_incrementRevision.Location = new System.Drawing.Point(6, 42);
            this.ckbx_incrementRevision.Name = "ckbx_incrementRevision";
            this.ckbx_incrementRevision.Size = new System.Drawing.Size(160, 17);
            this.ckbx_incrementRevision.TabIndex = 16;
            this.ckbx_incrementRevision.Text = "Increment numerical revision";
            this.ckbx_incrementRevision.UseVisualStyleBackColor = true;
            // 
            // ckbx_cleanupNameAndRev
            // 
            this.ckbx_cleanupNameAndRev.AutoSize = true;
            this.ckbx_cleanupNameAndRev.Checked = true;
            this.ckbx_cleanupNameAndRev.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbx_cleanupNameAndRev.Location = new System.Drawing.Point(6, 19);
            this.ckbx_cleanupNameAndRev.Name = "ckbx_cleanupNameAndRev";
            this.ckbx_cleanupNameAndRev.Size = new System.Drawing.Size(94, 17);
            this.ckbx_cleanupNameAndRev.TabIndex = 4;
            this.ckbx_cleanupNameAndRev.Text = "Cleanup name";
            this.ckbx_cleanupNameAndRev.UseVisualStyleBackColor = true;
            // 
            // tb_editedFiles
            // 
            this.tb_editedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_editedFiles.Location = new System.Drawing.Point(390, 216);
            this.tb_editedFiles.Name = "tb_editedFiles";
            this.tb_editedFiles.Size = new System.Drawing.Size(412, 394);
            this.tb_editedFiles.TabIndex = 19;
            this.tb_editedFiles.Text = "";
            // 
            // tb_fcrNumber
            // 
            this.tb_fcrNumber.Location = new System.Drawing.Point(167, 61);
            this.tb_fcrNumber.Mask = "000000";
            this.tb_fcrNumber.Name = "tb_fcrNumber";
            this.tb_fcrNumber.Size = new System.Drawing.Size(44, 20);
            this.tb_fcrNumber.TabIndex = 20;
            this.tb_fcrNumber.ValidatingType = typeof(int);
            // 
            // btn_editContent
            // 
            this.btn_editContent.Location = new System.Drawing.Point(6, 143);
            this.btn_editContent.Name = "btn_editContent";
            this.btn_editContent.Size = new System.Drawing.Size(220, 23);
            this.btn_editContent.TabIndex = 19;
            this.btn_editContent.Text = "Edit PDF content";
            this.btn_editContent.UseVisualStyleBackColor = true;
            this.btn_editContent.Click += new System.EventHandler(this.btn_editContent_Click);
            // 
            // ckbx_backupFiles
            // 
            this.ckbx_backupFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbx_backupFiles.AutoSize = true;
            this.ckbx_backupFiles.Location = new System.Drawing.Point(216, 616);
            this.ckbx_backupFiles.Name = "ckbx_backupFiles";
            this.ckbx_backupFiles.Size = new System.Drawing.Size(297, 17);
            this.ckbx_backupFiles.TabIndex = 22;
            this.ckbx_backupFiles.Text = "TICK TO BACKUP FILES BEFORE ANY MODIFICATION";
            this.ckbx_backupFiles.UseVisualStyleBackColor = true;
            // 
            // gb_addrevisionBlock
            // 
            this.gb_addrevisionBlock.AutoSize = true;
            this.gb_addrevisionBlock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_addrevisionBlock.Controls.Add(this.tb_reviewer);
            this.gb_addrevisionBlock.Controls.Add(this.label4);
            this.gb_addrevisionBlock.Controls.Add(this.label2);
            this.gb_addrevisionBlock.Controls.Add(this.btn_instertRevBlock);
            this.gb_addrevisionBlock.Controls.Add(this.label3);
            this.gb_addrevisionBlock.Controls.Add(this.tb_reason);
            this.gb_addrevisionBlock.Controls.Add(this.tb_author);
            this.gb_addrevisionBlock.Controls.Add(this.label6);
            this.gb_addrevisionBlock.Controls.Add(this.tb_checker);
            this.gb_addrevisionBlock.Location = new System.Drawing.Point(461, 10);
            this.gb_addrevisionBlock.Name = "gb_addrevisionBlock";
            this.gb_addrevisionBlock.Size = new System.Drawing.Size(217, 187);
            this.gb_addrevisionBlock.TabIndex = 23;
            this.gb_addrevisionBlock.TabStop = false;
            this.gb_addrevisionBlock.Text = "Insert Revision Block";
            // 
            // gb_Modify
            // 
            this.gb_Modify.AutoSize = true;
            this.gb_Modify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_Modify.Controls.Add(this.btn_selectCopyFiles);
            this.gb_Modify.Controls.Add(this.rb_copyRedAnnots);
            this.gb_Modify.Controls.Add(this.rb_updateFcrBoxes);
            this.gb_Modify.Controls.Add(this.rb_updateRevisionBoxes);
            this.gb_Modify.Controls.Add(this.rb_blackenAnnots);
            this.gb_Modify.Controls.Add(this.tb_fcrNumber);
            this.gb_Modify.Controls.Add(this.btn_editContent);
            this.gb_Modify.Location = new System.Drawing.Point(223, 12);
            this.gb_Modify.Name = "gb_Modify";
            this.gb_Modify.Size = new System.Drawing.Size(232, 185);
            this.gb_Modify.TabIndex = 24;
            this.gb_Modify.TabStop = false;
            this.gb_Modify.Text = "Modify Contents";
            // 
            // btn_selectCopyFiles
            // 
            this.btn_selectCopyFiles.Location = new System.Drawing.Point(137, 84);
            this.btn_selectCopyFiles.Name = "btn_selectCopyFiles";
            this.btn_selectCopyFiles.Size = new System.Drawing.Size(74, 23);
            this.btn_selectCopyFiles.TabIndex = 25;
            this.btn_selectCopyFiles.Text = "Select files";
            this.btn_selectCopyFiles.UseVisualStyleBackColor = true;
            this.btn_selectCopyFiles.Click += new System.EventHandler(this.btn_selectCopyFiles_Click);
            // 
            // rb_copyRedAnnots
            // 
            this.rb_copyRedAnnots.AutoSize = true;
            this.rb_copyRedAnnots.Location = new System.Drawing.Point(6, 87);
            this.rb_copyRedAnnots.Name = "rb_copyRedAnnots";
            this.rb_copyRedAnnots.Size = new System.Drawing.Size(125, 17);
            this.rb_copyRedAnnots.TabIndex = 24;
            this.rb_copyRedAnnots.TabStop = true;
            this.rb_copyRedAnnots.Text = "Copy red annots from";
            this.rb_copyRedAnnots.UseVisualStyleBackColor = true;
            // 
            // rb_updateFcrBoxes
            // 
            this.rb_updateFcrBoxes.AutoSize = true;
            this.rb_updateFcrBoxes.Location = new System.Drawing.Point(6, 64);
            this.rb_updateFcrBoxes.Name = "rb_updateFcrBoxes";
            this.rb_updateFcrBoxes.Size = new System.Drawing.Size(155, 17);
            this.rb_updateFcrBoxes.TabIndex = 23;
            this.rb_updateFcrBoxes.TabStop = true;
            this.rb_updateFcrBoxes.Text = "Update red FCR boxes with";
            this.rb_updateFcrBoxes.UseVisualStyleBackColor = true;
            // 
            // rb_updateRevisionBoxes
            // 
            this.rb_updateRevisionBoxes.AutoSize = true;
            this.rb_updateRevisionBoxes.Location = new System.Drawing.Point(6, 41);
            this.rb_updateRevisionBoxes.Name = "rb_updateRevisionBoxes";
            this.rb_updateRevisionBoxes.Size = new System.Drawing.Size(215, 17);
            this.rb_updateRevisionBoxes.TabIndex = 22;
            this.rb_updateRevisionBoxes.TabStop = true;
            this.rb_updateRevisionBoxes.Text = "Update red rev labels to match file name";
            this.rb_updateRevisionBoxes.UseVisualStyleBackColor = true;
            // 
            // rb_blackenAnnots
            // 
            this.rb_blackenAnnots.AutoSize = true;
            this.rb_blackenAnnots.Location = new System.Drawing.Point(6, 18);
            this.rb_blackenAnnots.Name = "rb_blackenAnnots";
            this.rb_blackenAnnots.Size = new System.Drawing.Size(142, 17);
            this.rb_blackenAnnots.TabIndex = 21;
            this.rb_blackenAnnots.TabStop = true;
            this.rb_blackenAnnots.Text = "Change redlines to black";
            this.rb_blackenAnnots.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Files to be modified:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(387, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "File name preview/Error messages from modifications:";
            // 
            // btn_TEST
            // 
            this.btn_TEST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TEST.Location = new System.Drawing.Point(600, 635);
            this.btn_TEST.Name = "btn_TEST";
            this.btn_TEST.Size = new System.Drawing.Size(202, 23);
            this.btn_TEST.TabIndex = 21;
            this.btn_TEST.Text = "TEST";
            this.btn_TEST.UseVisualStyleBackColor = true;
            this.btn_TEST.Click += new System.EventHandler(this.btn_TEST_Click);
            // 
            // gb_Copy
            // 
            this.gb_Copy.AutoSize = true;
            this.gb_Copy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gb_Copy.Controls.Add(this.btn_Copy);
            this.gb_Copy.Controls.Add(this.btn_SelectSourceFiles);
            this.gb_Copy.Controls.Add(this.rb_copyAllAnnots);
            this.gb_Copy.Controls.Add(this.rb_copyRedAnnots1);
            this.gb_Copy.Location = new System.Drawing.Point(684, 12);
            this.gb_Copy.Name = "gb_Copy";
            this.gb_Copy.Size = new System.Drawing.Size(117, 185);
            this.gb_Copy.TabIndex = 24;
            this.gb_Copy.TabStop = false;
            this.gb_Copy.Text = "Copy";
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(9, 143);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(102, 23);
            this.btn_Copy.TabIndex = 27;
            this.btn_Copy.Text = "Copy";
            this.btn_Copy.UseVisualStyleBackColor = true;
            // 
            // btn_SelectSourceFiles
            // 
            this.btn_SelectSourceFiles.Location = new System.Drawing.Point(9, 114);
            this.btn_SelectSourceFiles.Name = "btn_SelectSourceFiles";
            this.btn_SelectSourceFiles.Size = new System.Drawing.Size(102, 23);
            this.btn_SelectSourceFiles.TabIndex = 26;
            this.btn_SelectSourceFiles.Text = "Select source files";
            this.btn_SelectSourceFiles.UseVisualStyleBackColor = true;
            // 
            // rb_copyAllAnnots
            // 
            this.rb_copyAllAnnots.AutoSize = true;
            this.rb_copyAllAnnots.Location = new System.Drawing.Point(9, 39);
            this.rb_copyAllAnnots.Name = "rb_copyAllAnnots";
            this.rb_copyAllAnnots.Size = new System.Drawing.Size(97, 17);
            this.rb_copyAllAnnots.TabIndex = 26;
            this.rb_copyAllAnnots.TabStop = true;
            this.rb_copyAllAnnots.Text = "Copy all annots";
            this.rb_copyAllAnnots.UseVisualStyleBackColor = true;
            // 
            // rb_copyRedAnnots1
            // 
            this.rb_copyRedAnnots1.AutoSize = true;
            this.rb_copyRedAnnots1.Location = new System.Drawing.Point(9, 18);
            this.rb_copyRedAnnots1.Name = "rb_copyRedAnnots1";
            this.rb_copyRedAnnots1.Size = new System.Drawing.Size(102, 17);
            this.rb_copyRedAnnots1.TabIndex = 25;
            this.rb_copyRedAnnots1.TabStop = true;
            this.rb_copyRedAnnots1.Text = "Copy red annots";
            this.rb_copyRedAnnots1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 662);
            this.Controls.Add(this.gb_Copy);
            this.Controls.Add(this.btn_TEST);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gb_Modify);
            this.Controls.Add(this.gb_addrevisionBlock);
            this.Controls.Add(this.ckbx_backupFiles);
            this.Controls.Add(this.tb_editedFiles);
            this.Controls.Add(this.btn_selectFiles);
            this.Controls.Add(this.gb_FileNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_existingFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(707, 668);
            this.Name = "Form1";
            this.Text = "JDO-DT Pdf Tools";
            this.gb_FileNames.ResumeLayout(false);
            this.gb_FileNames.PerformLayout();
            this.gb_addrevisionBlock.ResumeLayout(false);
            this.gb_addrevisionBlock.PerformLayout();
            this.gb_Modify.ResumeLayout(false);
            this.gb_Modify.PerformLayout();
            this.gb_Copy.ResumeLayout(false);
            this.gb_Copy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_selectFiles;
        private System.Windows.Forms.RichTextBox tb_existingFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_author;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_checker;
        private System.Windows.Forms.GroupBox gb_FileNames;
        private System.Windows.Forms.CheckBox ckbx_cleanupNameAndRev;
        private System.Windows.Forms.TextBox tb_reason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckbx_addSketchIndex;
        private System.Windows.Forms.CheckBox ckbx_incrementRevision;
        private System.Windows.Forms.RichTextBox tb_editedFiles;
        private System.Windows.Forms.Button btn_preview;
        private System.Windows.Forms.Button btn_ModifyName;
        private System.Windows.Forms.MaskedTextBox tb_sketchIndex;
        private System.Windows.Forms.Button btn_instertRevBlock;
        private System.Windows.Forms.MaskedTextBox tb_fcrNumber;
        private System.Windows.Forms.Button btn_editContent;
        private System.Windows.Forms.CheckBox ckbx_backupFiles;
        private System.Windows.Forms.TextBox tb_reviewer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_addrevisionBlock;
        private System.Windows.Forms.GroupBox gb_Modify;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rb_updateFcrBoxes;
        private System.Windows.Forms.RadioButton rb_updateRevisionBoxes;
        private System.Windows.Forms.RadioButton rb_blackenAnnots;
        private System.Windows.Forms.Button btn_TEST;
        private System.Windows.Forms.CheckBox ckbx_getRevisionFromTracker;
        private System.Windows.Forms.RadioButton rb_copyRedAnnots;
        private System.Windows.Forms.Button btn_selectCopyFiles;
        private System.Windows.Forms.GroupBox gb_Copy;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_SelectSourceFiles;
        private System.Windows.Forms.RadioButton rb_copyAllAnnots;
        private System.Windows.Forms.RadioButton rb_copyRedAnnots1;
    }
}

