namespace DVLD
{
    partial class frmShowLocalApplicationInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowLocalApplicationInfo));
            this.uC_LocalDrivingLicenseApploicationInfo1 = new DVLD.UC_LocalDrivingLicenseApploicationInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uC_LocalDrivingLicenseApploicationInfo1
            // 
            this.uC_LocalDrivingLicenseApploicationInfo1.Location = new System.Drawing.Point(3, 3);
            this.uC_LocalDrivingLicenseApploicationInfo1.Name = "uC_LocalDrivingLicenseApploicationInfo1";
            this.uC_LocalDrivingLicenseApploicationInfo1.Size = new System.Drawing.Size(930, 404);
            this.uC_LocalDrivingLicenseApploicationInfo1.TabIndex = 0;
            this.uC_LocalDrivingLicenseApploicationInfo1.Load += new System.EventHandler(this.uC_LocalDrivingLicenseApploicationInfo1_Load);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(810, 418);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 36);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmShowLocalApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(934, 466);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.uC_LocalDrivingLicenseApploicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowLocalApplicationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowLocalApplicationInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_LocalDrivingLicenseApploicationInfo uC_LocalDrivingLicenseApploicationInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}