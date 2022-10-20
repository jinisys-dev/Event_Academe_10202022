namespace Jinisys.Hotel.Reports.Presentation
{
    partial class LostBusinessUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LostBusinessUI));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonthYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.rdoDateRange = new System.Windows.Forms.RadioButton();
            this.rdoYearly = new System.Windows.Forms.RadioButton();
            this.rdoMonthly = new System.Windows.Forms.RadioButton();
            this.gridLostBusiness = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.rdbEventType = new System.Windows.Forms.RadioButton();
            this.rdbMarketSegment = new System.Windows.Forms.RadioButton();
            this.rdbReason = new System.Windows.Forms.RadioButton();
            this.rdbTypeOfBooking = new System.Windows.Forms.RadioButton();
            this.btnPreview = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLostBusiness)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lost Business";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(7, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 7);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboMonthYear);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.rdoDateRange);
            this.groupBox1.Controls.Add(this.rdoYearly);
            this.groupBox1.Controls.Add(this.rdoMonthly);
            this.groupBox1.Location = new System.Drawing.Point(7, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 118);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(273, 85);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(121, 20);
            this.dtpTo.TabIndex = 8;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "to";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(124, 85);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(121, 20);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Items.AddRange(new object[] {
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.cboYear.Location = new System.Drawing.Point(124, 51);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 21);
            this.cboYear.TabIndex = 5;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // cboMonthYear
            // 
            this.cboMonthYear.FormattingEnabled = true;
            this.cboMonthYear.Items.AddRange(new object[] {
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.cboMonthYear.Location = new System.Drawing.Point(251, 19);
            this.cboMonthYear.Name = "cboMonthYear";
            this.cboMonthYear.Size = new System.Drawing.Size(83, 21);
            this.cboMonthYear.TabIndex = 4;
            this.cboMonthYear.SelectedIndexChanged += new System.EventHandler(this.cboMonthYear_SelectedIndexChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboMonth.Location = new System.Drawing.Point(124, 19);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(121, 21);
            this.cboMonth.TabIndex = 3;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // rdoDateRange
            // 
            this.rdoDateRange.AutoSize = true;
            this.rdoDateRange.Location = new System.Drawing.Point(6, 85);
            this.rdoDateRange.Name = "rdoDateRange";
            this.rdoDateRange.Size = new System.Drawing.Size(83, 17);
            this.rdoDateRange.TabIndex = 2;
            this.rdoDateRange.Text = "Date Range";
            this.rdoDateRange.UseVisualStyleBackColor = true;
            this.rdoDateRange.CheckedChanged += new System.EventHandler(this.rdoDateRange_CheckedChanged);
            // 
            // rdoYearly
            // 
            this.rdoYearly.AutoSize = true;
            this.rdoYearly.Location = new System.Drawing.Point(6, 52);
            this.rdoYearly.Name = "rdoYearly";
            this.rdoYearly.Size = new System.Drawing.Size(54, 17);
            this.rdoYearly.TabIndex = 1;
            this.rdoYearly.Text = "Yearly";
            this.rdoYearly.UseVisualStyleBackColor = true;
            this.rdoYearly.CheckedChanged += new System.EventHandler(this.rdoYearly_CheckedChanged);
            // 
            // rdoMonthly
            // 
            this.rdoMonthly.AutoSize = true;
            this.rdoMonthly.Checked = true;
            this.rdoMonthly.Location = new System.Drawing.Point(6, 19);
            this.rdoMonthly.Name = "rdoMonthly";
            this.rdoMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdoMonthly.TabIndex = 0;
            this.rdoMonthly.TabStop = true;
            this.rdoMonthly.Text = "Monthly";
            this.rdoMonthly.UseVisualStyleBackColor = true;
            this.rdoMonthly.CheckedChanged += new System.EventHandler(this.rdoMonthly_CheckedChanged);
            // 
            // gridLostBusiness
            // 
            this.gridLostBusiness.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gridLostBusiness.AllowEditing = false;
            this.gridLostBusiness.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLostBusiness.ColumnInfo = resources.GetString("gridLostBusiness.ColumnInfo");
            this.gridLostBusiness.Location = new System.Drawing.Point(7, 165);
            this.gridLostBusiness.Name = "gridLostBusiness";
            this.gridLostBusiness.Rows.Count = 1;
            this.gridLostBusiness.Rows.DefaultSize = 17;
            this.gridLostBusiness.Size = new System.Drawing.Size(815, 402);
            this.gridLostBusiness.TabIndex = 8;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(662, 574);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 34);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export to excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(743, 574);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 34);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnFilter);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cboFilter);
            this.groupBox4.Controls.Add(this.rdbEventType);
            this.groupBox4.Controls.Add(this.rdbMarketSegment);
            this.groupBox4.Controls.Add(this.rdbReason);
            this.groupBox4.Controls.Add(this.rdbTypeOfBooking);
            this.groupBox4.Controls.Add(this.btnPreview);
            this.groupBox4.Location = new System.Drawing.Point(480, 41);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 118);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::Jinisys.Hotel.Reports.Properties.Resources.filesearch16;
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilter.Location = new System.Drawing.Point(166, 78);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 31);
            this.btnFilter.TabIndex = 11;
            this.btnFilter.Text = "&Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filter by :";
            // 
            // cboFilter
            // 
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(161, 32);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(160, 21);
            this.cboFilter.TabIndex = 10;
            // 
            // rdbEventType
            // 
            this.rdbEventType.AutoSize = true;
            this.rdbEventType.Location = new System.Drawing.Point(14, 38);
            this.rdbEventType.Name = "rdbEventType";
            this.rdbEventType.Size = new System.Drawing.Size(80, 17);
            this.rdbEventType.TabIndex = 7;
            this.rdbEventType.Text = "Event Type";
            this.rdbEventType.UseVisualStyleBackColor = true;
            this.rdbEventType.CheckedChanged += new System.EventHandler(this.radioButtonEvent_CheckedChanged);
            // 
            // rdbMarketSegment
            // 
            this.rdbMarketSegment.AutoSize = true;
            this.rdbMarketSegment.Checked = true;
            this.rdbMarketSegment.Location = new System.Drawing.Point(14, 15);
            this.rdbMarketSegment.Name = "rdbMarketSegment";
            this.rdbMarketSegment.Size = new System.Drawing.Size(103, 17);
            this.rdbMarketSegment.TabIndex = 6;
            this.rdbMarketSegment.TabStop = true;
            this.rdbMarketSegment.Text = "Market Segment";
            this.rdbMarketSegment.UseVisualStyleBackColor = true;
            this.rdbMarketSegment.CheckedChanged += new System.EventHandler(this.radioButtonEvent_CheckedChanged);
            // 
            // rdbReason
            // 
            this.rdbReason.AutoSize = true;
            this.rdbReason.Location = new System.Drawing.Point(14, 83);
            this.rdbReason.Name = "rdbReason";
            this.rdbReason.Size = new System.Drawing.Size(62, 17);
            this.rdbReason.TabIndex = 9;
            this.rdbReason.Text = "Reason";
            this.rdbReason.UseVisualStyleBackColor = true;
            this.rdbReason.CheckedChanged += new System.EventHandler(this.radioButtonEvent_CheckedChanged);
            // 
            // rdbTypeOfBooking
            // 
            this.rdbTypeOfBooking.AutoSize = true;
            this.rdbTypeOfBooking.Location = new System.Drawing.Point(14, 61);
            this.rdbTypeOfBooking.Name = "rdbTypeOfBooking";
            this.rdbTypeOfBooking.Size = new System.Drawing.Size(103, 17);
            this.rdbTypeOfBooking.TabIndex = 8;
            this.rdbTypeOfBooking.Text = "Type of Booking";
            this.rdbTypeOfBooking.UseVisualStyleBackColor = true;
            this.rdbTypeOfBooking.CheckedChanged += new System.EventHandler(this.radioButtonEvent_CheckedChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::Jinisys.Hotel.Reports.Properties.Resources.filesearch16;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(247, 78);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(77, 31);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "     &Show";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // LostBusinessUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 620);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gridLostBusiness);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Name = "LostBusinessUI";
            this.Text = "Lost Business";
            this.Load += new System.EventHandler(this.LostBusinessUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLostBusiness)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoMonthly;
        private System.Windows.Forms.RadioButton rdoDateRange;
        private System.Windows.Forms.RadioButton rdoYearly;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonthYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private C1.Win.C1FlexGrid.C1FlexGrid gridLostBusiness;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.RadioButton rdbEventType;
        private System.Windows.Forms.RadioButton rdbMarketSegment;
        private System.Windows.Forms.RadioButton rdbReason;
        private System.Windows.Forms.RadioButton rdbTypeOfBooking;
        private System.Windows.Forms.Button btnPreview;
    }
}