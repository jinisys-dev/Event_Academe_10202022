using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.Reservation.BusinessLayer;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class StatisticsAccountsTypeUI : Form
    {
        public StatisticsAccountsTypeUI()
        {
            InitializeComponent();
        }

        private void StatisticsAccountsTypeUI_Load(object sender, EventArgs e)
        {
            loadDropDowns();
        }
        private void loadDropDowns()
        {
            GroupBookingDropDownFacade _BookingFacade = new GroupBookingDropDownFacade();
            DataTable _oDataTable = _BookingFacade.getSpecificFieldName("MarketSegment");

            
            cboMarketSegment.Items.Clear();
            cboMarketSegment.Items.Add("");
            foreach (DataRow _oRow in _oDataTable.Rows)
            {
                cboMarketSegment.Items.Add(_oRow["value"].ToString().ToUpper());
            }

            DataTable _oDataTableAccountType = _BookingFacade.getSpecificFieldName("AccountType");
            cboClientType.Items.Clear();
            cboClientType.Items.Add("");
            foreach (DataRow _oRow in _oDataTableAccountType.Rows)
            {
                cboClientType.Items.Add(_oRow["value"].ToString().ToUpper());
            }

        }
        private void btnShow_Click(object sender, EventArgs e)
        {


        }
        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}