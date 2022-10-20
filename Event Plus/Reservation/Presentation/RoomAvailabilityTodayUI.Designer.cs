namespace Jinisys.Hotel.Reservation.Presentation
{
    partial class RoomAvailabilityTodayUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomAvailabilityTodayUI));
this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
this.label73 = new System.Windows.Forms.Label();
this.label74 = new System.Windows.Forms.Label();
this.dtpToDate = new System.Windows.Forms.DateTimePicker();
this.label1 = new System.Windows.Forms.Label();
this.grdAvailability = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.chkShowAtStartUp = new System.Windows.Forms.CheckBox();
this.nudDays = new System.Windows.Forms.NumericUpDown();
this.label2 = new System.Windows.Forms.Label();
this.btnRefresh = new System.Windows.Forms.Button();
((System.ComponentModel.ISupportInitialize)(this.grdAvailability)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
this.SuspendLayout();
// 
// dtpFromDate
// 
this.dtpFromDate.Location = new System.Drawing.Point(236, 485);
this.dtpFromDate.Name = "dtpFromDate";
this.dtpFromDate.Size = new System.Drawing.Size(198, 20);
this.dtpFromDate.TabIndex = 8;
this.dtpFromDate.Visible = false;
// 
// label73
// 
this.label73.AutoSize = true;
this.label73.Location = new System.Drawing.Point(193, 488);
this.label73.Name = "label73";
this.label73.Size = new System.Drawing.Size(37, 14);
this.label73.TabIndex = 9;
this.label73.Text = "From :";
this.label73.Visible = false;
// 
// label74
// 
this.label74.AutoSize = true;
this.label74.Location = new System.Drawing.Point(193, 515);
this.label74.Name = "label74";
this.label74.Size = new System.Drawing.Size(25, 14);
this.label74.TabIndex = 11;
this.label74.Text = "To :";
this.label74.Visible = false;
// 
// dtpToDate
// 
this.dtpToDate.Location = new System.Drawing.Point(236, 512);
this.dtpToDate.Name = "dtpToDate";
this.dtpToDate.Size = new System.Drawing.Size(198, 20);
this.dtpToDate.TabIndex = 10;
this.dtpToDate.Visible = false;
// 
// label1
// 
this.label1.AutoSize = true;
this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label1.Location = new System.Drawing.Point(312, 11);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(301, 32);
this.label1.TabIndex = 12;
this.label1.Text = "Available Rooms Today";
// 
// grdAvailability
// 
this.grdAvailability.AllowBigSelection = false;
this.grdAvailability.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdAvailability.AutoGenerateColumns = false;
this.grdAvailability.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
this.grdAvailability.BackColorBkg = System.Drawing.SystemColors.Control;
this.grdAvailability.BackColorFixed = System.Drawing.SystemColors.Desktop;
this.grdAvailability.BackColorSel = System.Drawing.Color.Transparent;
this.grdAvailability.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
this.grdAvailability.Cols = 14;
this.grdAvailability.ColumnInfo = resources.GetString("grdAvailability.ColumnInfo");
this.grdAvailability.ExplorerBar = ((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings)(((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExMove) 
            | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort)));
this.grdAvailability.ExtendLastCol = true;
this.grdAvailability.FixedCols = 0;
this.grdAvailability.ForeColorFixed = System.Drawing.SystemColors.ActiveCaptionText;
this.grdAvailability.ForeColorSel = System.Drawing.Color.Black;
this.grdAvailability.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdAvailability.Location = new System.Drawing.Point(33, 116);
this.grdAvailability.Name = "grdAvailability";
this.grdAvailability.NodeClosedPicture = null;
this.grdAvailability.NodeOpenPicture = null;
this.grdAvailability.OutlineCol = -1;
this.grdAvailability.RowHeightMin = 20;
this.grdAvailability.Rows = 9;
this.grdAvailability.Size = new System.Drawing.Size(799, 543);
this.grdAvailability.StyleInfo = resources.GetString("grdAvailability.StyleInfo");
this.grdAvailability.TabIndex = 14;
this.grdAvailability.TreeColor = System.Drawing.Color.DarkGray;
// 
// chkShowAtStartUp
// 
this.chkShowAtStartUp.AutoSize = true;
this.chkShowAtStartUp.Location = new System.Drawing.Point(721, 84);
this.chkShowAtStartUp.Name = "chkShowAtStartUp";
this.chkShowAtStartUp.Size = new System.Drawing.Size(104, 18);
this.chkShowAtStartUp.TabIndex = 15;
this.chkShowAtStartUp.Text = "Show at startup";
this.chkShowAtStartUp.UseVisualStyleBackColor = true;
// 
// nudDays
// 
this.nudDays.Location = new System.Drawing.Point(108, 83);
this.nudDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
this.nudDays.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
this.nudDays.Name = "nudDays";
this.nudDays.Size = new System.Drawing.Size(58, 20);
this.nudDays.TabIndex = 16;
this.nudDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.nudDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
this.nudDays.ValueChanged += new System.EventHandler(this.nudDays_ValueChanged);
// 
// label2
// 
this.label2.AutoSize = true;
this.label2.Location = new System.Drawing.Point(34, 86);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(70, 14);
this.label2.TabIndex = 17;
this.label2.Text = "No. of Days :";
// 
// btnRefresh
// 
this.btnRefresh.Location = new System.Drawing.Point(174, 77);
this.btnRefresh.Name = "btnRefresh";
this.btnRefresh.Size = new System.Drawing.Size(66, 31);
this.btnRefresh.TabIndex = 18;
this.btnRefresh.Text = "Re&fresh";
this.btnRefresh.UseVisualStyleBackColor = true;
this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
// 
// RoomAvailabilityTodayUI
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.BackColor = System.Drawing.SystemColors.Control;
this.ClientSize = new System.Drawing.Size(1109, 671);
this.Controls.Add(this.btnRefresh);
this.Controls.Add(this.label2);
this.Controls.Add(this.nudDays);
this.Controls.Add(this.chkShowAtStartUp);
this.Controls.Add(this.grdAvailability);
this.Controls.Add(this.label1);
this.Controls.Add(this.label74);
this.Controls.Add(this.dtpToDate);
this.Controls.Add(this.label73);
this.Controls.Add(this.dtpFromDate);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
this.Name = "RoomAvailabilityTodayUI";
this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Today\'s Available Rooms";
this.Activated += new System.EventHandler(this.RoomAvailabilityUI_Activated);
this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomAvailabilityUI_FormClosing);
this.Load += new System.EventHandler(this.RoomAvailabilityUI_Load);
((System.ComponentModel.ISupportInitialize)(this.grdAvailability)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
this.ResumeLayout(false);
this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdAvailability;
        private System.Windows.Forms.CheckBox chkShowAtStartUp;
		private System.Windows.Forms.NumericUpDown nudDays;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnRefresh;
    }
}