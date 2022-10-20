using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reservation.Presentation;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;

using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.Cashier.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reports.BusinessLayer;


namespace Jinisys.Hotel.Cashier.Presentation
{
    public partial class FolioLedgerInquiryUI : Form
    {
        private FolioFacade oFolioFacade;
        private ScheduleFacade oScheduleFacade;
        private GuestFacade oGuestFacade;
      

        public FolioLedgerInquiryUI()
        {
            InitializeComponent();
        }

        private void btnBrowseCust_Click(object sender, EventArgs e)
        {
              IndividualGuestLookUP guest_look = new IndividualGuestLookUP();
              guest_look.Location = new System.Drawing.Point(0,0);
			  this.txtAccount.Text = guest_look.showDialog();
              this.txtAccount.Tag = guest_look.getAccountID();

              this.lvwBrowseGuestName.Visible = false;
              txtAccount_KeyPress(sender, new KeyPressEventArgs('\r'));
        }

        private void btnViewFolioTrans_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabFolioInquiry.SelectedIndex == 0)
                {
                    //if (this.grdInquiry.Rows.Count > 1)
                    //{
                    //    string folioId = this.grdInquiry.GetDataDisplay(this.grdInquiry.Row, 1);

                    //    this.viewFolioDetails(folioId);
                    //}
                    gridIndividualHistory_MouseDoubleClick(null, null);
                }
                else if (this.tabFolioInquiry.SelectedIndex == 1)
                {
                    //string folioId = this.grdFolioSearch.GetDataDisplay(this.grdFolioSearch.Row, 1);

                    //this.viewFolioDetails(folioId);
                    gridCompanyHistory_MouseDoubleClick(null, null);
                }
                //else
                //{
                //    MessageBox.Show("Please select specific hotel stay", "Folio Ledger Inquiry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.tabFolioInquiry.SelectedIndex = 0;
                //}


            }catch(Exception){
            }
        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                this.grdInquiry.Rows.Count = 1;


				if (this.txtAccount.Tag != null)
				{
					getFolioHistory();
				}
				else
				{
					this.lvwBrowseGuestName.Visible = false;
                    getFolioHistory();
				}

            }
        }
        public void viewFolioDetails(string a_FolioId)
        {
            try
            {
                //this.MdiParent.Cursor = Cursors.WaitCursor;
                Jinisys.Hotel.Reports.BusinessLayer.ReportFacade oReportFacade = new Jinisys.Hotel.Reports.BusinessLayer.ReportFacade();
                Jinisys.Hotel.Reports.Presentation.ReportViewer ViewBillUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                ViewBillUI.MdiParent = this.MdiParent;
                ViewBillUI.rptViewer.ReportSource = oReportFacade.getIndividualGuestBill(a_FolioId, "A");
                ViewBillUI.Show();

                //this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("EXCEPTION: @ viewFolioDetails() " + ex.Message);
            }
        }
        private void getFolioHistory()
        {
            this.grdInquiry.Rows.Count = 1;

            DataTable getHistory;
            oFolioFacade = new FolioFacade();

			if (this.txtAccount.Tag == null)
			{
				getHistory = oFolioFacade.GetFolioHistory(this.txtAccount.Text);
			}
			else
			{
				getHistory = oFolioFacade.GetFolioHistory(this.txtAccount.Tag.ToString());
			}

			if (getHistory == null)
			{
				return;
			}

            oScheduleFacade = new ScheduleFacade();
            DataTable dtRoom;

            DataRow dtrow;
            int i = 1;
            this.grdInquiry.Rows.Count = getHistory.Rows.Count + 1;
            foreach (DataRow tempLoopVar_dtrow in getHistory.Rows)
            {
                dtrow = tempLoopVar_dtrow;
                Schedule oSchedule = new Schedule();
                //this.grdInquiry.Rows=this.grdInquiry.Rows+1;
                dtRoom = new DataTable();
                dtRoom = oScheduleFacade.GetRoomSchedulesForHistory(dtrow["FolioId"].ToString());

                string roomInfo = "";
                DataRow dtRoomInfo;
                foreach (DataRow tempLoopVar_dtRoomInfo in dtRoom.Rows)
                {
                    dtRoomInfo = tempLoopVar_dtRoomInfo;
                    roomInfo += dtRoomInfo["RoomId"].ToString() + " - " + dtRoomInfo["RoomType"].ToString() + " @ Php " + Double.Parse(dtRoomInfo["Rate"].ToString()).ToString("N") + " | ";
                }

				string _folioStatus = dtrow["Status"].ToString();


				if (_folioStatus == "CANCELLED" || _folioStatus == "NO SHOW")
				{
					this.grdInquiry.SetCellStyle(i, 0, "cancelled");
					this.grdInquiry.SetCellStyle(i, 1, "cancelled");
					this.grdInquiry.SetCellStyle(i, 2, "cancelled");
					this.grdInquiry.SetCellStyle(i, 3, "cancelled");
					this.grdInquiry.SetCellStyle(i, 4, "cancelled");
				}
				else
				{
					this.grdInquiry.SetCellStyle(i, 0, "Normal");
					this.grdInquiry.SetCellStyle(i, 1, "Normal");
					this.grdInquiry.SetCellStyle(i, 2, "Normal");
					this.grdInquiry.SetCellStyle(i, 3, "Normal");
					this.grdInquiry.SetCellStyle(i, 4, "Normal");
				}

				this.grdInquiry.SetData(i, 0, roomInfo);
				this.grdInquiry.SetData(i, 1, dtrow["folioID"].ToString());
				this.grdInquiry.SetData(i, 2, string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["FromDate"].ToString())));
				this.grdInquiry.SetData(i, 3, string.Format(GlobalVariables.gDateFormat, DateTime.Parse(dtrow["Todate"].ToString())));
				this.grdInquiry.SetData(i, 4, _folioStatus);
                this.grdInquiry.SetData(i, 5, dtrow["remarks"].ToString());

				i++;
                
            }
            grdInquiry.AutoSizeCols();

            //new
            gridIndividualHistory.Rows.Count = 1;
            int _row = 1;
            foreach (DataRow _dRow in getHistory.Rows)
            {
                gridIndividualHistory.Rows.Count++;
                _row = gridIndividualHistory.Rows.Count - 1;
                gridIndividualHistory.SetData(_row, 0, _dRow["referenceNo"].ToString());
                gridIndividualHistory.SetData(_row, 1, _dRow["groupName"].ToString());
                gridIndividualHistory.SetData(_row, 2, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_dRow["fromDate"].ToString())));
                gridIndividualHistory.SetData(_row, 3, string.Format("{0:dd-MMM-yyyy}", DateTime.Parse(_dRow["toDate"].ToString())));
                gridIndividualHistory.SetData(_row, 4, _dRow["folioID"].ToString());
            }
        }

        private void grdInquiry_DoubleClick(object sender, EventArgs e)
        {
            btnViewFolioTrans_Click(sender, e);
        }

        DataView dtViewGroup;
        private void FolioLedgerInquiryUI_Load(object sender, EventArgs e)
        {
            CompanyFacade oCompanyFacade = new CompanyFacade();
            Company oCompany = new Company();

            oCompany = oCompanyFacade.getCompanyAccountsData();

            dtViewGroup = oCompany.Tables[0].DefaultView;
            lvwBrowseGroupName.Items.Clear();
            foreach (DataRow dtRow in oCompany.Tables[0].Rows)
            {
                ListViewItem lvwItem = new ListViewItem(dtRow["CompanyId"].ToString());
                lvwItem.SubItems.Add(dtRow["CompanyName"].ToString());

                this.lvwBrowseGroupName.Items.Add(lvwItem);
            }
			//>> focus on Text Box AccountId
			try
			{
				SendKeys.Send("\t");
			}
			catch { }

            if (ConfigVariables.gIsEMMOnly == "true")
            {
                tabFolioInquiry.Controls.Remove(tabFolio);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string loAccountID = "";
        private void txtAccount_TextChanged(object sender, EventArgs e)
        {
            if (this.txtAccount.Tag != null)
            {
                loAccountID = this.txtAccount.Tag.ToString();
                getFolioHistory();
                return;
            }


            if (txtAccount.Text.Trim().Length <= 0)
            {
                this.lvwBrowseGuestName.Visible = false;
                return;
            }
            else
            {
                this.lvwBrowseGuestName.Visible = true;
                loadList();
            }

        }

        private void btnBrowseCompany_Click(object sender, EventArgs e)
        {
            loadGroupList();
            this.lvwBrowseGroupName.Visible = true;
        }

        private void lvwBrowseGroupName_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtCompanyName.Tag = lvwBrowseGroupName.SelectedItems[0].Text;
                this.txtCompanyName.Text = lvwBrowseGroupName.SelectedItems[0].SubItems[1].Text;
                this.txtCompanyName.Tag = null;
            }
            catch
            { }

            this.lvwBrowseGroupName.Visible = false;

        }

        private void lvwBrowseGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                try
                {
                    this.txtCompanyName.Tag = lvwBrowseGroupName.SelectedItems[0].Text;
                    this.txtCompanyName.Text = lvwBrowseGroupName.SelectedItems[0].SubItems[1].Text;
                    this.txtCompanyName.Tag = null;
                }
                catch
                { }

                this.lvwBrowseGroupName.Visible = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape) )
            {
                this.lvwBrowseGroupName.Visible = false;
            }
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCompanyName.Tag != null)
            {

                string companyId = txtCompanyName.Tag.ToString();

                SalesForecastFacade oSalesForecastFacade = new SalesForecastFacade();
                DataTable dtTable = new DataTable();
                dtTable = oSalesForecastFacade.getCompanyGuests(companyId);

                this.grdCompanyGuests.Rows.Count = dtTable.Rows.Count + 1;
                int i = 1;
                foreach (DataRow dtRow in dtTable.Rows)
                {
					string _accountId = dtRow["AccountId"].ToString();
					string _guestName = dtRow["GuestName"].ToString();

					//>> check if AccountId not empty
					if (_accountId.Trim().Length > 0)
					{
						this.grdCompanyGuests.SetData(i, 0, _accountId);
						this.grdCompanyGuests.SetData(i, 1, _guestName);

						i++;
					}
                }
            }


            if (txtCompanyName.Text.Trim().Length <= 0)
            {
                this.lvwBrowseGroupName.Visible = false;
                txtCompanyName.Tag = null;
                return;
            }
            else
            {
                this.lvwBrowseGroupName.Visible = true;
                loadGroupList();
            }

            //new
            if (this.txtCompanyName.Tag != null)
            {
                loAccountID = this.txtCompanyName.Tag.ToString();
                string _companyID = txtCompanyName.Tag.ToString();
                oFolioFacade = new FolioFacade();
                DataTable _dt = oFolioFacade.GetFolioHistory(_companyID);
                gridCompanyHistory.Rows.Count = 1;
                int _row = 1;
                foreach(DataRow _dRow in _dt.Rows)
                {
                    gridCompanyHistory.Rows.Count++;
                    _row = gridCompanyHistory.Rows.Count - 1;
                    gridCompanyHistory.SetData(_row, 0, _dRow["referenceNo"].ToString());
                    gridCompanyHistory.SetData(_row, 1, _dRow["groupName"].ToString());
                    gridCompanyHistory.SetData(_row, 2, string.Format("{0:dd-MMM-yyyy}",DateTime.Parse(_dRow["fromDate"].ToString())));
                    gridCompanyHistory.SetData(_row, 3, string.Format("{0:dd-MMM-yyyy}",DateTime.Parse(_dRow["toDate"].ToString())));
                    gridCompanyHistory.SetData(_row, 4, _dRow["folioID"].ToString());
                }

            }




        }

        private void grdCompanyGuests_Click(object sender, EventArgs e)
        {
            if (this.grdCompanyGuests.Rows.Count > 1)
            {
                this.txtAccount.Tag = grdCompanyGuests.GetDataDisplay(grdCompanyGuests.Row, 0);
                this.txtAccount.Text = grdCompanyGuests.GetDataDisplay(grdCompanyGuests.Row, 1);
                this.txtAccount.Tag = null;
            }
        }

        private void grdCompanyGuests_DoubleClick(object sender, EventArgs e)
        {
            if (this.grdCompanyGuests.Rows.Count > 1)
            {
                this.tabFolioInquiry.SelectedIndex = 0;
            }
        }

     
        private object loadList()
        {
            string filterValue;
            
            if (dtView == null)
            {
                dtView = getRec();
            }
            filterValue = this.txtAccount.Text.ToString().Replace("\'", "\'\'");
           
            dtView.RowStateFilter = DataViewRowState.OriginalRows;
            dtView.RowFilter = "LastName like \'" + filterValue + "%\' or FirstName like \'" + filterValue + "%\' or AccountId like \'" + filterValue + "%\'";
       
            DataRowView dtr;
            this.lvwBrowseGuestName.Items.Clear();
            foreach (DataRowView tempLoopVar_dtr in dtView)
            {
                dtr = tempLoopVar_dtr;
                ListViewItem li = new ListViewItem(dtr["AccountId"].ToString());
                li.SubItems.Add(dtr["LastName"].ToString());
                li.SubItems.Add(dtr["FirstName"].ToString());
                this.lvwBrowseGuestName.Items.Add(li);
            }
            return null;
        }
        DataView dtView;
        public DataView getRec()
        {
            try
            {
                Guest oGuest = new Guest();
                GuestFacade oGuestFacade = new GuestFacade();
				oGuest = oGuestFacade.getGuests();
                
                DataView dtView = oGuest.Tables[0].DefaultView;
                return dtView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwBrowseGuestName.Visible)
                {
                    this.lvwBrowseGuestName.Select();
                    //this.lvwBrowseGuestName.Items[0].Selected = true;
                }
            }
        }

        private void lvwBrowseGuestName_DoubleClick(object sender, EventArgs e)
        {
			try
			{
				string accountId = this.lvwBrowseGuestName.SelectedItems[0].Text;

				string _guestName = this.lvwBrowseGuestName.SelectedItems[0].SubItems[1].Text + ", " + this.lvwBrowseGuestName.SelectedItems[0].SubItems[2].Text;

				if (accountId.Trim().Length > 0)
				{
					this.lvwBrowseGuestName.Visible = false;
					this.txtAccount.Tag = accountId;
					this.txtAccount.Text = _guestName;
					txtAccount_TextChanged(sender, e);
					this.txtAccount.Tag = null;
				}
			}
			catch
			{ }
        }

        private void lvwBrowseGuestName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                lvwBrowseGuestName_DoubleClick(sender, new EventArgs());
            }
            else if (e.KeyChar == Convert.ToChar( Keys.Escape ))
            {
                this.lvwBrowseGuestName.Visible = false;
            }

        }


        private object loadGroupList()
        {
            string filterValue;

            //if (dtViewGroup == null)
            //{
            //    dtView = getRec();
            //}
            filterValue = this.txtCompanyName.Text.ToString().Replace("\'", "\'\'");

            dtViewGroup.RowStateFilter = DataViewRowState.OriginalRows;
            dtViewGroup.RowFilter = "CompanyName like \'" + filterValue + "%\' or CompanyId like \'" + filterValue + "%\'";

            DataRowView dtr;
            this.lvwBrowseGroupName.Items.Clear();
            foreach (DataRowView tempLoopVar_dtr in dtViewGroup)
            {
                dtr = tempLoopVar_dtr;
                ListViewItem li = new ListViewItem(dtr["CompanyId"].ToString());
                li.SubItems.Add(dtr["CompanyName"].ToString());
                //li.SubItems.Add(dtr["FirstName"].ToString());
                this.lvwBrowseGroupName.Items.Add(li);
            }
            return null;
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (this.lvwBrowseGroupName.Visible)
                {
                    this.lvwBrowseGroupName.Select();
                    this.lvwBrowseGroupName.Items[0].Selected = true;
                }
            }
        }

		private void tabFolioInquiry_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabFolioInquiry.SelectedIndex == 0)
			{
				this.txtAccount.Focus();
			}
			else
			{
				this.txtCompanyName.Focus();
			}
		}

        private void txtFolioSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    grdFolioSearch.Rows.Count = 1;
                    Folio _oFolio = new Folio();
                    oFolioFacade = new FolioFacade();
                    oScheduleFacade = new ScheduleFacade();

                    _oFolio = oFolioFacade.GetFolio(txtFolioSearch.Text.ToUpper());
                    if (_oFolio == null)
                    {
                        MessageBox.Show("Folio ID not found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        grdFolioSearch.Rows.Count++;
                        DataTable dtRoom = new DataTable();
                        dtRoom = oScheduleFacade.GetRoomSchedulesForHistory(_oFolio.FolioID);

                        string roomInfo = "";
                        DataRow dtRoomInfo;
                        foreach (DataRow tempLoopVar_dtRoomInfo in dtRoom.Rows)
                        {
                            dtRoomInfo = tempLoopVar_dtRoomInfo;
                            roomInfo += dtRoomInfo["RoomId"].ToString() + " - " + dtRoomInfo["RoomType"].ToString() + " @ Php " + Double.Parse(dtRoomInfo["Rate"].ToString()).ToString("N") + " | ";
                        }

                        string _folioStatus = _oFolio.Status;


                        if (_folioStatus == "CANCELLED" || _folioStatus == "NO SHOW")
                        {
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 0, "cancelled");
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 1, "cancelled");
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 2, "cancelled");
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 3, "cancelled");
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 4, "cancelled");
                        }
                        else
                        {
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 0, "Normal");
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 1, "Normal");
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 2, "Normal");
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 3, "Normal");
                            this.grdFolioSearch.SetCellStyle(grdFolioSearch.Rows.Count - 1, 4, "Normal");
                        }

                        this.grdFolioSearch.SetData(grdFolioSearch.Rows.Count - 1, 0, roomInfo);
                        this.grdFolioSearch.SetData(grdFolioSearch.Rows.Count - 1, 1, _oFolio.FolioID);
                        this.grdFolioSearch.SetData(grdFolioSearch.Rows.Count - 1, 2, string.Format(GlobalVariables.gDateFormat, _oFolio.FromDate));
                        this.grdFolioSearch.SetData(grdFolioSearch.Rows.Count - 1, 3, string.Format(GlobalVariables.gDateFormat, _oFolio.Todate));
                        this.grdFolioSearch.SetData(grdFolioSearch.Rows.Count - 1, 4, _folioStatus);
                    }
                }
            }
            catch
            { }
        }

        private void grdFolioSearch_DoubleClick(object sender, EventArgs e)
        {
            btnViewFolioTrans_Click(sender, e);
        }

        private void gridIndividualHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string _folioID = gridIndividualHistory.GetDataDisplay(gridIndividualHistory.Row, 4).ToString();
            //GroupReservationUI _oGroupReservationUI = new GroupReservationUI(_folioID);
            //_oGroupReservationUI.MdiParent = this.MdiParent;
            //_oGroupReservationUI.Show();

            ReservationUI _ReservationUI = new ReservationUI(_folioID);
            _ReservationUI.MdiParent = this.MdiParent;
            _ReservationUI.Show();

            //this.Close();

            return;
        }

        private void gridCompanyHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string _folioID = gridCompanyHistory.GetDataDisplay(gridCompanyHistory.Row, 4).ToString();
            //GroupReservationUI _oGroupReservationUI = new GroupReservationUI(_folioID);
            //_oGroupReservationUI.MdiParent = this.MdiParent;
            //_oGroupReservationUI.Show();
            ReservationUI _ReservationUI = new ReservationUI(_folioID);
            _ReservationUI.MdiParent = this.MdiParent;
            _ReservationUI.Show();

            //this.Close();

            return;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            //Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();
            string _accountID = "";
            string _category = "";
            string _folioID = "";
            try
            {
                if(tabFolioInquiry.SelectedIndex == 0)
                {
                    if(gridIndividualHistory.Rows.Count > 1)
                    {
                        _accountID = loAccountID;
                        _folioID = gridIndividualHistory.GetDataDisplay(gridIndividualHistory.Row, 4);
                        _category = "Individual";
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if(gridCompanyHistory.Rows.Count > 1)
                    {
                        _accountID = loAccountID;
                        _folioID = gridCompanyHistory.GetDataDisplay(gridCompanyHistory.Row, 4);
                        _category = "Company";
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }

            Reports.Presentation.ReportViewer oReportViewerUI = new Reports.Presentation.ReportViewer();
            oReportViewerUI = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getAccountReport2(_folioID, _accountID);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();

            oReportViewerUI = new Reports.Presentation.ReportViewer();
            oReportViewerUI.rptViewer.ReportSource = _oReportFacade.getAccountReport(_accountID, _category);
            oReportViewerUI.MdiParent = this.MdiParent;
            oReportViewerUI.Show();
            
        }

        private void btnACR_Click(object sender, EventArgs e)
        {
            pnlRemarks.BringToFront();
            pnlRemarks.Location = new Point(this.Left, this.Top);
            pnlRemarks.Visible = true;
        }

        private void btnRemarksOK_Click(object sender, EventArgs e)
        {
            Folio _oFolio = new Folio();
            FolioFacade _facade = new FolioFacade();
            Company _company = new Company();
            CompanyFacade _cFacade = new CompanyFacade();
            Guest _guest = new Guest();
            GuestFacade _gFacade = new GuestFacade();
            string _companyName = "";

            string _folioID = "";
            try
            {
                if (tabFolioInquiry.SelectedIndex == 0)
                {
                    if (gridIndividualHistory.Rows.Count > 1)
                    {
                        _folioID = gridIndividualHistory.GetDataDisplay(gridIndividualHistory.Row, 4);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (gridCompanyHistory.Rows.Count > 1)
                    {
                        _folioID = gridCompanyHistory.GetDataDisplay(gridCompanyHistory.Row, 4);
                    }
                    else
                    {
                        return;
                    }
                }

                _oFolio = _facade.GetFolio(_folioID);


                if (_oFolio.CompanyID.StartsWith("G"))
                {
                    _company = _cFacade.getCompanyAccount(_oFolio.CompanyID);
                    _companyName = _company.CompanyName;
                }
                else
                {
                    _guest = _gFacade.getGuestRecord(_oFolio.CompanyID);
                    _companyName = _guest.LastName + ", " + _guest.FirstName;
                }
            }
            catch
            {
                return;
            }


            if (_folioID != "")
            {
                Reports.Presentation.ReportViewer reportViewerUI = new Reports.Presentation.ReportViewer();
                ReportFacade reportFacade = new ReportFacade();
                reportViewerUI.rptViewer.ReportSource = reportFacade.getCompanyBill_PICC(_folioID, _oFolio.GroupName, _oFolio.FromDate, _companyName, _oFolio.ReferenceNo, _oFolio.CompanyID, txtGroupRemarks.Text,"", chkNoPayments.Checked);
                reportViewerUI.MdiParent = this.MdiParent;
                reportViewerUI.Show();
            }
            else
            {
                return;
            }
        }

        private void btnRemarksCancel_Click(object sender, EventArgs e)
        {
            pnlRemarks.SendToBack();
            pnlRemarks.Visible = false;
        }

    }
}