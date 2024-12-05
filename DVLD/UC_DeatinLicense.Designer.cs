namespace DVLD
{
    partial class UC_DeatinLicense
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_DeatinLicense));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchLicense = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uC_DriverLicenseInfo1 = new DVLD.UC_DriverLicenseInfo();
            this.gpDetainInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblLID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDeatinID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDetian = new System.Windows.Forms.Button();
            this.linkLabelShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.linklableShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.tbDetainFees = new System.Windows.Forms.TextBox();
            this.epDetainFees = new System.Windows.Forms.ErrorProvider(this.components);
            this.epEmptyField = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.gpDetainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDetainFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmptyField)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearchLicense);
            this.groupBox1.Controls.Add(this.tbSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 93);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // btnSearchLicense
            // 
            this.btnSearchLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchLicense.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchLicense.Image")));
            this.btnSearchLicense.Location = new System.Drawing.Point(508, 28);
            this.btnSearchLicense.Name = "btnSearchLicense";
            this.btnSearchLicense.Size = new System.Drawing.Size(58, 50);
            this.btnSearchLicense.TabIndex = 19;
            this.btnSearchLicense.UseVisualStyleBackColor = true;
            this.btnSearchLicense.Click += new System.EventHandler(this.btnSearchLicense_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.tbSearch.Location = new System.Drawing.Point(129, 43);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(353, 25);
            this.tbSearch.TabIndex = 18;
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSearch_KeyPress);
            this.tbSearch.Validating += new System.ComponentModel.CancelEventHandler(this.tbSearch_Validating);
            this.tbSearch.Validated += new System.EventHandler(this.tbSearch_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 17;
            this.label2.Text = "LicenseID :  ";
            // 
            // uC_DriverLicenseInfo1
            // 
            this.uC_DriverLicenseInfo1.Location = new System.Drawing.Point(3, 108);
            this.uC_DriverLicenseInfo1.Name = "uC_DriverLicenseInfo1";
            this.uC_DriverLicenseInfo1.Size = new System.Drawing.Size(932, 390);
            this.uC_DriverLicenseInfo1.TabIndex = 77;
            // 
            // gpDetainInfo
            // 
            this.gpDetainInfo.Controls.Add(this.tbDetainFees);
            this.gpDetainInfo.Controls.Add(this.pictureBox2);
            this.gpDetainInfo.Controls.Add(this.lblLID);
            this.gpDetainInfo.Controls.Add(this.label1);
            this.gpDetainInfo.Controls.Add(this.lblDetainDate);
            this.gpDetainInfo.Controls.Add(this.pictureBox1);
            this.gpDetainInfo.Controls.Add(this.label3);
            this.gpDetainInfo.Controls.Add(this.lblCreatedBy);
            this.gpDetainInfo.Controls.Add(this.pictureBox13);
            this.gpDetainInfo.Controls.Add(this.pictureBox8);
            this.gpDetainInfo.Controls.Add(this.pictureBox7);
            this.gpDetainInfo.Controls.Add(this.label9);
            this.gpDetainInfo.Controls.Add(this.label8);
            this.gpDetainInfo.Controls.Add(this.lblDeatinID);
            this.gpDetainInfo.Controls.Add(this.label4);
            this.gpDetainInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpDetainInfo.Location = new System.Drawing.Point(9, 504);
            this.gpDetainInfo.Name = "gpDetainInfo";
            this.gpDetainInfo.Size = new System.Drawing.Size(926, 164);
            this.gpDetainInfo.TabIndex = 83;
            this.gpDetainInfo.TabStop = false;
            this.gpDetainInfo.Text = "Detain Info";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(664, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 30);
            this.pictureBox2.TabIndex = 112;
            this.pictureBox2.TabStop = false;
            // 
            // lblLID
            // 
            this.lblLID.AutoSize = true;
            this.lblLID.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLID.ForeColor = System.Drawing.Color.Black;
            this.lblLID.Location = new System.Drawing.Point(714, 36);
            this.lblLID.Name = "lblLID";
            this.lblLID.Size = new System.Drawing.Size(42, 19);
            this.lblLID.TabIndex = 101;
            this.lblLID.Text = "[???]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(479, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 100;
            this.label1.Text = "License ID :";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.ForeColor = System.Drawing.Color.Black;
            this.lblDetainDate.Location = new System.Drawing.Point(228, 78);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(63, 19);
            this.lblDetainDate.TabIndex = 96;
            this.lblDetainDate.Text = "[??????]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(185, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 30);
            this.pictureBox1.TabIndex = 95;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 22);
            this.label3.TabIndex = 94;
            this.label3.Text = "Detain Date :";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedBy.Location = new System.Drawing.Point(713, 78);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(63, 19);
            this.lblCreatedBy.TabIndex = 93;
            this.lblCreatedBy.Text = "[??????]";
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(664, 67);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(34, 30);
            this.pictureBox13.TabIndex = 90;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(182, 112);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(34, 30);
            this.pictureBox8.TabIndex = 82;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(185, 33);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(34, 30);
            this.pictureBox7.TabIndex = 74;
            this.pictureBox7.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(479, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 22);
            this.label9.TabIndex = 78;
            this.label9.Text = "Created By :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(18, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 22);
            this.label8.TabIndex = 77;
            this.label8.Text = "Detain Fees :";
            // 
            // lblDeatinID
            // 
            this.lblDeatinID.AutoSize = true;
            this.lblDeatinID.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeatinID.ForeColor = System.Drawing.Color.Black;
            this.lblDeatinID.Location = new System.Drawing.Point(230, 41);
            this.lblDeatinID.Name = "lblDeatinID";
            this.lblDeatinID.Size = new System.Drawing.Size(42, 19);
            this.lblDeatinID.TabIndex = 73;
            this.lblDeatinID.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 22);
            this.label4.TabIndex = 73;
            this.label4.Text = "Detain ID :";
            // 
            // btnDetian
            // 
            this.btnDetian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetian.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDetian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetian.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetian.Image = ((System.Drawing.Image)(resources.GetObject("btnDetian.Image")));
            this.btnDetian.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetian.Location = new System.Drawing.Point(811, 681);
            this.btnDetian.Name = "btnDetian";
            this.btnDetian.Size = new System.Drawing.Size(124, 43);
            this.btnDetian.TabIndex = 84;
            this.btnDetian.Text = "  Detain";
            this.btnDetian.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetian.UseVisualStyleBackColor = true;
            this.btnDetian.Click += new System.EventHandler(this.btnDetian_Click);
            // 
            // linkLabelShowLicenseHistory
            // 
            this.linkLabelShowLicenseHistory.AutoSize = true;
            this.linkLabelShowLicenseHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowLicenseHistory.Location = new System.Drawing.Point(20, 700);
            this.linkLabelShowLicenseHistory.Name = "linkLabelShowLicenseHistory";
            this.linkLabelShowLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.linkLabelShowLicenseHistory.TabIndex = 86;
            this.linkLabelShowLicenseHistory.TabStop = true;
            this.linkLabelShowLicenseHistory.Text = "Show License History";
            this.linkLabelShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseHistory_LinkClicked);
            // 
            // linklableShowNewLicenseInfo
            // 
            this.linklableShowNewLicenseInfo.AutoSize = true;
            this.linklableShowNewLicenseInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklableShowNewLicenseInfo.Location = new System.Drawing.Point(211, 700);
            this.linklableShowNewLicenseInfo.Name = "linklableShowNewLicenseInfo";
            this.linklableShowNewLicenseInfo.Size = new System.Drawing.Size(174, 19);
            this.linklableShowNewLicenseInfo.TabIndex = 85;
            this.linklableShowNewLicenseInfo.TabStop = true;
            this.linklableShowNewLicenseInfo.Text = "Show New License Info";
            this.linklableShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklableShowNewLicenseInfo_LinkClicked);
            // 
            // tbDetainFees
            // 
            this.tbDetainFees.Location = new System.Drawing.Point(232, 113);
            this.tbDetainFees.Name = "tbDetainFees";
            this.tbDetainFees.Size = new System.Drawing.Size(100, 27);
            this.tbDetainFees.TabIndex = 113;
            this.tbDetainFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDetainFees.Validating += new System.ComponentModel.CancelEventHandler(this.tbDetainFees_Validating);
            this.tbDetainFees.Validated += new System.EventHandler(this.tbDetainFees_Validated);
            // 
            // epDetainFees
            // 
            this.epDetainFees.ContainerControl = this;
            // 
            // epEmptyField
            // 
            this.epEmptyField.ContainerControl = this;
            // 
            // UC_DeatinLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelShowLicenseHistory);
            this.Controls.Add(this.linklableShowNewLicenseInfo);
            this.Controls.Add(this.btnDetian);
            this.Controls.Add(this.gpDetainInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.uC_DriverLicenseInfo1);
            this.Name = "UC_DeatinLicense";
            this.Size = new System.Drawing.Size(946, 739);
            this.Load += new System.EventHandler(this.UC_DeatinLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpDetainInfo.ResumeLayout(false);
            this.gpDetainInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDetainFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEmptyField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchLicense;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private UC_DriverLicenseInfo uC_DriverLicenseInfo1;
        private System.Windows.Forms.GroupBox gpDetainInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblLID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDeatinID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDetian;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseHistory;
        private System.Windows.Forms.LinkLabel linklableShowNewLicenseInfo;
        private System.Windows.Forms.TextBox tbDetainFees;
        private System.Windows.Forms.ErrorProvider epDetainFees;
        private System.Windows.Forms.ErrorProvider epEmptyField;
    }
}
