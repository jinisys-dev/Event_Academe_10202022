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
        public partial class EventHeaderUI : Form
        {

            #region CONSTRUCTORS

            public EventHeaderUI()
            {
                InitializeComponent();
                this.Text = "Event Types";
                loControlListener = new ControlListener();
            }

            #endregion

            #region VARIABLES

            ControlListener loControlListener;
            private OperationMode loOperationMode;
            private EventTypeFacade loEventTypeFacade;
            private GenericList<EventType> lEventTypeList;

            #endregion

            #region METHODS

            private void loadEventTypeData()
            {
                loEventTypeFacade = new EventTypeFacade();
                lEventTypeList = loEventTypeFacade.getEventTypes();

                this.grdEventTypes.Rows = lEventTypeList.Count + 1;
                int _ctr = 1;

                foreach (EventType _oEventType in lEventTypeList)
                {
                    grdEventTypes.set_TextMatrix(_ctr, 0, _oEventType.EventID.ToString());
                    grdEventTypes.set_TextMatrix(_ctr, 1, _oEventType.Event_Type);

                    _ctr++;
                }

                grdEventTypes_RowColChange(this, new EventArgs());
            }

            private void viewRecord(string pEventID)
            {
                grid.Rows = 1;
                foreach (EventType _oEventType in lEventTypeList)
                {
                    if (_oEventType.EventID == int.Parse(pEventID))
                    {
                        this.txtDescription.Text = _oEventType.Description;
                        this.txtEventType.Text = _oEventType.Event_Type;
                        this.txtEventID.Text = _oEventType.EventID.ToString();

                        if (_oEventType.BanquetType == 1)
                        {
                            this.chkParty.Checked = true;
                        }
                        else
                        {
                            this.chkParty.Checked = false;
                        }
                    }
                }

                loEventTypeFacade = new EventTypeFacade();
                GenericList<EventType> _oEventTypeDetailList = loEventTypeFacade.getEventAttributes(pEventID);
                int _ctr = 1;
                grid.Rows = _oEventTypeDetailList.Count + 1;
                foreach (EventType _oEventTypeDetails in _oEventTypeDetailList)
                {
                    grid.set_TextMatrix(_ctr, 0, _oEventTypeDetails.Key);
                    _ctr++;
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
                foreach (Control _ctrl in grpMain.Controls)
                {
                    if (_ctrl is TextBox)
                        _ctrl.Text = "";
                }
                grid.Rows = 1;
                set_Enable(true);
                txtEventID.Text = "AUTO";
            }

            private void set_Enable(bool _pSetEnable)
            {
                this.btnRemove.Enabled = _pSetEnable;
                this.btnAdd.Enabled = _pSetEnable;
            }

            private bool checkRequiredFields()
            {
                if (txtEventType.Text != "" && txtDescription.Text != "")
                    return true;
                else
                    return false;
            }

            private void insertNewEventType(EventType poEventType)
            {
                loEventTypeFacade = new EventTypeFacade();
                try
                {
                    loEventTypeFacade.saveEventType(poEventType, ref lEventTypeList);

                    int _cntRow = 1;
                    while (_cntRow < grid.Rows)
                    {
                        if (_cntRow != 0)
                        {
                            EventType _oEventTypeDetails = new EventType();
                            _oEventTypeDetails.Key = grid.GetDataDisplay(_cntRow, 0);
                            _oEventTypeDetails.EventID = poEventType.EventID;

                            loEventTypeFacade = new EventTypeFacade();
                            loEventTypeFacade.saveEventAttributes(_oEventTypeDetails);
                        }
                        _cntRow++;
                    }

                    int lastRow = this.grdEventTypes.Rows;
                    this.grdEventTypes.Rows += 1;
                    this.grdEventTypes.set_TextMatrix(lastRow, 0, poEventType.EventID.ToString());
                    this.grdEventTypes.set_TextMatrix(lastRow, 1, poEventType.Event_Type);

                    this.grdEventTypes.Row = lastRow;
                    this.grdEventTypes_RowColChange(this, new EventArgs());

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void updateEventTypes(EventType poEventType)
            {
                loEventTypeFacade = new EventTypeFacade();

                try
                {
                    loEventTypeFacade.updateEventType(poEventType, lEventTypeList);
                    loEventTypeFacade.deleteEventAttributes(txtEventID.Text);
                    int row = this.grdEventTypes.Row;

                    int _cntRow = 1;
                    while (_cntRow < grid.Rows)
                    {
                        if (_cntRow != 0)
                        {
                            EventType _oEventTypeDetails = new EventType();
                            _oEventTypeDetails.Key = grid.GetDataDisplay(_cntRow, 0);
                            _oEventTypeDetails.EventID = poEventType.EventID;
                            _oEventTypeDetails.Event_Type = poEventType.Event_Type;

                            loEventTypeFacade = new EventTypeFacade();
                            loEventTypeFacade.saveEventAttributes(_oEventTypeDetails);
                        }
                        _cntRow++;
                    }

                    this.grdEventTypes.set_TextMatrix(row, 1, poEventType.Event_Type);
                    this.grdEventTypes_RowColChange(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Transaction failed.\r\nException: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void initializeNewEventType(ref EventType poEventType)
            {
                poEventType.Description = txtDescription.Text;
                poEventType.Event_Type = txtEventType.Text;

                if (chkParty.Checked == true)
                {
                    poEventType.BanquetType = 1;
                }
                else
                {
                    poEventType.BanquetType = 0;
                }
            }

            #endregion

            #region EVENTS

            private void grdEventTypes_RowColChange(object sender, EventArgs e)
            {
                loControlListener.StopListen(this);
                try
                {
                    int _cntRow = this.grdEventTypes.Row;
                    string _eventID = this.grdEventTypes.get_TextMatrix(_cntRow, 0);

                    viewRecord(_eventID);
                    set_Enable(true);
                }
                catch
                { }
                finally
                {
                    loControlListener.Listen(this);
                }
            }

            private void btnAdd_Click(object sender, EventArgs e)
            {
                if (loOperationMode.Equals(OperationMode.Add))
                    this.grid.Rows++;
                else
                {
                    this.Text = "Event Types*";
                    this.grid.Rows++;
                }
            }

            private void btnRemove_Click(object sender, EventArgs e)
            {
                this.Text = "Event Types*";
                grid.RemoveItem(grid.Row);
            }

            private void btnNew_Click(object sender, EventArgs e)
            {
                setOperationMode(OperationMode.Add);
                loControlListener.StopListen(this);

                initializeBlankForm();
                this.txtDescription.Focus();

                setActionButtonStates(false);
                set_Enable(true);
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (checkRequiredFields())
                {
                    DialogResult _rsp = MessageBox.Show("Save event type? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (_rsp == DialogResult.Yes)
                    {
                        EventType _oEventType = new EventType();
                        initializeNewEventType(ref _oEventType);

                        if (loOperationMode == OperationMode.Add)
                        {
                            insertNewEventType(_oEventType);
                        }
                        else
                        {
                            _oEventType.EventID = int.Parse(txtEventID.Text);
                            updateEventTypes(_oEventType);
                        }

                        this.Text = "Event Types";
                        btnCancel_Click(sender, new EventArgs());
                    }
                }
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                if (this.grdEventTypes.Rows > 1)
                {
                    this.grdEventTypes_RowColChange(this, new EventArgs());
                }

                this.Text = "Event Types";
                setActionButtonStates(true);
                loControlListener.Listen(this);
                set_Enable(false);
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                DialogResult _rsp = MessageBox.Show("Remove event type from list?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_rsp == DialogResult.Yes)
                {
                    loEventTypeFacade = new EventTypeFacade();

                    try
                    {
                        loEventTypeFacade.deleteEventType(txtEventID.Text, ref lEventTypeList);
                        grdEventTypes.RemoveItem(grdEventTypes.Row);

                        if (grdEventTypes.Rows > 1)
                        {
                            grdEventTypes.Row = 1;
                            grdEventTypes_RowColChange(this, new EventArgs());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            private void EventHeaderUI_Load(object sender, EventArgs e)
            {
                loadEventTypeData();
                setActionButtonStates(true);
                set_Enable(false);
                grdEventTypes_RowColChange(this, new EventArgs());
            }

            private void EventHeaderUI_TextChanged(object sender, EventArgs e)
            {
                if (this.Text.IndexOf('*') > 0)
                {
                    setOperationMode(OperationMode.Edit);
                    setActionButtonStates(false);
                    set_Enable(true);
                }
                else
                {
                    setActionButtonStates(true);
                    set_Enable(false);
                }
            }

            #endregion
        }
    }
}