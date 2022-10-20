using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Cashier.BusinessLayer;


namespace Jinisys.Hotel.Cashier.Presentation
{
    public partial class OpenShiftUI : Form
    {
        public OpenShiftUI()
        {
            InitializeComponent();
        }


        private OpenShiftFacade oOpenShiftFacade;
        private CashTerminal oCashTerminal;
       
        public OpenShiftUI(CashTerminal a_CashTerminal)
        {
            InitializeComponent();

            this.oCashTerminal = a_CashTerminal;
        }


        private void OpenShiftUI_Load(object sender, EventArgs e)
        {
            this.lblLoggedUser.Text = GlobalVariables.gLoggedOnUser;
            this.lblTransactionDate.Text = string.Format("{0:dddd, MMMM dd, yyyy}",DateTime.Parse(GlobalVariables.gAuditDate));

            this.lblDrawerNo.Text = oCashTerminal.TerminalId.ToString();


			// if gAuditDate > CashTerminal.UpdateTime means NIGHT AUDIT PROCESS has occured
			// so, reset Shift Code to 1
			// else INCREMENT;
			long dateDiff = DateTimeClass.DateDiff(DateTimeClass.DateInterval.Day, oCashTerminal.UpdateTime, DateTime.Parse(GlobalVariables.gAuditDate));
			if (dateDiff > 0)
			{
				this.lblShiftCode.Text = "1";
			}
			else
			{
				int nextShift = int.Parse(oCashTerminal.ShiftCode) + 1;
				this.lblShiftCode.Text = nextShift.ToString();
			}

            this.txtOpeningBalance.Text = oCashTerminal.OpeningBalance.ToString("N");
            this.txtBeginningBalance.Text = oCashTerminal.BeginningBalance.ToString("N");

        }

        private void txtOpeningAdjustment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double openingBalance = 0.00;
                double beginningBalace = 0.00;
                double openingAdjustment = 0.00;

                openingAdjustment = double.Parse(this.txtOpeningAdjustment.Text);
                openingBalance = double.Parse(this.txtOpeningBalance.Text);

                beginningBalace = openingBalance + openingAdjustment;
                this.txtBeginningBalance.Text = string.Format("{0:#,##0.00}", beginningBalace);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.txtBeginningBalance.Text = this.txtOpeningBalance.Text;
                this.txtOpeningAdjustment.Text = "0.00";
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
        //private int loadData()
        //{
        //    oCashTerminal = new CashTerminal();
        //    oOpenShiftFacade = new OpenShiftFacade();

        //    oCashTerminal = oOpenShiftFacade.GetCashierTerminals();

        //    bool isValidTerminal = false;
        //    if ( oCashTerminal != null )
        //    {
        //        foreach (DataRow dRow in oCashTerminal.Tables[0].Rows)
        //        {
        //            if (GlobalVariables.gTerminalID.ToString() == dRow["TerminalId"].ToString())
        //            {
        //                isValidTerminal = true;
        //            }

        //        }

        //        // this is to check wether Workstation is a valid Cash Terminal
        //        // jrom 4-Jan-2007
        //        if (isValidTerminal)
        //        {
        //            this.lblDrawerNo.Text = GlobalVariables.gTerminalID.ToString();
        //        }
        //        else
        //        {
        //            MessageBox.Show("This Station is not a valid Cash Terminal.\r\nPlease contact system administrator.", "Open Shift", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //    }
        //    return 1;
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            // proceed opening DRAWER here and UPDATE database ..
            oOpenShiftFacade = new OpenShiftFacade();
            assignEntityValues();
            if (oOpenShiftFacade.OpenCashDrawer(ref oCashTerminal))
            { 
                
                GlobalVariables.gCashDrawerOpen = true;
                GlobalVariables.gShiftCode = int.Parse(oCashTerminal.ShiftCode);
                this.Close();
            }
        }
        private void assignEntityValues()
        {
            oCashTerminal.TerminalId = int.Parse(this.lblDrawerNo.Text );
            oCashTerminal.ShiftCode = this.lblShiftCode.Text;
            oCashTerminal.OpeningBalance = double.Parse( this.txtOpeningBalance.Text );
            oCashTerminal.OpeningAdjustment = double.Parse(this.txtOpeningAdjustment.Text);
            oCashTerminal.BeginningBalance = double.Parse(this.txtBeginningBalance.Text);

        }

        

        //private void lblDrawerNo_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        foreach (DataRow dRow in oCashTerminal.Tables[0].Rows)
        //        {
        //            if (dRow["TerminalId"].ToString() == this.lblDrawerNo.Text)
        //            {
        //                cashTerminalStatus = dRow["Status"].ToString();

        //                if (cashTerminalStatus == "OPEN")
        //                {
        //                    MessageBox.Show("Cash Drawer already opened.", "Open Shift", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    this.btnOk.Visible = false;
        //                    this.nudShiftCode.ReadOnly = true;
        //                    this.txtOpeningAdjustment.ReadOnly = true;
        //                }
        //                else
        //                {
        //                    this.nudShiftCode.Value = int.Parse(dRow["ShiftCode"].ToString()) + 1;
        //                    this.txtOpeningBalance.Text = string.Format("{0:#,###,##0.00}", double.Parse(dRow["OpeningBalance"].ToString()));
        //                    this.txtBeginningBalance.Text = string.Format("{0:#,###,##0.00}", double.Parse(dRow["BeginningBalance"].ToString()));
        //                }

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error");
        //    }
        //}

        //private void OpenShiftUI_Activated(object sender, EventArgs e)
        //{
        //    loadData();
        //}
        

    }
}