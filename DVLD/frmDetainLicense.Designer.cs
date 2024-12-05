namespace DVLD
{
    partial class frmDetainLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetainLicense));
            this.btnClose = new System.Windows.Forms.Button();
            this.uC_DeatinLicense1 = new DVLD.UC_DeatinLicense();
            this.lblReplcaementType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(677, 749);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 44);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // uC_DeatinLicense1
            // 
            this.uC_DeatinLicense1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uC_DeatinLicense1.Location = new System.Drawing.Point(0, 68);
            this.uC_DeatinLicense1.Name = "uC_DeatinLicense1";
            this.uC_DeatinLicense1.Size = new System.Drawing.Size(960, 739);
            this.uC_DeatinLicense1.TabIndex = 0;
            // 
            // lblReplcaementType
            // 
            this.lblReplcaementType.AutoSize = true;
            this.lblReplcaementType.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplcaementType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblReplcaementType.Location = new System.Drawing.Point(362, 13);
            this.lblReplcaementType.Name = "lblReplcaementType";
            this.lblReplcaementType.Size = new System.Drawing.Size(252, 42);
            this.lblReplcaementType.TabIndex = 88;
            this.lblReplcaementType.Text = "Detain License";
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 807);
            this.Controls.Add(this.lblReplcaementType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.uC_DeatinLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC_DeatinLicense uC_DeatinLicense1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblReplcaementType;
    }
}