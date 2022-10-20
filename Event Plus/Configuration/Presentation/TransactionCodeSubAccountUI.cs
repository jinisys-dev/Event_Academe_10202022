using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public partial class TransactionCodeSubAccountUI : Jinisys.Hotel.UIFramework.Maintenance2UI
    {
        public TransactionCodeSubAccountUI()
        {
            InitializeComponent();

            loTransactionCode_SubAccountFacade = new TransactionCode_SubAccountFacade();
            loTransactionCode_SubAccountList = new List<TransactionCode_SubAccount>();

        }

        public ControlListener oControlListener = new ControlListener();
        public TransactionCode_SubAccountFacade loTransactionCode_SubAccountFacade;
        public IList<TransactionCode_SubAccount> loTransactionCode_SubAccountList;
        private OperationMode mOperationMode;

        private void TransactionCodeSubAccountUI_Load(object sender, EventArgs e)
        {
            // load all Transaction Codes
            if (loadTransactionCodes() == true)
            {
                this.cboTransactionCode.DataSource = oTransactionCode.Tables[0];
                this.cboTransactionCode.DisplayMember = "TranCode";

                this.cboMemo.DataSource = oTransactionCode.Tables[0];
                this.cboMemo.DisplayMember = "Memo";
            }

            loTransactionCode_SubAccountList = loTransactionCode_SubAccountFacade.loadTransactionCodeSubAccounts();


            this.grdSubAccounts.Rows = 1;
            int i = this.grdSubAccounts.Rows;
            foreach (TransactionCode_SubAccount oTransactionCode_SubAccount in loTransactionCode_SubAccountList)
            {
                this.grdSubAccounts.Rows += 1;

                this.grdSubAccounts.set_TextMatrix(i, 0, oTransactionCode_SubAccount.TransactionCode);
                this.grdSubAccounts.set_TextMatrix(i, 1, oTransactionCode_SubAccount.SubAccountCode);

                i++;
            }

            this.grdSubAccounts_RowColChange(this, new EventArgs());
            this.btnCancel_Click(this, new EventArgs());


            this.cboTransactionCode.Enabled = false;
            this.txtSubAccountCode.Enabled = false;

            setActionButtonStates(true);
        }

        private TransactionCode oTransactionCode;
        private TransactionCodeFacade oTransactionCodeFacade;


        public bool loadTransactionCodes()
        {
            try
            {
                oTransactionCodeFacade = new TransactionCodeFacade();
                oTransactionCode = new TransactionCode();
                oTransactionCode = (TransactionCode)oTransactionCodeFacade.loadObject();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void cboTransactionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow dRow = null;
            try
            {
                dRow = oTransactionCode.Tables[0].Rows[cboTransactionCode.SelectedIndex];

                this.cboMemo.Text = dRow["Memo"].ToString();
                this.txtAcctSide.Text = dRow["AcctSide"].ToString();
            }
            catch
            {
            }


        }

        private void grdSubAccounts_RowColChange(object sender, EventArgs e)
        {
            oControlListener.StopListen(this);
            try
            {
                int row = this.grdSubAccounts.Row;
                string _tranCode = this.grdSubAccounts.get_TextMatrix(row, 0);
                string _subAccount = this.grdSubAccounts.get_TextMatrix(row, 1);

                viewRecord(_tranCode, _subAccount);
            }
            catch
            { }
            finally
            {
                oControlListener.Listen(this);
            }
        }

        private void viewRecord(string pTranCode, string pSubAccount)
        {
            foreach (TransactionCode_SubAccount _oSubAccount in loTransactionCode_SubAccountList)
            {
                if (_oSubAccount.TransactionCode == pTranCode && _oSubAccount.SubAccountCode == pSubAccount)
                {

                    this.cboTransactionCode.Text = pTranCode;
                    this.txtSubAccountCode.Text = pSubAccount;

                    this.nudGovtTax.Value = System.Convert.ToDecimal(_oSubAccount.GovernmentTax);
                    this.chkGovtTaxInclusive.Checked = _oSubAccount.GovernmentTaxInclusive == 1 ? true : false;

                    this.nudLocalTax.Value = System.Convert.ToDecimal(_oSubAccount.LocalTax);
                    this.chkLocalTaxInclusive.Checked = _oSubAccount.LocalTaxInclusive == 1 ? true : false;

                    this.nudServiceCharge.Value = System.Convert.ToDecimal(_oSubAccount.ServiceCharge);
                    this.chkServiceChargeInclusive.Checked = _oSubAccount.ServiceChargeInclusive == 1 ? true : false;

                    return;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkRequiredFields())
            {
                DialogResult rsp = MessageBox.Show("Save Sub-account information ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsp == DialogResult.Yes)
                {

                    TransactionCode_SubAccount oTransactionCode_SubAccount = new TransactionCode_SubAccount();
                    initializeNewSubAccountObject(ref oTransactionCode_SubAccount);

                    if (mOperationMode == OperationMode.Add)
                    {
                        insertNewSubAccount(oTransactionCode_SubAccount);

                    } // else if operation mode is EDIT
                    else
                    {
                        oTransactionCode_SubAccount.TransactionCode = this.cboTransactionCode.Text;
                        oTransactionCode_SubAccount.SubAccountCode = this.txtSubAccountCode.Text;

                        updateNewSubAccountInfo(oTransactionCode_SubAccount);
                    }

                    //setActionButtonStates(true);
                    this.Text = "Transaction Code Sub-Accounts";
                    btnCancel_Click(sender, new EventArgs());

                    this.cboTransactionCode.Enabled = true;
                    this.txtSubAccountCode.Enabled = true;

                }
            }
        }

        private void initializeNewSubAccountObject(ref TransactionCode_SubAccount poTransactionCodeSubAccount)
        {
            poTransactionCodeSubAccount.TransactionCode = this.cboTransactionCode.Text;
            poTransactionCodeSubAccount.SubAccountCode = this.txtSubAccountCode.Text;

            poTransactionCodeSubAccount.GovernmentTax = this.nudGovtTax.Value;
            poTransactionCodeSubAccount.GovernmentTaxInclusive = this.chkGovtTaxInclusive.Checked ? 1 : 0;


            poTransactionCodeSubAccount.LocalTax = this.nudLocalTax.Value;
            poTransactionCodeSubAccount.LocalTaxInclusive = this.chkLocalTaxInclusive.Checked ? 1 : 0;

            poTransactionCodeSubAccount.ServiceCharge = this.nudServiceCharge.Value;
            poTransactionCodeSubAccount.ServiceChargeInclusive = this.chkServiceChargeInclusive.Checked ? 1 : 0;
        }


        /// <summary>
        /// Checks if all required field are filled.
        /// </summary>
        /// <returns>True or False</returns>
        private bool checkRequiredFields()
        {
            if (this.txtSubAccountCode.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Please input sub account code.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtSubAccountCode.Focus();
                return false;
            }

            return true;
        }

        private void insertNewSubAccount(TransactionCode_SubAccount poTransactionCode_SubAccount)
        {
            loTransactionCode_SubAccountFacade = new TransactionCode_SubAccountFacade();


            try
            {
                loTransactionCode_SubAccountFacade.insertNewSubAccount(poTransactionCode_SubAccount, ref loTransactionCode_SubAccountList);

                int lastRow = this.grdSubAccounts.Rows;
                this.grdSubAccounts.Rows += 1;
                this.grdSubAccounts.set_TextMatrix(lastRow, 0, poTransactionCode_SubAccount.TransactionCode);
                this.grdSubAccounts.set_TextMatrix(lastRow, 1, poTransactionCode_SubAccount.SubAccountCode);

                this.grdSubAccounts.Row = lastRow;
                this.grdSubAccounts_RowColChange(this, new EventArgs());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateNewSubAccountInfo(TransactionCode_SubAccount poTransactionCode_SubAccount)
        {
            loTransactionCode_SubAccountFacade = new TransactionCode_SubAccountFacade();

            try
            {
                loTransactionCode_SubAccountFacade.updateSubAccountInfo(poTransactionCode_SubAccount, ref loTransactionCode_SubAccountList);

                int row = this.grdSubAccounts.Row;
                //this.grdSubAccounts.set_TextMatrix(row, 1, a_Driver.LastName + ", " + a_Driver.FirstName);

                this.grdSubAccounts_RowColChange(this, new EventArgs());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.grdSubAccounts.Rows > 1)
            {
                this.grdSubAccounts_RowColChange(this, new EventArgs());
            }


            this.Text = "Transaction Code Sub-Accounts";
            setActionButtonStates(true);
            oControlListener.Listen(this);

        }

        private void setActionButtonStates(bool a_states)
        {
            //this.btnSearch.Enabled = pStates;
            this.btnDelete.Enabled = a_states;
            this.btnNew.Enabled = a_states;
            this.btnSave.Enabled = !a_states;
            this.btnCancel.Enabled = !a_states;
            this.btnClose.Enabled = a_states;

            // set CANCEL BUTTON for this form
            // if in EDIT/ADD mode CANCEL BUTTON is btnCancel
            // else CANCEL BUTTON is btnClose
            if (a_states)
            {
                this.CancelButton = this.btnClose;
            }
            else
            {
                this.CancelButton = this.btnCancel;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            setOperationMode(OperationMode.Add);
            oControlListener.StopListen(this);

            initializeBlankForm();
            this.cboTransactionCode.Focus();

            setActionButtonStates(false);

            this.cboTransactionCode.Enabled = true;
            this.txtSubAccountCode.Enabled = true;
        }

        private void setOperationMode(OperationMode a_OperationMode)
        {
            mOperationMode = a_OperationMode;
        }


        private void initializeBlankForm()
        {
            this.txtSubAccountCode.Text = "";

            this.nudGovtTax.Value = 0;
            this.nudLocalTax.Value = 0;
            this.nudServiceCharge.Value = 0;

            this.chkGovtTaxInclusive.Checked = true;
            this.chkLocalTaxInclusive.Checked = true;
            this.chkServiceChargeInclusive.Checked = true;
        }

        private void TransactionCodeSubAccountUI_TextChanged(object sender, EventArgs e)
        {
            if (this.Text.IndexOf('*') > 0)
            {
                setOperationMode(OperationMode.Edit);
                setActionButtonStates(false);
            }
            else
            {
                setActionButtonStates(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Remove this item from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                loTransactionCode_SubAccountFacade = new TransactionCode_SubAccountFacade();

                try
                {
                    loTransactionCode_SubAccountFacade = new TransactionCode_SubAccountFacade();
                    TransactionCode_SubAccount _oTransactionCodeSubAccount = new TransactionCode_SubAccount();
                    initializeNewSubAccountObject(ref _oTransactionCodeSubAccount);

                    loTransactionCode_SubAccountFacade.deleteSubAccountInfo(_oTransactionCodeSubAccount, ref loTransactionCode_SubAccountList);

                    this.grdSubAccounts.RemoveItem(this.grdSubAccounts.Row);

                    if (this.grdSubAccounts.Rows > 1)
                    {
                        this.grdSubAccounts.Row = 1;
                        this.grdSubAccounts_RowColChange(this, new EventArgs());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

