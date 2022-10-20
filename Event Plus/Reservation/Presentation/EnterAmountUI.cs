using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class EnterAmountUI : Form
    {
        public EnterAmountUI()
        {
            InitializeComponent();
        }

        private double mAmount;
        public double Amount
        {
            get { return mAmount; }
            set { mAmount = value; }
        }

        private bool mSuccess;
        public bool Success
        {
            get { return mSuccess; }
            set { mSuccess = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Amount = double.Parse(txtAmount.Text);
                this.Success = true;
                this.Close();
            }
            catch (Exception ex)
            {
                txtAmount.Focus();
                txtAmount.SelectAll();
                epvError.SetError(txtAmount, "Invalid numberic value.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Success = false;
            this.Close();
        }

        private void EnterAmountUI_Load(object sender, EventArgs e)
        {
            epvError.SetIconAlignment(txtAmount, ErrorIconAlignment.MiddleRight);
            epvError.BlinkRate = 1000;
            epvError.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
    }
}