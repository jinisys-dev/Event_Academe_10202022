using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

using System.Collections;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class RateType_Inquiry : Form
    {
        public RateType_Inquiry()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private FolioFacade oFolioFacade;
        private DataView dtView;
        private void RateType_Inquiry_Load(object sender, EventArgs e)
        {
            oFolioFacade = new FolioFacade();
            ArrayList arrRateTypes = oFolioFacade.getRateTypesForInquiry();

            this.gridRateTypes.Rows = 1;
            int i = 1;
            foreach (DataRow dRow in arrRateTypes)
            {
                
                this.gridRateTypes.Rows += 1;

                this.gridRateTypes.set_TextMatrix(i,0,dRow["roomtypecode"].ToString());
                this.gridRateTypes.set_TextMatrix(i, 1, dRow["ratecode"].ToString());

                decimal rate = decimal.Parse(dRow["rateamount"].ToString());
                this.gridRateTypes.set_TextMatrix(i, 2, rate.ToString("N"));

                i++;
            }

        }

        private void gridRateTypes_Click(object sender, EventArgs e)
        {
            if (gridRateTypes.Col == 3)
            { 
                this.gridRateTypes.EditCell();
            }
        }

        string whereCondition = "";
        string paramRateCodes = "";
        string paramDateRange = "";
        private void btnView_Click(object sender, EventArgs e)
        {
            //this.MdiParent.Cursor = Cursors.WaitCursor;

            paramDateRange = "from  " + string.Format("{0:MMM dd, yyyy}",this.dtpStartDate.Value) + "   to   " + string.Format("{0:MMM dd, yyyy}",this.dtpEndDate.Value);
            paramRateCodes = "";

            oFolioFacade = new FolioFacade();
            dtView = oFolioFacade.getRoomHistory().DefaultView;


            whereCondition = "";
            int i = 1;
            int rows = this.gridRateTypes.Rows;

            for (i = 1; i < rows; i++)
            {
                C1.Win.C1FlexGrid.CheckEnum chkNum = this.gridRateTypes.GetCellCheck(i, 3);
                if(chkNum == C1.Win.C1FlexGrid.CheckEnum.Checked)
                //string isChecked = this.gridRateTypes.get_TextMatrix(_ctr, 3);
                //if (isChecked != "")
                //{
                {
                    string _roomType = this.gridRateTypes.get_TextMatrix(i, 0); 
                    string _rateType = this.gridRateTypes.get_TextMatrix(i, 1);

                    paramRateCodes += _roomType + "-" + _rateType + "\r\n";
                    whereCondition += "(RoomType = '" + _roomType + "' and RateType = '" + _rateType + "') or ";
                }
            }

            try
            {
                whereCondition = whereCondition.Substring(0, whereCondition.Length - 3);
            }
            catch
            {
                MessageBox.Show("Please select rate types from list.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.gridList.Focus();
                return;
            }

            //whereCondition += " and (FromDate >= '"+ this.dtpStartDate.Value + "' and ToDate <= '" + this.dtpEndDate.Value + "')";

            dtView.RowFilter = whereCondition;

            this.gridList.Rows.Count = 1;
            i = 1;
            foreach (DataRowView dtRowView in dtView)
            {
                DateTime _fromDate = DateTime.Parse(dtRowView["FromDate"].ToString());
                string _strFromDate = string.Format("{0:MM/dd/yyyy}",_fromDate);
                DateTime _toDate = DateTime.Parse(dtRowView["ToDate"].ToString());
                string _strToDate = string.Format("{0:MM/dd/yyyy}",_toDate);

                decimal _rate = decimal.Parse(dtRowView["Rate"].ToString());

                if (_fromDate.Date >= this.dtpStartDate.Value.Date && _toDate.Date <= this.dtpEndDate.Value.Date)
                {
                    this.gridList.Rows.Count += 1;

                    this.gridList.SetData(i, 0, dtRowView["RoomId"].ToString());
                    this.gridList.SetData(i, 1, dtRowView["GuestsName"].ToString());

                    this.gridList.SetData(i, 2, _strFromDate);
                    this.gridList.SetData(i, 3, _strToDate);

                    this.gridList.SetData(i, 4, dtRowView["RoomType"].ToString());
                    this.gridList.SetData(i, 5, dtRowView["RateType"].ToString());
                    this.gridList.SetData(i, 6, _rate.ToString("N"));

                    this.gridList.SetData(i, 7, dtRowView["Status"].ToString());
                    this.gridList.SetData(i, 8, dtRowView["FolioId"].ToString());

                    this.gridList.SetData(i, 9, dtRowView["Remarks"].ToString());

                    i++;
                }
            }

            this.MdiParent.Cursor = Cursors.Default;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnView_Click(sender, e);

            DataTable dtReport = new DataTable();
            dtReport.Columns.Add("RoomId");
            dtReport.Columns.Add("GuestsName");
            dtReport.Columns.Add("FromDate", typeof(System.DateTime));
            dtReport.Columns.Add("ToDate", typeof(System.DateTime));
            dtReport.Columns.Add("RoomType");
            dtReport.Columns.Add("RateType");
            dtReport.Columns.Add("Rate", typeof(System.Double));
            dtReport.Columns.Add("Status");
            dtReport.Columns.Add("FolioId");
            dtReport.Columns.Add("Remarks");


            int row = this.gridList.Rows.Count;
            for (int i = 1; i < row; i++)
            {
                DataRow newRow = dtReport.NewRow();
                newRow["RoomId"] = this.gridList.GetData(i, 0).ToString();
                newRow["GuestsName"] = this.gridList.GetData(i, 1).ToString();
                newRow["FromDate"] = this.gridList.GetData(i, 2).ToString();
                newRow["ToDate"] = this.gridList.GetData(i, 3).ToString();
                newRow["RoomType"] = this.gridList.GetData(i, 4).ToString();
                newRow["RateType"] = this.gridList.GetData(i, 5).ToString();
                newRow["Rate"] = this.gridList.GetData(i, 6).ToString();
                newRow["Status"] = this.gridList.GetData(i, 7).ToString();
                newRow["FolioId"] = this.gridList.GetData(i, 8).ToString();
                newRow["Remarks"] = this.gridList.GetData(i, 9).ToString();

                dtReport.Rows.Add(newRow);

            }


            Reports.Presentation.Report_Documents.Audit.GuestListByRateCode rptDoc = new Reports.Presentation.Report_Documents.Audit.GuestListByRateCode();
            rptDoc.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

            rptDoc.Database.Tables[0].SetDataSource(dtReport);
            rptDoc.SetParameterValue(0, paramDateRange);
            rptDoc.SetParameterValue(1, paramRateCodes);



            ReportViewer viewReport = new ReportViewer();
            viewReport.MdiParent = this.MdiParent;
            viewReport.rptViewer.ReportSource = rptDoc;
            viewReport.Show();
        }

        private void gridList_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                string folioId = this.gridList.GetData(this.gridList.Row, 8).ToString();

                viewFolioDetails(folioId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Description: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

    }
}