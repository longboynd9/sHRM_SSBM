namespace UpdatesHRM
{
    partial class sHRM_Update
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelPBHienTai = new System.Windows.Forms.Label();
            this.labelPBMoiNhat = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.labelProgress = new System.Windows.Forms.Label();
            this.btnTruyCapsHRM = new System.Windows.Forms.Button();
            this.rtbError = new System.Windows.Forms.RichTextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 17.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cập nhật phần mềm";
            // 
            // labelPBHienTai
            // 
            this.labelPBHienTai.AutoSize = true;
            this.labelPBHienTai.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.labelPBHienTai.Location = new System.Drawing.Point(4, 118);
            this.labelPBHienTai.Margin = new System.Windows.Forms.Padding(0);
            this.labelPBHienTai.Name = "labelPBHienTai";
            this.labelPBHienTai.Size = new System.Drawing.Size(92, 16);
            this.labelPBHienTai.TabIndex = 2;
            this.labelPBHienTai.Text = "labelPBHienTai";
            // 
            // labelPBMoiNhat
            // 
            this.labelPBMoiNhat.AutoSize = true;
            this.labelPBMoiNhat.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.labelPBMoiNhat.Location = new System.Drawing.Point(4, 135);
            this.labelPBMoiNhat.Margin = new System.Windows.Forms.Padding(0);
            this.labelPBMoiNhat.Name = "labelPBMoiNhat";
            this.labelPBMoiNhat.Size = new System.Drawing.Size(98, 16);
            this.labelPBMoiNhat.TabIndex = 3;
            this.labelPBMoiNhat.Text = "labelPBMoiNhat";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(1, 172);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(358, 21);
            this.progressBar.TabIndex = 4;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(5, 156);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 14);
            this.labelProgress.TabIndex = 6;
            // 
            // btnTruyCapsHRM
            // 
            this.btnTruyCapsHRM.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruyCapsHRM.Image = global::UpdatesHRM.Properties.Resources._2016_04_23_14_45_47;
            this.btnTruyCapsHRM.Location = new System.Drawing.Point(176, 193);
            this.btnTruyCapsHRM.Name = "btnTruyCapsHRM";
            this.btnTruyCapsHRM.Size = new System.Drawing.Size(132, 33);
            this.btnTruyCapsHRM.TabIndex = 7;
            this.btnTruyCapsHRM.Text = "Truy cập sHRM";
            this.btnTruyCapsHRM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTruyCapsHRM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTruyCapsHRM.UseVisualStyleBackColor = true;
            this.btnTruyCapsHRM.Click += new System.EventHandler(this.btnTruyCapsHRM_Click);
            // 
            // rtbError
            // 
            this.rtbError.BackColor = System.Drawing.SystemColors.Menu;
            this.rtbError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbError.Location = new System.Drawing.Point(1, 227);
            this.rtbError.Name = "rtbError";
            this.rtbError.Size = new System.Drawing.Size(358, 38);
            this.rtbError.TabIndex = 8;
            this.rtbError.Text = "";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = global::UpdatesHRM.Properties.Resources.update;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(42, 193);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 33);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Cập nhật sHRM";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UpdatesHRM.Properties.Resources.LogoLogin;
            this.pictureBox1.InitialImage = global::UpdatesHRM.Properties.Resources.LogoLogin;
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sHRM_Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 268);
            this.Controls.Add(this.rtbError);
            this.Controls.Add(this.btnTruyCapsHRM);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelPBMoiNhat);
            this.Controls.Add(this.labelPBHienTai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "sHRM_Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật sHRM";
            this.Load += new System.EventHandler(this.sHRM_Update_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPBHienTai;
        private System.Windows.Forms.Label labelPBMoiNhat;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnUpdate;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Button btnTruyCapsHRM;
        private System.Windows.Forms.RichTextBox rtbError;
    }
}