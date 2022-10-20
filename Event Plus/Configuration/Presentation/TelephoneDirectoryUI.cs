using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	public partial class TelephoneDirectoryUI : Form
	{
		public TelephoneDirectoryUI()
		{
			InitializeComponent();

			
			imgTel = imgIcons.Images[0];
			imgCP = imgIcons.Images[1];
			imgOthers = imgIcons.Images[2];

		}

		Image imgCP = null;
		Image imgTel = null;
		Image imgOthers = null;
		private void TelephoneDirectoryUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		ContactFacade lContactFacade = null;
		private void TelephoneDirectoryUI_Load(object sender, EventArgs e)
		{
			loadData();
		}

		private void loadData()
		{
			lContactFacade = new ContactFacade();

			DataTable _temp = lContactFacade.loadContacts();

			//this.grdContacts.DataSource = _temp;
			this.grdContacts.Rows.Count = _temp.Rows.Count + 1;
			int i = 1;
			foreach (DataRow _dRow in _temp.Rows)
			{
				Image img = null;

				this.grdContacts.SetData(i, 0, i);
				string _contactType = _dRow["contactType"].ToString();

				switch (_contactType)
				{
					case "TELEPHONE":
					case "FAX":
						img = imgTel;
						break;
					case "MOBILE":
						img = imgCP;
						break;
					default:
						img = imgOthers;
						break;
				}

				this.grdContacts.SetCellImage(i, 1, img);


				this.grdContacts.SetData(i, 2, _dRow["contactNumber"]);
				this.grdContacts.SetData(i, 3, _dRow["contactName"]);
				this.grdContacts.SetData(i, 4, _dRow["company"]);
				this.grdContacts.SetData(i, 5, _dRow["id"]);

				i++;
			}
		}

		private void btnAddNew_Click(object sender, EventArgs e)
		{
			ContactsUI contactUI = new ContactsUI();
			contactUI.ShowDialog();

			loadData();
		}

		private void grdContacts_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				int _row = grdContacts.Row;
				if (_row <= 0)
					return;

				string _str = this.grdContacts.GetDataDisplay(_row, 5);
				int _id = int.Parse(_str);

				ContactsUI contactsUI = new ContactsUI(_id);
				contactsUI.ShowDialog();


				loadData();

			}
			catch { }


		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			grdContacts_DoubleClick(sender, e);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				int _row = this.grdContacts.Row;
				if (_row <= 0)
				{ 
					return;
				}

				string _contactName = this.grdContacts.GetDataDisplay(_row, 3);
				
				DialogResult rsp = MessageBox.Show("Are you sure you want to remove Contact " + _contactName + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (rsp == DialogResult.Yes)
				{
					try
					{
						//>> remove Contact from database
						int _contactId = int.Parse(this.grdContacts.GetDataDisplay(_row, 5));
						lContactFacade = new ContactFacade();
						lContactFacade.deleteContact(_contactId);

						this.grdContacts.RemoveItem(_row);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch { }
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			int _startRow = this.grdContacts.Row;
			string _searchText = this.txtSearch.Text;
			_searchText = _searchText.ToUpper();

			if (_searchText.Trim().Length > 0)
			{
				
				while (_startRow < this.grdContacts.Rows.Count)
				{
					
					string _contactNum = this.grdContacts.GetDataDisplay(_startRow, 2);
					string _contactName = this.grdContacts.GetDataDisplay(_startRow, 3);
					string _companyName = this.grdContacts.GetDataDisplay(_startRow, 4);

					if (_contactNum.StartsWith(_searchText) ||
					   _contactName.StartsWith(_searchText) ||
					   _companyName.StartsWith(_searchText))
					{
						this.grdContacts.Row = _startRow;
						return;
					}

					_startRow++;
				}


				_startRow = 0;
				while (_startRow < this.grdContacts.Rows.Count)
				{

					string _contactNum = this.grdContacts.GetDataDisplay(_startRow, 2);
					string _contactName = this.grdContacts.GetDataDisplay(_startRow, 3);
					string _companyName = this.grdContacts.GetDataDisplay(_startRow, 4);

					if (_contactNum.StartsWith(_searchText) ||
					   _contactName.StartsWith(_searchText) ||
					   _companyName.StartsWith(_searchText))
					{
						this.grdContacts.Row = _startRow;
						return;
					}
					_startRow++;
				}


			}
		}


	}
}