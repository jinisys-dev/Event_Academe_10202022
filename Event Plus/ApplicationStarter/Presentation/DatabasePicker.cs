using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ApplicationStarter.Business_Layer;

namespace ApplicationStarter.Presentation
{
    public partial class DatabasePicker : Form
    {
        public DatabasePicker()
        {
            InitializeComponent();
        }
        private static string lConnectionString;
        private static string lNewConStr;
        private Utility oUtility;
        private void DatabasePicker_Load(object sender, EventArgs e)
        {
            try
            {
                string _connStr = ConfigurationManager.AppSettings.Get("connection");
                lConnectionString = _connStr;
                string[] aConStr = _connStr.Split(';');
                string lNewConStr = "";
                for (int i = 0; i < aConStr.Length; i++)
                {
                    if (!aConStr[i].ToLower().Contains("database"))
                    {
                        lNewConStr = lNewConStr + aConStr[i];
                        if (i != aConStr.Length - 1)
                            lNewConStr = lNewConStr + ';';
                    }
                }
                oUtility = new Utility(lNewConStr);
                DataTable dtDatabaseList = oUtility.getDatabases();
                foreach (DataRow _dRow in dtDatabaseList.Rows)
                {
                    string _temp = _dRow["Database"].ToString();
                    if(_temp.ToLower().StartsWith("event"))
                        cboDatabase.Items.Add(_temp);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public string getConnectionString()
        {
            return lNewConStr;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboDatabase.Text == "")
            {
                MessageBox.Show("Please choose a database", "Academe Version Error");
                return;
            }
            string[] aConStr = lConnectionString.Split(';');
            for (int i = 0; i < aConStr.Length; i++)
            {
                if (aConStr[i].ToLower().Contains("database"))
                    aConStr[i] = "database=" + cboDatabase.Text;
            }
            lNewConStr = aConStr[0] + ";" + aConStr[1] + ";" + aConStr[2] + ";" + aConStr[3] + ";" + aConStr[4];
            //MessageBox.Show(lNewConStr);
            this.oUtility.closeConnection();
            this.Close();
        }
    }
}