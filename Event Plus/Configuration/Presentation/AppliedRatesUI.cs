using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.ConfigurationHotel
{
    namespace Presentation
    {
        public partial class AppliedRatesUI : Form
        {
            #region CONSTRUCTORS

            public AppliedRatesUI()
            {
                InitializeComponent();
                this.Text = "Applied Rates";
                loControlListener = new ControlListener();
            }

            #endregion

            #region VARIABLES

            private ControlListener loControlListener;
            private OperationMode loOperationMode;
            private AppliedRatesFacade loAppliedRatesFacade;
            private GenericList<AppliedRates> lAppliedRatesList;

            #endregion

            #region METHODS

            private void loadAppliedRates()
            {
                loAppliedRatesFacade = new AppliedRatesFacade();
                lAppliedRatesList = loAppliedRatesFacade.getAppliedRates();

                gridMain.Rows = lAppliedRatesList.Count + 1;
                int _cntRow = 1;
                foreach (AppliedRates _oAppliedRates in lAppliedRatesList)
                {
                    gridMain.set_TextMatrix(_cntRow, 0, _oAppliedRates.AppliedRateID.ToString());
                    gridMain.set_TextMatrix(_cntRow, 1, _oAppliedRates.Description);

                    _cntRow++;
                }

                gridMain_RowColChange(this, new EventArgs());
            }

            private void viewAppliedRate(string pAppliedRateID)
            {
                foreach (AppliedRates _oAppliedRate in lAppliedRatesList)
                {
                    if (_oAppliedRate.AppliedRateID == int.Parse(pAppliedRateID))
                    {
                        txtDESCRIPTION.Text = _oAppliedRate.Description;
                        lblAppliedID.Text = _oAppliedRate.AppliedRateID.ToString();
                        nudNumberOccupants.Value = decimal.Parse(_oAppliedRate.NumberOfOccupants.ToString());
                        cboRateType.Text = _oAppliedRate.RateType;
                    }
                }
            }

            private void setActionButtonStates(bool pStates)
            {
                this.btnDelete.Enabled = pStates;
                this.btnNew.Enabled = pStates;
                this.btnSave.Enabled = !pStates;
                this.btnCancel.Enabled = !pStates;
                this.btnClose.Enabled = pStates;

                if (pStates)
                {
                    this.CancelButton = this.btnClose;
                }
                else
                {
                    this.CancelButton = this.btnCancel;
                }
            }

            private void setOperationMode(OperationMode poOperationMode)
            {
                loOperationMode = poOperationMode;
            }

            private void initializeBlankForm()
            {
                lblAppliedID.Text = "Auto";
                txtDESCRIPTION.Text = "";
                nudNumberOccupants.Value = 0;
                cboRateType.Text = "";
            }

            private void initializeNewAppliedRate(ref AppliedRates poAppliedRates)
            {
                poAppliedRates.NumberOfOccupants = int.Parse(nudNumberOccupants.Value.ToString());
                poAppliedRates.Description = txtDESCRIPTION.Text;
                poAppliedRates.RateType = cboRateType.Text;
            }

            private void insertNewAppliedRate(AppliedRates poAppliedRate)
            {
                loAppliedRatesFacade = new AppliedRatesFacade();

                try
                {
                    loAppliedRatesFacade.saveAppliedRates(poAppliedRate, ref lAppliedRatesList);

                    int _lastRow = gridMain.Rows;
                    gridMain.Rows += 1;
                    gridMain.set_TextMatrix(_lastRow, 0, poAppliedRate.AppliedRateID.ToString());
                    gridMain.set_TextMatrix(_lastRow, 1, poAppliedRate.Description);

                    gridMain.Row = _lastRow;
                    gridMain_RowColChange(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void updateAppliedRate(AppliedRates poAppliedRate)
            {
                loAppliedRatesFacade = new AppliedRatesFacade();

                try
                {
                    loAppliedRatesFacade.updateAppliedRates(poAppliedRate, ref lAppliedRatesList);

                    int _cntRow = gridMain.Row;
                    gridMain.set_TextMatrix(_cntRow, 0, poAppliedRate.AppliedRateID.ToString());
                    gridMain.set_TextMatrix(_cntRow, 1, poAppliedRate.Description);

                    gridMain_RowColChange(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            #endregion

            #region EVENTS

            private void AppliedRatesUI_TextChanged(object sender, EventArgs e)
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

            private void AppliedRatesUI_Load(object sender, EventArgs e)
            {
                loadAppliedRates();
            }

            private void gridMain_RowColChange(object sender, EventArgs e)
            {
                loControlListener.StopListen(this);
                try
                {
                    int _cntRow = this.gridMain.Row;
                    string _rateID = this.gridMain.get_TextMatrix(_cntRow, 0);

                    viewAppliedRate(_rateID);
                }
                catch
                { }
                finally
                {
                    loControlListener.Listen(this);
                }
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                if (this.gridMain.Rows > 1)
                {
                    this.gridMain_RowColChange(this, new EventArgs());
                }


                this.Text = "Applied Rates";
                setActionButtonStates(true);
                loControlListener.Listen(this);
            }

            private void btnNew_Click(object sender, EventArgs e)
            {
                setOperationMode(OperationMode.Add);
                loControlListener.StopListen(this);

                initializeBlankForm();
                txtDESCRIPTION.Focus();

                setActionButtonStates(false);
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                DialogResult _rsp = MessageBox.Show("Save new applied rate? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_rsp == DialogResult.Yes)
                {

                    AppliedRates _oAppliedRate = new AppliedRates();
                    initializeNewAppliedRate(ref _oAppliedRate);

                    if (loOperationMode == OperationMode.Add)
                    {
                        insertNewAppliedRate(_oAppliedRate);

                    } // else if operation mode is EDIT
                    else
                    {
                        _oAppliedRate.AppliedRateID = int.Parse(this.lblAppliedID.Text);
                        updateAppliedRate(_oAppliedRate);
                    }

                    this.Text = "Applied Rates";
                    btnCancel_Click(sender, new EventArgs());
                }

            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                DialogResult _response = MessageBox.Show("Remove this rate from the list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (_response == DialogResult.Yes)
                {
                    loAppliedRatesFacade = new AppliedRatesFacade();

                    try
                    {
                        string _appliedRateID = this.lblAppliedID.Text;

                        loAppliedRatesFacade.deleteAppliedRates(_appliedRateID, ref lAppliedRatesList);

                        this.gridMain.RemoveItem(this.gridMain.Row);

                        if (this.gridMain.Rows > 1)
                        {
                            this.gridMain.Row = 1;
                            this.gridMain_RowColChange(this, new EventArgs());
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            //<<
            #endregion
        }
    }
}