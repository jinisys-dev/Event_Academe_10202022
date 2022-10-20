using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Collections;
using System.IO;

using System.Web.UI.WebControls;
using System.Web.UI;

namespace Jinisys.Hotel.Reports.Presentation
{
	public partial class DailyHotelRevenueUI : Form
	{

		public DailyHotelRevenueUI()
		{
			InitializeComponent();

			lReportFacade = new ReportFacade();
			loadDefaultColumns();

			setupGrid();


		}

		private void loadDefaultColumns()
		{

			//defaultColumns.Add("LineNo");
			defaultColumns.Add("DATE");
			defaultColumns.Add("GUESTNAME");
			defaultColumns.Add("ROOM");
			defaultColumns.Add("GROSS");
			defaultColumns.Add("VAT");
			defaultColumns.Add("LTAX");
			defaultColumns.Add("SERVCHARGE");

			defaultColumns.Add("REVENUE");
			defaultColumns.Add("REMARKS");

			defaultColumns.Add("1000"); //ROOM
			defaultColumns.Add("1201"); //Restaurant

			defaultColumns.Add("1205"); //Minibar
			defaultColumns.Add("1300"); //Bus Center
			defaultColumns.Add("1602"); //Transpo
			defaultColumns.Add("1701"); //Laundry
			defaultColumns.Add("1100"); //Telephone
			defaultColumns.Add("1001"); //Extra Bed

			defaultColumns.Add("1302"); //Car Rental
			defaultColumns.Add("1400"); //Lobby Booth
			defaultColumns.Add("1600"); //Utility
			defaultColumns.Add("1601"); //Internet

			defaultColumns.Add("1402"); //Misc
		}

		ArrayList defaultColumns = new ArrayList();

		private ReportFacade lReportFacade;
		private void HotelRevenueReportUI_Load(object sender, EventArgs e)
		{
			this.dtpStartDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
			this.dtpEndDate.Value = this.dtpStartDate.Value;
		}

		DataTable tmpTable;
		private void setupGrid()
		{
			//set columns
			this.grdHotelRevenue.Cols.Count = 10;
			this.grdHotelRevenue.Cols[0].Caption = "No.";
			this.grdHotelRevenue.Cols[0].Name = "LineNo";

			this.grdHotelRevenue.Cols[1].Caption = "DATE";
			this.grdHotelRevenue.Cols[1].Name = "DATE";

			this.grdHotelRevenue.Cols[2].Caption = "GUEST NAME";
			this.grdHotelRevenue.Cols[2].Name = "GUESTNAME";

			this.grdHotelRevenue.Cols[3].Caption = "ROOM";
			this.grdHotelRevenue.Cols[3].Name = "ROOM";

			this.grdHotelRevenue.Cols[4].Caption = "REF. Type";
			this.grdHotelRevenue.Cols[4].Name = "REFTYPE";

			this.grdHotelRevenue.Cols[5].Caption = "REF. No";
			this.grdHotelRevenue.Cols[5].Name = "REFNO";

			this.grdHotelRevenue.Cols[6].Caption = "GROSS";
			this.grdHotelRevenue.Cols[6].Name = "GROSS";

			this.grdHotelRevenue.Cols[7].Caption = "VAT";
			this.grdHotelRevenue.Cols[7].Name = "VAT";

			this.grdHotelRevenue.Cols[8].Caption = "LTAX";
			this.grdHotelRevenue.Cols[8].Name = "LTAX";

			this.grdHotelRevenue.Cols[9].Caption = "SERV. CHARGE";
			this.grdHotelRevenue.Cols[9].Name = "SERVCHARGE";



			this.grdHotelRevenue.Rows[0].Height = 35;


			//DataTable tmpTable;
			tmpTable = lReportFacade.getTransactionCodes();

			DataView _tempView = tmpTable.DefaultView;
			_tempView.RowFilter = "tranTypeID = '1'";

			int totalCols = 0;
			foreach (DataRowView row in _tempView)
			{

				totalCols = this.grdHotelRevenue.Cols.Count;
				this.grdHotelRevenue.Cols.Add();
				this.grdHotelRevenue.Cols[totalCols].Caption = row["Memo"].ToString();
				this.grdHotelRevenue.Cols[totalCols].Name = row["tranCode"].ToString();


			}

			totalCols = this.grdHotelRevenue.Cols.Count;
			//add column revenue & remarks
			this.grdHotelRevenue.Cols.Add();
			this.grdHotelRevenue.Cols[totalCols].Caption = "REVENUE";
			this.grdHotelRevenue.Cols[totalCols].Name = "REVENUE";

			this.grdHotelRevenue.Cols.Add();
			this.grdHotelRevenue.Cols[totalCols + 1].Caption = "REMARKS";
			this.grdHotelRevenue.Cols[totalCols + 1].Name = "REMARKS";

			applyReportCustomization(defaultColumns);
		}

