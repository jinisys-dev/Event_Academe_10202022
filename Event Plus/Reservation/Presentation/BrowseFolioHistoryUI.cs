using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public class BrowseFolioHistoryUI : Jinisys.Hotel.UIFramework.LookUPUI
    {

        #region " Windows Form Designer generated lCode "

        public BrowseFolioHistoryUI()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call

        }

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

        private System.ComponentModel.IContainer components;

        //Required by the Windows Form Designer

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the lCode editor.
        internal System.Windows.Forms.ListView lvwHistory;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        internal System.Windows.Forms.ColumnHeader ColumnHeader7;
        internal System.Windows.Forms.ColumnHeader ColumnHeader8;
        internal System.Windows.Forms.ColumnHeader ColumnHeader9;
        internal System.Windows.Forms.ColumnHeader ColumnHeader11;
        internal System.Windows.Forms.ColumnHeader ColumnHeader12;
        internal System.Windows.Forms.ColumnHeader ColumnHeader13;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.ToolTip tipHistory;
        internal System.Windows.Forms.Button btnViewFolioTrans;
        internal System.Windows.Forms.ContextMenu cmuPop;
        internal System.Windows.Forms.MenuItem mnuViewDetails;
        internal System.Windows.Forms.MenuItem MenuItem2;
        internal System.Windows.Forms.MenuItem mnuClose;
        private ColumnHeader columnHeader10;
        internal Button btnViewFolio;
        private ColumnHeader columnHeader15;
        private DateTimePicker dtTo;
        private Label label3;
        private DateTimePicker dtFrom;
        private Button btnFilterSearch;
        internal System.Windows.Forms.ColumnHeader ColumnHeader14;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseFolioHistoryUI));
            this.lvwHistory = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.btnFilterSearch = new System.Windows.Forms.Button();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.tipHistory = new System.Windows.Forms.ToolTip(this.components);
            this.btnViewFolioTrans = new System.Windows.Forms.Button();
            this.cmuPop = new System.Windows.Forms.ContextMenu();
            this.mnuViewDetails = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuClose = new System.Windows.Forms.MenuItem();
            this.ColumnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.btnViewFolio = new System.Windows.Forms.Button();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwLookUp
            // 
            this.lvwLookUp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader9,
            this.ColumnHeader14,
            this.ColumnHeader11,
            this.ColumnHeader12,
            this.ColumnHeader13,
            this.columnHeader10,
            this.columnHeader15});
            this.lvwLookUp.Location = new System.Drawing.Point(13, 38);
            this.lvwLookUp.Size = new System.Drawing.Size(743, 236);
            this.tipHistory.SetToolTip(this.lvwLookUp, "decimal Click to View Detailed Information");
            this.lvwLookUp.DoubleClick += new System.EventHandler(this.lvwLookUp_DoubleClick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Location = new System.Drawing.Point(80, 792);
            this.GroupBox1.Size = new System.Drawing.Size(637, 70);
            this.GroupBox1.Visible = false;
            // 
            // cboCriteria
            // 
            this.cboCriteria.Size = new System.Drawing.Size(160, 22);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(669, 292);
            this.btnClose.Size = new System.Drawing.Size(85, 31);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(497, 465);
            this.btnSelect.Visible = false;
            // 
            // lvwHistory
            // 
            this.lvwHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8});
            this.lvwHistory.FullRowSelect = true;
            this.lvwHistory.GridLines = true;
            this.lvwHistory.HoverSelection = true;
            this.lvwHistory.Location = new System.Drawing.Point(5, 10);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(644, 178);
            this.lvwHistory.TabIndex = 1;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = " ID";
            this.ColumnHeader1.Width = 35;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "From";
            this.ColumnHeader2.Width = 75;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "To";
            this.ColumnHeader3.Width = 75;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Adult";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader4.Width = 40;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Child";
            this.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader5.Width = 40;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Rooms";
            this.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader6.Width = 210;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Amount";
            this.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader7.Width = 75;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Status";
            this.ColumnHeader8.Width = 85;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Event ID";
            this.ColumnHeader9.Width = 88;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "From";
            this.ColumnHeader11.Width = 110;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "To";
            this.ColumnHeader12.Width = 110;
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Status";
            this.ColumnHeader13.Width = 122;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.label3);
            this.GroupBox2.Controls.Add(this.dtFrom);
            this.GroupBox2.Controls.Add(this.btnFilterSearch);
            this.GroupBox2.Controls.Add(this.dtTo);
            this.GroupBox2.Location = new System.Drawing.Point(2, -2);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(760, 283);
            this.GroupBox2.TabIndex = 11;
            this.GroupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "to";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "MMMM dd, yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(407, 14);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(145, 20);
            this.dtFrom.TabIndex = 14;
            // 
            // btnFilterSearch
            // 
            this.btnFilterSearch.Image = global::Jinisys.Hotel.Reservation.Properties.Resources.search_small;
            this.btnFilterSearch.Location = new System.Drawing.Point(725, 12);
            this.btnFilterSearch.Name = "btnFilterSearch";
            this.btnFilterSearch.Size = new System.Drawing.Size(28, 24);
            this.btnFilterSearch.TabIndex = 1;
            this.btnFilterSearch.UseVisualStyleBackColor = true;
            this.btnFilterSearch.Click += new System.EventHandler(this.btnFilterSearch_Click);
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "MMMM dd, yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(574, 14);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(145, 20);
            this.dtTo.TabIndex = 0;
            // 
            // btnViewFolioTrans
            // 
            this.btnViewFolioTrans.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnViewFolioTrans.Location = new System.Drawing.Point(569, 292);
            this.btnViewFolioTrans.Name = "btnViewFolioTrans";
            this.btnViewFolioTrans.Size = new System.Drawing.Size(96, 31);
            this.btnViewFolioTrans.TabIndex = 12;
            this.btnViewFolioTrans.Text = "&Print Event";
            this.btnViewFolioTrans.Click += new System.EventHandler(this.btnViewFolioTrans_Click);
            // 
            // cmuPop
            // 
            this.cmuPop.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuViewDetails,
            this.MenuItem2,
            this.mnuClose});
            // 
            // mnuViewDetails
            // 
            this.mnuViewDetails.DefaultItem = true;
            this.mnuViewDetails.Index = 0;
            this.mnuViewDetails.Text = "&View Details";
            this.mnuViewDetails.Click += new System.EventHandler(this.mnuViewDetails_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 1;
            this.MenuItem2.Text = "-";
            // 
            // mnuClose
            // 
            this.mnuClose.Index = 2;
            this.mnuClose.Text = "&Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Room(s) Rented";
            this.ColumnHeader14.Width = 200;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Driver";
            this.columnHeader10.Width = 110;
            // 
            // btnViewFolio
            // 
            this.btnViewFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnViewFolio.Location = new System.Drawing.Point(467, 292);
            this.btnViewFolio.Name = "btnViewFolio";
            this.btnViewFolio.Size = new System.Drawing.Size(96, 31);
            this.btnViewFolio.TabIndex = 13;
            this.btnViewFolio.Text = "&View Details";
            this.btnViewFolio.Click += new System.EventHandler(this.btnViewFolio_Click);
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Revenue";
            this.columnHeader15.Width = 70;
            // 
            // BrowseFolioHistoryUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(764, 331);
            this.Controls.Add(this.btnViewFolio);
            this.Controls.Add(this.btnViewFolioTrans);
            this.Controls.Add(this.GroupBox2);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BrowseFolioHistoryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event History -";
            this.Controls.SetChildIndex(this.GroupBox2, 0);
            this.Controls.SetChildIndex(this.btnViewFolioTrans, 0);
            this.Controls.SetChildIndex(this.btnViewFolio, 0);
            this.Controls.SetChildIndex(this.lvwLookUp, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.GroupBox1, 0);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region " CONSTRUCTORS "

        public BrowseFolioHistoryUI(string AccountID, string folioOwner)
        {
            InitializeComponent();


            oGuest = new Guest();
            mAccountId = AccountID;

            this.Text = this.Text + folioOwner;
            getFolioHistory();
        }

        #endregion

        #region " VARIABLES "

        private string mAccountId;

        private FolioFacade oFolioFacade;
        private ScheduleFacade oScheduleFacade;
        //private GuestFacade _oGuestFacade;
        private Guest oGuest;

        #endregion

        #region " METHODS "

        private void getFolioHistory()
        {
            DataTable getHistory;
            oFolioFacade = new FolioFacade();
            getHistory = oFolioFacade.GetFolioHistory(mAccountId);

            oScheduleFacade = new ScheduleFacade();
            DataTable dtRoom;

            DataRow dtrow;
            foreach (DataRow tempLoopVar_dtrow in getHistory.Rows)
            {
                dtrow = tempLoopVar_dtrow;
                Schedule oSchedule = new Schedule();

                dtRoom = new DataTable();
                dtRoom = oScheduleFacade.GetRoomEventForHistory(dtrow["FolioId"].ToString());

                string roomInfo = "";
                DataRow dtRoomInfo;

                /* Gene
                 * 02-Mar-12
                 * One room per row
                 */
                // Old Code
                //foreach (DataRow tempLoopVar_dtRoomInfo in dtRoom.Rows)
                //{
                //    dtRoomInfo = tempLoopVar_dtRoomInfo;
                //    roomInfo += dtRoomInfo["RoomId"] + "(" + dtRoomInfo["RoomType"] + ") @ Php " + decimal.Parse(dtRoomInfo["Rate"].ToString()).ToString("N") + " | ";
                //}

                //ListViewItem listViewItem = new ListViewItem(dtrow["folioID"].ToString());
                //listViewItem.SubItems.Add(roomInfo);
                //listViewItem.SubItems.Add(string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["FromDate"].ToString())));
                //listViewItem.SubItems.Add(string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["Todate"].ToString())));
                //listViewItem.SubItems.Add(dtrow["Status"].ToString());
                //listViewItem.SubItems.Add(dtrow["driver"].ToString());

                //if (dtrow["Status"].ToString() == "CANCELLED" || dtrow["Status"].ToString() == "NO SHOW")
                //{
                //    listViewItem.BackColor = System.Drawing.Color.Gainsboro;
                //}

                //lvwLookUp.Items.Add(listViewItem);

                foreach (DataRow tempLoopVar_dtRoomInfo in dtRoom.Rows)
                {
                    dtRoomInfo = tempLoopVar_dtRoomInfo;
                    roomInfo = dtRoomInfo["RoomId"] + "(" + dtRoomInfo["RoomType"] + ") @ Php " + decimal.Parse(dtRoomInfo["Rate"].ToString()).ToString("N") + " | ";


                    ListViewItem listViewItem = new ListViewItem(dtrow["folioID"].ToString());
                    listViewItem.SubItems.Add(roomInfo);
                    listViewItem.SubItems.Add(string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["FromDate"].ToString())));
                    listViewItem.SubItems.Add(string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["Todate"].ToString())));
                    listViewItem.SubItems.Add(dtrow["Status"].ToString());
                    listViewItem.SubItems.Add(dtrow["driver"].ToString());
                    listViewItem.SubItems.Add(dtRoomInfo["RoomRevenue"].ToString());
                    if (dtrow["Status"].ToString() == "CANCELLED" || dtrow["Status"].ToString() == "NO SHOW")
                    {
                        listViewItem.BackColor = System.Drawing.Color.Gainsboro;
                    }

                    lvwLookUp.Items.Add(listViewItem);
                }
            }
        }

        public void viewFolioDetails(string a_FolioId)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ReportFacade oReportFacade = new ReportFacade();
                ReportViewer ViewBillUI = new ReportViewer();
                ViewBillUI.MdiParent = (Form)GlobalVariables.gMDI;
                Folio _oFolio = new Folio();
                FolioFacade _oFolioFacade = new FolioFacade();
                _oFolio = _oFolioFacade.GetFolio(a_FolioId);
                if (_oFolio.FolioType == "JOINER")
                {
                    ViewBillUI.rptViewer.ReportSource = oReportFacade.getIndividualGuestBill(_oFolio.MasterFolio, "ALL");
                }
                else if (_oFolio.FolioType != "GROUP")
                {
                    ViewBillUI.rptViewer.ReportSource = oReportFacade.getIndividualGuestBill(a_FolioId, "ALL");
                }
                else
                {
                    ViewBillUI.rptViewer.ReportSource = oReportFacade.getCompanyBill(a_FolioId);
                }
                ViewBillUI.Show();

                this.Cursor = Cursors.Default;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region " EVENTS "

        private void lvwLookUp_decimalClick(System.Object sender, System.EventArgs e)
        {
            viewFolioDetails(this.lvwLookUp.SelectedItems[0].Text);
        }

        private void mnuViewDetails_Click(System.Object sender, System.EventArgs e)
        {
            viewFolioDetails(this.lvwLookUp.SelectedItems[0].Text);
        }

        private void btnViewFolioTrans_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                viewFolioDetails(this.lvwLookUp.SelectedItems[0].Text);
            }
            catch (Exception) { }
        }

        private void lvwLookUp_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Drawing.Point pos = new System.Drawing.Point(e.X, e.Y);
                this.cmuPop.Show(this.lvwLookUp, pos);
            }
        }

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void mnuClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void lvwLookUp_DoubleClick(object sender, EventArgs e)
        {
            btnViewFolioTrans_Click(sender, e);
        }

        private void btnViewFolio_Click(object sender, EventArgs e)
        {            
            if (lvwLookUp.SelectedItems.Count > 0)
                viewFolio(this.lvwLookUp.SelectedItems[0].Text);
        }

        private void viewFolio(string pFolioID)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                Folio _oFolio = new Folio();
                FolioFacade _oFolioFacade = new FolioFacade();
                _oFolio = _oFolioFacade.GetFolio(pFolioID);

                if (_oFolio.FolioType == "JOINER")
                {
                    if (_oFolio.MasterFolio == "" || _oFolio.MasterFolio == "0")
                    {
                        // do nothing
                    }
                    else
                    {
                        /* Pass FolioID of masterFolio since
                        * SHARE to another guest
                        */
                        //lFolioID = lMasterFolio;
                        _oFolio.FolioID = _oFolio.MasterFolio;

                        DialogResult rsp = MessageBox.Show("Guest type is joiner.\r\n\r\nShow Master Folio information?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rsp == DialogResult.No)
                        {
                            this.MdiParent.Cursor = Cursors.Default;
                            return;
                        }
                    }

                    ReservationFolioUI _oReservationUI = new ReservationFolioUI(ReservationOperationMode.ViewFolioInformation, _oFolio.FolioID);
                    _oReservationUI.MdiParent = this.MdiParent;
                    _oReservationUI.Show();
                }
                else if (_oFolio.FolioType == "GROUP")
                {
                    // Gene 2013-12-04
                    //GroupReservationUI _oGroupReservationUI = new GroupReservationUI(_oFolio.FolioID);
                    //_oGroupReservationUI.MdiParent = this.MdiParent;
                    //_oGroupReservationUI.Show();

                    ReservationUI _oReservationUI = new ReservationUI(_oFolio.FolioID);
                    _oReservationUI.MdiParent = this.MdiParent;
                    _oReservationUI.Show();

                }
                else
                {
                    ReservationFolioUI _oReservationUI = new ReservationFolioUI(ReservationOperationMode.ViewFolioInformation, _oFolio.FolioID);
                    _oReservationUI.MdiParent = this.MdiParent;
                    _oReservationUI.Show();
                }

                this.Cursor = Cursors.Default;
                this.Close();

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterSearch_Click(object sender, EventArgs e)
        {
            getFilterFolioHistory();
        }

        private void getFilterFolioHistory()
        {
            DataTable getHistory;
            oFolioFacade = new FolioFacade();
            getHistory = oFolioFacade.GetFolioHistory(mAccountId);

            try
            {

                DataView _dtView = getHistory.DefaultView;

                _dtView.RowFilter = "(fromDate>='" + string.Format("{0:MM/dd/yyyy hh:mm:ss }", DateTime.Parse(dtFrom.Text)) + "' AND fromDate <= '" + string.Format("{0:MM/dd/yyyy hh:mm:ss}", DateTime.Parse(dtTo.Text)) +
                "') OR (toDate >= '" + string.Format("{0:MM/dd/yyyy hh:mm:ss}", DateTime.Parse(dtFrom.Text)) + "' AND toDate <= '" + string.Format("{0:MM/dd/yyyy hh:mm:ss}", DateTime.Parse(dtTo.Text)) + "')";

                oScheduleFacade = new ScheduleFacade();
                DataTable dtRoom;

                DataRow dtrow;
                lvwLookUp.Items.Clear();

                foreach (DataRow tempLoopVar_dtrow in _dtView.ToTable().Rows)
                {

                   

                    dtrow = tempLoopVar_dtrow;
                    //if ((DateTime.Parse(dtFrom.Text) >= DateTime.Parse(tempLoopVar_dtrow["fromDate"].ToString()) && DateTime.Parse(dtTo.Text) <= DateTime.Parse(tempLoopVar_dtrow["fromDate"].ToString()))
                    //    || (DateTime.Parse(dtFrom.Text) >= DateTime.Parse(tempLoopVar_dtrow["toDate"].ToString()) && DateTime.Parse(dtTo.Text) <= DateTime.Parse(tempLoopVar_dtrow["toDate"].ToString())))
                    //{

                 
                    Schedule oSchedule = new Schedule();

                    dtRoom = new DataTable();
                    dtRoom = oScheduleFacade.GetRoomEventForHistory(dtrow["FolioId"].ToString());

                    //    DataView _dtView = dtRoom.DefaultView;

                    //     _dtView.RowFilter = "(FROMDATE >= '" + string.Format("{0:MM/dd/yyyy hh:mm:ss}", ) + "' AND FROMDATE <= '" + string.Format("{0:MM/dd/yyyy hh:mm:ss}", DateTime.Parse(dtTo.Text)) +")";//+
                    //     "') OR (TODATE >= '" + string.Format("{0:MM/dd/yyyy hh:mm:ss}", DateTime.Parse(dtFrom.Text)) + "' AND FROMDATE <= '" + string.Format("{0:MM/dd/yyyy hh:mm:ss}", DateTime.Parse(dtTo.Text)) + "')"; 

                    string roomInfo = "";
                    DataRow dtRoomInfo;

                    /* Gene
                     * 02-Mar-12
                     * One room per row
                     */
                    // Old Code
                    //foreach (DataRow tempLoopVar_dtRoomInfo in dtRoom.Rows)
                    //{
                    //    dtRoomInfo = tempLoopVar_dtRoomInfo;
                    //    roomInfo += dtRoomInfo["RoomId"] + "(" + dtRoomInfo["RoomType"] + ") @ Php " + decimal.Parse(dtRoomInfo["Rate"].ToString()).ToString("N") + " | ";
                    //}

                    //ListViewItem listViewItem = new ListViewItem(dtrow["folioID"].ToString());
                    //listViewItem.SubItems.Add(roomInfo);
                    //listViewItem.SubItems.Add(string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["FromDate"].ToString())));
                    //listViewItem.SubItems.Add(string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["Todate"].ToString())));
                    //listViewItem.SubItems.Add(dtrow["Status"].ToString());
                    //listViewItem.SubItems.Add(dtrow["driver"].ToString());

                    //if (dtrow["Status"].ToString() == "CANCELLED" || dtrow["Status"].ToString() == "NO SHOW")
                    //{
                    //    listViewItem.BackColor = System.Drawing.Color.Gainsboro;
                    //}

                    //lvwLookUp.Items.Add(listViewItem);

                    foreach (DataRow tempLoopVar_dtRoomInfo in dtRoom.Rows)
                    {

                        dtRoomInfo = tempLoopVar_dtRoomInfo;
                        roomInfo = dtRoomInfo["RoomId"] + "(" + dtRoomInfo["RoomType"] + ") @ Php " + decimal.Parse(dtRoomInfo["Rate"].ToString()).ToString("N") + " | ";


                        ListViewItem listViewItem = new ListViewItem(dtrow["folioID"].ToString());
                        listViewItem.SubItems.Add(roomInfo);
                        listViewItem.SubItems.Add(string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["FromDate"].ToString())));
                        listViewItem.SubItems.Add(string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["Todate"].ToString())));
                        listViewItem.SubItems.Add(dtrow["Status"].ToString());
                        listViewItem.SubItems.Add(dtrow["driver"].ToString());
                        listViewItem.SubItems.Add(dtRoomInfo["RoomRevenue"].ToString());
                        if (dtrow["Status"].ToString() == "CANCELLED" || dtrow["Status"].ToString() == "NO SHOW")
                        {
                            listViewItem.BackColor = System.Drawing.Color.Gainsboro;
                        }

                        lvwLookUp.Items.Add(listViewItem);

                    }
                }
               // }
            }
            catch
            {

            }
        }
    }
	
}
