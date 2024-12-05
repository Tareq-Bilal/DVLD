namespace DVLD
{
    partial class frmTestAppintments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestAppintments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTestAppintment = new System.Windows.Forms.Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvTestAppointments = new System.Windows.Forms.DataGridView();
            this.lblTetsAppointmentType = new System.Windows.Forms.Label();
            this.pbTestTypePicture = new System.Windows.Forms.PictureBox();
            this.cmsTestAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uC_LocalDrivingLicenseApploicationInfo1 = new DVLD.UC_LocalDrivingLicenseApploicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypePicture)).BeginInit();
            this.cmsTestAppointments.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 579);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Appointments : ";
            // 
            // btnAddTestAppintment
            // 
            this.btnAddTestAppintment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddTestAppintment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTestAppintment.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTestAppintment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTestAppintment.Image")));
            this.btnAddTestAppintment.Location = new System.Drawing.Point(871, 569);
            this.btnAddTestAppintment.Name = "btnAddTestAppintment";
            this.btnAddTestAppintment.Size = new System.Drawing.Size(61, 38);
            this.btnAddTestAppintment.TabIndex = 20;
            this.btnAddTestAppintment.UseVisualStyleBackColor = true;
            this.btnAddTestAppintment.Click += new System.EventHandler(this.btnAddTestAppintment_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.Black;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(123, 818);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(31, 22);
            this.lblNumberOfRecords.TabIndex = 23;
            this.lblNumberOfRecords.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 817);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "# Records : ";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(820, 807);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 36);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvTestAppointments
            // 
            this.dgvTestAppointments.AllowUserToAddRows = false;
            this.dgvTestAppointments.AllowUserToDeleteRows = false;
            this.dgvTestAppointments.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTestAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestAppointments.ContextMenuStrip = this.cmsTestAppointments;
            this.dgvTestAppointments.Location = new System.Drawing.Point(16, 613);
            this.dgvTestAppointments.Name = "dgvTestAppointments";
            this.dgvTestAppointments.ReadOnly = true;
            this.dgvTestAppointments.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTestAppointments.Size = new System.Drawing.Size(921, 188);
            this.dgvTestAppointments.TabIndex = 24;
            // 
            // lblTetsAppointmentType
            // 
            this.lblTetsAppointmentType.AutoSize = true;
            this.lblTetsAppointmentType.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTetsAppointmentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTetsAppointmentType.Location = new System.Drawing.Point(309, 105);
            this.lblTetsAppointmentType.Name = "lblTetsAppointmentType";
            this.lblTetsAppointmentType.Size = new System.Drawing.Size(338, 36);
            this.lblTetsAppointmentType.TabIndex = 26;
            this.lblTetsAppointmentType.Text = "Test Appointment Type";
            // 
            // pbTestTypePicture
            // 
            this.pbTestTypePicture.Location = new System.Drawing.Point(386, 5);
            this.pbTestTypePicture.Name = "pbTestTypePicture";
            this.pbTestTypePicture.Size = new System.Drawing.Size(233, 95);
            this.pbTestTypePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestTypePicture.TabIndex = 25;
            this.pbTestTypePicture.TabStop = false;
            // 
            // cmsTestAppointments
            // 
            this.cmsTestAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsTestAppointments.Name = "cmsPeople";
            this.cmsTestAppointments.Size = new System.Drawing.Size(197, 102);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("takeTestToolStripMenuItem.Image")));
            this.takeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // uC_LocalDrivingLicenseApploicationInfo1
            // 
            this.uC_LocalDrivingLicenseApploicationInfo1.LocalDrivingLicenseApplicationID = 0;
            this.uC_LocalDrivingLicenseApploicationInfo1.Location = new System.Drawing.Point(7, 155);
            this.uC_LocalDrivingLicenseApploicationInfo1.Name = "uC_LocalDrivingLicenseApploicationInfo1";
            this.uC_LocalDrivingLicenseApploicationInfo1.Size = new System.Drawing.Size(930, 412);
            this.uC_LocalDrivingLicenseApploicationInfo1.TabIndex = 0;
            // 
            // frmTestAppintments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(950, 858);
            this.Controls.Add(this.lblTetsAppointmentType);
            this.Controls.Add(this.pbTestTypePicture);
            this.Controls.Add(this.dgvTestAppointments);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddTestAppintment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uC_LocalDrivingLicenseApploicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestAppintments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTestAppintments";
            this.Load += new System.EventHandler(this.frmTestAppintments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypePicture)).EndInit();
            this.cmsTestAppointments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UC_LocalDrivingLicenseApploicationInfo uC_LocalDrivingLicenseApploicationInfo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTestAppintment;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvTestAppointments;
        private System.Windows.Forms.Label lblTetsAppointmentType;
        private System.Windows.Forms.PictureBox pbTestTypePicture;
        private System.Windows.Forms.ContextMenuStrip cmsTestAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}