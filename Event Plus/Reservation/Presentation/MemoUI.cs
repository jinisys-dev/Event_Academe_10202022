using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using C1.Win;
using C1.Win.C1FlexGrid;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class MemoUI : Form
    {
        public MemoUI()
        {
            InitializeComponent();
        }
        private string lFolioID;
        private DataTable pRecipients;
        private EventFacade lEventFacade;

       
        public MemoUI(string pFolioID)
        {
            lFolioID = pFolioID;
            InitializeComponent();
        }

        private void MemoUI_Load(object sender, EventArgs e)
        {
            lEventFacade = new EventFacade();
             MemoUI_Load();
        }

        private void MemoUI_Load()
        {
            dtpFrom.Text = Convert.ToString(DateTime.Now.Subtract(new TimeSpan(6, 0, 0, 0)));
            setSearchChange(); //loadSystemAmendments();
            loadMemoRecipients();
            setDataFields();
        }
        private  void setDataFields()
        {
            txtControlNo.Text = lFolioID;  
        }
        private void loadMemoRecipients()
        {
            try
            {
                pRecipients = lEventFacade.getMemoRecipients();
                grdMemoFor.DataSource = pRecipients;
            }
            catch
            {
            }
        }
        private void loadSystemAmendments()
        {
            grdSystemChanges.Rows.Count = 1;
            ReportFacade _oReportFacade = new ReportFacade();
            DataTable _dtTable = _oReportFacade.searchChangesLog(lFolioID, "remarks");
            DataView _dtView = _dtTable.DefaultView;
            string[] _changesLogTables = ConfigVariables.gAmendmentsChangesLogTables.Split(',');

            _dtView.RowStateFilter = DataViewRowState.OriginalRows;
            _dtView.Sort = "DATE_CHANGED ASC";

            if (_changesLogTables.Length > 1)
            {
                string _filter = "TABLE_NAME = '" + _changesLogTables[0] + "'";
                for (int i = 1; i < _changesLogTables.Length; i++)
                {
                    _filter = _filter + " or TABLE_NAME = '" + _changesLogTables[i] + "'";
                }
                _dtView.RowFilter = _filter;
            }
            else if (_changesLogTables.Length == 1)
            {
                _dtView.RowFilter = "TABLE_NAME = '" + _changesLogTables[0] + "'";
            }
            
            
            foreach (DataRowView dtRowView in _dtView)
            {
                grdSystemChanges.Rows.Count++;
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 0, false);
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 1, dtRowView["Remarks"].ToString().Split(':')[0]);
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 2, dtRowView["Old_Value"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 3, dtRowView["New_Value"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 4, dtRowView["User_ID"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 5, dtRowView["Date_Changed"].ToString());
                grdSystemChanges.SetData(grdSystemChanges.Rows.Count - 1, 6, dtRowView["ID"].ToString());

            }
            grdSystemChanges.AutoSizeRows();
            grdSystemChanges.AutoSizeCols();
        }

        private void setSearchChange()
        {
            string[] _changesLogTables = ConfigVariables.gAmendmentsChangesLogTables.Split(',');
            string _filter = "";
        
            for (int i = 0; i < _changesLogTables.Length; i++)
            {
                _filter += ""+_changesLogTables[i]+"" +((i== _changesLogTables.Length-1)? "":",");  
            }
            ReportFacade _oReportFacade = new ReportFacade();
            grdSystemChanges.DataSource = _oReportFacade.getReportMemorandum(lFolioID, string.Format("{0:yyyy-MM-d}", DateTime.Parse(dtpFrom.Text)), string.Format("{0:yyyy-MM-d}", DateTime.Parse(dtpTo.Text)), _filter);
        }
        private string getEventOfficer(string pFolioID)
        {
            ReportFacade _ReportFacade = new ReportFacade();
            DataTable _dt = _ReportFacade.getEventOfficers(pFolioID, GlobalVariables.gHotelId);
            if (_dt.Rows.Count < 1)
            {
                return "";
            }
            else if (_dt.Rows.Count == 1)
            {
                return (_dt.Rows[0]["firstName"].ToString() + " " + _dt.Rows[0]["lastName"].ToString());
            }
            else
            {
                string _eventOfficers = "";
                foreach (DataRow _dRow in _dt.Rows)
                {
                    _eventOfficers = _eventOfficers + ", " + _dRow["firstName"].ToString() + " " + _dRow["lastName"].ToString();
                }
                return _eventOfficers.Substring(1);
            }
        }
        private void tbnGenerate_Click(object sender, EventArgs e)
        {

                if (grdSystemChanges.Rows.Count == 1)
                {
                    MessageBox.Show("No Record of Changes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            //try
            //{
                Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.Memorandum _Memo = new Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management.Memorandum();

                string _date = string.Format("{0:d MMMMM yyyy}", DateTime.Now);
                EventOfficer _EventOfficers = new EventOfficer();
                string _eventOfficer = getEventOfficer(lFolioID);
                string _eventServicesSpecialist = "";
                string _assistantDirectorEventsDivision = "";
                string _eventDateDuration = string.Format("{0: MMMMM d yyyy}", DateTime.Parse(dtpFrom.Text)) + "-" + string.Format("{0: MMMMM d yyyy}", DateTime.Parse(dtpTo.Text));
                ReportFacade _oReportFacade = new ReportFacade();

                 string[] _changesLogTables = ConfigVariables.gAmendmentsChangesLogTables.Split(',');
                string _filter = "";
            
                for (int i = 0; i < _changesLogTables.Length; i++)
                {
                    _filter += ""+_changesLogTables[i]+"" +((i== _changesLogTables.Length-1)? "":",");  
                }
                DataTable _dtTable = _oReportFacade.getReportMemorandum(lFolioID, string.Format("{0:yyyy-MM-d}", DateTime.Parse(dtpFrom.Text)), string.Format("{0:yyyy-MM-d}", DateTime.Parse(dtpTo.Text)), _filter);
                pRecipients = ConvertFlexgridToDataTable(grdMemoFor, pRecipients, "description");
                _dtTable = ConvertFlexgridToDataTableAll(grdSystemChanges, _dtTable, "ID");
                
                _Memo.OpenSubreport("MemorandumSubReport.rpt").SetDataSource(pRecipients);
                _Memo.Database.Tables[0].SetDataSource(_dtTable);
                _Memo.SetParameterValue(0, _date);
                _Memo.SetParameterValue(1, _eventOfficer);
                _Memo.SetParameterValue(2, _eventServicesSpecialist);
                _Memo.SetParameterValue(3, _assistantDirectorEventsDivision);
                _Memo.SetParameterValue(4, _eventDateDuration);
                Reports.Presentation.ReportViewer _oReportViewer = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                _oReportViewer.rptViewer.ReportSource = _Memo;
                // _oReportViewer.MdiParent = this.MdiParent;
                _oReportViewer.Show();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
         
        }
        public DataTable ConvertFlexgridToDataTable(C1.Win.C1FlexGrid.C1FlexGrid pGrid, DataTable pRefData,string pRef)
        {
            DataTable _Temp = pRefData.Copy();
            DataTable _TempReference = pRefData.Copy();
            _Temp.Clear();
            int _index = 0;          
            //bool _Flag = false;
            //foreach (DataRow row in _TempReference.Rows)
            //{
            //    foreach (C1.Win.C1FlexGrid.Row _Row in pGrid.Rows)
            //    {
            //        try
            //        {

            //            if (row[pRef].ToString().Contains(_Row[pRef].ToString()))
            //            {
            //                _Temp.ImportRow(row);

            //                break;
            //            }
            //        }
            //        catch
            //        {
            //        }
            //    }
            //    _index++;
            //    continue;
            //}
             foreach (C1.Win.C1FlexGrid.Row _Row in pGrid.Rows)
             {
                 try
                 {
                     if (_index > 0)
                     {
                         DataRow row = _Temp.NewRow();
                         row[pRef] = _Row[pRef].ToString();
                         _Temp.Rows.Add(row);
                     }
                 }
                 catch
                 { }
                 _index++;
             }
            return _Temp;
        }
        public DataTable ConvertFlexgridToDataTableAll(C1.Win.C1FlexGrid.C1FlexGrid pGrid, DataTable pRefData, string pRef)
        {
            //DataTable _Temp = pRefData.Copy();
            //DataTable _TempReference = pRefData.Copy();
            //_Temp.Clear();
            //int _index = 0;
            //bool _Flag = false;

            //foreach (DataRow row in _TempReference.Rows)
            //{
            //    foreach (C1.Win.C1FlexGrid.Row _Row in pGrid.Rows)
            //    {
            //        try
            //        {
            //            if (_Flag == false)
            //            {
            //                if (row[pRef].ToString().Contains(_Row[0].ToString()))
            //                {
            //                    _Temp.ImportRow(row);

            //                    _Flag = true;
            //                }
            //            }
            //        }
            //        catch
            //        {
            //        }
            //    }
            //    _index++;
            //    _Flag = false;
            //}
            //return _Temp;

            DataTable _resultData = pRefData.Clone();
            string _tempIds = "";

            int _countRows =0;

            foreach (C1.Win.C1FlexGrid.Row _row in pGrid.Rows)
            {
                if (_countRows > 0)
                {
                    _tempIds += _row["ID"].ToString() + ((pGrid.Rows.Count - 1 == _countRows) ? "" : ",");

                }
                _countRows++;
            }
            DataRow[] _rowData = pRefData.Select("ID IN ("+_tempIds+")");
            foreach (DataRow _row in _rowData)
            {
                _resultData.ImportRow(_row);
            }
            return _resultData;

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            MemoUI_Load();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddRecipient_Click(object sender, EventArgs e)
        {
            try
            {
                grdMemoFor.Rows.Count++;
            }
            catch
            { }
        }
        private void btnRemoveRecipient_Click(object sender, EventArgs e)
        {
            try
            {
                //grdMemoFor.Rows.Remove(grdMemoFor.Row);
                grdMemoFor.RemoveItem(grdMemoFor.Row);
                //pRecipients.Rows[grdMemoFor.Row].Delete();
            }
            catch
            {}
        }

        private void btnAddChanges_Click(object sender, EventArgs e)
        {
             try
            {
                grdSystemChanges.Rows.Count++;
            }
            catch
            {}
        }

        private void btnRemoveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSystemChanges.Rows.Count != 2)
                {
                    grdSystemChanges.Rows.Remove(grdSystemChanges.Row);
                }
            }
            catch
            { }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            setSearchChange();
        }

        private void grdSystemChanges_Click(object sender, EventArgs e)
        {
         
        }
       

      
    }
}