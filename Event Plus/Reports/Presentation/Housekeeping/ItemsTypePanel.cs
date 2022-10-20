using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Jinisys.Housekeeping.Reports.Presentation
{
    public partial class ItemsTypePanel : UserControl
    {
        public ItemsTypePanel()
        {
            InitializeComponent();
        }

        public delegate void btnViewEventHandler(Object sender, EventArgs e);
        public event btnViewEventHandler btnViewClick;

   

        public int CategoryID
        {
            get { return int.Parse(this.comboBox1.ValueMember); }
        }
     
        public DataTable DataSource
        {
            get { return (DataTable)this.comboBox1.DataSource; }
            set {

                this.comboBox1.DataSource = value;
                this.comboBox1.Refresh();
            }
        }
        public String DisplayMember
        {
            get { return this.comboBox1.DisplayMember; }
            set 
            { 
               this.comboBox1.DisplayMember = value;
               this.comboBox1.Refresh();
            }
        }
        public String ValueMember
        {
            get { return this.comboBox1.ValueMember; }
            set { this.comboBox1.ValueMember = "CategoryID"; }
        }
        public String SelectedValue
        {
            get
            {
                if (this.comboBox1.SelectedValue == null)
                {
                    this.comboBox1.SelectedValue = this.comboBox1.Items[0];
                }
                return this.comboBox1.SelectedValue.ToString();
            }
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            btnViewClick(this, e);
        }
    }
}
