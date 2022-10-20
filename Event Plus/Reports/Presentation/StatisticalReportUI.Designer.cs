namespace Jinisys.Hotel.Reports.Presentation
{
    partial class StatisticalReportUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticalReportUI));
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdReport = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.rdbAccountType = new System.Windows.Forms.RadioButton();
            this.rdbOrganizer = new System.Windows.Forms.RadioButton();
            this.rdbEventType = new System.Windows.Forms.RadioButton();
            this.rdbMarketSegment = new System.Windows.Forms.RadioButton();
            this.rdbSource = new System.Windows.Forms.RadioButton();
            this.rdbClientType = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpAnnual = new System.Windows.Forms.DateTimePicker();
            this.dtpMonthly = new System.Windows.Forms.DateTimePicker();
            this.dtpDaily = new System.Windows.Forms.DateTimePicker();
            this.rdbDateRange = new System.Windows.Forms.RadioButton();
            this.rdbYearly = new System.Windows.Forms.RadioButton();
            this.rdbMonthly = new System.Windows.Forms.RadioButton();
            this.rdbDaily = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMMM-yyyy";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(343, 130);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(147, 20);
            this.dtpEndDate.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMMM-yyyy";
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(122, 130);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(147, 20);
            this.dtpStartDate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.grdReport, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 169);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grdReport
            // 
            this.grdReport.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.grdReport.AllowEditing = false;
            this.grdReport.ColumnInfo = resources.GetString("grdReport.ColumnInfo");
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.ExtendLastCol = true;
            this.grdReport.Location = new System.Drawing.Point(5, 5);
            this.grdReport.Name = "grdReport";
            this.grdReport.Rows.Count = 10;
            this.grdReport.Rows.DefaultSize = 17;
            this.grdReport.Size = new System.Drawing.Size(848, 427);
            this.grdReport.StyleInfo = resources.GetString("grdReport.StyleInfo");
            this.grdReport.TabIndex = 0;
            this.grdReport.AfterDataRefresh += new System.ComponentModel.ListChangedEventHandler(this.grdReport_AfterDataRefresh);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(858, 168);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cboFilter);
            this.groupBox4.Controls.Add(this.rdbAccountType);
            this.groupBox4.Controls.Add(this.rdbOrganizer);
            this.groupBox4.Controls.Add(this.rdbEventType);
            this.groupBox4.Controls.Add(this.rdbMarketSegment);
            this.groupBox4.Controls.Add(this.rdbSource);
            this.groupBox4.Controls.Add(this.rdbClientType);
            this.groupBox4.Controls.Add(this.btnPreview);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(518, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(335, 158);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Report Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filter by :";
            // 
            // cboFilter
            // 
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(166, 49);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(160, 21);
            this.cboFilter.TabIndex = 1;
            // 
            // rdbAccountType
            // 
            this.rdbAccountType.AutoSize = true;
            this.rdbAccountType.Location = new System.Drawing.Point(19, 133);
            this.rdbAccountType.Name = "rdbAccountType";
            this.rdbAccountType.Size = new System.Drawing.Size(78, 17);
            this.rdbAccountType.TabIndex = 10;
            this.rdbAccountType.Text = "Client Type";
            this.rdbAccountType.UseVisualStyleBackColor = true;
            this.rdbAccountType.CheckedChanged += new System.EventHandler(this.rdbClientType_CheckedChanged);
            // 
            // rdbOrganizer
            // 
            this.rdbOrganizer.AutoSize = true;
            this.rdbOrganizer.Location = new System.Drawing.Point(19, 110);
            this.rdbOrganizer.Name = "rdbOrganizer";
            this.rdbOrganizer.Size = new System.Drawing.Size(70, 17);
            this.rdbOrganizer.TabIndex = 10;
            this.rdbOrganizer.Text = "Organizer";
            this.rdbOrganizer.UseVisualStyleBackColor = true;
            this.rdbOrganizer.CheckedChanged += new System.EventHandler(this.rdbClientType_CheckedChanged);
            // 
            // rdbEventType
            // 
            this.rdbEventType.AutoSize = true;
            this.rdbEventType.Location = new System.Drawing.Point(19, 87);
            this.rdbEventType.Name = "rdbEventType";
            this.rdbEventType.Size = new System.Drawing.Size(80, 17);
            this.rdbEventType.TabIndex = 9;
            this.rdbEventType.Text = "Event Type";
            this.rdbEventType.UseVisualStyleBackColor = true;
            this.rdbEventType.CheckedChanged += new System.EventHandler(this.rdbClientType_CheckedChanged);
            // 
            // rdbMarketSegment
            // 
            this.rdbMarketSegment.AutoSize = true;
            this.rdbMarketSegment.Location = new System.Drawing.Point(19, 64);
            this.rdbMarketSegment.Name = "rdbMarketSegment";
            this.rdbMarketSegment.Size = new System.Drawing.Size(103, 17);
            this.rdbMarketSegment.TabIndex = 8;
            this.rdbMarketSegment.Text = "Market Segment";
            this.rdbMarketSegment.UseVisualStyleBackColor = true;
            this.rdbMarketSegment.CheckedChanged += new System.EventHandler(this.rdbClientType_CheckedChanged);
            // 
            // rdbSource
            // 
            this.rdbSource.AutoSize = true;
            this.rdbSource.Location = new System.Drawing.Point(19, 41);
            this.rdbSource.Name = "rdbSource";
            this.rdbSource.Size = new System.Drawing.Size(59, 17);
            this.rdbSource.TabIndex = 7;
            this.rdbSource.Text = "Source";
            this.rdbSource.UseVisualStyleBackColor = true;
            this.rdbSource.CheckedChanged += new System.EventHandler(this.rdbClientType_CheckedChanged);
            // 
            // rdbClientType
            // 
            this.rdbClientType.AutoSize = true;
            this.rdbClientType.Checked = true;
            this.rdbClientType.Location = new System.Drawing.Point(19, 18);
            this.rdbClientType.Name = "rdbClientType";
            this.rdbClientType.Size = new System.Drawing.Size(78, 17);
            this.rdbClientType.TabIndex = 6;
            this.rdbClientType.TabStop = true;
            this.rdbClientType.Text = "Client Type";
            this.rdbClientType.UseVisualStyleBackColor = true;
            this.rdbClientType.Visible = false;
            this.rdbClientType.CheckedChanged += new System.EventHandler(this.rdbClientType_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpAnnual);
            this.groupBox3.Controls.Add(this.dtpMonthly);
            this.groupBox3.Controls.Add(this.dtpDaily);
            this.groupBox3.Controls.Add(this.rdbDateRange);
            this.groupBox3.Controls.Add(this.rdbYearly);
            this.groupBox3.Controls.Add(this.dtpEndDate);
            this.groupBox3.Controls.Add(this.dtpStartDate);
            this.groupBox3.Controls.Add(this.rdbMonthly);
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.rdbDaily);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(5, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(505, 158);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Parameter";
            // 
            // dtpAnnual
            // 
            this.dtpAnnual.CustomFormat = "yyyy";
            this.dtpAnnual.Enabled = false;
            this.dtpAnnual.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAnnual.Location = new System.Drawing.Point(122, 76);
            this.dtpAnnual.Name = "dtpAnnual";
            this.dtpAnnual.ShowUpDown = true;
            this.dtpAnnual.Size = new System.Drawing.Size(147, 20);
            this.dtpAnnual.TabIndex = 15;
            // 
            // dtpMonthly
            // 
            this.dtpMonthly.CustomFormat = "MMMM  yyyy";
            this.dtpMonthly.Enabled = false;
            this.dtpMonthly.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthly.Location = new System.Drawing.Point(122, 50);
            this.dtpMonthly.Name = "dtpMonthly";
            this.dtpMonthly.ShowUpDown = true;
            this.dtpMonthly.Size = new System.Drawing.Size(147, 20);
            this.dtpMonthly.TabIndex = 14;
            // 
            // dtpDaily
            // 
            this.dtpDaily.CustomFormat = "dd-MMMM-yyyy";
            this.dtpDaily.Enabled = false;
            this.dtpDaily.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDaily.Location = new System.Drawing.Point(122, 25);
            this.dtpDaily.Name = "dtpDaily";
            this.dtpDaily.Size = new System.Drawing.Size(147, 20);
            this.dtpDaily.TabIndex = 11;
            // 
            // rdbDateRange
            // 
            this.rdbDateRange.AutoSize = true;
            this.rdbDateRange.Location = new System.Drawing.Point(22, 106);
            this.rdbDateRange.Name = "rdbDateRange";
            this.rdbDateRange.Size = new System.Drawing.Size(83, 17);
            this.rdbDateRange.TabIndex = 3;
            this.rdbDateRange.Text = "Date Range";
            this.rdbDateRange.UseVisualStyleBackColor = true;
            this.rdbDateRange.CheckedChanged += new System.EventHandler(this.rdbDaily_CheckedChanged);
            // 
            // rdbYearly
            // 
            this.rdbYearly.AutoSize = true;
            this.rdbYearly.Location = new System.Drawing.Point(22, 80);
            this.rdbYearly.Name = "rdbYearly";
            this.rdbYearly.Size = new System.Drawing.Size(54, 17);
            this.rdbYearly.TabIndex = 2;
            this.rdbYearly.Text = "Yearly";
            this.rdbYearly.UseVisualStyleBackColor = true;
            this.rdbYearly.CheckedChanged += new System.EventHandler(this.rdbDaily_CheckedChanged);
            // 
            // rdbMonthly
            // 
            this.rdbMonthly.AutoSize = true;
            this.rdbMonthly.Location = new System.Drawing.Point(22, 54);
            this.rdbMonthly.Name = "rdbMonthly";
            this.rdbMonthly.Size = new System.Drawing.Size(62, 17);
            this.rdbMonthly.TabIndex = 1;
            this.rdbMonthly.Text = "Monthly";
            this.rdbMonthly.UseVisualStyleBackColor = true;
            this.rdbMonthly.CheckedChanged += new System.EventHandler(this.rdbDaily_CheckedChanged);
            // 
            // rdbDaily
            // 
            this.rdbDaily.AutoSize = true;
            this.rdbDaily.Checked = true;
            this.rdbDaily.Location = new System.Drawing.Point(22, 28);
            this.rdbDaily.Name = "rdbDaily";
            this.rdbDaily.Size = new System.Drawing.Size(48, 17);
            this.rdbDaily.TabIndex = 0;
            this.rdbDaily.TabStop = true;
            this.rdbDaily.Text = "Daily";
            this.rdbDaily.UseVisualStyleBackColor = true;
            this.rdbDaily.CheckedChanged += new System.EventHandler(this.rdbDaily_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Image = global::Jinisys.Hotel.Reports.Properties.Resources.filesearch16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(171, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 16;
            this.button1.Text = "&Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Image = global::Jinisys.Hotel.Reports.Properties.Resources.filesearch16;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(252, 95);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(77, 31);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "     &Show";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::Jinisys.Hotel.Reports.Properties.Resources.printer16;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(413, 87);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(77, 31);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "     &Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // StatisticalReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatisticalReportUI";
            this.Load += new System.EventHandler(this.StatisticalReportUI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbDaily;
        private System.Windows.Forms.DateTimePicker dtpDaily;
        private System.Windows.Forms.RadioButton rdbDateRange;
        private System.Windows.Forms.RadioButton rdbYearly;
        private System.Windows.Forms.RadioButton rdbMonthly;
        private System.Windows.Forms.RadioButton rdbEventType;
        private System.Windows.Forms.RadioButton rdbMarketSegment;
        private System.Windows.Forms.RadioButton rdbSource;
        private System.Windows.Forms.RadioButton rdbClientType;
        private C1.Win.C1FlexGrid.C1FlexGrid grdReport;
        private System.Windows.Forms.DateTimePicker dtpMonthly;
        private System.Windows.Forms.DateTimePicker dtpAnnual;
        private System.Windows.Forms.RadioButton rdbOrganizer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rdbAccountType;
    }
}