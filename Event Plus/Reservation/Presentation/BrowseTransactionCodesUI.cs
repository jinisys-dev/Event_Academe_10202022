using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.Reservation.Presentation
{
	public partial class BrowseTransactionCodesUI : Form
	{
		public BrowseTransactionCodesUI()
		{
			InitializeComponent();
		}

		private C1.Win.C1FlexGrid.C1FlexGrid vsGrid;
		private string strCondition = "";
		private DateTime lFromDate;
		private DateTime lToDate;
		public BrowseTransactionCodesUI(ref C1.Win.C1FlexGrid.C1FlexGrid grid,string condition, DateTime pFromDate, DateTime pToDate)
		{
			InitializeComponent();


			vsGrid = grid;
			strCondition = condition;

			//if (pFromDate != null)
				lFromDate = pFromDate;

			//if (pToDate != null)
				lToDate = pToDate;
		}

		private void BrowseTransactionCodesUI_Load(object sender, EventArgs e)
		{
			loadTransactionCodes();
		}

		private void loadTransactionCodes()
		{
			try
			{
				TransactionCodeFacade oTransactionCodesDAO = new TransactionCodeFacade();
				DataSet ds = (DataSet)oTransactionCodesDAO.loadObject();

				DataView dtView = ds.Tables[0].DefaultView;
				dtView.RowStateFilter = DataViewRowState.OriginalRows;
				dtView.RowFilter = strCondition;


				int i = 1;
				this.gridTransactionCodes.Rows = dtView.Count + 1;

				foreach (DataRowView dtrView in dtView)
				{


					gridTransactionCodes.set_TextMatrix(i, 0, dtrView["trancode"].ToString());
					gridTransactionCodes.set_TextMatrix(i, 1, dtrView["memo"].ToString());

					i++;
				}
			}
			catch { }
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void gridTransactionCodes_DoubleClick(object sender, EventArgs e)
		{
			int row = 1;

			try
			{
				row = this.gridTransactionCodes.Row;


				string tranCode = this.gridTransactionCodes.get_TextMatrix(row,0);
				string memo = this.gridTransactionCodes.get_TextMatrix(row,1);

				vsGrid.Rows.Count += 1;
				int lastRow = vsGrid.Rows.Count - 1;
				
				vsGrid.SetData(lastRow, 0, tranCode);
				vsGrid.SetData(lastRow, 1, memo);
				vsGrid.SetData(lastRow, 2, "P");

				vsGrid.SetData(lastRow, 3, 0);
				vsGrid.SetData(lastRow, 4, 0);

				vsGrid.SetData(lastRow, 3, lFromDate);
				vsGrid.SetData(lastRow, 4, lToDate.AddDays(-1));


				this.gridTransactionCodes.RemoveItem(row);
			}
			catch
			{ }
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			this.gridTransactionCodes_DoubleClick(sender, e);
		}


	}
}