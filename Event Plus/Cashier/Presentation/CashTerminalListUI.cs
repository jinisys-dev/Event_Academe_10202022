using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Cashier.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Security.Presentation;
using Jinisys.Hotel.Cashier.Presentation;


namespace Jinisys.Hotel.Cashier.Presentation
{
    public partial class CashTerminalListUI : Form
    {
        public CashTerminalListUI()
        {
            InitializeComponent();
        }

        bool _forceCloseCashDrawer = false;
        public CashTerminalListUI(bool forceCloseCashDrawer)
        {
            InitializeComponent();

            _forceCloseCashDrawer = forceCloseCashDrawer;
        }

        private void CashTerminalListUI_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private OpenShiftFacade oOpenShiftFacade;
        private CashTerminal oCashTerminal;
        public int loadData()
        {
            oCashTerminal = new CashTerminal();
            oOpenShiftFacade = new OpenShiftFacade();

            oCashTerminal = oOpenShiftFacade.GetCashierTerminals();

            this.grdCashTerminalList.Rows = 1;
            if (oCashTerminal != null)
            {
                foreach (DataRow dRow in oCashTerminal.Tables[0].Rows)
                {
                    this.grdCashTerminalList.Rows += 1;

                    this.grdCashTerminalList.set_TextMatrix( this.grdCashTerminalList.Rows-1,0,dRow["TerminalId"].ToString() );                    
                    this.grdCashTerminalList.set_TextMatrix(this.grdCashTerminalList.Rows - 1, 1, dRow["Terminal"].ToString() );
                    this.grdCashTerminalList.set_TextMatrix(this.grdCashTerminalList.Rows - 1, 2, dRow["Status"].ToString() );
                    this.grdCashTerminalList.set_TextMatrix(this.grdCashTerminalList.Rows - 1, 3, dRow["UpdatedBy"].ToString());
                }

               
            }
            return 1;
        }

        private void grdCashTerminalList_DoubleClick(object sender, EventArgs e)
        {
            this.btnSelect_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.grdCashTerminalList.get_TextMatrix(this.grdCashTerminalList.Row, 2) == "OPEN")
            {
                MessageBox.Show("Cash Drawer already open.", "Open Shift", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                CashTerminal a_CashTerminal = new CashTerminal();

                assignCashTerminalValues(ref a_CashTerminal);

                // checks wether COMPUTER TERMINAL is the same as Terminal ID selected
                if (a_CashTerminal.TerminalId == GlobalVariables.gTerminalID)
                {
                    OpenShiftUI oOpenShiftUI = new OpenShiftUI(a_CashTerminal);
                    oOpenShiftUI.MdiParent = this.MdiParent;
                    oOpenShiftUI.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cash Terminal selected is not valid in this PC.\r\nContact system administrator for help.", "Open Shift", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } 

        }

        public int assignCashTerminalValues( ref CashTerminal a_CashTerminal )
        {
            foreach (DataRow dRow in oCashTerminal.Tables[0].Rows)
            {
                if (dRow["TerminalId"].ToString() == this.grdCashTerminalList.get_TextMatrix(this.grdCashTerminalList.Row, 0))
                {
                    a_CashTerminal.TerminalId = int.Parse(dRow["TerminalId"].ToString() );
                    a_CashTerminal.Terminal = dRow["Terminal"].ToString();
                    a_CashTerminal.CashierId = dRow["CashierId"].ToString();
                    a_CashTerminal.ShiftCode = dRow["ShiftCode"].ToString();
                    a_CashTerminal.OpeningBalance = double.Parse( dRow["OpeningBalance"].ToString() );
                    a_CashTerminal.OpeningAdjustment = double.Parse( dRow["OpeningAdjustment"].ToString() );

                    a_CashTerminal.BeginningBalance = double.Parse( dRow["BeginningBalance"].ToString() );
                    a_CashTerminal.ChargeInAmount = double.Parse( dRow["ChargeInAmount"].ToString() );

                    a_CashTerminal.Cash = double.Parse( dRow["Cash"].ToString() );
                    a_CashTerminal.CreditCard = double.Parse( dRow["CreditCard"].ToString() );

                    a_CashTerminal.Cheque = double.Parse( dRow["Cheque"].ToString() );
                    a_CashTerminal.Others = double.Parse( dRow["Others"].ToString() );
                    a_CashTerminal.Adjustment = double.Parse( dRow["Adjustment"].ToString() );
                    a_CashTerminal.NetAmount = double.Parse( dRow["NetAmount"].ToString() );

                    a_CashTerminal.UpdatedBy = dRow["UpdatedBy"].ToString();
					a_CashTerminal.UpdateTime = DateTime.Parse(dRow["UpdateTime"].ToString());
                    break;
                }

            }

            return 1;
        }

        private void CashTerminalListUI_Activated(object sender, EventArgs e)
        {
            if (_forceCloseCashDrawer)
            {
                this.btnSelect.Visible = false;
                this.btnForceCloseCashDrawer.Visible = true;
            }
            else
            {
                this.btnSelect.Visible = true;
                this.btnForceCloseCashDrawer.Visible = false;
            }
        }

        private void btnForceCloseCashDrawer_Click(object sender, EventArgs e)
        {
            int _row = this.grdCashTerminalList.Row;
            if (_row <= 0)
            {
                return;
            }

            string _strTerminalID = this.grdCashTerminalList.GetDataDisplay(_row, 0);
            int _iTerminalID = 0;
            int.TryParse(_strTerminalID, out _iTerminalID);


            string _terminalStatus = this.grdCashTerminalList.GetDataDisplay(_row, 2);

            if (_terminalStatus != "OPEN")
            {
                return;
            }

            //check if AUTHORIZED
            string _priv = "Forcibly close cash drawer";

            VerifyUserUI oVerifyUserUI = new VerifyUserUI(_priv);
            if (!oVerifyUserUI.showDialog())
            {
                // exit if not authorized
                return;
            }

            CloseShiftUI oCloseShift = new CloseShiftUI(_iTerminalID, true);
            oCloseShift.MdiParent = this.MdiParent;
            oCloseShift.Show();

            this.Close();
        }

    }
}