using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Event_Management;
using Jinisys.Hotel.Reports.Presentation;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class BookingSheetDepartment : Form
    {
        private string lFolioId = "";
        public BookingSheetDepartment(string pFolioId)
        {
            InitializeComponent();
            lFolioId = pFolioId;
        }

        TableLogOnInfo logOnInfo;
        TableLogOnInfos logOnInfos = new TableLogOnInfos();
        private void setDatabaseLogOn()
        {
            logOnInfo = new TableLogOnInfo();
            //TableLogOnInfo logOnInfo = new TableLogOnInfo();
            string con = ConfigurationManager.AppSettings.Get("connection");
            string[] split ={ ";", "=" };
            string[] strCon = con.Split(split, StringSplitOptions.RemoveEmptyEntries);

            logOnInfo.ConnectionInfo.ServerName = strCon[1];
            logOnInfo.ConnectionInfo.UserID = strCon[3];
            logOnInfo.ConnectionInfo.Password = strCon[5];
            logOnInfo.ConnectionInfo.DatabaseName = strCon[7];
            //logOnInfo.ConnectionInfo.Type = ConnectionInfoType.CRQE;

            logOnInfos.Add(logOnInfo);
        }
 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(rdbDepartment.Checked==true)
            {
                grpDepartment.Enabled = true;
                foreach (Control _ctrl in grpDepartment.Controls)
                {
                    if (_ctrl is CheckBox)
                    {
                        CheckBox _oCheckBox = new CheckBox();
                        _oCheckBox = (CheckBox)_ctrl;
                        if (_oCheckBox.Checked == true)
                        {
                            string _maintenanceCondition = ""; //" and (requirementID like 'ENGINEERING%' or requirementID like 'FUNCTION ROOM%')";
                            
                            ReportFacade _oReportFacade = new ReportFacade();
                            BookingSheet _oBookingSheet = new BookingSheet();
                            _oBookingSheet = _oReportFacade.getBookingSheet(lFolioId, _maintenanceCondition);

                            switch (_oCheckBox.Text.ToUpper())
                            {
                                case "DINING":
                                    _oBookingSheet.SetParameterValue("viewMainSection", false);
                                    _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBev", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", false);
                                    _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                                    _oBookingSheet.SetParameterValue("viewEventRequirements", false);
                                    _oBookingSheet.SetParameterValue("Department", "DINING");
                                    _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");
                                    break;
                                case "HOUSEKEEPING":
                                    _oBookingSheet.SetParameterValue("viewMainSection", false);
                                    _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBev", false);
                                    _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", false);
                                    if (bool.Parse(ConfigVariables.gIsEMMOnly) == true)
                                    {
                                        _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                                    }
                                    else
                                    {
                                        _oBookingSheet.SetParameterValue("viewRoomRequirements", true);
                                    } _oBookingSheet.SetParameterValue("viewEventRequirements", false);
                                    _oBookingSheet.SetParameterValue("Department", "HOUSEKEEPING");
                                    _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");
                                    break;
                                case "BANQUET":
                                    _oBookingSheet.SetParameterValue("viewMainSection", false);
                                    _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBev", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", false);
                                    _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                                    _oBookingSheet.SetParameterValue("viewEventRequirements", false);
                                    _oBookingSheet.SetParameterValue("Department", "BANQUET");
                                    _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");
                                    break;
                                case "FRONT OFFICE":
                                    _oBookingSheet.SetParameterValue("viewMainSection", true);
                                    _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBev", false);
                                    _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", true);
                                    if (bool.Parse(ConfigVariables.gIsEMMOnly) == true)
                                    {
                                        _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                                    }
                                    else
                                    {
                                        _oBookingSheet.SetParameterValue("viewRoomRequirements", true);
                                    } _oBookingSheet.SetParameterValue("viewEventRequirements", false);
                                    _oBookingSheet.SetParameterValue("Department", "FRONT OFFICE");
                                    _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");
                                    break;
                                case "MAINTENANCE":
                                    _oBookingSheet.SetParameterValue("viewMainSection", false);
                                    _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBev", false);
                                    _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", false);
                                    _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                                    _oBookingSheet.SetParameterValue("viewEventRequirements", true);
                                    _oBookingSheet.SetParameterValue("Department", "MAINTENANCE");
                                    _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");
                                    break;
                                case "KITCHEN":
                                    _oBookingSheet.SetParameterValue("viewMainSection", false);
                                    _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBev", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", false);
                                    _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                                    _oBookingSheet.SetParameterValue("viewEventRequirements", false);
                                    _oBookingSheet.SetParameterValue("Department", "KITCHEN");
                                    _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");
                                    break;
                                case "SALES":
                                case "OPERATIONS":
                                case "ACCOUNTING":
                                    _oBookingSheet.SetParameterValue("viewMainSection", true);
                                    _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBev", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", false);
                                    if (bool.Parse(ConfigVariables.gIsEMMOnly) == true)
                                    {
                                        _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                                    }
                                    else
                                    {
                                        _oBookingSheet.SetParameterValue("viewRoomRequirements", true);
                                    } _oBookingSheet.SetParameterValue("viewEventRequirements", false);
                                    _oBookingSheet.SetParameterValue("Department", _oCheckBox.Text.ToUpper());
                                    _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");
                                    break;

                                default:
                                    _oBookingSheet.SetParameterValue("viewMainSection", true);
                                    _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBev", true);
                                    _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", true);
                                    if (bool.Parse(ConfigVariables.gIsEMMOnly) == true)
                                    {
                                        _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                                    }
                                    else
                                    {
                                        _oBookingSheet.SetParameterValue("viewRoomRequirements", true);
                                    } _oBookingSheet.SetParameterValue("viewEventRequirements", true);
                                    _oBookingSheet.SetParameterValue("Department", _oCheckBox.Text.ToUpper());
                                    _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");
                                    break;
                            }

                            Reports.Presentation.ReportViewer _oReportViewer = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                            _oReportViewer.rptViewer.ParameterFieldInfo = _oBookingSheet.ParameterFields;
                            _oReportViewer.rptViewer.ReportSource = _oBookingSheet;

                            _oReportViewer.MdiParent = this.MdiParent;
                            _oReportViewer.Show();
                        }
                    }
                }
            }
            else if (rdbAll.Checked == true)
            {
                grpDepartment.Enabled = false;

                ReportFacade _oReportFacade = new ReportFacade();
                BookingSheet _oBookingSheet = new BookingSheet();
                _oBookingSheet = _oReportFacade.getBookingSheet(lFolioId, "");

                _oBookingSheet.SetParameterValue("viewMainSection", true);
                _oBookingSheet.SetParameterValue("viewWeddingDetails", true);
                _oBookingSheet.SetParameterValue("viewFoodBev", true);
                _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", false);
                if (bool.Parse(ConfigVariables.gIsEMMOnly) == true)
                {
                    _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                }
                else
                {
                    _oBookingSheet.SetParameterValue("viewRoomRequirements", true);
                }
                _oBookingSheet.SetParameterValue("viewEventRequirements", true);
                _oBookingSheet.SetParameterValue("Department", "ALL");
                _oBookingSheet.SetParameterValue("header", "BOOKING SHEET");

                Reports.Presentation.ReportViewer _oReportViewer = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                _oReportViewer.rptViewer.ParameterFieldInfo = _oBookingSheet.ParameterFields;
                _oReportViewer.rptViewer.ReportSource = _oBookingSheet;

                _oReportViewer.MdiParent = this.MdiParent;
                _oReportViewer.Show();
            }
            else if (rdbMealRequirements.Checked == true)
            {
                grpDepartment.Enabled = false;

                ReportFacade _oReportFacade = new ReportFacade();
                BookingSheet _oBookingSheet = new BookingSheet();
                _oBookingSheet = _oReportFacade.getBookingSheet(lFolioId, "");

                _oBookingSheet.SetParameterValue("viewMainSection", false);
                _oBookingSheet.SetParameterValue("viewWeddingDetails", false);
                _oBookingSheet.SetParameterValue("viewFoodBev", true);
                _oBookingSheet.SetParameterValue("viewFoodBevHeaderOnly", false);
                _oBookingSheet.SetParameterValue("viewRoomRequirements", false);
                _oBookingSheet.SetParameterValue("viewEventRequirements", false);
                _oBookingSheet.SetParameterValue("Department", "RESTAURANT");
                _oBookingSheet.SetParameterValue("header", "MEAL REQUIREMENTS");

                Reports.Presentation.ReportViewer _oReportViewer = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
                _oReportViewer.rptViewer.ParameterFieldInfo = _oBookingSheet.ParameterFields;
                _oReportViewer.rptViewer.ReportSource = _oBookingSheet;

                _oReportViewer.MdiParent = this.MdiParent;
                _oReportViewer.Show();
            }
            else
            {
                MessageBox.Show("Please select type to print.", "Folio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void rdbDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDepartment.Checked == true)
                grpDepartment.Enabled = true;
            else
                grpDepartment.Enabled = false;
        }
    }
}