		private void applyReportCustomization(ArrayList defaultColumns)
		{
			foreach (C1.Win.C1FlexGrid.Column gridCol in this.grdHotelRevenue.Cols)
			{
				gridCol.Visible = false;

				foreach (string col in defaultColumns)
				{
					if (gridCol.Name == col)
					{
						gridCol.Visible = true;
						break;
					}
				}
			}

		}

		private void DailyHotelRevenueUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.dtpEndDate.Value;
            DateTime endDate = this.dtpStartDate.Value;

            DataTable temp = lReportFacade.getDailyHotelRevenue(startDate, endDate);
            DataView dtView = temp.DefaultView;
            dtView.Sort = "TransactionDate, TransactionCode, GuestName";

            this.grdHotelRevenue.Rows.Count = temp.Rows.Count + 1;
            int i = 1;
            foreach (DataRowView row in dtView)
            {
                try
                {
                    decimal _amount = 0;
                    decimal _netAmount = 0;
                    decimal _mealAmount = 0;

                    decimal.TryParse(row["Amount"].ToString(), out _amount);
                    decimal.TryParse(row["NetAmount"].ToString(), out _netAmount);
                    decimal.TryParse(row["MealAmount"].ToString(), out _mealAmount);

                    string _transCode = row["transactionCode"].ToString();
                    this.grdHotelRevenue.SetData(i, _transCode, _amount);

                    if (_transCode == "1000") //1000 = room charge
                    {
                        //1201 = Restaurant
                        this.grdHotelRevenue.SetData(i, "1201", _mealAmount);
                    }

                    this.grdHotelRevenue.SetData(i, 0, i);
                    this.grdHotelRevenue.SetData(i, 1, row["TransactionDate"]);

                    this.grdHotelRevenue.SetData(i, 2, row["GuestName"]);
                    this.grdHotelRevenue.SetData(i, 3, row["RoomID"]);
                    this.grdHotelRevenue.SetData(i, 4, row["transactionSource"]);
                    this.grdHotelRevenue.SetData(i, 5, row["referenceNo"]);

                    //if (_amount > 0)
                    //{
                    this.grdHotelRevenue.SetData(i, 6, _netAmount);

                    this.grdHotelRevenue.SetData(i, 7, row["GovernmentTax"]);
                    this.grdHotelRevenue.SetData(i, 8, row["LocalTax"]);
                    this.grdHotelRevenue.SetData(i, 9, row["ServiceCharge"]);

                    this.grdHotelRevenue.SetData(i, "REVENUE", row["NetAmount"]);
                    //}
                    //else
                    //{
                    //    this.grdHotelRevenue.SetData(i, 6, (_netAmount * -1));

                    //    //this.grdHotelRevenue.SetData(i, _transCode, (_netAmount * -1));


                    //    decimal govtTax = 0;
                    //    decimal localTax = 0;
                    //    decimal serviceCharge = 0;

                    //    decimal.TryParse(row["GovernmentTax"].ToString(), out govtTax);
                    //    decimal.TryParse(row["LocalTax"].ToString(), out localTax);
                    //    decimal.TryParse(row["ServiceCharge"].ToString(), out serviceCharge);

                    //    govtTax *= -1;
                    //    localTax *= -1;
                    //    serviceCharge *= -1;
                    //    this.grdHotelRevenue.SetData(i, 7, govtTax);
                    //    this.grdHotelRevenue.SetData(i, 8, localTax);
                    //    this.grdHotelRevenue.SetData(i, 9, serviceCharge);

                    //    this.grdHotelRevenue.SetData(i, "REVENUE", (_netAmount * -1));
                    //}




                }
                catch { }

                i++;
            }

        }

