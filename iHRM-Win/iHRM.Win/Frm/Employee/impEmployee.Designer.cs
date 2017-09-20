namespace iHRM.Win.Frm.Employee
{
    partial class impEmployee
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
            this.SuspendLayout();
            // 
            // impEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 356);
            this.Form_Description = "Nhập thông tin của nhân viên từ excel";
            this.Form_Title = "Import nhân viên";
            this.Name = "impEmployee";
            this.Text = "Import nhân viên";
            this.Load += new System.EventHandler(this.impEmployee_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}