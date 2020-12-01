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
            this.ckbx_createNewNames = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_author = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbc_revisionBlock = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.modifyPdfs = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btn_selectFiles
            // 
            this.btn_selectFiles.Location = new System.Drawing.Point(12, 12);
            this.btn_selectFiles.Name = "btn_selectFiles";
            this.btn_selectFiles.Size = new System.Drawing.Size(75, 23);
            this.btn_selectFiles.TabIndex = 0;
            this.btn_selectFiles.Text = "Select Files";
            this.btn_selectFiles.UseVisualStyleBackColor = true;
            this.btn_selectFiles.Click += new System.EventHandler(this.btn_selectFiles_Click);
            // 
            // btn_modify
            // 
            this.btn_modify.Location = new System.Drawing.Point(93, 12);
            this.btn_modify.Name = "btn_modify";
            this.btn_modify.Size = new System.Drawing.Size(75, 23);
            this.btn_modify.TabIndex = 1;
            this.btn_modify.Text = "Modify";
            this.btn_modify.UseVisualStyleBackColor = true;
            this.btn_modify.Click += new System.EventHandler(this.btn_modify_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 65);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(301, 297);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // ckbx_createNewNames
            // 
            this.ckbx_createNewNames.AutoSize = true;
            this.ckbx_createNewNames.Location = new System.Drawing.Point(207, 16);
            this.ckbx_createNewNames.Name = "ckbx_createNewNames";
            this.ckbx_createNewNames.Size = new System.Drawing.Size(106, 17);
            this.ckbx_createNewNames.TabIndex = 3;
            this.ckbx_createNewNames.Text = "Rename all files?";
            this.ckbx_createNewNames.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "For help contact Shem.Noremberg@atkinsglobal.com (2020)";
            // 
            // tb_author
            // 
            this.tb_author.Location = new System.Drawing.Point(57, 39);
            this.tb_author.Name = "tb_author";
            this.tb_author.Size = new System.Drawing.Size(111, 20);
            this.tb_author.TabIndex = 5;
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
            // ckbc_revisionBlock
            // 
            this.ckbc_revisionBlock.AutoSize = true;
            this.ckbc_revisionBlock.Location = new System.Drawing.Point(207, 38);
            this.ckbc_revisionBlock.Name = "ckbc_revisionBlock";
            this.ckbc_revisionBlock.Size = new System.Drawing.Size(108, 17);
            this.ckbc_revisionBlock.TabIndex = 7;
            this.ckbc_revisionBlock.Text = "Insert rev. block?";
            this.ckbc_revisionBlock.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar1.Location = new System.Drawing.Point(12, 381);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(303, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // lbl_progress
            // 
            this.lbl_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Location = new System.Drawing.Point(12, 365);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 436);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ckbc_revisionBlock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_author);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbx_createNewNames);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_modify);
            this.Controls.Add(this.btn_selectFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "Form1";
            this.Text = "JDO-DT Pdf Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_selectFiles;
        private System.Windows.Forms.Button btn_modify;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox ckbx_createNewNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_author;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbc_revisionBlock;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_progress;
        private System.ComponentModel.BackgroundWorker modifyPdfs;
    }
}

