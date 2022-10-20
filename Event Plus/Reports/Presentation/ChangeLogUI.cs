using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;
using Jinisys.Hotel.Reports.Presentation;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class ChangeLogUI : Form
    {
        public ChangeLogUI()
        {
            InitializeComponent();
        }


        ReportFacade oReportFacade = new ReportFacade();
        DataView dtvChanges;
        private void btnView_Click(object sender, EventArgs e)
        {
            if (tabSearch.TabPages[0] == tabSearch.SelectedTab)
            {
                try
                {
                    string startDate = string.Format("{0:yyyy-MM-dd}", dtpStartDate.Value);
                    string endDate = string.Format("{0:yyyy-MM-dd}", dtpEndDate.Value);

                    DataTable dtChanges = new DataTable();

                    dtChanges = oReportFacade.getChangesLog(startDate, endDate);

                    dtvChanges = dtChanges.DefaultView;
                    dtvChanges.RowStateFilter = DataViewRowState.OriginalRows;
                    dtvChanges.RowFilter = "Terminal_Id = '" + this.nudgTerminalID.Value + "' and Shift_Code = '" + this.nudgShiftCode.Value + "'";


                    int i = 1;
                    this.grdChanges.Rows.Count = 1;
                    foreach (DataRowView dRow in dtvChanges)
                    {
                        this.grdChanges.Rows.Count += 1;

                        this.grdChanges.SetData(i, 0, dRow["Terminal_Id"].ToString());
                        this.grdChanges.SetData(i, 1, dRow["Shift_Code"].ToString());
                        this.grdChanges.SetData(i, 2, dRow["User_Id"].ToString());
                        this.grdChanges.SetData(i, 3, dRow["Supervisor_Id"].ToString());
                        this.grdChanges.SetData(i, 4, dRow["Remarks"].ToString());
                        this.grdChanges.SetData(i, 5, dRow["Table_Name"].ToString());
                        this.grdChanges.SetData(i, 6, dRow["Field_Changed"].ToString());
                        this.grdChanges.SetData(i, 7, dRow["Old_Value"].ToString());
                        this.grdChanges.SetData(i, 8, dRow["New_Value"].ToString());
                        this.grdChanges.SetData(i, 9, dRow["Date_Changed"].ToString());

                        i++;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                grdChanges.Rows.Count = 1;

                DataTable dtChanges = new DataTable();

                dtChanges = oReportFacade.searchChangesLog(txtSearchText.Text, cboSearchCriteria.Text);
                dtvChanges = dtChanges.DefaultView;
                dtvChanges.RowStateFilter = DataViewRowState.OriginalRows;

                int i = 1;
                this.grdChanges.Rows.Count = 1;
                foreach (DataRowView dRow in dtvChanges)
                {
                    this.grdChanges.Rows.Count += 1;

                    this.grdChanges.SetData(i, 0, dRow["Terminal_Id"].ToString());
                    this.grdChanges.SetData(i, 1, dRow["Shift_Code"].ToString());
                    this.grdChanges.SetData(i, 2, dRow["User_Id"].ToString());
                    this.grdChanges.SetData(i, 3, dRow["Supervisor_Id"].ToString());
                    this.grdChanges.SetData(i, 4, dRow["Remarks"].ToString());
                    this.grdChanges.SetData(i, 5, dRow["Table_Name"].ToString());
                    this.grdChanges.SetData(i, 6, dRow["Field_Changed"].ToString());
                    this.grdChanges.SetData(i, 7, dRow["Old_Value"].ToString());
                    this.grdChanges.SetData(i, 8, dRow["New_Value"].ToString());
                    this.grdChanges.SetData(i, 9, dRow["Date_Changed"].ToString());

                    i++;
                }
            }
        }

        private void ChangeLogUI_Load(object sender, EventArgs e)
        {
            this.cboFields.SelectedIndex = 0;
            this.nudgTerminalID.Value = GlobalVariables.gTerminalID;
            this.nudgShiftCode.Value = GlobalVariables.gShiftCode;

            this.btnView_Click(sender, new EventArgs());
        }

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            searchItem();
        }


        private void searchItem()
        {
            string searchVal = this.textBox1.Text;
            int col = 1;
            int start = this.grdChanges.Row + 1 ;

            col = cboFields.SelectedIndex;

            for (int i = start; i < this.grdChanges.Rows.Count;i++ )
            {
                if (col > 9)
                {
                    for (int c = 1; c < this.grdChanges.Cols.Count; c++)
                    {
                        if (this.grdChanges.GetDataDisplay(i, c).Contains(searchVal.ToUpper()))
                        {
                            this.grdChanges.Row = i;
                            return;
                        }
                    }
                }
                else
                {
                    if(this.grdChanges.GetDataDisplay(i , col).Contains( searchVal.ToUpper() ))
                    {
                        this.grdChanges.Row = i;
                        return;
                    }
                }
            }

            // if not found from SELECTED ROW
            // start from ROW 1
            start = 1;
            for (int i = start; i < this.grdChanges.Rows.Count; i++)
            {
                if (col > 9)
                {
                    for (int c = 1; c < this.grdChanges.Cols.Count; c++)
                    {
                        if (this.grdChanges.GetDataDisplay(i, c).Contains(searchVal.ToUpper()))
                        {
                            this.grdChanges.Row = i;
                            return;
                        }
                    }
                }
                else
                {
                    if (this.grdChanges.GetDataDisplay(i, col).Contains(searchVal.ToUpper()))
                    {
                        this.grdChanges.Row = i;
                        return;
                    }
                }
            }


            // if NOT FOUND
            MessageBox.Show("No matching record found.","Message", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                searchItem();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;

            string a_Startdate = string.Format("{0:MMM dd, yyyy}", this.dtpStartDate.Value);
            string a_EndDate = string.Format("{0:MMM dd, yyyy}", this.dtpEndDate.Value);


            ReportViewer oReportViewer = new ReportViewer();
            ChangeLogReport changeLogReport = new ChangeLogReport();

            changeLogReport.Database.Tables[0].SetDataSource(dtvChanges);
            changeLogReport.Database.Tables[1].SetDataSource(CrystalReportAddons.reportHeader());

            changeLogReport.SetParameterValue(0, "from " + a_Startdate + " to " + a_EndDate);

            oReportViewer.rptViewer.ReportSource = changeLogReport;
            oReportViewer.MdiParent = this.MdiParent;
            oReportViewer.Show();

            //this.Cursor = Cursors.Default;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}