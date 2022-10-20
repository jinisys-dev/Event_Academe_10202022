namespace Jinisys.Hotel.Reports.Presentation
{
    partial class SalesAndMarketingRevenueReportUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesAndMarketingRevenueReportUI));
            this.pnlReport = new System.Windows.Forms.Panel();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.grdHotelRevenue = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnCustomize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.pnlCustomizeReport = new System.Windows.Forms.Panel();
            this.lvwCustomizableFields = new System.Windows.Forms.ListView();
            this.colColumnName = new System.Windows.Forms.ColumnHeader();
            this.colColumnID = new System.Windows.Forms.ColumnHeader();
            this.btnClosePanel = new System.Windows.Forms.Button();
            this.btnApplyCustomization = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.pnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHotelRevenue)).BeginInit();
            this.pnlCustomizeReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlReport
            // 
            this.pnlReport.BackColor = System.Drawing.Color.White;
            this.pnlReport.Controls.Add(this.btnExportToExcel);
            this.pnlReport.Controls.Add(this.btnClose);
            this.pnlReport.Controls.Add(this.dtpStartDate);
            this.pnlReport.Controls.Add(this.label4);
            this.pnlReport.Controls.Add(this.dtpEndDate);
            this.pnlReport.Controls.Add(this.label3);
            this.pnlReport.Controls.Add(this.grdHotelRevenue);
            this.pnlReport.Controls.Add(this.btnCustomize);
            this.pnlReport.Controls.Add(this.label1);
            this.pnlReport.Controls.Add(this.btnShow);
            this.pnlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReport.Location = new System.Drawing.Point(0, 0);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(860, 545);
            this.pnlReport.TabIndex = 6;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExportToExcel.Location = new System.Drawing.Point(668, 33);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(105, 31);
            this.btnExportToExcel.TabIndex = 10;
            this.btnExportToExcel.Text = "&Export to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Location = new System.Drawing.Point(779, 33);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(172, 44);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(102, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(149, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "To ";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(47, 44);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(94, 20);
            this.dtpEndDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "From  ";
            // 
            // grdHotelRevenue
            // 
            this.grdHotelRevenue.AllowEditing = false;
            this.grdHotelRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdHotelRevenue.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.grdHotelRevenue.ColumnInfo = resources.GetString("grdHotelRevenue.ColumnInfo");
            this.grdHotelRevenue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdHotelRevenue.Location = new System.Drawing.Point(10, 89);
            this.grdHotelRevenue.Name = "grdHotelRevenue";
            this.grdHotelRevenue.Rows.Count = 1;
            this.grdHotelRevenue.Rows.DefaultSize = 18;
            this.grdHotelRevenue.Size = new System.Drawing.Size(841, 445);
            this.grdHotelRevenue.StyleInfo = resources.GetString("grdHotelRevenue.StyleInfo");
            this.grdHotelRevenue.TabIndex = 0;
            // 
            // btnCustomize
            // 
            this.btnCustomize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomize.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCustomize.Location = new System.Drawing.Point(557, 33);
            this.btnCustomize.Name = "btnCustomize";
            this.btnCustomize.Size = new System.Drawing.Size(105, 31);
            this.btnCustomize.TabIndex = 6;
            this.btnCustomize.Text = "&Customize Report";
            this.btnCustomize.UseVisualStyleBackColor = false;
            this.btnCustomize.Click += new System.EventHandler(this.btnCustomize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sales and Marketing - Revenue Report";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShow.Location = new System.Drawing.Point(448, 33);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(103, 31);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // pnlCustomizeReport
            // 
            this.pnlCustomizeReport.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlCustomizeReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomizeReport.Controls.Add(this.lvwCustomizableFields);
            this.pnlCustomizeReport.Controls.Add(this.btnClosePanel);
            this.pnlCustomizeReport.Controls.Add(this.btnApplyCustomization);
            this.pnlCustomizeReport.Controls.Add(this.label2);
            this.pnlCustomizeReport.Location = new System.Drawing.Point(202, 31);
            this.pnlCustomizeReport.Name = "pnlCustomizeReport";
            this.pnlCustomizeReport.Size = new System.Drawing.Size(292, 335);
            this.pnlCustomizeReport.TabIndex = 11;
            this.pnlCustomizeReport.Visible = false;
            this.pnlCustomizeReport.VisibleChanged += new System.EventHandler(this.pnlCustomizeReport_VisibleChanged);
            // 
            // lvwCustomizableFields
            // 
            this.lvwCustomizableFields.CheckBoxes = true;
            this.lvwCustomizableFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colColumnName,
            this.colColumnID});
            this.lvwCustomizableFields.FullRowSelect = true;
            this.lvwCustomizableFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwCustomizableFields.Location = new System.Drawing.Point(18, 36);
            this.lvwCustomizableFields.Name = "lvwCustomizableFields";
            this.lvwCustomizableFields.Size = new System.Drawing.Size(250, 241);
            this.lvwCustomizableFields.TabIndex = 12;
            this.lvwCustomizableFields.UseCompatibleStateImageBehavior = false;
            this.lvwCustomizableFields.View = System.Windows.Forms.View.Details;
            // 
            // colColumnName
            // 
            this.colColumnName.Width = 230;
            // 
            // colColumnID
            // 
            this.colColumnID.Width = 0;
            // 
            // btnClosePanel
            // 
            this.btnClosePanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClosePanel.Location = new System.Drawing.Point(208, 287);
            this.btnClosePanel.Name = "btnClosePanel";
            this.btnClosePanel.Size = new System.Drawing.Size(60, 30);
            this.btnClosePanel.TabIndex = 11;
            this.btnClosePanel.Text = "&Cancel";
            this.btnClosePanel.UseVisualStyleBackColor = false;
            this.btnClosePanel.Click += new System.EventHandler(this.btnClosePanel_Click);
            // 
            // btnApplyCustomization
            // 
            this.btnApplyCustomization.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnApplyCustomization.Location = new System.Drawing.Point(19, 287);
            this.btnApplyCustomization.Name = "btnApplyCustomization";
            this.btnApplyCustomization.Size = new System.Drawing.Size(60, 30);
            this.btnApplyCustomization.TabIndex = 10;
            this.btnApplyCustomization.Text = "&Ok";
            this.btnApplyCustomization.UseVisualStyleBackColor = false;
            this.btnApplyCustomization.Click += new System.EventHandler(this.btnApplyCustomization_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Please select fields to display :";
            // 
            // sfdExport
            // 
            this.sfdExport.DefaultExt = "*.xls";
            this.sfdExport.FileName = "Revenue Report";
            this.sfdExport.Title = "Select location";
            // 
            // SalesAndMarketingRevenueReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 545);
            this.Controls.Add(this.pnlCustomizeReport);
            this.Controls.Add(this.pnlReport);
            this.Name = "SalesAndMarketingRevenueReportUI";
            this.Text = "Sales and Marketing Revenue Report";
            this.Activated += new System.EventHandler(this.SalesAndMarketingRevenueUI_Activated);
            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHotelRevenue)).EndInit();
            this.pnlCustomizeReport.ResumeLayout(false);
            this.pnlCustomizeReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private C1.Win.C1FlexGrid.C1FlexGrid grdHotelRevenue;
        private System.Windows.Forms.Button btnCustomize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel pnlCustomizeReport;
        private System.Windows.Forms.ListView lvwCustomizableFields;
        private System.Windows.Forms.ColumnHeader colColumnName;
        private System.Windows.Forms.ColumnHeader colColumnID;
        private System.Windows.Forms.Button btnClosePanel;
        private System.Windows.Forms.Button btnApplyCustomization;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog sfdExport;
    }
}