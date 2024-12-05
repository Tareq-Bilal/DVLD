namespace DVLD
{
    partial class UC_PersonInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uC_FindUserByFilter1 = new DVLD.UC_FindUserByFilter();
            this.uC_PersonInfo1 = new DVLD.UC_PersonInfo();
            this.SuspendLayout();
            // 
            // uC_FindUserByFilter1
            // 
            this.uC_FindUserByFilter1.Location = new System.Drawing.Point(3, 3);
            this.uC_FindUserByFilter1.Name = "uC_FindUserByFilter1";
            this.uC_FindUserByFilter1.Size = new System.Drawing.Size(967, 81);
            this.uC_FindUserByFilter1.TabIndex = 1;
            // 
            // uC_PersonInfo1
            // 
            this.uC_PersonInfo1.Location = new System.Drawing.Point(3, 86);
            this.uC_PersonInfo1.Name = "uC_PersonInfo1";
            this.uC_PersonInfo1.Size = new System.Drawing.Size(967, 325);
            this.uC_PersonInfo1.TabIndex = 0;
            // 
            // UC_PersonInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uC_FindUserByFilter1);
            this.Controls.Add(this.uC_PersonInfo1);
            this.Name = "UC_PersonInfoWithFilter";
            this.Size = new System.Drawing.Size(979, 417);
            this.Load += new System.EventHandler(this.UC_PersonInfoWithFilter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_PersonInfo uC_PersonInfo1;
        private UC_FindUserByFilter uC_FindUserByFilter1;
    }
}
