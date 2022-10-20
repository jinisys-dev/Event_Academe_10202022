namespace Jinisys.Hotel.Reports.Presentation
{
    partial class StatisticAccountTypeUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticAccountTypeUI));
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.gridResult = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.nudFrom = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.cboMarketSegment = new System.Windows.Forms.ComboBox();
            this.lblMarketSegment = new System.Windows.Forms.Label();
            this.lblClientType = new System.Windows.Forms.Label();
            this.cboClientType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudTo = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sfdExportToExcel = new System.Windows.Forms.SaveFileDialog();
            this.grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpResult
            // 
            this.grpResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResult.Controls.Add(this.gridResult);
            this.grpResult.Location = new System.Drawing.Point(15, 96);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(493, 457);
            this.grpResult.TabIndex = 0;
            this.grpResult.TabStop = false;
            // 
            // gridResult
            // 
            this.gridResult.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gridResult.AllowEditing = false;
            this.gridResult.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gridResult.ColumnInfo = "3,0,0,0,0,85,Columns:0{Name:\"No\";Caption:\"No.\";}\t1{Width:182;Name:\"organizer\";Cap" +
                "tion:\"Name of Organization\";}\t2{Name:\"Years\";Caption:\"Years Client\";}\t";
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.Location = new System.Drawing.Point(3, 16);
            this.gridResult.Name = "gridResult";
            this.gridResult.Rows.Count = 1;
            this.gridResult.Rows.DefaultSize = 17;
            this.gridResult.Size = new System.Drawing.Size(487, 438);
            this.gridResult.StyleInfo = resources.GetString("gridResult.StyleInfo");
            this.gridResult.TabIndex = 8;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(437, 50);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(68, 48);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(363, 50);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(68, 48);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // nudFrom
            // 
            this.nudFrom.Location = new System.Drawing.Point(55, 25);
            this.nudFrom.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nudFrom.Name = "nudFrom";
            this.nudFrom.Size = new System.Drawing.Size(73, 20);
            this.nudFrom.TabIndex = 3;
            this.nudFrom.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(12, 29);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(30, 13);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "From";
            // 
            // cboMarketSegment
            // 
            this.cboMarketSegment.FormattingEnabled = true;
            this.cboMarketSegment.Location = new System.Drawing.Point(167, 73);
            this.cboMarketSegment.Name = "cboMarketSegment";
            this.cboMarketSegment.Size = new System.Drawing.Size(149, 21);
            this.cboMarketSegment.TabIndex = 5;
            // 
            // lblMarketSegment
            // 
            this.lblMarketSegment.AutoSize = true;
            this.lblMarketSegment.Location = new System.Drawing.Point(164, 56);
            this.lblMarketSegment.Name = "lblMarketSegment";
            this.lblMarketSegment.Size = new System.Drawing.Size(88, 13);
            this.lblMarketSegment.TabIndex = 6;
            this.lblMarketSegment.Text = "Market Segment:";
            // 
            // lblClientType
            // 
            this.lblClientType.AutoSize = true;
            this.lblClientType.Location = new System.Drawing.Point(164, 12);
            this.lblClientType.Name = "lblClientType";
            this.lblClientType.Size = new System.Drawing.Size(60, 13);
            this.lblClientType.TabIndex = 8;
            this.lblClientType.Text = "Client Type";
            // 
            // cboClientType
            // 
            this.cboClientType.FormattingEnabled = true;
            this.cboClientType.Location = new System.Drawing.Point(167, 30);
            this.cboClientType.Name = "cboClientType";
            this.cboClientType.Size = new System.Drawing.Size(104, 21);
            this.cboClientType.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "To";
            // 
            // nudTo
            // 
            this.nudTo.Location = new System.Drawing.Point(55, 51);
            this.nudTo.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nudTo.Name = "nudTo";
            this.nudTo.Size = new System.Drawing.Size(73, 20);
            this.nudTo.TabIndex = 9;
            this.nudTo.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudFrom);
            this.groupBox1.Controls.Add(this.lblYear);
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 86);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range";
            // 
            // sfdExportToExcel
            // 
            this.sfdExportToExcel.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdExportToExcel_FileOk);
            // 
            // StatisticAccountTypeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 565);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblClientType);
            this.Controls.Add(this.cboClientType);
            this.Controls.Add(this.lblMarketSegment);
            this.Controls.Add(this.cboMarketSegment);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.grpResult);
            this.Name = "StatisticAccountTypeUI";
            this.Text = "StatisticAccountTypeUI";
            this.Load += new System.EventHandler(this.StatisticAccountTypeUI_Load);
            this.grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Button btnExport;
        private C1.Win.C1FlexGrid.C1FlexGrid gridResult;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.NumericUpDown nudFrom;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cboMarketSegment;
        private System.Windows.Forms.Label lblMarketSegment;
        private System.Windows.Forms.Label lblClientType;
        private System.Windows.Forms.ComboBox cboClientType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SaveFileDialog sfdExportToExcel;

    }
}