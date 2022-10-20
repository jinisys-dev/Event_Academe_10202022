using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;

namespace Jinisys.Hotel.Reservation.Presentation
{
	public partial class BrowseFolioUI : Form
	{
		public BrowseFolioUI()
		{
			InitializeComponent();
		}

		private Folio selectedFolio = null;
		DataView dtvFolio;

		FolioFacade oFolioFacade = new FolioFacade();
		CompanyFacade oCompanyFacade = new CompanyFacade();
			
		private void BrowseFolioUI_Load(object sender, EventArgs e)
		{
			//oFolioFacade = new FolioFacade();
			ReservationsFacade oReservationFacade = new ReservationsFacade();

			DataTable dtFolio = oReservationFacade.GetReservationList();
			dtvFolio = dtFolio.DefaultView;

			dtvFolio.RowStateFilter = DataViewRowState.OriginalRows;
			dtvFolio.RowFilter = "Status = 'ONGOING' and FolioType <> 'GROUP'";
			dtvFolio.Sort = "FolioId desc";

			
			ScheduleFacade oScheduleFacade = new ScheduleFacade();
			GuestFacade oGuestFacade = new GuestFacade();
			Guest oGuest = new Guest();
			Company oCompany = new Company();

			foreach (DataRowView dtRow in dtvFolio)
			{

				string folioId = dtRow["folioID"].ToString();
				string companyName = "";

				string companyId = dtRow["companyId"].ToString();
				if (companyId != "" || companyId != "0")
				{
					oCompany = oCompanyFacade.getCompanyAccount(companyId);

					companyName = oCompany.CompanyName;
				}

				string fromDate = string.Format("{0:dd-MMM-yy}", DateTime.Parse(dtRow["fromdate"].ToString()));
				string todate = string.Format("{0:dd-MMM-yy}", DateTime.Parse(dtRow["todate"].ToString()));
                //jlo 8-9-10 forcibly set parameter constant to avoid possible errors
                //havent check for possible errors if not constant parameter is used because of lack of time
				string roomno = oFolioFacade.GetCurrentRoomOccupied( folioId , "INDIVIDUAL").ToString();
				string accountId = dtRow["accountid"].ToString();

				oGuest = oGuestFacade.getGuestRecord(accountId);

				DataGridViewRow row = new DataGridViewRow();
				object[] obj = { roomno, 
					            folioId, 
					            oGuest.LastName, 
					            oGuest.FirstName, 
					            oGuest.TOTAL_SALES_CONTRIBUTION, 
					            oGuest.AccountId,
								fromDate,
								todate,
							    companyName};

				row.CreateCells(this.dtgFolio, obj);

				this.dtgFolio.Rows.Add(row);

			}

			// FOR GROUP
			dtvFolio.RowStateFilter = DataViewRowState.OriginalRows;
			dtvFolio.RowFilter = "Status = 'ONGOING' and FolioType = 'GROUP'";
			dtvFolio.Sort = "FolioId desc";

			
			foreach (DataRowView dtRow in dtvFolio)
			{

				string folioId = dtRow["folioID"].ToString();
				string companyName = "";

				string companyId = dtRow["companyId"].ToString();
				if (companyId != "" || companyId != "0")
				{
					oCompany = oCompanyFacade.getCompanyAccount(companyId);

					companyName = oCompany.CompanyName;
				}

				decimal totalContribution = (decimal)oCompany.TOTAL_SALES_CONTRIBUTION; ;
				string fromDate = string.Format("{0:dd-MMM-yy}", DateTime.Parse(dtRow["fromdate"].ToString()));
				string todate = string.Format("{0:dd-MMM-yy}", DateTime.Parse(dtRow["todate"].ToString()));
				string groupName = dtRow["groupName"].ToString();
                //jlo 8-9-10 forcibly set parameter constant to avoid possible errors
                //havent check for possible errors if not constant parameter is used because of lack of time
				string roomno = oFolioFacade.GetCurrentRoomOccupied(folioId, "INDIVIDUAL").ToString();
				string accountId = dtRow["accountid"].ToString();

				string group = companyName;
				if (accountId != "")
				{
					oGuest = oGuestFacade.getGuestRecord(accountId);

					totalContribution = (decimal)oGuest.TOTAL_SALES_CONTRIBUTION;
					group = oGuest.LastName + ", " + oGuest.FirstName;
				}
				else
				{
					accountId = companyId;
				}
				
				

				DataGridViewRow row = new DataGridViewRow();
				object[] obj = { roomno, 
					            folioId, 
					            groupName, 
					            group, 
					            totalContribution,
					            accountId,
								fromDate,
								todate};

				row.CreateCells(this.dtgGroup, obj);

				this.dtgGroup.Rows.Add(row);

			}


			this.cboSearchCriteria.SelectedIndex = 0;
		}

