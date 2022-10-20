namespace Jinisys.Hotel.Reservation.Presentation
{
    partial class StatisticsAccountsTypeUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsAccountsTypeUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridEventsRevenue = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblYear = new System.Windows.Forms.Label();
            this.cboClientType = new System.Windows.Forms.ComboBox();
            this.cboMarketSegment = new System.Windows.Forms.ComboBox();
            this.lblMarketSegment = new System.Windows.Forms.Label();
            this.lblClientType = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEventsRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridEventsRevenue);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 460);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gridEventsRevenue
            // 
            this.gridEventsRevenue.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gridEventsRevenue.AllowEditing = false;
            this.gridEventsRevenue.ColumnInfo = "3,0,0,0,0,85,Columns:0{Caption:\"No\";}\t1{Width:160;Caption:\"Name of Organization\";" +
                "}\t2{Caption:\"Year/s\";}\t";
            this.gridEventsRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEventsRevenue.Location = new System.Drawing.Point(3, 16);
            this.gridEventsRevenue.Name = "gridEventsRevenue";
            this.gridEventsRevenue.Rows.Count = 1;
            this.gridEventsRevenue.Rows.DefaultSize = 17;
            this.gridEventsRevenue.Size = new System.Drawing.Size(405, 441);
            this.gridEventsRevenue.StyleInfo = resources.GetString("gridEventsRevenue.StyleInfo");
            this.gridEventsRevenue.TabIndex = 8;
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(157, 13);
            this.nudYear.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(83, 20);
            this.nudYear.TabIndex = 1;
            this.nudYear.Value = new decimal(new int[] {
            2014,
            0,
            0,
            0});
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(352, 35);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(68, 49);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(279, 35);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 49);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(116, 15);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 3;
            this.lblYear.Text = "Year";
            // 
            // cboClientType
            // 
            this.cboClientType.FormattingEnabled = true;
            this.cboClientType.Location = new System.Drawing.Point(119, 63);
            this.cboClientType.Name = "cboClientType";
            this.cboClientType.Size = new System.Drawing.Size(121, 21);
            this.cboClientType.TabIndex = 4;
            // 
            // cboMarketSegment
            // 
            this.cboMarketSegment.FormattingEnabled = true;
            this.cboMarketSegment.Location = new System.Drawing.Point(119, 39);
            this.cboMarketSegment.Name = "cboMarketSegment";
            this.cboMarketSegment.Size = new System.Drawing.Size(121, 21);
            this.cboMarketSegment.TabIndex = 5;
            // 
            // lblMarketSegment
            // 
            this.lblMarketSegment.AutoSize = true;
            this.lblMarketSegment.Location = new System.Drawing.Point(28, 42);
            this.lblMarketSegment.Name = "lblMarketSegment";
            this.lblMarketSegment.Size = new System.Drawing.Size(85, 13);
            this.lblMarketSegment.TabIndex = 6;
            this.lblMarketSegment.Text = "Market Segment";
            // 
            // lblClientType
            // 
            this.lblClientType.AutoSize = true;
            this.lblClientType.Location = new System.Drawing.Point(53, 66);
            this.lblClientType.Name = "lblClientType";
            this.lblClientType.Size = new System.Drawing.Size(60, 13);
            this.lblClientType.TabIndex = 7;
            this.lblClientType.Text = "Client Type";
            // 
            // StatisticsAccountsTypeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 558);
            this.Controls.Add(this.lblClientType);
            this.Controls.Add(this.lblMarketSegment);
            this.Controls.Add(this.cboMarketSegment);
            this.Controls.Add(this.cboClientType);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.groupBox1);
            this.Name = "StatisticsAccountsTypeUI";
            this.Text = "StatisticsAccountsTypeUI";
            this.Load += new System.EventHandler(this.StatisticsAccountsTypeUI_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEventsRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid gridEventsRevenue;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cboClientType;
        private System.Windows.Forms.ComboBox cboMarketSegment;
        private System.Windows.Forms.Label lblMarketSegment;
        private System.Windows.Forms.Label lblClientType;

    }
}