using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Cashier.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Reports.BusinessLayer;
using Jinisys.Hotel.Reports.Presentation;
using Jinisys.Hotel.Security.BusinessLayer;

namespace Jinisys.Hotel.Cashier.Presentation
{

    public partial class CloseShiftUI : Form
    {

        private CashTerminal oCashTerminal;
        private OpenShiftFacade oOpenShiftFacade;
        private CashTerminal myCashTerminal;
        private CloseShiftFacade oCloseShiftFacade;

        public CloseShiftUI()
        {
            InitializeComponent();

        }

		public CloseShiftUI(int pTerminalId)
		{
			InitializeComponent();

			// check wether GlobalVariables.gCashDrawerOpen is TRUE
			if (!GlobalVariables.gCashDrawerOpen)
			{
				// get all cash terminals and check if some is open
				oCashTerminal = new CashTerminal();
				oOpenShiftFacade = new OpenShiftFacade();
				oCashTerminal = oOpenShiftFacade.GetCashierTerminals();

				foreach (DataRow dRow in oCashTerminal.Tables[0].Rows)
				{
					if (dRow["Status"].ToString() == "OPEN" && dRow["UpdatedBy"].ToString().ToUpper() == GlobalVariables.gLoggedOnUser.ToUpper())
					{
						assignCashTerminalValues(dRow);
						return;
					}
				}
			}
			else
			{
				// get all cash terminals and check if some is open
				oCashTerminal = new CashTerminal();
				oOpenShiftFacade = new OpenShiftFacade();
				oCashTerminal = oOpenShiftFacade.GetCashierTerminals();

				foreach (DataRow dRow in oCashTerminal.Tables[0].Rows)
				{
					if (dRow["Status"].ToString() == "OPEN" && dRow["UpdatedBy"].ToString().ToUpper() == GlobalVariables.gLoggedOnUser.ToUpper())
					{
						assignCashTerminalValues(dRow);
						return;
					}
				}
				return;
			}

            //check if has right to FORCIBLY close cash drawer
            bool isAuthorized = false;
            string privilegeToSearch = "Forcibly close cash drawer";

            User oUser = (User)GlobalVariables.goUser;
            foreach (Role role in oUser.Roles)
            {
                foreach (Role_Privilege privilege in role.Privileges)
                {
                    if (privilege.Privilege.ToUpper() == privilegeToSearch.ToUpper() && privilege.Allowed == 1)
                    {
                        GlobalVariables.goSupervisor = oUser;
                        GlobalVariables.gLoggedSupervisor = oUser.UserId;

                        isAuthorized = true;
                        CashTerminalListUI oCashTerminalList = new CashTerminalListUI(true);
                        oCashTerminalList.MdiParent = (Form)GlobalVariables.gMDI;

                        oCashTerminalList.Show();


                        this.Close();
                    }
                }
            }
            if (!isAuthorized)
            {
                MessageBox.Show("No cash drawer opened.", "Close Shift", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
		}

        //for FORCIBLY closing of cash drawers
        public CloseShiftUI(int pTerminalId, bool forciblyClose)
        {
            InitializeComponent();

            // get all cash terminals and check if some is open
            oCashTerminal = new CashTerminal();
            oOpenShiftFacade = new OpenShiftFacade();
            oCashTerminal = oOpenShiftFacade.GetCashierTerminals();

            foreach (DataRow dRow in oCashTerminal.Tables[0].Rows)
            {
                int _terminalID = 0;
                int.TryParse(dRow["TerminalId"].ToString(), out _terminalID);

                string _status = dRow["Status"].ToString();


                if (_status == "OPEN" &&
                    _terminalID == pTerminalId)
                {
                    assignCashTerminalValues(dRow);
                    return;
                }
            }

        }

        private void OpenShiftUI_Load(object sender, EventArgs e)
        {
			

            try
            {
                this.lblLoggedUser.Text = GlobalVariables.gLoggedOnUser;
                this.lblTransactionDate.Text = string.Format("{0:dddd, MMMM dd, yyyy}", DateTime.Parse(GlobalVariables.gAuditDate));

                this.lblDrawerNo.Text = myCashTerminal.TerminalId.ToString();

                this.lblShiftCode.Text = myCashTerminal.ShiftCode;

                this.lblOpeningBalance.Text = myCashTerminal.OpeningBalance.ToString("N");
				this.lblOpeningAdjustment.Text = myCashTerminal.OpeningAdjustment.ToString("N");
                this.lblBeginningBalance.Text = myCashTerminal.BeginningBalance.ToString("N");

				this.lblCash.Text = myCashTerminal.Cash.ToString("N");
				this.lblCreditCard.Text = myCashTerminal.CreditCard.ToString("N");
				this.lblCheque.Text = myCashTerminal.Cheque.ToString("N");
				this.lblOthers.Text = myCashTerminal.Others.ToString("N");
                //this.txtAdjustment.Text = string.Format(gCurrencyFormat, myCashTerminal.Adjustment);

                // computes TOTAL AMOUNT RECEIVED
                double totalAmountRecevied = 0.00;
                totalAmountRecevied = myCashTerminal.Cash + myCashTerminal.CreditCard + myCashTerminal.Cheque + myCashTerminal.Others;

				this.lblAmountReceived.Text = totalAmountRecevied.ToString("N");

                // computes NETAmount
                double netAmount = 0.00;
                netAmount = myCashTerminal.BeginningBalance + totalAmountRecevied;

				this.txtNetAmount.Text = netAmount.ToString("N");

                this.txtEndingBalance.Text = this.txtNetAmount.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int assignCashTerminalValues(DataRow dRow)
        {
            myCashTerminal = new CashTerminal();

            myCashTerminal.TerminalId = int.Parse( dRow["TerminalId"].ToString());
            myCashTerminal.Terminal = dRow["Terminal"].ToString();
            myCashTerminal.CashierId = dRow["CashierId"].ToString();
            myCashTerminal.ShiftCode = dRow["ShiftCode"].ToString();
            myCashTerminal.OpeningBalance = double.Parse( dRow["OpeningBalance"].ToString() );
            myCashTerminal.OpeningAdjustment = double.Parse( dRow["OpeningAdjustment"].ToString() );
            myCashTerminal.BeginningBalance = double.Parse( dRow["BeginningBalance"].ToString() );
            myCashTerminal.ChargeInAmount = double.Parse( dRow["ChargeInAmount"].ToString() );
            myCashTerminal.Cash = double.Parse( dRow["Cash"].ToString() );
            myCashTerminal.CreditCard = double.Parse( dRow["CreditCard"].ToString() );
            myCashTerminal.Cheque = double.Parse( dRow["Cheque"].ToString() );
            myCashTerminal.Others = double.Parse( dRow["Others"].ToString() );
            myCashTerminal.Adjustment = double.Parse( dRow["Adjustment"].ToString() );
            myCashTerminal.NetAmount = double.Parse( dRow["NetAmount"].ToString() );

            return 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAdjustment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // computes NETAmount
                double netAmount = 0.00;
                netAmount = myCashTerminal.BeginningBalance + double.Parse(this.lblAmountReceived.Text) + double.Parse(this.txtAdjustment.Text);

				this.txtNetAmount.Text = netAmount.ToString("N");
            }
            catch (Exception)
            {
                this.txtAdjustment.Text = "0.00";
            }
        }

        private void txtAmountRemitted_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // computes NETAmount
                double beginningBalance = 0.00;
                beginningBalance = double.Parse(this.txtNetAmount.Text) - double.Parse(this.txtAmountRemitted.Text);

				this.txtEndingBalance.Text = beginningBalance.ToString("N");
            }
            catch
            {

            }
        }

        private void txtNetAmount_TextChanged(object sender, EventArgs e)
        {
            txtAmountRemitted_TextChanged(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult rsp = MessageBox.Show("Close cash drawer now?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsp == DialogResult.No)
            {
                return;
            }

            ////this.MdiParent.Cursor = Cursors.WaitCursor;

            CashTerminal a_CashTerminal = new CashTerminal();
            if (assignEntityValuesForClosing(ref  a_CashTerminal) == 1)
            {

                oCloseShiftFacade = new CloseShiftFacade();
                if (oCloseShiftFacade.CloseCashDrawer(ref a_CashTerminal))
                {
                    GlobalVariables.gCashDrawerOpen = false;
                    GlobalVariables.gShiftCode = 0;

                    // preview cashier reports here...
                    ReportFacade oReportFacade = new ReportFacade();
                    ReportViewer oReportViewer = new ReportViewer();

                    oReportViewer.rptViewer.ReportSource = oReportFacade.getCashierTransaction(myCashTerminal.TerminalId.ToString(), myCashTerminal.CashierId, myCashTerminal.ShiftCode);
                    oReportViewer.MdiParent = this.MdiParent;
                    oReportViewer.Show();

					//generateNonGuestChargesTransactions();
					//generateNonGuestPaymentsTransactions();
					//generateNonGuestPaidOutTransactions();

                    this.Close();
                }
            }
            else
            {
                //this.MdiParent.Cursor = Cursors.WaitCursor;
            }
        }

		//private void generateNonGuestChargesTransactions()
		//{
		//    ReportViewer rptViewer = new ReportViewer();
		//    ReportFacade oReportFacade = new ReportFacade();
		//    rptViewer.rptViewer.ReportSource = oReportFacade.getDateRangeNonGuestChargesTransactions(GlobalVariables.gAuditDate, GlobalVariables.gAuditDate);

		//    rptViewer.MdiParent = this.MdiParent;
		//    rptViewer.Show();
		//}

		//private void generateNonGuestPaymentsTransactions()
		//{
		//    ReportViewer rptViewer = new ReportViewer();
		//    ReportFacade oReportFacade = new ReportFacade();
		//    rptViewer.rptViewer.ReportSource = oReportFacade.getDateRangeNonGuestPaymentsTransactions(GlobalVariables.gAuditDate, GlobalVariables.gAuditDate);

		//    rptViewer.MdiParent = this.MdiParent;
		//    rptViewer.Show();
		//}

		//private void generateNonGuestPaidOutTransactions()
		//{
		//    ReportViewer rptViewer = new ReportViewer();
		//    ReportFacade oReportFacade = new ReportFacade();
		//    rptViewer.rptViewer.ReportSource = oReportFacade.getDateRangeNonGuestPaidOutTransactions(GlobalVariables.gAuditDate, GlobalVariables.gAuditDate);

		//    rptViewer.MdiParent = this.MdiParent;
		//    rptViewer.Show();
		//}


        private int assignEntityValuesForClosing(ref CashTerminal a_CashTerminal)
        {
            try
            {
                a_CashTerminal.TerminalId = myCashTerminal.TerminalId;
                a_CashTerminal.Terminal = myCashTerminal.Terminal;
                a_CashTerminal.CashierId = myCashTerminal.CashierId;
                a_CashTerminal.ShiftCode = myCashTerminal.ShiftCode;

                a_CashTerminal.OpeningBalance = myCashTerminal.OpeningBalance;
                a_CashTerminal.OpeningAdjustment = myCashTerminal.OpeningAdjustment;
                a_CashTerminal.BeginningBalance = myCashTerminal.BeginningBalance;

                a_CashTerminal.ChargeInAmount = myCashTerminal.ChargeInAmount;
                a_CashTerminal.Cash = myCashTerminal.Cash;
                a_CashTerminal.CreditCard = myCashTerminal.CreditCard;
                a_CashTerminal.Cheque = myCashTerminal.Cheque;
                a_CashTerminal.Others = myCashTerminal.Others;

                a_CashTerminal.Adjustment = double.Parse(this.txtAdjustment.Text);
                a_CashTerminal.AmountRemitted = double.Parse(this.txtAmountRemitted.Text);
                a_CashTerminal.NetAmount = double.Parse(this.txtNetAmount.Text);
                a_CashTerminal.Remarks = this.txtRemarks.Text;

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

        }


    }
}