		int curRow = 0;
		private void btnSearch_Click(object sender, EventArgs e)
		{
			deselectAll();

			int criteriaIndex = this.cboSearchCriteria.SelectedIndex;

			int row = 0;
			try
			{
				row = this.dtgFolio.CurrentRow.Index;
				if (row == 0)
					row = curRow;

				row += 1;
			}
			catch
			{ }

			for(int i = row; i < this.dtgFolio.RowCount ; i++)
			{
				string cellValue = this.dtgFolio.Rows[i].Cells[criteriaIndex].Value.ToString();
				string searchValue = this.txtSearch.Text.ToUpper();

				if (cellValue.ToUpper().Contains(searchValue))
				{

					this.dtgFolio.Rows[i].Selected = true;
					curRow = i;
					return;
				}
			}

			// only reach here if not found from CURRENT CURSOR POSITION - DOWN
			for (int i = 1; i < this.dtgFolio.RowCount; i++)
			{
				string cellValue = this.dtgFolio.Rows[i].Cells[criteriaIndex].Value.ToString();
				string searchValue = this.txtSearch.Text.ToUpper();

				if (cellValue.ToUpper().Contains(searchValue))
				{
					this.dtgFolio.Rows[i].Selected = true;
					curRow = i;
					return;
				}
			}

			//MessageBox.Show("No matching record found.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			try
			{
				this.dtgFolio.Rows[0].Selected = true;
			}
			catch { }
		}

		private void deselectAll()
		{
			int rows = this.dtgFolio.RowCount;
			for (int i = 0; i < rows; i++)
			{
				this.dtgFolio.Rows[i].Selected = false;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			
			if (mFolioType == FolioType.Individual)
			{
				string roomNo = this.dtgFolio.Rows[curRow].Cells[0].Value.ToString();
				string folioId = this.dtgFolio.Rows[curRow].Cells[1].Value.ToString();
				string lastName = this.dtgFolio.Rows[curRow].Cells[2].Value.ToString();
				string firstName = this.dtgFolio.Rows[curRow].Cells[3].Value.ToString();
				string accountId = this.dtgFolio.Rows[curRow].Cells[5].Value.ToString();

				DateTime fromDate = DateTime.Parse(this.dtgFolio.Rows[curRow].Cells[6].Value.ToString());
				DateTime toDate = DateTime.Parse(this.dtgFolio.Rows[curRow].Cells[7].Value.ToString());
				string companyName = this.dtgFolio.Rows[curRow].Cells[8].Value == null ? "" : this.dtgFolio.Rows[curRow].Cells[8].Value.ToString();

				Folio oFolio = new Folio();
				oFolio = oFolioFacade.GetFolio(folioId);
				oFolio.RoomNo = roomNo;

				oFolio.CreateSubFolio();
				SubFolio subF;
				foreach (SubFolio tempLoopVar_subF in oFolio.SubFolios)
				{
					subF = tempLoopVar_subF;
					subF.Folio.FolioTransactions = oFolioFacade.GetFolioTransactions(subF.Folio.FolioID, subF.SubFolio_Renamed);
					subF.Ledger = oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);

				}// end foreach
				try
				{
					Company oCompany = oCompanyFacade.getCompanyAccount(oFolio.CompanyID);

					oFolio.Company = oCompany;
				}
				catch { }

				selectedFolio = oFolio;

			} // end if
			else 
			{
				string roomNo = this.dtgGroup.Rows[curRowGroup].Cells[0].Value.ToString();
				string folioId = this.dtgGroup.Rows[curRowGroup].Cells[1].Value.ToString();
				Folio oFolio = new Folio();
				oFolio = oFolioFacade.GetFolio(folioId);
				oFolio.RoomNo = roomNo;
				oFolio.CreateSubFolio();
				SubFolio subF;
				foreach (SubFolio tempLoopVar_subF in oFolio.SubFolios)
				{
					subF = tempLoopVar_subF;
					subF.Folio.FolioTransactions = oFolioFacade.GetFolioTransactions(subF.Folio.FolioID, subF.SubFolio_Renamed);
					subF.Ledger = oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);

				}// end foreach

				try
				{
					Company oCompany = oCompanyFacade.getCompanyAccount(oFolio.CompanyID);

					oFolio.Company = oCompany;
				}
				catch { }

				selectedFolio = oFolio;

			} // end else

			this.Close();

		}

		public Folio showDialog(Form parent)
		{
			base.ShowDialog(parent);

			return selectedFolio;
		}

		private void dtgDrivers_DoubleClick(object sender, EventArgs e)
		{
			this.btnOK_Click(sender, e);
		}

		private void dtgDrivers_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnOK_Click(sender, e);
			}
		}

		private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnSearch_Click(sender, new EventArgs());
			}
		}

		private void dtgFolio_SelectionChanged(object sender, EventArgs e)
		{
			curRow = this.dtgFolio.CurrentRow.Index;
		}

		int curRowGroup;
		private void dtgGroup_SelectionChanged(object sender, EventArgs e)
		{
			curRowGroup = this.dtgFolio.CurrentRow.Index;
		}

		private enum FolioType { Individual, Group };
		private FolioType mFolioType = FolioType.Individual;

		private void tabFolios_SelectedIndexChanged(object sender, EventArgs e)
		{
			int _tab = this.tabFolios.SelectedIndex;

			switch (_tab)
			{ 
				case 0:
					mFolioType = FolioType.Individual;
					break;
				case 1:
					mFolioType = FolioType.Group;
					break;
			}

		}

		private void dtgGroup_DoubleClick(object sender, EventArgs e)
		{
			this.btnOK_Click(sender, e);
		}

		private void dtgGroup_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.btnOK_Click(sender, e);
			}
		}
	}
}