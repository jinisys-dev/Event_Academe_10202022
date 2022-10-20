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
	public partial class ReasonForCancelUI : Form
	{
		public ReasonForCancelUI()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (this.txtReason.Text.Trim().Length <= 0)
			{
				this.txtReason.Focus();
				return;
			}

			this.Close();
		}

		public string showDialog()
		{
			base.ShowDialog();

			return this.txtReason.Text;
		}

        private void ReasonForCancelUI_Load(object sender, EventArgs e)
        {
            GroupBookingDropDownFacade _oGroupBookingDropDown = new GroupBookingDropDownFacade();
            string[] _strReason = _oGroupBookingDropDown.getByFieldName("Reason");
            cboReason.DataSource = _strReason;
            string[] _strBookingType = _oGroupBookingDropDown.getByFieldName("CancelBookingType");
            cboCancelBookingType.DataSource = _strBookingType;
        }

        public string getReason()
        {
            return cboReason.Text;
        }

        public string getBookingType()
        {
            return cboCancelBookingType.Text;
        }

	}
}