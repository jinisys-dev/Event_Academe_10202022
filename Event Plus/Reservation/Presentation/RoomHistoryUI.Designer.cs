namespace Jinisys.Hotel.Reservation.Presentation
{
    partial class RoomHistoryUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomHistoryUI));
            this.grdRoomList = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grdRoomHistory = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabRoomHistory = new System.Windows.Forms.TabControl();
            this.tabGuest = new System.Windows.Forms.TabPage();
            this.tabHousekeeper = new System.Windows.Forms.TabPage();
            this.grdHousekeepers = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabEngineeringJobs = new System.Windows.Forms.TabPage();
            this.grdEngineeringJobs = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFolio = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoomList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoomHistory)).BeginInit();
            this.tabRoomHistory.SuspendLayout();
            this.tabGuest.SuspendLayout();
            this.tabHousekeeper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHousekeepers)).BeginInit();
            this.tabEngineeringJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEngineeringJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRoomList
            // 
            this.grdRoomList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRoomList.AutoGenerateColumns = false;
            this.grdRoomList.AutoResize = false;
            this.grdRoomList.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdRoomList.ColumnInfo = "1,0,0,0,0,85,Columns:0{Width:91;Caption:\"Room No.\";AllowDragging:False;AllowEditi" +
                "ng:False;DataType:System.String;TextAlign:LeftCenter;TextAlignFixed:LeftCenter;}" +
                "\t";
            this.grdRoomList.ExtendLastCol = true;
            this.grdRoomList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdRoomList.ForeColor = System.Drawing.Color.Black;
            this.grdRoomList.Location = new System.Drawing.Point(16, 58);
            this.grdRoomList.Name = "grdRoomList";
            this.grdRoomList.Rows.Count = 9;
            this.grdRoomList.Rows.DefaultSize = 17;
            this.grdRoomList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdRoomList.Size = new System.Drawing.Size(121, 461);
            this.grdRoomList.StyleInfo = resources.GetString("grdRoomList.StyleInfo");
            this.grdRoomList.TabIndex = 185;
            this.grdRoomList.RowColChange += new System.EventHandler(this.grdRoomList_RowColChange);
            // 
            // grdRoomHistory
            // 
            this.grdRoomHistory.AllowEditing = false;
            this.grdRoomHistory.ColumnInfo = resources.GetString("grdRoomHistory.ColumnInfo");
            this.grdRoomHistory.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdRoomHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRoomHistory.ExtendLastCol = true;
            this.grdRoomHistory.Location = new System.Drawing.Point(3, 3);
            this.grdRoomHistory.Name = "grdRoomHistory";
            this.grdRoomHistory.Rows.DefaultSize = 17;
            this.grdRoomHistory.Size = new System.Drawing.Size(532, 429);
            this.grdRoomHistory.StyleInfo = resources.GetString("grdRoomHistory.StyleInfo");
            this.grdRoomHistory.TabIndex = 0;
            this.grdRoomHistory.DoubleClick += new System.EventHandler(this.grdRoomHistory_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(624, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 189;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabRoomHistory
            // 
            this.tabRoomHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRoomHistory.Controls.Add(this.tabGuest);
            this.tabRoomHistory.Controls.Add(this.tabHousekeeper);
            this.tabRoomHistory.Controls.Add(this.tabEngineeringJobs);
            this.tabRoomHistory.Location = new System.Drawing.Point(143, 58);
            this.tabRoomHistory.Name = "tabRoomHistory";
            this.tabRoomHistory.SelectedIndex = 0;
            this.tabRoomHistory.Size = new System.Drawing.Size(546, 462);
            this.tabRoomHistory.TabIndex = 190;
            // 
            // tabGuest
            // 
            this.tabGuest.Controls.Add(this.grdRoomHistory);
            this.tabGuest.Location = new System.Drawing.Point(4, 23);
            this.tabGuest.Name = "tabGuest";
            this.tabGuest.Padding = new System.Windows.Forms.Padding(3);
            this.tabGuest.Size = new System.Drawing.Size(538, 435);
            this.tabGuest.TabIndex = 0;
            this.tabGuest.Text = "Event";
            this.tabGuest.UseVisualStyleBackColor = true;
            // 
            // tabHousekeeper
            // 
            this.tabHousekeeper.Controls.Add(this.grdHousekeepers);
            this.tabHousekeeper.Location = new System.Drawing.Point(4, 23);
            this.tabHousekeeper.Name = "tabHousekeeper";
            this.tabHousekeeper.Padding = new System.Windows.Forms.Padding(3);
            this.tabHousekeeper.Size = new System.Drawing.Size(538, 435);
            this.tabHousekeeper.TabIndex = 1;
            this.tabHousekeeper.Text = "Housekeepers";
            this.tabHousekeeper.UseVisualStyleBackColor = true;
            // 
            // grdHousekeepers
            // 
            this.grdHousekeepers.ColumnInfo = resources.GetString("grdHousekeepers.ColumnInfo");
            this.grdHousekeepers.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdHousekeepers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHousekeepers.ExtendLastCol = true;
            this.grdHousekeepers.Location = new System.Drawing.Point(3, 3);
            this.grdHousekeepers.Name = "grdHousekeepers";
            this.grdHousekeepers.Rows.DefaultSize = 17;
            this.grdHousekeepers.Size = new System.Drawing.Size(532, 429);
            this.grdHousekeepers.StyleInfo = resources.GetString("grdHousekeepers.StyleInfo");
            this.grdHousekeepers.TabIndex = 1;
            // 
            // tabEngineeringJobs
            // 
            this.tabEngineeringJobs.Controls.Add(this.grdEngineeringJobs);
            this.tabEngineeringJobs.Location = new System.Drawing.Point(4, 23);
            this.tabEngineeringJobs.Name = "tabEngineeringJobs";
            this.tabEngineeringJobs.Padding = new System.Windows.Forms.Padding(3);
            this.tabEngineeringJobs.Size = new System.Drawing.Size(538, 435);
            this.tabEngineeringJobs.TabIndex = 2;
            this.tabEngineeringJobs.Text = "Engineering Jobs";
            this.tabEngineeringJobs.UseVisualStyleBackColor = true;
            // 
            // grdEngineeringJobs
            // 
            this.grdEngineeringJobs.ColumnInfo = resources.GetString("grdEngineeringJobs.ColumnInfo");
            this.grdEngineeringJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEngineeringJobs.Location = new System.Drawing.Point(3, 3);
            this.grdEngineeringJobs.Name = "grdEngineeringJobs";
            this.grdEngineeringJobs.Rows.Count = 1;
            this.grdEngineeringJobs.Rows.DefaultSize = 17;
            this.grdEngineeringJobs.Size = new System.Drawing.Size(532, 429);
            this.grdEngineeringJobs.StyleInfo = resources.GetString("grdEngineeringJobs.StyleInfo");
            this.grdEngineeringJobs.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.Location = new System.Drawing.Point(552, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(66, 31);
            this.btnPrint.TabIndex = 191;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 192;
            this.label1.Text = "Room History";
            // 
            // btnFolio
            // 
            this.btnFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolio.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFolio.Location = new System.Drawing.Point(552, 21);
            this.btnFolio.Name = "btnFolio";
            this.btnFolio.Size = new System.Drawing.Size(66, 31);
            this.btnFolio.TabIndex = 193;
            this.btnFolio.Text = "&View";
            this.btnFolio.UseVisualStyleBackColor = true;
            this.btnFolio.Click += new System.EventHandler(this.btnFolio_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(428, 6);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 194;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(428, 32);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 195;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 196;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 14);
            this.label3.TabIndex = 197;
            this.label3.Text = "To";
            // 
            // RoomHistoryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(702, 535);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.btnFolio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.tabRoomHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdRoomList);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RoomHistoryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room History";
            this.Load += new System.EventHandler(this.RoomHistoryUI_Load);
            this.Activated += new System.EventHandler(this.RoomHistoryUI_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.grdRoomList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoomHistory)).EndInit();
            this.tabRoomHistory.ResumeLayout(false);
            this.tabGuest.ResumeLayout(false);
            this.tabHousekeeper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHousekeepers)).EndInit();
            this.tabEngineeringJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEngineeringJobs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal C1.Win.C1FlexGrid.C1FlexGrid grdRoomList;
        private System.Windows.Forms.Button btnClose;
        private C1.Win.C1FlexGrid.C1FlexGrid grdRoomHistory;
        private System.Windows.Forms.TabControl tabRoomHistory;
        private System.Windows.Forms.TabPage tabGuest;
        private System.Windows.Forms.TabPage tabHousekeeper;
        private C1.Win.C1FlexGrid.C1FlexGrid grdHousekeepers;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFolio;
        private System.Windows.Forms.TabPage tabEngineeringJobs;
        private C1.Win.C1FlexGrid.C1FlexGrid grdEngineeringJobs;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}