		private void btnCustomize_Click(object sender, EventArgs e)
		{
			this.pnlCustomizeReport.Left = (this.Width / 2) - (this.pnlCustomizeReport.Width / 2);
			this.pnlCustomizeReport.Top = (this.Height / 2) - (this.pnlCustomizeReport.Height / 2);

			this.pnlCustomizeReport.Visible = true;


			this.lvwCustomizableFields.Items.Clear();
			foreach (C1.Win.C1FlexGrid.Column col in this.grdHotelRevenue.Cols)
			{

				ListViewItem lvwItem = new ListViewItem(col.Caption);
				lvwItem.SubItems.Add(col.Name);

				System.Windows.Forms.CheckBox chk = new System.Windows.Forms.CheckBox();
				chk.Tag = col.Name;
				chk.Text = col.Caption;

				if (col.Visible)
				{
					lvwItem.Checked = true;
				}
				else
				{
					lvwItem.Checked = false;
				}

				this.lvwCustomizableFields.Items.Add(lvwItem);

			}

		}

		private void btnClosePanel_Click(object sender, EventArgs e)
		{
			this.pnlCustomizeReport.Visible = false;
		}

		private void pnlCustomizeReport_VisibleChanged(object sender, EventArgs e)
		{
			if (pnlCustomizeReport.Visible)
			{
				this.pnlReport.Enabled = false;
			}
			else
			{
				this.pnlReport.Enabled = true;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnApplyCustomization_Click(object sender, EventArgs e)
		{
			ArrayList selectedColumns = new ArrayList();

			foreach (ListViewItem item in this.lvwCustomizableFields.Items)
			{
				if (item.Checked)
				{
					selectedColumns.Add(item.SubItems[1].Text);

				}
			}

			applyReportCustomization(selectedColumns);
			this.pnlCustomizeReport.Visible = false;
		}

		private void btnExportToExcel_Click(object sender, EventArgs e)
		{
			if (this.grdHotelRevenue.Rows.Count <= 1)
			{
				return;
			}

			try
			{
				string strFileName = "Revenue Report (" + this.dtpStartDate.Value.ToString("MMMddyyyy") + " to " + this.dtpEndDate.Value.ToString("MMMddyyyy") + ")" ;

				sfdExport.Filter = "Excel Files (*.xls)|*.xls|CSV Files (*.csv)|*.CSV";
				sfdExport.FileName = strFileName;

				if (sfdExport.ShowDialog() == DialogResult.OK)
				{
					string filelocation = sfdExport.FileName;

					DataTable reportTable = new DataTable("Revenue Report");

					//ArrayList colNames = new ArrayList();

					//get column names
					int totalCol = this.grdHotelRevenue.Cols.Count;
					int colIndex = 0;
					for (int i = 0; i < totalCol; i++)
					{

						if (this.grdHotelRevenue.Cols[i].Visible)
						{
							string columnName = this.grdHotelRevenue.GetDataDisplay(0, i);

							DataColumn col = new DataColumn(columnName);
							colIndex++;

							reportTable.Columns.Add(col);


							//string paramColName = this.grdHotelRevenue.GetDataDisplay(0, i);
							//colNames.Add(paramColName);
						}


					}


					//get row values
					int totalRow = this.grdHotelRevenue.Rows.Count;

					for (int r = 1; r < totalRow; r++)
					{
						DataRow newRow = reportTable.NewRow();
						int tempTableCol = 0;
						for (int c = 0; c < totalCol; c++)
						{

							if (this.grdHotelRevenue.Cols[c].Visible)
							{
								newRow[tempTableCol] = this.grdHotelRevenue.GetDataDisplay(r, c);
								tempTableCol++;
							}
						}

						reportTable.Rows.Add(newRow);
					}


					System.Web.UI.WebControls.DataGrid grid = new System.Web.UI.WebControls.DataGrid();
					grid.HeaderStyle.Font.Bold = true;
					grid.DataSource = reportTable;

					grid.DataBind();
					
					// render the DataGrid control to a file
					using (StreamWriter sw = new StreamWriter(filelocation))
					{
						using (HtmlTextWriter hw = new HtmlTextWriter(sw))
						{
							grid.RenderControl(hw);
						}
					}

					MessageBox.Show("Export successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		}

		//public DailyHotelRevenueUI()
		//{
		//    InitializeComponent();

		//    lReportFacade = new ReportFacade();
		//    loadDefaultColumns();

		//    setupGrid();


		//}

		//private void loadDefaultColumns()
		//{

		//    //defaultColumns.Add("LineNo");
		//    defaultColumns.Add("DATE");
		//    defaultColumns.Add("GUESTNAME");
		//    defaultColumns.Add("ROOM");
		//    defaultColumns.Add("GROSS");
		//    defaultColumns.Add("VAT");
		//    defaultColumns.Add("LTAX");
		//    defaultColumns.Add("SERVCHARGE");

		//    defaultColumns.Add("REVENUE");
		//    defaultColumns.Add("REMARKS");

		//    defaultColumns.Add("1000"); //ROOM
		//    defaultColumns.Add("1201"); //Restaurant

		//    defaultColumns.Add("1205"); //Minibar
		//    defaultColumns.Add("1300"); //Bus Center
		//    defaultColumns.Add("1602"); //Transpo
		//    defaultColumns.Add("1701"); //Laundry
		//    defaultColumns.Add("1100"); //Telephone
		//    defaultColumns.Add("1001"); //Extra Bed
		//    defaultColumns.Add("1402"); //Misc
		//    defaultColumns.Add("1600"); //Utility
		//    defaultColumns.Add("1601"); //Internet
		//    defaultColumns.Add("1400"); //Lobby Booth

		//}

		//ArrayList defaultColumns = new ArrayList();

		//private ReportFacade lReportFacade;
		//private void HotelRevenueReportUI_Load(object sender, EventArgs e)
		//{
		//    this.dtpStartDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
		//    this.dtpEndDate.Value = this.dtpStartDate.Value;
		//}

		//DataTable tmpTable;
		//private void setupGrid()
		//{
		//    //set columns
		//    this.grdHotelRevenue.Cols.Count = 10;
		//    this.grdHotelRevenue.Cols[0].Caption = "No.";
		//    this.grdHotelRevenue.Cols[0].Name = "LineNo";

		//    this.grdHotelRevenue.Cols[1].Caption = "DATE";
		//    this.grdHotelRevenue.Cols[1].Name = "DATE";

		//    this.grdHotelRevenue.Cols[2].Caption = "GUEST NAME";
		//    this.grdHotelRevenue.Cols[2].Name = "GUESTNAME";

		//    this.grdHotelRevenue.Cols[3].Caption = "ROOM";
		//    this.grdHotelRevenue.Cols[3].Name = "ROOM";

		//    this.grdHotelRevenue.Cols[4].Caption = "REF. Type";
		//    this.grdHotelRevenue.Cols[4].Name = "REFTYPE";

		//    this.grdHotelRevenue.Cols[5].Caption = "REF. No";
		//    this.grdHotelRevenue.Cols[5].Name = "REFNO";

		//    this.grdHotelRevenue.Cols[6].Caption = "GROSS";
		//    this.grdHotelRevenue.Cols[6].Name = "GROSS";

		//    this.grdHotelRevenue.Cols[7].Caption = "VAT";
		//    this.grdHotelRevenue.Cols[7].Name = "VAT";

		//    this.grdHotelRevenue.Cols[8].Caption = "LTAX";
		//    this.grdHotelRevenue.Cols[8].Name = "LTAX";

		//    this.grdHotelRevenue.Cols[9].Caption = "SERV. CHARGE";
		//    this.grdHotelRevenue.Cols[9].Name = "SERVCHARGE";



		//    this.grdHotelRevenue.Rows[0].Height = 35;


		//    //DataTable tmpTable;
		//    tmpTable = lReportFacade.getTransactionCodes();

		//    DataView _tempView = tmpTable.DefaultView;
		//    _tempView.RowFilter = "tranTypeID = '1'";

		//    int totalCols = 0;
		//    foreach (DataRowView row in _tempView)
		//    {

		//        totalCols = this.grdHotelRevenue.Cols.Count;
		//        this.grdHotelRevenue.Cols.Add();
		//        this.grdHotelRevenue.Cols[totalCols].Caption = row["Memo"].ToString();
		//        this.grdHotelRevenue.Cols[totalCols].Name = row["tranCode"].ToString();


		//    }

		//    totalCols = this.grdHotelRevenue.Cols.Count;
		//    //add column revenue & remarks
		//    this.grdHotelRevenue.Cols.Add();
		//    this.grdHotelRevenue.Cols[totalCols].Caption = "REVENUE";
		//    this.grdHotelRevenue.Cols[totalCols].Name = "REVENUE";

		//    this.grdHotelRevenue.Cols.Add();
		//    this.grdHotelRevenue.Cols[totalCols + 1].Caption = "REMARKS";
		//    this.grdHotelRevenue.Cols[totalCols + 1].Name = "REMARKS";

		//    applyReportCustomization(defaultColumns);
		//}

		//private void applyReportCustomization(ArrayList defaultColumns)
		//{
		//    foreach (C1.Win.C1FlexGrid.Column gridCol in this.grdHotelRevenue.Cols)
		//    {
		//        gridCol.Visible = false;

		//        foreach (string col in defaultColumns)
		//        {
		//            if (gridCol.Name == col)
		//            {
		//                ////check if all rows in this column doesnt have a value
		//                //bool hasRowValue = false;
		//                //for (int i = 0; i < grdHotelRevenue.Rows.Count; i++)
		//                //{
		//                //    if (this.grdHotelRevenue.GetDataDisplay(i, col) != "")
		//                //    {
		//                //        hasRowValue = true;
		//                //        //break;
		//                //    }
		//                //}

		//                //if (!hasRowValue)
		//                //{
		//                    gridCol.Visible = true;
		//                    break;
		//                //}
		//            }
		//        }
		//    }

		//}

		//private void DailyHotelRevenueUI_Activated(object sender, EventArgs e)
		//{
		//    this.WindowState = FormWindowState.Maximized;
		//}

		//private void btnShow_Click(object sender, EventArgs e)
		//{
		//    this.Cursor = Cursors.WaitCursor;

		//    DateTime startDate = this.dtpEndDate.Value;
		//    DateTime endDate = this.dtpStartDate.Value;

		//    DataTable temp = lReportFacade.getDailyHotelRevenue(startDate, endDate);
		//    DataView dtView = temp.DefaultView;
		//    dtView.Sort = "TransactionDate, TransactionCode, GuestName";

		//    this.grdHotelRevenue.Rows.Count = temp.Rows.Count + 1;
		//    int i = 1;
		//    foreach (DataRowView row in dtView)
		//    {
		//        try
		//        {
		//            decimal _amount = 0;
		//            decimal _netAmount = 0;
		//            decimal _mealAmount = 0;

		//            decimal.TryParse(row["Amount"].ToString(), out _amount);
		//            decimal.TryParse(row["NetAmount"].ToString(), out _netAmount);
		//            decimal.TryParse(row["MealAmount"].ToString(), out _mealAmount);

		//            string _transCode = row["transactionCode"].ToString();
		//            this.grdHotelRevenue.SetData(i, _transCode, _amount);

		//            if (_transCode == "1000") //1000 = room charge
		//            {
		//                //1201 = Restaurant
		//                this.grdHotelRevenue.SetData(i, "1201", _mealAmount);
		//            }

		//            this.grdHotelRevenue.SetData(i, 0, i);
		//            this.grdHotelRevenue.SetData(i, 1, row["TransactionDate"]);

		//            this.grdHotelRevenue.SetData(i, 2, row["GuestName"]);
		//            this.grdHotelRevenue.SetData(i, 3, row["RoomID"]);
		//            this.grdHotelRevenue.SetData(i, 4, row["transactionSource"]);
		//            this.grdHotelRevenue.SetData(i, 5, row["referenceNo"]);
					


		//            if (_amount > 0)
		//            {
		//                this.grdHotelRevenue.SetData(i, 6, _netAmount);

		//                this.grdHotelRevenue.SetData(i, 7, row["GovernmentTax"]);
		//                this.grdHotelRevenue.SetData(i, 8, row["LocalTax"]);
		//                this.grdHotelRevenue.SetData(i, 9, row["ServiceCharge"]);

		//                this.grdHotelRevenue.SetData(i, "REVENUE", row["NetAmount"]);
		//            }
		//            else
		//            {
		//                this.grdHotelRevenue.SetData(i, 6, (_netAmount * -1));

		//                this.grdHotelRevenue.SetData(i, _transCode, (_netAmount * -1));

		//                this.grdHotelRevenue.SetData(i, 7, "0.00");
		//                this.grdHotelRevenue.SetData(i, 8, "0.00");
		//                this.grdHotelRevenue.SetData(i, 9, "0.00");

		//                this.grdHotelRevenue.SetData(i, "REVENUE", (_netAmount * -1));
		//            }




		//        }
		//        catch 
		//        {
		//        }

		//        i++;
		//    }

		//    this.Cursor = Cursors.Default;
		//}

		//private void btnCustomize_Click(object sender, EventArgs e)
		//{
		//    this.pnlCustomizeReport.Left = (this.Width / 2) - (this.pnlCustomizeReport.Width / 2);
		//    this.pnlCustomizeReport.Top = (this.Height / 2) - (this.pnlCustomizeReport.Height / 2);

		//    this.pnlCustomizeReport.Visible = true;


		//    this.lvwCustomizableFields.Items.Clear();
		//    foreach (C1.Win.C1FlexGrid.Column col in this.grdHotelRevenue.Cols)
		//    {

		//        ListViewItem lvwItem = new ListViewItem(col.Caption);
		//        lvwItem.SubItems.Add(col.Name);

		//        System.Windows.Forms.CheckBox chk = new System.Windows.Forms.CheckBox();
		//        chk.Tag = col.Name;
		//        chk.Text = col.Caption;

		//        if (col.Visible)
		//        {
		//            lvwItem.Checked = true;
		//        }
		//        else
		//        {
		//            lvwItem.Checked = false;
		//        }

		//        this.lvwCustomizableFields.Items.Add(lvwItem);

		//    }

		//}

		//private void btnClosePanel_Click(object sender, EventArgs e)
		//{
		//    this.pnlCustomizeReport.Visible = false;
		//}

		//private void pnlCustomizeReport_VisibleChanged(object sender, EventArgs e)
		//{
		//    if (pnlCustomizeReport.Visible)
		//    {
		//        this.pnlReport.Enabled = false;
		//    }
		//    else
		//    {
		//        this.pnlReport.Enabled = true;
		//    }
		//}

		//private void btnClose_Click(object sender, EventArgs e)
		//{
		//    this.Close();
		//}

		//private void btnApplyCustomization_Click(object sender, EventArgs e)
		//{
		//    ArrayList selectedColumns = new ArrayList();

		//    foreach (ListViewItem item in this.lvwCustomizableFields.Items)
		//    {
		//        if (item.Checked)
		//        {
		//            selectedColumns.Add(item.SubItems[1].Text);

		//        }
		//    }

		//    applyReportCustomization(selectedColumns);
		//    this.pnlCustomizeReport.Visible = false;
		//}

		//private void btnExportToExcel_Click(object sender, EventArgs e)
		//{
		//    if (this.grdHotelRevenue.Rows.Count <= 1)
		//    {
		//        return;
		//    }

		//    try
		//    {
		//        sfdExport.Filter = "Excel Files (*.xls)|*.XLS|CSV Files (*.csv)|*.CSV";
		//        sfdExport.FileName = "Revenue Report from " + this.dtpStartDate.Value.ToString("MMMddyyyy") + " to " + this.dtpEndDate.Value.ToString("MMMddyyyy");

		//        if (sfdExport.ShowDialog() == DialogResult.OK)
		//        {
		//            string filelocation = sfdExport.FileName;

		//            DataTable reportTable = new DataTable("Revenue Report");

		//            //ArrayList colNames = new ArrayList();

		//            //get column names
		//            int totalCol = this.grdHotelRevenue.Cols.Count;
		//            int colIndex = 0;
		//            for (int i = 0; i < totalCol; i++)
		//            {

		//                if (this.grdHotelRevenue.Cols[i].Visible)
		//                {
		//                    string columnName = this.grdHotelRevenue.GetDataDisplay(0, i);

		//                    DataColumn col = new DataColumn(columnName);
		//                    colIndex++;

		//                    reportTable.Columns.Add(col);


		//                    //string paramColName = this.grdHotelRevenue.GetDataDisplay(0, i);
		//                    //colNames.Add(paramColName);
		//                }


		//            }


		//            //get row values
		//            int totalRow = this.grdHotelRevenue.Rows.Count;

		//            for (int r = 1; r < totalRow; r++)
		//            {
		//                DataRow newRow = reportTable.NewRow();
		//                int tempTableCol = 0;
		//                for (int c = 0; c < totalCol; c++)
		//                {

		//                    if (this.grdHotelRevenue.Cols[c].Visible)
		//                    {
		//                        newRow[tempTableCol] = this.grdHotelRevenue.GetDataDisplay(r, c);
		//                        tempTableCol++;
		//                    }
		//                }

		//                reportTable.Rows.Add(newRow);
		//            }

		//            // create the DataGrid and perform the databinding
		//            System.Web.UI.WebControls.DataGrid grid = new System.Web.UI.WebControls.DataGrid();
		//            grid.HeaderStyle.Font.Bold = true;
		//            grid.DataSource = reportTable;

		//            grid.DataBind();

		//            // render the DataGrid control to a file
		//            using (StreamWriter sw = new StreamWriter(filelocation))
		//            {
		//                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
		//                {
		//                    grid.RenderControl(hw);
		//                }
		//            }

		//            MessageBox.Show("Export successful.","Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//        }
		//    }
		//    catch(Exception ex)
		//    {
		//        MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//        return;
		//    }
		//}


	}
}