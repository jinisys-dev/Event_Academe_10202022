namespace Jinisys.Hotel.Reservation.Presentation
{
    partial class RateType_Inquiry
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

        #region Windows Form Designer generated lCode

        /// <summary>
        /// Required _method for Designer support - do not modify
        /// the contents of this _method with the lCode editor.
        /// </summary>
        private void InitializeComponent()
        {
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateType_Inquiry));
this.groupBox1 = new System.Windows.Forms.GroupBox();
this.btnView = new System.Windows.Forms.Button();
this.btnPrint = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
this.label2 = new System.Windows.Forms.Label();
this.label1 = new System.Windows.Forms.Label();
this.groupBox2 = new System.Windows.Forms.GroupBox();
this.gridRateTypes = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.groupBox3 = new System.Windows.Forms.GroupBox();
this.gridList = new C1.Win.C1FlexGrid.C1FlexGrid();
this.label4 = new System.Windows.Forms.Label();
this.groupBox1.SuspendLayout();
this.groupBox2.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.gridRateTypes)).BeginInit();
this.groupBox3.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
this.SuspendLayout();
// 
// groupBox1
// 
this.groupBox1.Controls.Add(this.btnView);
this.groupBox1.Controls.Add(this.btnPrint);
this.groupBox1.Controls.Add(this.btnClose);
this.groupBox1.Controls.Add(this.dtpEndDate);
this.groupBox1.Controls.Add(this.dtpStartDate);
this.groupBox1.Controls.Add(this.label2);
this.groupBox1.Controls.Add(this.label1);
this.groupBox1.Location = new System.Drawing.Point(508, 52);
this.groupBox1.Name = "groupBox1";
this.groupBox1.Size = new System.Drawing.Size(341, 216);
this.groupBox1.TabIndex = 2;
this.groupBox1.TabStop = false;
this.groupBox1.Text = "Preference";
// 
// btnView
// 
this.btnView.Location = new System.Drawing.Point(94, 172);
this.btnView.Name = "btnView";
this.btnView.Size = new System.Drawing.Size(66, 31);
this.btnView.TabIndex = 5;
this.btnView.Text = "&View";
this.btnView.UseVisualStyleBackColor = true;
this.btnView.Click += new System.EventHandler(this.btnView_Click);
// 
// btnPrint
// 
this.btnPrint.Location = new System.Drawing.Point(166, 172);
this.btnPrint.Name = "btnPrint";
this.btnPrint.Size = new System.Drawing.Size(66, 31);
this.btnPrint.TabIndex = 6;
this.btnPrint.Text = "&Print";
this.btnPrint.UseVisualStyleBackColor = true;
this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
// 
// btnClose
// 
this.btnClose.Location = new System.Drawing.Point(238, 172);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 7;
this.btnClose.Text = "Cl&ose";
this.btnClose.UseVisualStyleBackColor = true;
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// dtpEndDate
// 
this.dtpEndDate.Location = new System.Drawing.Point(55, 108);
this.dtpEndDate.Name = "dtpEndDate";
this.dtpEndDate.Size = new System.Drawing.Size(249, 20);
this.dtpEndDate.TabIndex = 4;
// 
// dtpStartDate
// 
this.dtpStartDate.Location = new System.Drawing.Point(55, 54);
this.dtpStartDate.Name = "dtpStartDate";
this.dtpStartDate.Size = new System.Drawing.Size(249, 20);
this.dtpStartDate.TabIndex = 3;
// 
// label2
// 
this.label2.AutoSize = true;
this.label2.Location = new System.Drawing.Point(52, 89);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(55, 14);
this.label2.TabIndex = 1;
this.label2.Text = "End date :";
// 
// label1
// 
this.label1.AutoSize = true;
this.label1.Location = new System.Drawing.Point(52, 35);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(60, 14);
this.label1.TabIndex = 0;
this.label1.Text = "Start date :";
// 
// groupBox2
// 
this.groupBox2.Controls.Add(this.gridRateTypes);
this.groupBox2.Location = new System.Drawing.Point(27, 52);
this.groupBox2.Name = "groupBox2";
this.groupBox2.Size = new System.Drawing.Size(475, 216);
this.groupBox2.TabIndex = 0;
this.groupBox2.TabStop = false;
this.groupBox2.Text = "Rate Types";
// 
// gridRateTypes
// 
this.gridRateTypes.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.gridRateTypes.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.gridRateTypes.Cols = 4;
this.gridRateTypes.ColumnInfo = resources.GetString("gridRateTypes.ColumnInfo");
this.gridRateTypes.ExtendLastCol = true;
this.gridRateTypes.FixedCols = 0;
this.gridRateTypes.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.gridRateTypes.Location = new System.Drawing.Point(17, 19);
this.gridRateTypes.Name = "gridRateTypes";
this.gridRateTypes.NodeClosedPicture = null;
this.gridRateTypes.NodeOpenPicture = null;
this.gridRateTypes.OutlineCol = -1;
this.gridRateTypes.Size = new System.Drawing.Size(445, 189);
this.gridRateTypes.StyleInfo = resources.GetString("gridRateTypes.StyleInfo");
this.gridRateTypes.TabIndex = 2;
this.gridRateTypes.TreeColor = System.Drawing.Color.DarkGray;
this.gridRateTypes.Click += new System.EventHandler(this.gridRateTypes_Click);
// 
// groupBox3
// 
this.groupBox3.Controls.Add(this.gridList);
this.groupBox3.Location = new System.Drawing.Point(27, 268);
this.groupBox3.Name = "groupBox3";
this.groupBox3.Size = new System.Drawing.Size(822, 395);
this.groupBox3.TabIndex = 8;
this.groupBox3.TabStop = false;
// 
// gridList
// 
this.gridList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
this.gridList.AllowEditing = false;
this.gridList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
this.gridList.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.gridList.ColumnInfo = resources.GetString("gridList.ColumnInfo");
this.gridList.Location = new System.Drawing.Point(8, 16);
this.gridList.Name = "gridList";
this.gridList.Rows.DefaultSize = 17;
this.gridList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
this.gridList.Size = new System.Drawing.Size(806, 370);
this.gridList.StyleInfo = resources.GetString("gridList.StyleInfo");
this.gridList.TabIndex = 11;
this.gridList.DoubleClick += new System.EventHandler(this.gridList_DoubleClick);
// 
// label4
// 
this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
this.label4.Location = new System.Drawing.Point(21, 15);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(337, 34);
this.label4.TabIndex = 9;
this.label4.Text = "Guests List by Rate Code";
// 
// RateType_Inquiry
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(860, 669);
this.Controls.Add(this.label4);
this.Controls.Add(this.groupBox3);
this.Controls.Add(this.groupBox2);
this.Controls.Add(this.groupBox1);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Name = "RateType_Inquiry";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Guest By Rate Code";
this.Load += new System.EventHandler(this.RateType_Inquiry_Load);
this.groupBox1.ResumeLayout(false);
this.groupBox1.PerformLayout();
this.groupBox2.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.gridRateTypes)).EndInit();
this.groupBox3.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private C1.Win.C1FlexGrid.C1FlexGrid gridList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnPrint;
        private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic gridRateTypes;
        private System.Windows.Forms.Label label4;
    }
}