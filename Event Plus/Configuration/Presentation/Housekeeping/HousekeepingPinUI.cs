using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public partial class HousekeepingPinUI : Form
    {
        public HousekeepingPinUI()
        {
            InitializeComponent();
        }
        private bool isPinOK;
        public bool ShoPinUI()
        {
            this.ShowDialog();
            return isPinOK;
        }
        private void CheckPin()
        {
			//MinibarSaleFacade sf = new MinibarSaleFacade();
            //isPinOK = sf.checkPinCode(this.txtPin.Text.Trim());
        }
        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                CheckPin();
                this.Close();
            }
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CheckPin();
            this.Close();
        }
        
    }
}