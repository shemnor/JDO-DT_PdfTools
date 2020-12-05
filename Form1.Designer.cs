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
            this.btn_modify = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ckbx_deleteOldFile = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_author = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbc_addRevisionBlock = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.modifyPdfs = new System.ComponentModel.BackgroundWorker();
            this.ckbx_blackenAnnots = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_checker = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_selectFiles
            // 
            this.btn_selectFiles.Location = new System.Drawing.Point(12, 12);
            this.btn_selectFiles.Name = "btn_selectFiles";
            this.btn_selectFiles.Size = new System.Drawing.Size(87, 23);
            this.btn_selectFiles.TabIndex = 0;
            this.btn_selectFiles.Text = "Select Files";
            this.btn_selectFiles.UseVisualStyleBackColor = true;
            this.btn_selectFiles.Click += new System.EventHandler(this.btn_selectFiles_Click);
            // 
            // btn_modify
            // 
            this.btn_modify.Location = new System.Drawing.Point(105, 12);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(75, 23);
            this.btn_modify.TabIndex = 10;
            this.btn_modify.Text = "Modify";
            this.btn_modify.UseVisualStyleBackColor = true;
            this.btn_modify.Click += new System.EventHandler(this.btn_modify_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 91);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(360, 218);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // ckbx_deleteOldFile
            // 
            this.ckbx_deleteOldFile.AutoSize = true;
            this.ckbx_deleteOldFile.Location = new System.Drawing.Point(186, 16);
            this.ckbx_deleteOldFile.Name = "ckbx_deleteOldFile";
            this.ckbx_deleteOldFile.Size = new System.Drawing.Size(92, 17);
            this.ckbx_deleteOldFile.TabIndex = 3;
            this.ckbx_deleteOldFile.Text = "Overwrite files";
            this.ckbx_deleteOldFile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please send bugs and feedback to shem.noremberg@atkinsglobal.com";
            // 
            // tb_author
            // 
            this.tb_author.Location = new System.Drawing.Point(69, 38);
            this.tb_author.Name = "tb_author";
            this.tb_author.Size = new System.Drawing.Size(111, 20);
            this.tb_author.TabIndex = 1;
            this.tb_author.Text = "XX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Author:";
            // 
            // ckbc_addRevisionBlock
            // 
            this.ckbc_addRevisionBlock.AutoSize = true;
            this.ckbc_addRevisionBlock.Location = new System.Drawing.Point(186, 40);
            this.ckbc_addRevisionBlock.Name = "ckbc_addRevisionBlock";
            this.ckbc_addRevisionBlock.Size = new System.Drawing.Size(102, 17);
            this.ckbc_addRevisionBlock.TabIndex = 4;
            this.ckbc_addRevisionBlock.Text = "Insert rev. block";
            this.ckbc_addRevisionBlock.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(12, 334);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(360, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // lbl_progress
            // 
            this.lbl_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Location = new System.Drawing.Point(13, 318);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(65, 13);
            this.lbl_progress.TabIndex = 9;
            this.lbl_progress.Text = "Progress 0%";
            // 
            // modifyPdfs
            // 
            this.modifyPdfs.WorkerReportsProgress = true;
            this.modifyPdfs.DoWork += new System.ComponentModel.DoWorkEventHandler(this.modifyPDFs_DoWork);
            this.modifyPdfs.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.modifyPDFs_ProgressChanged);
            this.modifyPdfs.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.modifyPDFs_RunWorkerCompleted);
            // 
            // ckbx_blackenAnnots
            // 
            this.ckbx_blackenAnnots.AutoSize = true;
            this.ckbx_blackenAnnots.Location = new System.Drawing.Point(186, 64);
            this.ckbx_blackenAnnots.Name = "ckbx_blackenAnnots";
            this.ckbx_blackenAnnots.Size = new System.Drawing.Size(143, 17);
            this.ckbx_blackenAnnots.TabIndex = 5;
            this.ckbx_blackenAnnots.Text = "Change redlines to black";
            this.ckbx_blackenAnnots.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Checker:";
            // 
            // tb_checker
            // 
            this.tb_checker.Location = new System.Drawing.Point(69, 61);
            this.tb_checker.Name = "tb_checker";
            this.tb_checker.Size = new System.Drawing.Size(111, 20);
            this.tb_checker.TabIndex = 2;
            this.tb_checker.Text = "XX";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 382);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_checker);
            this.Controls.Add(this.ckbx_blackenAnnots);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ckbc_addRevisionBlock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_author);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbx_deleteOldFile);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_modify);
            this.Controls.Add(this.btn_selectFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "Form1";
            this.Text = "JDO-DT Pdf Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_selectFiles;
        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox ckbx_deleteOldFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_author;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbc_addRevisionBlock;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_progress;
        private System.ComponentModel.BackgroundWorker modifyPdfs;
        private System.Windows.Forms.CheckBox ckbx_blackenAnnots;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_checker;
    }
}

