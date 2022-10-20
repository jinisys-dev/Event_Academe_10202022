using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reports.Presentation
{
	public partial class RoomRevenueUI : Form
	{
		public RoomRevenueUI()
		{
			InitializeComponent();
		}

		private void RoomRevenueUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			this.cboViewType.SelectedIndex = 0;
		}

		private void RoomRevenueUI_Load(object sender, EventArgs e)
		{

			ReportFacade oReportFacade = new ReportFacade();
			DataTable dtRooms = oReportFacade.getRooms();

			
			DataView dtvRooms = dtRooms.DefaultView;
			dtvRooms.Sort = "RoomTypeCode desc";


			this.grdRooms.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
			this.grdRooms.Cols[0].AllowMerging = true;

			this.grdRooms.Rows.Count = dtvRooms.Count + 1;
			int i = 1;

			foreach (DataRowView dtRowView in dtvRooms)
			{
				string _roomTypeCode = dtRowView["RoomTypeCode"].ToString();

				this.grdRooms.SetData(i, 0, _roomTypeCode);
				this.grdRooms.SetData(i, 1, "~" + dtRowView["RoomId"]);

				i++;
			}

			this.dtpFromDate.Value = DateTime.Parse(GlobalVariables.gAuditDate);
			this.dtpToDate.Value = this.dtpFromDate.Value.AddDays(7);
		}

		private ReportFacade loReportFacade;
		private void btnView_Click(object sender, EventArgs e)
		{
			loReportFacade = new ReportFacade();

			this.grdRooms.Cols.Count = 2;

			string _dateFormat = "dd-MMM-yyyy";
			int _diff = 0;

			switch (this.cboViewType.SelectedIndex)
			{ 
				case 0:
					_dateFormat = "dd-MMM-yyyy";

					_diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, this.dtpFromDate.Value.Date, this.dtpToDate.Value.Date);
					_diff++;
					
					this.grdRooms.Cols.Count = _diff + 2;
					for (int i = 0; i < _diff; i++)
					{
						this.grdRooms.SetData(0, i+2, this.dtpFromDate.Value.AddDays(i).ToString(_dateFormat));

						DataTable _dtTemp = loReportFacade.getRoomRevenuePerDay(this.dtpFromDate.Value.AddDays(i).ToString("yyyy-MM-dd"));


						foreach (DataRow _dRow in _dtTemp.Rows)
						{
							for (int c = 1; c < this.grdRooms.Rows.Count; c++)
							{
								if (("~" + _dRow["roomId"].ToString()) == this.grdRooms.GetDataDisplay(c, 1))
								{
									this.grdRooms.SetData(c,i+2,_dRow["RoomRevenue"]);
								}
							}
						}

					}

					break;

				case 1:
					_dateFormat = "MMM-yyyy";

					_diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Month, this.dtpFromDate.Value.Date, this.dtpToDate.Value.Date);
					_diff++;

					this.grdRooms.Cols.Count = _diff + 2;
					for (int i = 0; i < _diff; i++)
					{
						this.grdRooms.SetData(0, i + 2, this.dtpFromDate.Value.AddMonths(i).ToString(_dateFormat));

						int _month = this.dtpFromDate.Value.AddMonths(i).Month;
						int _year = this.dtpFromDate.Value.AddMonths(i).Year;

						DataTable _dtTemp = loReportFacade.getRoomRevenuePerMonth(_month, _year);

						foreach (DataRow _dRow in _dtTemp.Rows)
						{
							for (int c = 1; c < this.grdRooms.Rows.Count; c++)
							{
								if (("~" + _dRow["roomId"].ToString()) == this.grdRooms.GetDataDisplay(c, 1))
								{
									this.grdRooms.SetData(c, i + 2, _dRow["RoomRevenue"]);
								}
							}
						}

					}


					break;
				case 2:
					_dateFormat = "yyyy";

					_diff = (int)DateTimeClass.DateDiff(DateTimeClass.DateInterval.Year, this.dtpFromDate.Value.Date, this.dtpToDate.Value.Date);
					_diff++;

					this.grdRooms.Cols.Count = _diff + 2;
					for (int i = 0; i < _diff; i++)
					{
						this.grdRooms.SetData(0, i + 2, this.dtpFromDate.Value.AddYears(i).ToString(_dateFormat));

						int _year = this.dtpFromDate.Value.AddYears(i).Year;
						DataTable _dtTemp = loReportFacade.getRoomRevenuePerYear(_year);

						foreach (DataRow _dRow in _dtTemp.Rows)
						{
							for (int c = 1; c < this.grdRooms.Rows.Count; c++)
							{
								if (("~" + _dRow["roomId"].ToString()) == this.grdRooms.GetDataDisplay(c, 1))
								{
									this.grdRooms.SetData(c, i + 2, _dRow["RoomRevenue"]);
								}
							}
						}

					}


					break;
			}




			for (int _col = 2; _col < this.grdRooms.Cols.Count; _col++)
			{
				this.grdRooms.Cols[_col].DataType = typeof(System.Decimal);
				this.grdRooms.Cols[_col].Format = "N";
			}

			showSubTotals();

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void showSubTotals()
		{
			this.grdRooms.Tree.Column = 0;
			this.grdRooms.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData;

			for (int i = 1; i < this.grdRooms.Cols.Count; i++)
			{
				this.grdRooms.Cols[i].DataType = typeof(System.Decimal);
				this.grdRooms.Cols[i].Format = "N";

				this.grdRooms.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, -1, -1, i, "GRAND TOTAL : ");
				this.grdRooms.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 0, i, "TOTAL : ");
			}

			grdRooms.AutoSizeCols();
		}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // pass datatable to report document
            switch (cboViewType.SelectedIndex)
            {
                case 0:
                    string _StartDate = string.Format("{0:yyyy-MM-dd}", this.dtpFromDate.Value);
                    string _endDate = string.Format("{0:yyyy-MM-dd}", this.dtpToDate.Value);

                    ReportFacade oReportFacade = new ReportFacade();
                    ReportViewer rptViewerUI = new ReportViewer();
                    rptViewerUI.rptViewer.ReportSource = oReportFacade.getRoomRevenuePerDayReport(_StartDate, _endDate);
                    rptViewerUI.MdiParent = this.MdiParent;
                    rptViewerUI.Show();
                    break;
            }
        }
	}
}