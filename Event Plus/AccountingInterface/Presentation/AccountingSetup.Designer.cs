namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    partial class AccountingSetup
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblConnectionLabel = new System.Windows.Forms.Label();
            this.txtConnectionStr = new System.Windows.Forms.TextBox();
            this.btnBrowseConnection = new System.Windows.Forms.Button();
            this.ofdOracle = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoNightAudit = new System.Windows.Forms.RadioButton();
            this.rdoAnnual = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.rdoWeekly = new System.Windows.Forms.RadioButton();
            this.rdoDaily = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cboDay = new System.Windows.Forms.ComboBox();
            this.cboDayofMonth = new System.Windows.Forms.ComboBox();
            this.lblMonthly = new System.Windows.Forms.Label();
            this.dtpAnnual = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.lblEvery = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboBackOfficeName = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to Folio Plus Hotel Management System - Back Office Integration Setup";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "This tool lets you integrate your Folio Plus with a third party Accounting Softwa" +
                "re. To start, choose your Accounting software from the list below.";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(311, 478);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 31);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(383, 478);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblConnectionLabel
            // 
            this.lblConnectionLabel.Location = new System.Drawing.Point(35, 227);
            this.lblConnectionLabel.Name = "lblConnectionLabel";
            this.lblConnectionLabel.Size = new System.Drawing.Size(379, 20);
            this.lblConnectionLabel.TabIndex = 9;
            this.lblConnectionLabel.Text = "DNS Connection.";
            // 
            // txtConnectionStr
            // 
            this.txtConnectionStr.Location = new System.Drawing.Point(35, 250);
            this.txtConnectionStr.Name = "txtConnectionStr";
            this.txtConnectionStr.Size = new System.Drawing.Size(379, 20);
            this.txtConnectionStr.TabIndex = 10;
            this.txtConnectionStr.Text = "DSN=";
            // 
            // btnBrowseConnection
            // 
            this.btnBrowseConnection.Location = new System.Drawing.Point(421, 249);
            this.btnBrowseConnection.Name = "btnBrowseConnection";
            this.btnBrowseConnection.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseConnection.TabIndex = 11;
            this.btnBrowseConnection.Text = "...";
            this.btnBrowseConnection.UseVisualStyleBackColor = true;
            this.btnBrowseConnection.Click += new System.EventHandler(this.btnBrowseConnection_Click);
            // 
            // ofdOracle
            // 
            this.ofdOracle.FileName = "*.xls";
            this.ofdOracle.Filter = "Excel *.xls|";
            this.ofdOracle.InitialDirectory = "C:\\";
            this.ofdOracle.Title = "Select Excel File";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoNightAudit);
            this.groupBox1.Controls.Add(this.rdoAnnual);
            this.groupBox1.Controls.Add(this.rdoMonthly);
            this.groupBox1.Controls.Add(this.rdoWeekly);
            this.groupBox1.Controls.Add(this.rdoDaily);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.lblEvery);
            this.groupBox1.Location = new System.Drawing.Point(26, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 167);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Posting schedule";
            // 
            // rdoNightAudit
            // 
            this.rdoNightAudit.AutoSize = true;
            this.rdoNightAudit.Location = new System.Drawing.Point(29, 134);
            this.rdoNightAudit.Name = "rdoNightAudit";
            this.rdoNightAudit.Size = new System.Drawing.Size(148, 18);
            this.rdoNightAudit.TabIndex = 23;
            this.rdoNightAudit.Text = "After Night Audit Process";
            this.rdoNightAudit.UseVisualStyleBackColor = true;
            this.rdoNightAudit.CheckedChanged += new System.EventHandler(this.rdoNightAudit_CheckedChanged);
            // 
            // rdoAnnual
            // 
            this.rdoAnnual.AutoSize = true;
            this.rdoAnnual.Location = new System.Drawing.Point(29, 103);
            this.rdoAnnual.Name = "rdoAnnual";
            this.rdoAnnual.Size = new System.Drawing.Size(59, 18);
            this.rdoAnnual.TabIndex = 22;
            this.rdoAnnual.Text = "Annual";
            this.rdoAnnual.UseVisualStyleBackColor = true;
            this.rdoAnnual.CheckedChanged += new System.EventHandler(this.rdoAnnual_CheckedChanged);
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.Location = new System.Drawing.Point(29, 79);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(62, 18);
            this.rdoMonthly.TabIndex = 21;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            this.rdoMonthly.CheckedChanged += new System.EventHandler(this.rdoMonthly_CheckedChanged);
            // 
            // rdoWeekly
            // 
            this.rdoWeekly.AutoSize = true;
            this.rdoWeekly.Location = new System.Drawing.Point(29, 55);
            this.rdoWeekly.Name = "rdoWeekly";
            this.rdoWeekly.Size = new System.Drawing.Size(60, 18);
            this.rdoWeekly.TabIndex = 20;
            this.rdoWeekly.Text = "Weekly";
            this.rdoWeekly.UseVisualStyleBackColor = true;
            this.rdoWeekly.CheckedChanged += new System.EventHandler(this.rdoWeekly_CheckedChanged);
            // 
            // rdoDaily
            // 
            this.rdoDaily.AutoSize = true;
            this.rdoDaily.Checked = true;
            this.rdoDaily.Location = new System.Drawing.Point(29, 31);
            this.rdoDaily.Name = "rdoDaily";
            this.rdoDaily.Size = new System.Drawing.Size(48, 18);
            this.rdoDaily.TabIndex = 19;
            this.rdoDaily.TabStop = true;
            this.rdoDaily.Text = "Daily";
            this.rdoDaily.UseVisualStyleBackColor = true;
            this.rdoDaily.CheckedChanged += new System.EventHandler(this.rdoDaily_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cboDay);
            this.flowLayoutPanel1.Controls.Add(this.cboDayofMonth);
            this.flowLayoutPanel1.Controls.Add(this.lblMonthly);
            this.flowLayoutPanel1.Controls.Add(this.dtpAnnual);
            this.flowLayoutPanel1.Controls.Add(this.dtpTime);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(240, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(176, 108);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // cboDay
            // 
            this.cboDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDay.FormattingEnabled = true;
            this.cboDay.Items.AddRange(new object[] {
            "SUNDAY",
            "MONDAY",
            "TUESDAY",
            "WEDNESDAY",
            "THURSDAY",
            "FRIDAY",
            "SATURDAY"});
            this.cboDay.Location = new System.Drawing.Point(3, 3);
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(147, 22);
            this.cboDay.TabIndex = 0;
            this.cboDay.Visible = false;
            // 
            // cboDayofMonth
            // 
            this.cboDayofMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDayofMonth.FormattingEnabled = true;
            this.cboDayofMonth.Items.AddRange(new object[] {
            "1st",
            "2nd",
            "3rd",
            "4th",
            "5th",
            "6th",
            "7th",
            "8th",
            "9th",
            "10th",
            "11th",
            "12th",
            "13th",
            "14th",
            "15th",
            "16th",
            "17th",
            "18th",
            "19th",
            "20th",
            "21st",
            "22nd",
            "23rd",
            "24th",
            "25th",
            "26th",
            "27th",
            "28th",
            "29th",
            "30th"});
            this.cboDayofMonth.Location = new System.Drawing.Point(3, 31);
            this.cboDayofMonth.Name = "cboDayofMonth";
            this.cboDayofMonth.Size = new System.Drawing.Size(72, 22);
            this.cboDayofMonth.TabIndex = 5;
            this.cboDayofMonth.Visible = false;
            // 
            // lblMonthly
            // 
            this.lblMonthly.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthly.Location = new System.Drawing.Point(81, 28);
            this.lblMonthly.Name = "lblMonthly";
            this.lblMonthly.Size = new System.Drawing.Size(87, 25);
            this.lblMonthly.TabIndex = 3;
            this.lblMonthly.Text = "day of Month";
            this.lblMonthly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpAnnual
            // 
            this.dtpAnnual.CustomFormat = "MMMM dd";
            this.dtpAnnual.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAnnual.Location = new System.Drawing.Point(3, 59);
            this.dtpAnnual.Name = "dtpAnnual";
            this.dtpAnnual.Size = new System.Drawing.Size(145, 20);
            this.dtpAnnual.TabIndex = 4;
            this.dtpAnnual.Visible = false;
            // 
            // dtpTime
            // 
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(3, 85);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(145, 20);
            this.dtpTime.TabIndex = 2;
            // 
            // lblEvery
            // 
            this.lblEvery.Location = new System.Drawing.Point(179, 33);
            this.lblEvery.Name = "lblEvery";
            this.lblEvery.Size = new System.Drawing.Size(45, 16);
            this.lblEvery.TabIndex = 17;
            this.lblEvery.Text = "Every";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(35, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Back Office Name";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(278, 170);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(136, 20);
            this.txtVersion.TabIndex = 21;
            this.txtVersion.Text = "11i";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(278, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Version";
            // 
            // cboBackOfficeName
            // 
            this.cboBackOfficeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBackOfficeName.FormattingEnabled = true;
            this.cboBackOfficeName.Items.AddRange(new object[] {
            "Microsoft Dynamics-Navision",
            "Oracle 11i",
            "Exact-Globe",
            "SAP-Business 1",
            "PeachTree",
            "QuickBooks"});
            this.cboBackOfficeName.Location = new System.Drawing.Point(35, 168);
            this.cboBackOfficeName.Name = "cboBackOfficeName";
            this.cboBackOfficeName.Size = new System.Drawing.Size(190, 22);
            this.cboBackOfficeName.TabIndex = 22;
            this.cboBackOfficeName.SelectedIndexChanged += new System.EventHandler(this.cboBackOfficeName_SelectedIndexChanged);
            // 
            // AccountingSetup
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(480, 522);
            this.Controls.Add(this.cboBackOfficeName);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowseConnection);
            this.Controls.Add(this.txtConnectionStr);
            this.Controls.Add(this.lblConnectionLabel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AccountingSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounting Setup";
            this.Load += new System.EventHandler(this.AccountingSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblConnectionLabel;
        private System.Windows.Forms.TextBox txtConnectionStr;
        private System.Windows.Forms.Button btnBrowseConnection;
        private System.Windows.Forms.OpenFileDialog ofdOracle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEvery;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.ComboBox cboDay;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.RadioButton rdoAnnual;
        private System.Windows.Forms.RadioButton rdoMonthly;
        private System.Windows.Forms.RadioButton rdoWeekly;
        private System.Windows.Forms.RadioButton rdoDaily;
        private System.Windows.Forms.Label lblMonthly;
        private System.Windows.Forms.DateTimePicker dtpAnnual;
        private System.Windows.Forms.ComboBox cboDayofMonth;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RadioButton rdoNightAudit;
        private System.Windows.Forms.ComboBox cboBackOfficeName;
    }
}