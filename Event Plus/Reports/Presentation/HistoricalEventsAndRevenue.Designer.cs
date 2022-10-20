namespace Jinisys.Hotel.Reports.Presentation
{
    partial class HistoricalEventsAndRevenue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoricalEventsAndRevenue));
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.gridEventsRevenue = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.svDialogEventsAndRevenue = new System.Windows.Forms.SaveFileDialog();
            this.cboTyp = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.nudYearTo = new System.Windows.Forms.NumericUpDown();
            this.nudYearFrom = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventsRevenue)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYearTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYearFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.CustomFormat = "yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(332, 52);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpTo.Size = new System.Drawing.Size(84, 20);
            this.dtpTo.TabIndex = 1;
            this.dtpTo.Visible = false;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // gridEventsRevenue
            // 
            this.gridEventsRevenue.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gridEventsRevenue.ColumnInfo = "1,0,0,0,0,85,Columns:";
            this.gridEventsRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEventsRevenue.Location = new System.Drawing.Point(3, 16);
            this.gridEventsRevenue.Name = "gridEventsRevenue";
            this.gridEventsRevenue.Rows.Count = 1;
            this.gridEventsRevenue.Rows.DefaultSize = 17;
            this.gridEventsRevenue.Size = new System.Drawing.Size(713, 358);
            this.gridEventsRevenue.StyleInfo = resources.GetString("gridEventsRevenue.StyleInfo");
            this.gridEventsRevenue.TabIndex = 7;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(663, 23);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(65, 51);
            this.btnShow.TabIndex = 9;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.Location = new System.Drawing.Point(591, 23);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(66, 51);
            this.btnExportToExcel.TabIndex = 9;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gridEventsRevenue);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 377);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historical Events and Revenue";
            // 
            // lbFrom
            // 
            this.lbFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFrom.AutoSize = true;
            this.lbFrom.Location = new System.Drawing.Point(401, 48);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(33, 13);
            this.lbFrom.TabIndex = 13;
            this.lbFrom.Text = "From:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "To:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // svDialogEventsAndRevenue
            // 
            this.svDialogEventsAndRevenue.FileOk += new System.ComponentModel.CancelEventHandler(this.svDialogEventsAndRevenue_FileOk);
            // 
            // cboTyp
            // 
            this.cboTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTyp.FormattingEnabled = true;
            this.cboTyp.Location = new System.Drawing.Point(440, 18);
            this.cboTyp.Name = "cboTyp";
            this.cboTyp.Size = new System.Drawing.Size(128, 21);
            this.cboTyp.TabIndex = 11;
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(385, 21);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(49, 13);
            this.lblType.TabIndex = 12;
            this.lblType.Text = "Category";
            // 
            // nudYearTo
            // 
            this.nudYearTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYearTo.Location = new System.Drawing.Point(440, 70);
            this.nudYearTo.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudYearTo.Minimum = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.nudYearTo.Name = "nudYearTo";
            this.nudYearTo.Size = new System.Drawing.Size(79, 20);
            this.nudYearTo.TabIndex = 13;
            this.nudYearTo.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // nudYearFrom
            // 
            this.nudYearFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudYearFrom.Location = new System.Drawing.Point(440, 44);
            this.nudYearFrom.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudYearFrom.Minimum = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.nudYearFrom.Name = "nudYearFrom";
            this.nudYearFrom.Size = new System.Drawing.Size(79, 20);
            this.nudYearFrom.TabIndex = 14;
            this.nudYearFrom.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            this.nudYearFrom.ValueChanged += new System.EventHandler(this.nudYearFrom_ValueChanged);
            // 
            // HistoricalEventsAndRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 490);
            this.Controls.Add(this.nudYearFrom);
            this.Controls.Add(this.nudYearTo);
            this.Controls.Add(this.lbFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cboTyp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnShow);
            this.Name = "HistoricalEventsAndRevenue";
            this.Text = "HistoricalEventsAndRevenue";
            this.Load += new System.EventHandler(this.HistoricalEventsAndRevenue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEventsRevenue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudYearTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYearFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTo;
        private C1.Win.C1FlexGrid.C1FlexGrid gridEventsRevenue;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SaveFileDialog svDialogEventsAndRevenue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTyp;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lbFrom;
        private System.Windows.Forms.NumericUpDown nudYearTo;
        private System.Windows.Forms.NumericUpDown nudYearFrom;
    }
}