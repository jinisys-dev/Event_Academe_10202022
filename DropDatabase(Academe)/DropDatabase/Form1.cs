using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using MySql.Data.MySqlClient;

namespace DropDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadDatabase(string pDatabaseType)
        {
            cboHotel.Items.Clear();
            try
            {
                string _connectionString = "server=localhost;user id=root;password=j1n15y5admin;port=3307";
                MySqlConnection _oConnection = new MySqlConnection(_connectionString);

                DataTable _oDtTable = new DataTable();
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter("show databases", _oConnection);
                _oDataAdapter.Fill(_oDtTable);

                foreach (DataRow dRow in _oDtTable.Rows)
                {
                    string _temp = dRow["Database"].ToString();
                    if (pDatabaseType == "Hotel")
                    {
                        if (_temp.ToLower().StartsWith("hotel"))
                            cboHotel.Items.Add(_temp);
                    }
                    else if (pDatabaseType == "Resto")
                    {
                        if (_temp.ToLower().StartsWith("resto"))
                            cboHotel.Items.Add(_temp);
                        if (_temp.ToLower().StartsWith("common"))
                            cboHotel.Items.Add(_temp);
                        if (_temp.ToLower().StartsWith("inventory"))
                            cboHotel.Items.Add(_temp);
                    }
                    if (pDatabaseType == "Event")
                    {
                        if (_temp.ToLower().StartsWith("event"))
                            cboHotel.Items.Add(_temp);
                    }
                }
            }
            catch { }
        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDatabase(cboDatabase.Text);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboHotel.Text == "")
                {
                    MessageBox.Show("Please select a database to drop.", "Drop Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (Directory.Exists(txtMysqlPath.Text + "\\bin\\"))
                    {
                        string _errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose -f drop " + cboHotel.Text, 10000);
                        if (_errMsg != "" && _errMsg != null)
                        {
                            MessageBox.Show("Error upon dropping database.\nError message : " + lMySQLerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mysql path not found.");
                    }
                }

                MessageBox.Show("Finished dropping database!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Unable to drop database.", "Drop Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string lMySQLerror = "";
        private string ExecuteCommand(string command, int timeOut)
        {
            lMySQLerror = "";
            ProcessStartInfo processInfo;
            Process process;
            StreamReader _outputString;
            StreamReader _errorString;
            string _logFile = Application.StartupPath + "\\dbLogs" + DateTime.Now.ToString("MMddyyyy") + ".log";

            if (!Directory.Exists(txtMysqlPath.Text + "\\bin\\"))
            {
                MessageBox.Show("Mysql path is incorrect!.");
                return "";
            }

            processInfo = new ProcessStartInfo("cmd.exe", "/C " + command /*+ " >> " + _logFile*/);
            processInfo.WorkingDirectory = txtMysqlPath.Text + "\\bin\\";
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            //processInfo.CreateNoWindow = true;

            process = Process.Start(processInfo);
            _outputString = process.StandardOutput;
            _errorString = process.StandardError;

            StreamWriter _oStreamReader = new StreamWriter(_logFile, true);
            _oStreamReader.WriteLine("Started logging : " + DateTime.Now.ToString());
            _oStreamReader.WriteLine(_outputString.ReadToEnd());

            lMySQLerror = _errorString.ReadToEnd();
            _oStreamReader.WriteLine(lMySQLerror);
            _oStreamReader.WriteLine("End of logging : " + DateTime.Now.ToString());
            _oStreamReader.WriteLine("------------------------------------------------------------------");
            _oStreamReader.Close();
            //process.WaitForExit(timeOut);

            return lMySQLerror;

            //process.Close();
        }

        private void txtMysqlPath_Click(object sender, EventArgs e)
        {
            fbdMysql.ShowNewFolderButton = false;
            DialogResult _rsp = fbdMysql.ShowDialog();
            if (_rsp == DialogResult.OK)
            {
                txtMysqlPath.Text = fbdMysql.SelectedPath;
            }

        }
    }
}