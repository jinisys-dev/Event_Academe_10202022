namespace Jinisys.Hotel.Reports.Presentation
{
    partial class WeeklyScheduleUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeeklyScheduleUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpWeeklyTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpWeeklyFrom = new System.Windows.Forms.DateTimePicker();
            this.gridWeeklySchedule = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWeeklySchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpWeeklyTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpWeeklyFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpWeeklyTo
            // 
            this.dtpWeeklyTo.CustomFormat = "MMMM dd, yyyy";
            this.dtpWeeklyTo.Enabled = false;
            this.dtpWeeklyTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWeeklyTo.Location = new System.Drawing.Point(211, 15);
            this.dtpWeeklyTo.Name = "dtpWeeklyTo";
            this.dtpWeeklyTo.Size = new System.Drawing.Size(134, 20);
            this.dtpWeeklyTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // dtpWeeklyFrom
            // 
            this.dtpWeeklyFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtpWeeklyFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWeeklyFrom.Location = new System.Drawing.Point(47, 15);
            this.dtpWeeklyFrom.Name = "dtpWeeklyFrom";
            this.dtpWeeklyFrom.Size = new System.Drawing.Size(136, 20);
            this.dtpWeeklyFrom.TabIndex = 0;
            this.dtpWeeklyFrom.ValueChanged += new System.EventHandler(this.dtpWeeklyFrom_ValueChanged);
            // 
            // gridWeeklySchedule
            // 
            this.gridWeeklySchedule.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gridWeeklySchedule.AllowEditing = false;
            this.gridWeeklySchedule.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
            this.gridWeeklySchedule.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.Both;
            this.gridWeeklySchedule.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gridWeeklySchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWeeklySchedule.ColumnInfo = resources.GetString("gridWeeklySchedule.ColumnInfo");
            this.gridWeeklySchedule.Location = new System.Drawing.Point(12, 68);
            this.gridWeeklySchedule.Name = "gridWeeklySchedule";
            this.gridWeeklySchedule.Rows.Count = 1;
            this.gridWeeklySchedule.Rows.DefaultSize = 17;
            this.gridWeeklySchedule.Size = new System.Drawing.Size(834, 400);
            this.gridWeeklySchedule.TabIndex = 8;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.Location = new System.Drawing.Point(663, 474);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(102, 30);
            this.btnExportToExcel.TabIndex = 9;
            this.btnExportToExcel.Text = "Export to Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(771, 474);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // WeeklyScheduleUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 516);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.gridWeeklySchedule);
            this.Controls.Add(this.groupBox1);
            this.Name = "WeeklyScheduleUI";
            this.Text = "Weekly Schedule";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridWeeklySchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid gridWeeklySchedule;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtpWeeklyFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpWeeklyTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog sfdExport;
    }
}