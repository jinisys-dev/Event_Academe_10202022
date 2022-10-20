using System.Drawing;
using System.Globalization;
using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.NightAudit.BusinessLayer;

using System.Reflection;
using System.IO;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public class GroupReservationListUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
    {

        #region " Windows Form Designer generated lCode "

        //Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.Container components = null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the lCode editor.
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnChange;
        public System.Windows.Forms.Button btnInsert;
		internal System.Windows.Forms.Button bntCheckOut;
        internal Button btnClose;
        internal Button btnCheckIn;
        private C1.Win.C1FlexGrid.C1FlexGrid grdList;
		public Button btnExportToExcel;
		private Label label2;
		private GroupBox groupBox1;
		internal Label Label1;
		internal Label label11;
		internal Label label15;
		internal Label lblTotalReservation;
		internal Label lblTotalWaitList;
        private PictureBox pctBell;
        internal System.Windows.Forms.TextBox txtSearch;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupReservationListUI));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.grdList = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bntCheckOut = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTotalWaitList = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalReservation = new System.Windows.Forms.Label();
            this.pctBell = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBell)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(145, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(368, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.Location = new System.Drawing.Point(600, 17);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(114, 31);
            this.btnChange.TabIndex = 21;
            this.btnChange.Text = "&View Reservation";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInsert.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(717, 17);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(114, 31);
            this.btnInsert.TabIndex = 20;
            this.btnInsert.Text = "&New Reservation";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // grdList
            // 
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdList.AutoClipboard = true;
            this.grdList.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdList.ColumnInfo = resources.GetString("grdList.ColumnInfo");
            this.grdList.ExtendLastCol = true;
            this.grdList.Location = new System.Drawing.Point(10, 97);
            this.grdList.Name = "grdList";
            this.grdList.Rows.Count = 1;
            this.grdList.Rows.DefaultSize = 17;
            this.grdList.Rows.MaxSize = 250;
            this.grdList.Rows.MinSize = 29;
            this.grdList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdList.Size = new System.Drawing.Size(828, 503);
            this.grdList.StyleInfo = resources.GetString("grdList.StyleInfo");
            this.grdList.TabIndex = 28;
            this.grdList.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdList_BeforeEdit);
            this.grdList.DoubleClick += new System.EventHandler(this.lvwList_DoubleClick);
            this.grdList.RowColChange += new System.EventHandler(this.grdList_RowColChange);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(481, 609);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 26);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "&Cancel Reservation";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bntCheckOut
            // 
            this.bntCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntCheckOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntCheckOut.Enabled = false;
            this.bntCheckOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCheckOut.Location = new System.Drawing.Point(693, 609);
            this.bntCheckOut.Name = "bntCheckOut";
            this.bntCheckOut.Size = new System.Drawing.Size(74, 26);
            this.bntCheckOut.TabIndex = 27;
            this.bntCheckOut.Text = "Check O&ut";
            this.bntCheckOut.Click += new System.EventHandler(this.bntCheckOut_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(773, 609);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 26);
            this.btnClose.TabIndex = 191;
            this.btnClose.Text = "C&lose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckIn.Enabled = false;
            this.btnCheckIn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.Location = new System.Drawing.Point(613, 609);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(74, 26);
            this.btnCheckIn.TabIndex = 192;
            this.btnCheckIn.Text = "Check &In";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExportToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExportToExcel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExcel.Location = new System.Drawing.Point(12, 609);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(121, 26);
            this.btnExportToExcel.TabIndex = 193;
            this.btnExportToExcel.Text = "&Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 27);
            this.label2.TabIndex = 195;
            this.label2.Text = "Group Reservations";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(10, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 7);
            this.groupBox1.TabIndex = 196;
            this.groupBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 64);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(130, 14);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "Input Search String here :";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(788, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 14);
            this.label15.TabIndex = 201;
            this.label15.Text = "Wait List";
            // 
            // lblTotalWaitList
            // 
            this.lblTotalWaitList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalWaitList.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblTotalWaitList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalWaitList.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTotalWaitList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalWaitList.ForeColor = System.Drawing.Color.Red;
            this.lblTotalWaitList.Location = new System.Drawing.Point(747, 64);
            this.lblTotalWaitList.Name = "lblTotalWaitList";
            this.lblTotalWaitList.Size = new System.Drawing.Size(35, 20);
            this.lblTotalWaitList.TabIndex = 200;
            this.lblTotalWaitList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(665, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 14);
            this.label11.TabIndex = 199;
            this.label11.Text = "Reservations";
            // 
            // lblTotalReservation
            // 
            this.lblTotalReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalReservation.BackColor = System.Drawing.Color.White;
            this.lblTotalReservation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalReservation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReservation.ForeColor = System.Drawing.Color.Red;
            this.lblTotalReservation.Location = new System.Drawing.Point(624, 64);
            this.lblTotalReservation.Name = "lblTotalReservation";
            this.lblTotalReservation.Size = new System.Drawing.Size(35, 20);
            this.lblTotalReservation.TabIndex = 198;
            this.lblTotalReservation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pctBell
            // 
            this.pctBell.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.Clipboard_Information;
            this.pctBell.Location = new System.Drawing.Point(415, 314);
            this.pctBell.Name = "pctBell";
            this.pctBell.Size = new System.Drawing.Size(18, 18);
            this.pctBell.TabIndex = 202;
            this.pctBell.TabStop = false;
            // 
            // GroupReservationListUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(848, 647);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalReservation);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblTotalWaitList);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.grdList);
            this.Controls.Add(this.bntCheckOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pctBell);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GroupReservationListUI";
            this.Text = "Group Reservations";
            this.Activated += new System.EventHandler(this.GroupReservationListUI_Activated);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GroupReservationListUI_MouseUp);
            this.Load += new System.EventHandler(this.GroupReservationListUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBell)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region " VARIABLES "

        private ListViewItemComparer ListViewItemComparer = new ListViewItemComparer();
        private FormToObjectInstanceBinder oFormtoObjectBinder = new FormToObjectInstanceBinder();
        private ReservationsFacade oReservationsFacade = new ReservationsFacade();
        private string folioID;

        private Label lblFolioID;
        private Label lblGroupName;

        private string grpName;
        private static FormWindowState mState;


        #endregion

        #region " CONSTRUCTORS "
        
        public GroupReservationListUI()
        {
            InitializeComponent();

            GetReservationList();
            //GetListReservationList("status <>\'CLOSED\' and status<>\'CANCELLED\' and status<>\'NO SHOW\' and (foliotype=\'GROUP\' or foliotype='CORPORATE')");
        }

        //used to look up from check out
        public GroupReservationListUI(Label lblFID, Label lblGrpN)
        {
            InitializeComponent();

            
            //GetListReservationList("status <>\'CLOSED\' and status<>\'CANCELLED\' and status<>\'NO SHOW\' and (foliotype=\'GROUP\' or foliotype='CORPORATE')");
            lblFolioID = lblFID;
            lblGroupName = lblGrpN;

			GetReservationList();
        }
        
        #endregion
           
        #region " METHODS " 

        private void unselectListviewItems()
        {
            foreach(C1.Win.C1FlexGrid.Row _row in grdList.Rows)
            {
                if (_row.Index != 0)
                {
                    grdList.Rows[_row.Index].Selected = false;
                }
            }
        }

        public void btnInsert_Click()
        {
            GroupReservationUI.ACCOUNT_TYPE = AccountType.Corporate;
            //GroupReservationUI.Flag = "New";
            GroupReservationUI groupReservationsUI = new GroupReservationUI(grdList);
            groupReservationsUI.MdiParent = this.MdiParent;
            groupReservationsUI.Show();
            this.Close();
        }


        private void GetReservationList()
        {
            int _totalReservations = 0;
            int _totalWaitList = 0;
            int curProgress = 0;

            ScheduleFacade _oScheduleFacade = new ScheduleFacade();
            ReservationsFacade _oReservationFacade = new ReservationsFacade();

            DataTable folioTable = _oReservationFacade.getGroupReservationList();

            this.grdList.Rows.Count = 1;
            int totalRows = folioTable.Rows.Count;

            this.grdList.Rows.Count = totalRows + 1;

            ProgressForm progress = new ProgressForm();
            if (folioTable.Rows.Count > 0)
            {
                int count = folioTable.Rows.Count + 1;
                progress = new ProgressForm(count, "Loading Groups......");
                progress.Height = 27;
                progress.Show();
            }

            int i = 1;
            for (int r = 0; r < totalRows; r++)
            {
                string _companyName = folioTable.Rows[r]["companyName"].ToString();
                string _groupName = folioTable.Rows[r]["groupname"].ToString();
                string _folioId = folioTable.Rows[r]["folioid"].ToString();
                string _fromDate = folioTable.Rows[r]["fromdate"].ToString();
                string _toDate = folioTable.Rows[r]["todate"].ToString();
                string _charges = folioTable.Rows[r]["charges"].ToString();
                string _balance = folioTable.Rows[r]["balance"].ToString();
                string _folioRemarks = folioTable.Rows[r]["remarks"].ToString();
                //string _roomsBlocked = ""; //folioTable.Rows[r]["roomsBlocked"].ToString();

                int _requiredRooms = 0;
                int.TryParse(folioTable.Rows[r]["RequiredRooms"].ToString(), out _requiredRooms);

                int _blockedRooms = 0;
                int.TryParse(folioTable.Rows[r]["BlockedRooms"].ToString(), out _blockedRooms);

                string _status = folioTable.Rows[r]["status"].ToString();

                string _rooms = _oScheduleFacade.GetRoomFromSchedules(_folioId);
                if (_rooms.Trim().Length <= 1)
                    _rooms = "";

                //-------------------------[ column 0 - Rooms ]-----------------------------------'
                this.grdList.SetData(i, 0, _rooms);
                if (_folioRemarks != "")
                {
                    this.grdList.SetCellImage(i, 0, pctBell.Image);
                }

                //-------------------------[ column 1 - Company Name ]-----------------------------------'
                this.grdList.SetData(i, 1, _companyName);

                //-------------------------[ column 2 - GroupName ]-----------------------------------'
                this.grdList.SetData(i, 2, _groupName);

                //-------------------------[ column 3 - Folio No ]-----------------------------------'
                this.grdList.SetData(i, 3, _folioId);

                //-------------------------[ column 4 - From Date ]-----------------------------------'
                this.grdList.SetData(i, 4, _fromDate);

                //-------------------------[ column 5 - To Date ]-----------------------------------'
                this.grdList.SetData(i, 5, _toDate);

                //-------------------------[ column 6 - Total Charges ]-----------------------------------'
                this.grdList.SetData(i, 6, _charges);

                //-------------------------[ column 7 - Balance ]-----------------------------------'
                this.grdList.SetData(i, 7, _balance);

                //-------------------------[ column 8 - # assigned ]-----------------------------------'
                this.grdList.SetData(i, 8, _blockedRooms); //>> to be clarified

                //-------------------------[ column 9 - Required Rooms ]-----------------------------------'
                this.grdList.SetData(i, 9, _requiredRooms);

                //-------------------------[ column 10 - Blocked Rooms ]-----------------------------------'
                this.grdList.SetData(i, 10, _blockedRooms);

                //-------------------------[ column 11 - Status ]-----------------------------------'
                this.grdList.SetData(i, 11, _status);

                //-------------------------[ column 12 - Rooms that were blocked ]-----------------------------------'

                _totalReservations++;
                //for HIGHLIGHT
                if (_requiredRooms > _blockedRooms)
                {
                    _totalWaitList++;

                    this.grdList.Rows[i].Style = this.grdList.Styles["NeedMoreRooms"];
                }

                i++;
                curProgress++;
                progress.updateProgress(i);
            }

            //sort by From Date [column 4]
            grdList.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, 4);
            grdList.AutoSizeCols(11, 12, 2);

            this.lblTotalReservation.Text = _totalReservations.ToString();
            this.lblTotalWaitList.Text = _totalWaitList.ToString();
        }

        private ComboBox lComboBlockedRooms;

        //private void GetListReservationList(string whrcond)
        //{
        //    DataTable getFolioData;
        //    FolioFacade oFolioFacade = new FolioFacade();
        //    ScheduleFacade oScheduleFacade = new ScheduleFacade();
        //    CompanyFacade oCompanyFACADE = new CompanyFacade();
        //    GuestFacade oGuestFACADE = new GuestFacade();
        //    FolioTransactionFacade oFolioTransFacade = new FolioTransactionFacade();

        //    Reservation.BusinessLayer.ReservationsFacade oReservationFAcade = new Reservation.BusinessLayer.ReservationsFacade();
        //    getFolioData = oReservationFAcade.GetReservationList();

        //    //by Genny: Apr. 29, 2008
        //    //getting all folios but filtering it by foliotype
        //    DataView dtvGetFolio = getFolioData.DefaultView;
        //    dtvGetFolio.RowStateFilter = DataViewRowState.OriginalRows;
        //    dtvGetFolio.RowFilter = whrcond;

        //    grdList.Rows.Count = 1;
        //    Company oCompany = new Company();
        //    Guest oGuest = new Guest();

        //    DataRowView dtRow;

        //    foreach (DataRowView tempLoopVar_dtRow in dtvGetFolio)
        //    {
        //        grdList.Rows.Count++;
        //        dtRow = tempLoopVar_dtRow;

        //        string folios = "";
        //        string rooms = "";

        //        //-------------------------[ column 1 - GroupName ]-----------------------------------'
        //        string rNo = dtRow["FolioID"].ToString();
        //        grdList.SetData(i, 0, dtRow["GroupName"].ToString());

        //        //-------------------------[ column 2 - Company Name ]-----------------------------------'
        //        //if (dtRow["aCCOUNTTYPE"].ToString() == "COMPANY" || dtRow["aCCOUNTTYPE"].ToString() == "CORPORATE" || dtRow["aCCOUNTTYPE"].ToString() == "GROUP")
        //        if (dtRow["foliotype"].ToString() == "GROUP")
        //        {
        //            if (dtRow["COMPANYID"].ToString().StartsWith("G"))
        //            {
        //                oCompany = oCompanyFACADE.getCompanyAccount(dtRow["COMPANYID"].ToString());

        //                grdList.SetData(i, 1, oCompany.CompanyName == "" ? "N / A" : oCompany.CompanyName);
        //            }
        //            else
        //            {
        //                oGuest = oGuestFACADE.getGuestRecord(dtRow["COMPANYID"].ToString());
        //                grdList.SetData(i, 1, oGuest.LastName + ", " + oGuest.FirstName);
        //            }
        //        }

        //        //-------------------------[ column 3 - Folio No ]-----------------------------------'
        //        grdList.SetData(i, 2, rNo);
        
        //        DataTable getChildFolio = oFolioFacade.GetChildFoliosTable(rNo);
        //        if (getChildFolio.Rows.Count > 0)
        //        {
        //            DataRow dtRows;
        //            foreach (DataRow tempLoopVar_dtRows in getChildFolio.Rows)
        //            {
        //                dtRows = tempLoopVar_dtRows;
        //                string foliono = dtRows["FOlioID"].ToString();
        //                folios += foliono + ", ";
        //                rooms += oScheduleFacade.GetRoomFromSchedules(foliono);
        //            }
        //            folios = folios.Substring(0, folios.Length - 2); 
        //        }

        //        //-------------------------[ column 6 - Amount ]-----------------------------------'
        //        decimal charges = oFolioTransFacade.GetFolioCharges(rNo, "A");
        //        decimal payment = oFolioTransFacade.GetFolioPayments(rNo, "A");

        //        FolioFacade _oFolioFacade = new FolioFacade();
        //        Folio _oFolio = new Folio();
        //        _oFolio = _oFolioFacade.GetFolio(rNo);
        //        _oFolio.ChildFolios = _oFolioFacade.GetChildFolios(rNo);

        //        foreach (Folio _oChildFolio in _oFolio.ChildFolios)
        //        {
        //            _oChildFolio.CreateSubFolio();
        //            foreach (SubFolio _oSubfolio in _oChildFolio.SubFolios)
        //            {
        //                if (_oSubfolio.SubFolio_Renamed == "B")
        //                {
        //                    _oSubfolio.Folio.FolioTransactions = _oFolioFacade.GetFolioTransactions(_oSubfolio.Folio.FolioID, _oSubfolio.SubFolio_Renamed);
        //                    _oSubfolio.Ledger = _oFolioFacade.GetFolioLedger(_oSubfolio.Folio.FolioID, _oSubfolio.SubFolio_Renamed);

        //                    charges += _oSubfolio.Ledger.Charges;
        //                    payment += (_oSubfolio.Ledger.PayCard + _oSubfolio.Ledger.PayCash + _oSubfolio.Ledger.PayCheque + _oSubfolio.Ledger.PayGiftCheque + _oSubfolio.Ledger.BalanceForwarded);
        //                }
        //            }
        //        }
        //        decimal balance = charges - payment;
        //        grdList.SetData(i, 5, charges);

        //        //-------------------------[ column 7 - Balance ]----------------------------------'
        //        grdList.SetData(i, 6, balance);

        //        //-------------------------[ column 8 - Assigned Rooms ]---------------------------'
        //        ReservationsFacade reserveFacade = new ReservationsFacade();
        //        GenericList<Schedule> schedule = reserveFacade.getRoomsAssignedForMasterFolio(rNo);
        //        int _numberOfAssignedRooms = 0;

        //        foreach (Schedule sched in schedule)
        //        {
        //            _numberOfAssignedRooms++;
        //        }
        //        grdList.SetData(i, 7, _numberOfAssignedRooms);

        //        //-------------------------[ column 9 - Blocked Rooms ]----------------------------'
        //        EventRoomRequirementFacade _oRoomRequirementFacade = new EventRoomRequirementFacade();
        //        GenericList<EventRoomRequirements> roomsBlocked = _oRoomRequirementFacade.getRoomRequirements(rNo);
        //        int noBlocked = 0;
        //        foreach (EventRoomRequirements r in roomsBlocked)
        //        {
        //            noBlocked += r.BlockedRooms;
        //        }
        //        grdList.SetData(i, 8, noBlocked);

        //        //-------------------------[ column 10 - Status ]----------------------------'
        //        string stat = dtRow["status"].ToString();
        //        grdList.SetData(i, 9, stat);


        //        C1.Win.C1FlexGrid.CellStyle _cellStyle = grdList.Styles.Add("Red");
        //        if (balance < 0)
        //        {
        //            _cellStyle.ForeColor = System.Drawing.Color.Red;
        //            grdList.SetCellStyle(i, 6, grdList.Styles["Red"]);
        //        }

        //        //-------------------------[ column 4 - From Date ]----------------------------'
        //        grdList.SetData(i, 3, dtRow["fromDate"].ToString());

        //        //-------------------------[ column 5 - To Date ]----------------------------'
        //        grdList.SetData(i, 4,  dtRow["toDate"].ToString());
        //    }

        //    //try
        //    //{
        //    //    foreach (C1.Win.C1FlexGrid.Row _row in grdList.Rows)
        //    //    {
        //    //        if (double.Parse(l.SubItems[4].Text) >= 0)
        //    //            lvwList.Items[l.Index].SubItems[4].ForeColor = System.Drawing.Color.Black;
        //    //        else
        //    //            lvwList.Items[l.Index].SubItems[4].ForeColor = System.Drawing.Color.Red;
        //    //    }
        //    //}
        //    //catch { }
        //}

        public void NewEntry()
        {
            btnInsert_Click();
        }

        #endregion

        #region " EVENTS "

        private void btnChange_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (this.grdList.Rows.Count > 0)
                {
					string _folioId = grdList.GetDataDisplay(grdList.Row, 3);

					if (_folioId != "0")
                    {
                        GroupReservationUI.ACCOUNT_TYPE = AccountType.Corporate;

						GroupReservationUI GroupReservationsUI = new GroupReservationUI(
																     _folioId, 
																	 grdList);

                        GroupReservationsUI.MdiParent = this.MdiParent;
                        GroupReservationsUI.Top = 0;
                        GroupReservationsUI.Left = 0;
                        GroupReservationsUI.Show();
                        this.Close();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please Select an Item on the list","Group Reservation", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            {

            }
        }

        private void lvwList_DoubleClick(object sender, System.EventArgs e)
        {
			if (this.grdList.Rows.Count <= 1)
				return;

			string _folioID = grdList.GetDataDisplay(grdList.Row, 3);

			if (_folioID != "")
            {
                GroupReservationUI.ACCOUNT_TYPE = AccountType.Corporate;
				GroupReservationUI GroupReservationsUI = new GroupReservationUI(_folioID, grdList);
                GroupReservationsUI.MdiParent = this.MdiParent;
                GroupReservationsUI.Top = 0;
                GroupReservationsUI.Left = 0;
                GroupReservationsUI.Show();
                this.Close();
            }
            else
            {
                this.lblFolioID.Text = grdList.GetDataDisplay(grdList.Row, 3);
                this.lblGroupName.Text = grdList.GetDataDisplay(grdList.Row, 2);
                this.Close();
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlTransaction trans = GlobalVariables.gPersistentConnection.BeginTransaction();
            FolioFacade oFolioFacade = new FolioFacade();
            if ( MessageBox.Show("Action will Cancel the Reservation including the Sub Folios,\n Do You want to continue?", "Group Reservation",MessageBoxButtons.YesNo, MessageBoxIcon.Question  ) == DialogResult.Yes)
            {
                if (oFolioFacade.CheckStatusToCancel(folioID) == true)
                {
                    Folio oFolio = new Folio();

                    oFolio.Status = "CANCELLED";
                    oFolio = oFolioFacade.GetFolio(folioID);

                    bool hasBalance = false;

                    oFolio.CreateSubFolio();
                    decimal balance = 0;
                    foreach (SubFolio subF in oFolio.SubFolios)
                    {
                        subF.Ledger = oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);
                        balance = subF.Ledger.BalanceNet;
                        if (balance != 0)
                        {
                            hasBalance = true;
                        }
                    }

                    if (hasBalance)
                    {
                        MessageBox.Show("Transaction failed.\r\n\r\nGuest still has unsettled account.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //>>by Genny: Apr. 29, 2008
                    //for cancellation purposes
                    ReasonForCancelUI reasonUI = new ReasonForCancelUI();
                    string reason = reasonUI.showDialog();
                    string reasonType = reasonUI.getReason();
                    string bookingType = reasonUI.getBookingType();

                    if (reason == "" && reasonType == "" && bookingType == "")
                        return;

                    //update folio status to cancelled
                    oFolioFacade.setFolioStatus(folioID, "CANCELLED", reason, reasonType, bookingType);
                    //oFolioFacade.updateFolio(oFolio);
                    //update group's dependent folios to cancelled
                    oFolioFacade.SetChildFolioStatus(folioID, "CANCELLED", reason);

                    //cancell group's room events and also its child's room events
                    RoomEventFacade oRoomEventFacade = new RoomEventFacade();
                    oRoomEventFacade.CancelRoomEvents(folioID, "RESERVATION", "CANCELLED");
                    DataTable getChildFolio = oFolioFacade.GetChildFoliosTable(folioID);
                    if (getChildFolio.Rows.Count > 0)
                    {
                        DataRow dtRows;
                        foreach (DataRow tempLoopVar_dtRows in getChildFolio.Rows)
                        {
                            dtRows = tempLoopVar_dtRows;
                            string foliono = dtRows["FOlioID"].ToString();
                            oRoomEventFacade.CancelRoomEvents(foliono, "RESERVATION", "CANCELLED");

                            //jlo 6-9-2010 cancel joiners
                            oFolioFacade.updateJoinerAllFolioStatus("CANCELLED", foliono);
                            //jlo
                        }
                    }

                    //unblock rooms that are blocked for that group
                    RoomBlockFacade _oRoomBlockFacade = new RoomBlockFacade();
                    string _event = folioID;
                    GenericList<RoomBlock> _oRoomBlockList = _oRoomBlockFacade.getBlockedRoomsForEvent(_event);
                    foreach (RoomBlock _oRoomBlock in _oRoomBlockList)
                    {
                        _oRoomBlockFacade.deleteRoomBlockedByEvent(_oRoomBlock.RoomID, folioID, ref trans);
                    }
                    //<<

                    trans.Commit();

					updateCurrentRoomStatus();

                    btnDisplay_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Transaction failed.\r\nCannot Cancel a Group Reservation when there is a Check-In Member", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

		private void updateCurrentRoomStatus()
		{
			try
			{
				Type objectType = Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI.GetType();
				MethodInfo[] objMethods = objectType.GetMethods();
				MethodInfo method;
				foreach (MethodInfo tempLoopVar_method in objMethods)
				{
					method = tempLoopVar_method;
					if (method.Name.ToUpper() == "plotCurrentDayRoomStatus".ToUpper())
					{
						method.Invoke(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gMDI, null);
					}
				}
			}
			catch { }

		}

        private void btnInsert_Click(System.Object sender, System.EventArgs e)
        {
            btnInsert_Click();
        }
        
        private void btnDisplay_Click(System.Object sender, System.EventArgs e)
        {
            GetReservationList();
            //GetListReservationList("status <>\'CLOSED\' and status<>\'CANCELLED\' and status<>\'NO SHOW\' and (foliotype=\'GROUP\' or foliotype='CORPORATE')");
        }


        private void GroupReservationListUI_Activated(object sender, System.EventArgs e)
        {
			if (!formLoaded)
			{
				GetReservationList();
			}
            
			this.WindowState = FormWindowState.Maximized;
        }

        private void bntCheckOut_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                this.lblFolioID.Text = folioID;
                this.lblGroupName.Text = grpName;
            }
            catch (NullReferenceException)
            {
                FolioFacade _oFolioFacade = new FolioFacade();
                FolioTransactions _oFolioTransaction = new FolioTransactions();
                _oFolioTransaction = _oFolioFacade.GetFolioTransactions(folioID, "A");

                if (_oFolioTransaction == null || _oFolioTransaction.Count == 0)
                {
                    if (MessageBox.Show("A guest has no posted transactions. Do you want to post transactions?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PostRoomChargesFacade oPostRoomChargeFacade = new PostRoomChargesFacade();
                        if (oPostRoomChargeFacade.initializePostRoomCharges(folioID) == true)
                        {
                            MessageBox.Show("Posting transactions successful. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Transactions are already posted for the day. ", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                Jinisys.Hotel.Cashier.Presentation.CheckOutUI frmCheckOut = new Jinisys.Hotel.Cashier.Presentation.CheckOutUI(folioID, grpName);
                frmCheckOut.MdiParent = this.MdiParent;
                frmCheckOut.Show();
            }
            this.Close();
        }

      
        private void GroupReservationListUI_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Top = 0;
            Left = 0;
        }


		bool formLoaded = false;
        private void GroupReservationListUI_Load(object sender, System.EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

			formLoaded = true;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            DateTime _eventDate = DateTime.Parse(grdList.GetDataDisplay(grdList.Row, 4));

            if (_eventDate <= DateTime.Parse(GlobalVariables.gAuditDate))
            {
                DialogResult rsp = MessageBox.Show("Folio will now be ONGOING.\r\n\r\nAre you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsp == DialogResult.Yes)
                {
                    FolioFacade _oFolioFacade = new FolioFacade();
                    string _folioNo = grdList.GetDataDisplay(grdList.Row, 3);
                    Folio _oFolio = new Folio();
                    _oFolio = _oFolioFacade.GetFolio(_folioNo);
                    bool _isCheckedIn = false;

                    if (_oFolio.Schedule.Count <= 0)
                    {
                        if (_oFolioFacade.checkInFolio(_folioNo, ""))
                            _isCheckedIn = true;
                    }
                    else
                    {
                        foreach (Schedule _oSchedule in _oFolio.Schedule)
                        {
                            if (_oSchedule.FromDate == DateTime.Parse(GlobalVariables.gAuditDate))
                            {
                                if (_oFolioFacade.checkInFolio(_folioNo, _oSchedule.RoomID))
                                    _isCheckedIn = true;
                            }
                        }
                    }

                    if (_isCheckedIn == true)
                    {
                        MessageBox.Show("Transaction successful.\r\nGuest Status is now Check In", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //grdList.SetData(grdList.Row, 11, "ONGOING");
                        grdList.Rows.Remove(grdList.Row);
                    }
                    else
                    {
                        MessageBox.Show("Transaction was not successful.\r\nCheck folio schedules first.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    updateCurrentRoomStatus();
                }
            }
            else
            {
                MessageBox.Show("Event date is greater than the current audit date.\r\n Change first the event dates of the group before check in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				//grdList.Focus();
				int totalRows = this.grdList.Rows.Count;
				int curRow = this.grdList.Row;
				curRow++;

				for (int i = curRow; i < totalRows; i++)
				{
					string _companyName = grdList.GetDataDisplay(i, 0).ToUpper();
					string _groupName = grdList.GetDataDisplay(i, 1).ToUpper();
					string _folioID = grdList.GetDataDisplay(i, 2).ToUpper();

					string searchText = this.txtSearch.Text.ToUpper();

					if (_companyName.Contains(searchText)
						|| _groupName.Contains(searchText)
						|| _folioID.Contains(searchText))
					{						
						grdList.Row = i;
						return;
					}
				}

				//repeat search from top
				for (int i = 0; i < totalRows; i++)
				{
					string _companyName = grdList.GetDataDisplay(i, 0).ToUpper();
					string _groupName = grdList.GetDataDisplay(i, 1).ToUpper();
					string _folioID = grdList.GetDataDisplay(i, 2).ToUpper();

					string searchText = this.txtSearch.Text.ToUpper();

					if (_companyName.Contains(searchText)
						|| _groupName.Contains(searchText)
						|| _folioID.Contains(searchText))
					{


						grdList.Row = i;
						return;
					}
				}


				MessageBox.Show("No Record Found!", "Group Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);

			}
		}

		private void btnExportToExcel_Click(object sender, EventArgs e)
		{
			//this.MdiParent.Cursor = Cursors.WaitCursor;

			
			string _filePath = @"..\Excel Caledar\Template\CALSKED.csv";

			StreamWriter strWrite = new StreamWriter(_filePath);
			
			strWrite.WriteLine("DATE_FROM,DATE_TO,ACTIVITY,STATUS,WHOLE_DAY_EVENT,TIME_START,TIME_END,ROOMID,COLOR_INDEX");

		
			FolioFacade _oFolioFacade = new FolioFacade();
			DataTable _tempData = _oFolioFacade.getGroupBookingForExportToExcel();

			foreach (DataRow _dRow in _tempData.Rows)
			{
				string _lineStr = "";

				_lineStr += _dRow["FromDate"].ToString() + ", ";
				_lineStr += _dRow["ToDate"].ToString() + ", ";
				_lineStr += _dRow["EventType"].ToString() + ", ";
				_lineStr += _dRow["Status"].ToString() + ", ";
                _lineStr += ", ";
				_lineStr += _dRow["startTime"].ToString() + ", ";
                _lineStr += _dRow["endTime"].ToString() + ", ";
                _lineStr += _dRow["RoomID"].ToString() + ", ";

                switch (_dRow["Status"].ToString())
                {
                    case "ONGOING":
                        _lineStr += Color.Cyan.ToArgb().ToString();
                        break;

                    case "TENTATIVE":
                        _lineStr += Color.DeepSkyBlue.ToArgb().ToString();
                        break;

                    case "CONFIRMED":
                        _lineStr += Color.DodgerBlue.ToArgb().ToString();
                        break;

                    case "WAIT LIST":
                        _lineStr += Color.LightBlue.ToArgb().ToString();
                        break;
                }

				strWrite.WriteLine(_lineStr);
			}

			strWrite.Close();


            //string _batchFile = @"..\Excel Caledar\startExcel.bat";
            //System.Diagnostics.Process.Start(_batchFile);


			this.MdiParent.Cursor = Cursors.Default;


		}

		private void grdList_RowColChange(object sender, EventArgs e)
		{
			try
			{
				folioID = grdList.GetDataDisplay(grdList.Row, 3);
				grpName = grdList.GetDataDisplay(grdList.Row, 1);

				string _folioStatus = grdList.GetDataDisplay(grdList.Row, 11);

				if (_folioStatus == "TENTATIVE" ||
					_folioStatus == "CONFIRMED")
				{
					btnCheckIn.Enabled = true;
					bntCheckOut.Enabled = false;
				}
				else
				{
					bntCheckOut.Enabled = true;
					btnCheckIn.Enabled = false;
				}
				btnDelete.Enabled = true;
			}
			catch (Exception)
			{

			}
		}

        private void grdList_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            string _folioId = grdList.GetDataDisplay(grdList.Row, 3);
            ReservationsFacade _oReservationFacade = new ReservationsFacade();
            DataTable dtBlockedRooms = _oReservationFacade.getBlockedRooms(_folioId);
            if (grdList.Col == 12)
            {
                grdList.Cols[12].AllowEditing = true;
                lComboBlockedRooms = new ComboBox();
                lComboBlockedRooms.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (DataRow _dtBlockedroomsRow in dtBlockedRooms.Rows)
                {
                    lComboBlockedRooms.Items.Add(_dtBlockedroomsRow["roomid"].ToString());
                }
                this.grdList.Cols[12].Editor = lComboBlockedRooms;
            }
            else
            {
                grdList.Cols[grdList.Col].AllowEditing = false;
            }
        }
    }
}