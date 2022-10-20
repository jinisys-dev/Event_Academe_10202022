using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Jinisys.Hotel.Services.Presentation
{
    public partial class AddRemark : Form
    {
        public AddRemark(int flag,String TransInfo )
        {
            InitializeComponent();
            mMode =(mode) Enum.Parse(mMode.GetType(), flag.ToString(), true);
            this.Text = TransInfo;
        }
        public AddRemark(int flag, String TransInfo,String remarks)
        {
            InitializeComponent();
            mMode = (mode)Enum.Parse(mMode.GetType(), flag.ToString(), true);
            this.Text = TransInfo;
            this.textBoxRemarks.Text = remarks;
        }
        private enum mode
        {
            Add=0,
            View_Update
        }
        private mode mMode;
        public String Remarks
        {
            get { return this.textBoxRemarks.Text; }
        }
        public  DialogResult ShowAddRemark()
        {
        return    base.ShowDialog();
          
        }
        private void AddRemark_Load(object sender, EventArgs e)
        {

        }
    }
}