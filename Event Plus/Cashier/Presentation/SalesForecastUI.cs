using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Cashier.BusinessLayer;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Cashier.Presentation
{
    public partial class SalesForecastUI : Form
    {
        public SalesForecastUI()
        {
            InitializeComponent();
        }
        RoomTypeFacade oRoomTypeFacade;
        SalesForecastFacade oSalesForecastFacade;
        private void SalesForecastUI_Load(object sender, EventArgs e)
        {
			this.dtStartDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
			this.dtpEndDate.Value = this.dtStartDate.Value.AddDays(7);

            loadData();
            showSubTotals();  
        }

        private void showSubTotals()
        {
            grdSales.Tree.Column = 0;
            this.grdSales.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData;

			for (int i = 1; i < this.grdSales.Cols.Count; i++)
			{
				this.grdSales.Cols[i].DataType = typeof(System.Decimal);
				this.grdSales.Cols[i].Format = "N";

				grdSales.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, i, "Grand Total");
			}
           
            grdSales.AutoSizeCols();
        }
        private void loadData()
        {
			int _dateDiff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, dtStartDate.Value, dtpEndDate.Value);

			if (_dateDiff < 0)
				return;


			this.grdSales.Cols.Count = _dateDiff + 2;

            oRoomTypeFacade = new RoomTypeFacade();
            oSalesForecastFacade = new SalesForecastFacade();

            //ArrayList aRoomType = oRoomTypeFacade.getRoomTypesList();
			IList<RoomType> _oRoomTypeList = oRoomTypeFacade.getRoomTypesList("");

            this.grdSales.Rows.Count = _oRoomTypeList.Count + 1;
			int _row = 1;
            foreach (RoomType _oRoomType in _oRoomTypeList)
            {
				this.grdSales.SetData(_row, 0, _oRoomType.RoomTypeCode);
                
                for (int _col = 1; _col < this.grdSales.Cols.Count; _col++)
                {
					grdSales.SetData(_row, _col, "0.00");
                }

				_row++;
            }

            DateTime d = dtStartDate.Value;

            string from= dtStartDate.Value.ToString("yyyy-M-dd");
			string to = dtpEndDate.Value.ToString("yyyy-MM-dd");// dtStartDate.Value.AddDays(10).ToString("yyyy-M-dd");
			
            DataTable dTable = oSalesForecastFacade.getSalesForecast(from,to );
            for (int i = 1; i < this.grdSales.Cols.Count; i++)
            {
                this.grdSales.SetData(0, i, d.ToString("dd-MMM-yyyy"));
                d = d.AddDays(1);
            }
            
               
            for (int i = 1; i < this.grdSales.Rows.Count; i++)
            {
                foreach (DataRow dRow in dTable.Rows)
                {
                 if (dRow["RoomType"].ToString() == this.grdSales.GetDataDisplay(i, 0))
                    {
                        for (int in_col = 1; in_col < this.grdSales.Cols.Count; in_col++)
                        {
                            if (DateTime.Parse(dRow["EDate"].ToString()).ToString("dd-MMM-yyyy").Equals(this.grdSales.GetDataDisplay(0, in_col)))
                            {
                                grdSales.SetData(i, in_col, dRow["Amount"].ToString());
                            }
                        }
                    }
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void SalesForecastUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}

		private void btnView_Click(object sender, EventArgs e)
		{
			loadData();
			showSubTotals(); 
		}

      

        
      

    }
}