using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation.Report_Documents.Audit;

namespace Jinisys.Hotel.Reports.Presentation
{
    public partial class PaymentOrderUI : Form
    {
        public PaymentOrderUI()
        {
            InitializeComponent();
        }
        private string lEventID ;
        private string lEventName;
        private string lOrganizerID;
        private string lOrganizerName;

        public PaymentOrderUI(string pEventID, string pEventName,string pOrganizerID,string pOrganizerName )
        {
            InitializeComponent();
            lEventID = pEventID;
            lEventName = pEventName;
            lOrganizerID = pOrganizerID;
            lOrganizerName = pOrganizerName;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ReportFacade _oReportFacade = new ReportFacade();
            PaymentSlipReport _paymentSlipReport = new PaymentSlipReport();

            string _paymentType = "";
            if (rboCheque.Checked == true)
            {
                _paymentType = "CHEQUE";
            }
            else if (rboCash.Checked == true)
            {
                _paymentType = "CASH";
            }
            else if (rdoBank.Checked == true)
            {
                _paymentType = "BANK";
            }
            _paymentSlipReport.SetParameterValue(0, lEventID);
            _paymentSlipReport.SetParameterValue(1, lEventName);
            _paymentSlipReport.SetParameterValue(2, lOrganizerName);
            _paymentSlipReport.SetParameterValue(3, lOrganizerID);
            _paymentSlipReport.SetParameterValue(4, _paymentType);
            _paymentSlipReport.SetParameterValue(5,nudAmount.Value.ToString());
            _paymentSlipReport.SetParameterValue(6, DateTime.Parse(dtpDate.Text));
        
            Reports.Presentation.ReportViewer _oReportViewer = new Jinisys.Hotel.Reports.Presentation.ReportViewer();
            _oReportViewer.rptViewer.ReportSource = _paymentSlipReport;
            _oReportViewer.MdiParent = this.MdiParent;
            _oReportViewer.Show();
           // EventOrderFacade _eventOrder = new EventOrderFacade();
        }
        private void generatePaymentOrder()
        {

        }
        private void PaymentOrderUI_Load(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}