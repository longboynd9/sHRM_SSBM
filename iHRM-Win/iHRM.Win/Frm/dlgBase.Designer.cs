namespace iHRM.Win.Frm
{
    partial class dlgBase
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
            this.components = new System.ComponentModel.Container();
            this.buttonPanel1 = new iHRM.Win.UC.ButtonPanel(this.components);
            this.SuspendLayout();
            // 
            // buttonPanel1
            // 
            this.buttonPanel1.BackColor = System.Drawing.Color.Transparent;
            this.buttonPanel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText;
            this.buttonPanel1.enableButtonChoose = true;
            this.buttonPanel1.enableButtonDelete = true;
            this.buttonPanel1.enableButtonEdit = true;
            this.buttonPanel1.enableButtonExit = true;
            this.buttonPanel1.enableButtonExport = true;
            this.buttonPanel1.enableButtonFind = true;
            this.buttonPanel1.enableButtonImport = true;
            this.buttonPanel1.enableButtonNew = true;
            this.buttonPanel1.enableButtonPrint = true;
            this.buttonPanel1.enableButtonSave = true;
            this.buttonPanel1.Font = new System.Drawing.Font("Times New Roman", 12.5F);
            this.buttonPanel1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.buttonPanel1.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel1.Name = "buttonPanel1";
            this.buttonPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.buttonPanel1.showButtonChoose = false;
            this.buttonPanel1.showButtonDelete = false;
            this.buttonPanel1.showButtonEdit = false;
            this.buttonPanel1.showButtonExit = true;
            this.buttonPanel1.showButtonExport = false;
            this.buttonPanel1.showButtonFind = false;
            this.buttonPanel1.showButtonImport = false;
            this.buttonPanel1.showButtonNew = false;
            this.buttonPanel1.showButtonPrint = false;
            this.buttonPanel1.showButtonSave = true;
            this.buttonPanel1.ShowStyle = iHRM.Win.UC.ButtonPanel.eShowStyle.Custom;
            this.buttonPanel1.Size = new System.Drawing.Size(737, 42);
            this.buttonPanel1.TabIndex = 3;
            this.buttonPanel1.Text = "buttonPanel1";
            this.buttonPanel1.TextAndImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPanel1.useButtonChoose = false;
            this.buttonPanel1.useButtonDelete = false;
            this.buttonPanel1.useButtonEdit = false;
            this.buttonPanel1.useButtonExit = true;
            this.buttonPanel1.useButtonExport = false;
            this.buttonPanel1.useButtonFind = false;
            this.buttonPanel1.useButtonImport = false;
            this.buttonPanel1.useButtonNew = false;
            this.buttonPanel1.useButtonPrint = false;
            this.buttonPanel1.useButtonSave = true;
            this.buttonPanel1.OnSave += new System.EventHandler(this.buttonPanel1_OnSave);
            // 
            // dlgBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 347);
            this.Controls.Add(this.buttonPanel1);
            this.Name = "dlgBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgBase2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected UC.ButtonPanel buttonPanel1;
    }
}