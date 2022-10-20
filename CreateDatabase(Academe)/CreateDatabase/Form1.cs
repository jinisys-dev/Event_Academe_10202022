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

namespace CreateDatabase
{
    public partial class frmCreateDatabase : Form
    {
        public frmCreateDatabase()
        {
            InitializeComponent();

            //Thread _oThread = new Thread(new ThreadStart(loadForm));
            //_oThread.IsBackground = true;
            //_oThread.Priority = ThreadPriority.AboveNormal;
            //_oThread.Start();

            if (Directory.Exists(txtMysqlPath.Text + "\\bin\\"))
            {
                loadForm();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //ExecuteCommandAsync();
            if (Directory.Exists(txtMysqlPath.Text + "\\bin\\"))
            {
                loadForm();
                string dbType = cboDatabase.Text;
                string dbName = txtDBName.Text;
                string dbHotel = cboHotel.Text;

                createDatabase(dbType, dbName, dbHotel);
            }else
            {
                MessageBox.Show("Mysql path not found.");
            }
        }

        private void ExecuteCommandAsync()
        {
            //Thread _oThread = new Thread(new ParameterizedThreadStart(createDatabase));
            //_oThread.IsBackground = true;
            //_oThread.Priority = ThreadPriority.AboveNormal;
            //_oThread.Start();
            string dbType = cboDatabase.Text;
            string dbName = txtDBName.Text;
            string dbHotel = cboHotel.Text;

            ThreadStart _oThread = delegate { new frmCreateDatabase().createDatabase(dbType, dbName, dbHotel); };
            new Thread(_oThread).Start();
        }

        private void createDatabase(object pDatabaseType, object pDatabaseName, object pHotelDBName)
        {
            try
            {
                if (pDatabaseType.ToString() == "")
                {
                    MessageBox.Show("Please select a database type to create.", "Select Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    //StreamWriter strWriter;
                    string _errMsg;
                    switch (pDatabaseType.ToString())
                    {
                        case "Hotel":
                            StreamReader strReader = new StreamReader(Application.StartupPath + "\\hotel.dll");
                            string strOrig = strReader.ReadToEnd();
                            string strCopy = string.Copy(strOrig);

                            strCopy = strCopy.Replace("`hotelmgtsystem`", "`hotel_" + pDatabaseName + "`");
                            strCopy = strCopy.Replace("'hotelmgtsystem'", "'hotel_" + pDatabaseName + "'");
                            strCopy = strCopy.Replace("`hotelmgtsystem`", "hotel_" + txtDBName.Text);
                            // Gene 05/07/2013
                            // Academe 2
                            strCopy = strCopy.Replace("`pos`", "resto_" + txtDBName.Text);
                            strCopy = strCopy.Replace("`common`", "common_" + txtDBName.Text);
                            //>>
                            strReader.Close();

                            //jlo 3-21-11
                            StreamWriter strWriter = new StreamWriter(Application.StartupPath + "\\hotel.dll");
                            strWriter.Write(strCopy);
                            strWriter.Close();

                            if (File.Exists(Application.StartupPath + "\\temp.dll"))
                            {
                                File.Delete(Application.StartupPath + "\\temp.dll");
                            }
                            File.WriteAllText(Application.StartupPath + "\\temp.dll", strCopy);
                            try
                            {
                                //Console.WriteLine("Uploading database files...");

                                // Gene 05/02/2013
                                // Academe 2 DEMO
                                _errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create hotel_" + pDatabaseName, 10000);
                                //_errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create hotelmgtsystem", 10000);
                                if (_errMsg != "" && _errMsg != null)
                                {
                                    MessageBox.Show("Error upon creating database.\nError message : " + lMySQLerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                Thread.Sleep(10000);

                                // Gene 05/02/2013
                                // Academe 2 DEMO
                                _errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin -v -v -v hotel_" + pDatabaseName + " < \"" + Application.StartupPath + "\\temp.dll\"", 10000);
                                //_errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin -v -v -v hotelmgtsystem < \"" + Application.StartupPath + "\\temp.dll\"", 10000);
                                if (_errMsg != "" && _errMsg != null)
                                {
                                    MessageBox.Show("Error upon dumping database.\nError message : " + lMySQLerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                Thread.Sleep(10000);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                if(File.Exists(Application.StartupPath + "\\temp.dll"))
                                {
                                    File.Delete(Application.StartupPath + "\\temp.dll");
                                }
                            }
                            //jlo 3-21-11
                            strWriter = new StreamWriter(Application.StartupPath + "\\hotel.dll");
                            strWriter.Write(strOrig);
                            strWriter.Close();
                            break;

                            // Riyadh 05/13/2015
                            // Added for Event

                        case "Event":
                            strReader = new StreamReader(Application.StartupPath + "\\event.dll");
                            string strOrigEvent = strReader.ReadToEnd();
                            string strCopyEvent = string.Copy(strOrigEvent);

                            strCopyEvent = strCopyEvent.Replace("`eventmgtsystem`", "`event_" + pDatabaseName + "`");
                            strCopyEvent = strCopyEvent.Replace("'eventmgtsystem'", "'event_" + pDatabaseName + "'");
                            strCopyEvent = strCopyEvent.Replace("`eventmgtsystem`", "event_" + txtDBName.Text);
                            strReader.Close();

                            strWriter = new StreamWriter(Application.StartupPath + "\\event.dll");
                            strWriter.Write(strCopyEvent);
                            strWriter.Close();

                            if (File.Exists(Application.StartupPath + "\\temp.dll"))
                            {
                                File.Delete(Application.StartupPath + "\\temp.dll");
                            }
                            File.WriteAllText(Application.StartupPath + "\\temp.dll", strCopyEvent);
                            try
                            {
                                _errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create event_" + pDatabaseName, 10000);

                                if (_errMsg != "" && _errMsg != null)
                                {
                                    MessageBox.Show("Error upon creating database.\nError message : " + lMySQLerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                Thread.Sleep(10000);

                                _errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin -v -v -v event_" + pDatabaseName + " < \"" + Application.StartupPath + "\\temp.dll\"", 10000);
                               
                                if (_errMsg != "" && _errMsg != null)
                                {
                                    MessageBox.Show("Error upon dumping database.\nError message : " + lMySQLerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                Thread.Sleep(10000);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                if (File.Exists(Application.StartupPath + "\\temp.dll"))
                                {
                                    File.Delete(Application.StartupPath + "\\temp.dll");
                                }
                            }
                            
                            strWriter = new StreamWriter(Application.StartupPath + "\\event.dll");
                            strWriter.Write(strOrigEvent);
                            strWriter.Close();
                            break;

                        case "Resto":
                            strReader = new StreamReader(Application.StartupPath + "\\resto.dll");
                            string strOrigResto = strReader.ReadToEnd();
                            string strCopyResto = string.Copy(strOrigResto);

                            // Gene 05/06/2013
                            // Academe 2
                            StreamReader commonReader = new StreamReader(Application.StartupPath + "\\common.dll");
                            string strOrigCommon = commonReader.ReadToEnd();
                            string strCopyCommon = string.Copy(strOrigCommon);

                            StreamReader inventoryReader = new StreamReader(Application.StartupPath + "\\inventory.dll");
                            string strOrigInventory = inventoryReader.ReadToEnd();
                            string strCopyInventory = string.Copy(strOrigInventory);

                            strCopyCommon = strCopyCommon.Replace("`common`", "`common_" + pDatabaseName + "`");
                            strCopyCommon = strCopyCommon.Replace("'common'", "'common_" + pDatabaseName + "'");
                            //strCopyCommon = strCopyCommon.Replace("common", "common_" + pDatabaseName + "");
                            strCopyCommon = strCopyCommon.Replace("'pos'", "'resto_" + pDatabaseName + "'");
                            strCopyCommon = strCopyCommon.Replace("`pos`", "`resto_" + pDatabaseName + "`");
                            //strCopyCommon = strCopyCommon.Replace("pos", "resto_" + pDatabaseName + "");
                            strCopyCommon = strCopyCommon.Replace("'inventory'", "'inventory_" + pDatabaseName + "'");
                            strCopyCommon = strCopyCommon.Replace("`inventory`", "`inventory_" + pDatabaseName + "`");
                            strCopyCommon = strCopyCommon.Replace("inventory", "inventory_" + pDatabaseName + "");
                            strCopyCommon = strCopyCommon.Replace("'hotelmgtsystem'", "'" + pHotelDBName + "'");
                            strCopyCommon = strCopyCommon.Replace("`hotelmgtsystem`", "`" + pHotelDBName + "`");
                            strCopyCommon = strCopyCommon.Replace("hotelmgtsystem", "" + pHotelDBName + "");

                            strCopyInventory = strCopyInventory.Replace("`inventory`", "`inventory_" + pDatabaseName + "`");
                            strCopyInventory = strCopyInventory.Replace("'inventory'", "'inventory_" + pDatabaseName + "'");
                            //strCopyInventory = strCopyInventory.Replace("inventory", "inventory_" + pDatabaseName + "");
                            strCopyInventory = strCopyInventory.Replace("`common`", "`common_" + pDatabaseName + "`");
                            strCopyInventory = strCopyInventory.Replace("'common'", "'common_" + pDatabaseName + "'");
                            //strCopyInventory = strCopyInventory.Replace("common", "common_" + pDatabaseName + "");
                            strCopyInventory = strCopyInventory.Replace("`pos`", "`resto_" + pDatabaseName + "`");
                            strCopyInventory = strCopyInventory.Replace("'pos'", "'resto_" + pDatabaseName + "'");
                            
                            strCopyInventory = strCopyInventory.Replace("`hotelmgtsystem`", "`" + pHotelDBName+ "`");
                            strCopyInventory = strCopyInventory.Replace("'hotelmgtsystem'", "'" + pHotelDBName + "'");
                            strCopyInventory = strCopyInventory.Replace("hotelmgtsystem", "" + pHotelDBName + "");
                            //>>

                            // Gene 05/07/2013
                            // Academe 2
                            strCopyResto = strCopyResto.Replace("`pos`", "`resto_" + pDatabaseName + "`");
                            strCopyResto = strCopyResto.Replace("'pos'", "'resto_" + pDatabaseName + "'");                            
                            strCopyResto = strCopyResto.Replace("`hotelmgtsystem`", "`" + pHotelDBName + "`");
                            strCopyResto = strCopyResto.Replace("'hotelmgtsystem'", "'" + pHotelDBName + "'");
                            strCopyResto = strCopyResto.Replace("hotelmgtsystem", "" + pHotelDBName + "");
                            strCopyResto = strCopyResto.Replace("`common`", "`common_" + pDatabaseName + "`");
                            strCopyResto = strCopyResto.Replace("'common'", "'common_" + pDatabaseName + "'");
                            strCopyResto = strCopyResto.Replace("`inventory`", "`inventory_" + pDatabaseName + "`");
                            strCopyResto = strCopyResto.Replace("'inventory'", "'inventory_" + pDatabaseName + "'");
                            //>>
                            //strCopyResto = strCopyResto.Replace("`hotelmgtsystem`", cboHotel.Text);
                            strReader.Close();
                            commonReader.Close();
                            inventoryReader.Close();

                            // Gene 05/02/2013
                            // Academe 2 DEMO
                            strWriter = new StreamWriter(Application.StartupPath + "\\resto.dll");
                            strWriter.Write(strCopyResto);
                            strWriter.Close();
                            strWriter = new StreamWriter(Application.StartupPath + "\\common.dll");
                            strWriter.Write(strCopyCommon);
                            strWriter.Close();
                            strWriter = new StreamWriter(Application.StartupPath + "\\inventory.dll");
                            strWriter.Write(strCopyInventory);
                            strWriter.Close();
                            //>>

                            //Console.WriteLine("Uploading database files...");

                            // Gene 05/02/2013
                            // Academe 2 DEMO
                            _errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create resto_" + pDatabaseName, 10000);
                            _errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create common_" + pDatabaseName, 10000);
                            _errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create inventory_" + pDatabaseName, 10000);
                            //_errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create pos", 10000);
                            //_errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create common", 10000);
                            //_errMsg = ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create inventory", 10000);
                            //>>
                            if (_errMsg != "" && _errMsg != null)
                            {
                                MessageBox.Show("Error upon creating database.\nError message : " + lMySQLerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            Thread.Sleep(10000);

                            // Gene 05/02/2013
                            // Academe 2 DEMO
                            _errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin --verbose resto_" + pDatabaseName + " < \"" + Application.StartupPath + "\\resto.dll\"", 10000);
                            _errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin --verbose common_" + pDatabaseName + " < \"" + Application.StartupPath + "\\common.dll\"", 10000);
                            _errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin --verbose inventory_" + pDatabaseName + " < \"" + Application.StartupPath + "\\inventory.dll\"", 10000);
                            //_errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin --verbose pos < \"" + Application.StartupPath + "\\resto.dll\"", 10000);
                            //_errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin --verbose common < \"" + Application.StartupPath + "\\common.dll\"", 10000);
                            //_errMsg = ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin --verbose inventory < \"" + Application.StartupPath + "\\inventory.dll\"", 10000);
                            //>>
                            if (_errMsg != "" && _errMsg != null)
                            {
                                MessageBox.Show("Error upon dumping database.\nError message : " + lMySQLerror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            Thread.Sleep(10000);

                            // Gene 05/02/2013
                            // Academe 2 DEMO
                            strWriter = new StreamWriter(Application.StartupPath + "\\resto.dll");
                            strWriter.Write(strOrigResto);
                            strWriter.Close();
                            //>>

                            // Gene 05/06/2013
                            // Academe 2
                            strWriter = new StreamWriter(Application.StartupPath + "\\common.dll");
                            strWriter.Write(strOrigCommon);
                            strWriter.Close();

                            strWriter = new StreamWriter(Application.StartupPath + "\\inventory.dll");
                            strWriter.Write(strOrigInventory);
                            strWriter.Close();
                            //>>
                            break;

                        case "Housekeeping":
                            strReader = new StreamReader(Application.StartupPath + "\\housekeeping.sql");
                            string strOrigHkpg = strReader.ReadToEnd();
                            string strCopyHkpg = string.Copy(strOrigHkpg);

                            strCopyHkpg = strCopyHkpg.Replace("`housekeeping`", "`hk_" + txtDBName.Text + "`");
                            strCopyHkpg = strCopyHkpg.Replace("'housekeeping'", "'hk_" + txtDBName.Text + "'");
                            strCopyHkpg = strCopyHkpg.Replace("housekeeping", "hk_" + txtDBName.Text);
                            strReader.Close();

                            strWriter = new StreamWriter(Application.StartupPath + "\\housekeeping.sql");
                            strWriter.Write(strCopyHkpg);
                            strWriter.Close();

                            Console.WriteLine("Uploading database files...");
                            ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create " + txtDBName.Text, 10000);
                            Thread.Sleep(10000);
                            ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin --verbose < \"" + Application.StartupPath + "\\housekeeping.sql\"", 10000);
                            Thread.Sleep(10000);

                            strWriter = new StreamWriter(Application.StartupPath + "\\housekeeping.sql");
                            strWriter.Write(strOrigHkpg);
                            strWriter.Close();
                            break;

                        case "Call Accounting":
                            strReader = new StreamReader(Application.StartupPath + "\\callmgtsystem.sql");
                            string strOrigCallAcctg = strReader.ReadToEnd();
                            string strCopyCallAcctg = string.Copy(strOrigCallAcctg);

                            strCopyCallAcctg = strCopyCallAcctg.Replace("`callmgtsystem`", "`" + txtDBName.Text + "`");
                            strCopyCallAcctg = strCopyCallAcctg.Replace("'callmgtsystem'", "'" + txtDBName.Text + "'");
                            strCopyCallAcctg = strCopyCallAcctg.Replace("callmgtsystem", txtDBName.Text);
                            strReader.Close();

                            strWriter = new StreamWriter(Application.StartupPath + "\\callmgtsystem.sql");
                            strWriter.Write(strCopyCallAcctg);
                            strWriter.Close();

                            Console.WriteLine("Uploading database files...");
                            ExecuteCommand("mysqladmin --user=root -hlocalhost -pj1n15y5admin --verbose create " + txtDBName.Text, 10000);
                            Thread.Sleep(10000);
                            ExecuteCommand("mysql -uroot -hlocalhost -pj1n15y5admin --verbose < \"" + Application.StartupPath + "\\callmgtsystem.sql\"", 10000);
                            Thread.Sleep(10000);

                            strWriter = new StreamWriter(Application.StartupPath + "\\callmgtsystem.sql");
                            strWriter.Write(strOrigCallAcctg);
                            strWriter.Close();
                            break;

                        default:
                            MessageBox.Show("Unable to create database type.", "Create Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
                if (Directory.Exists(txtMysqlPath.Text + "\\bin\\"))
                {
                    MessageBox.Show("Finished uploading database!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Unable to create database.", "Create Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string lMySQLerror = "";
        private string ExecuteCommand(string command, int timeOut)
        {
            if (!Directory.Exists(txtMysqlPath.Text + "\\bin\\"))
            {
                MessageBox.Show("Mysql path is incorrect!.");
                return "";
            }

            lMySQLerror = "";
            ProcessStartInfo processInfo;
            Process process;
            StreamReader _outputString;
            StreamReader _errorString;
            string _logFile = Application.StartupPath + "\\dbLogs" + DateTime.Now.ToString("MMddyyyy") + ".log";
            processInfo = new ProcessStartInfo("cmd.exe", "/C " + command /*+ " >> " + _logFile*/);
            //processInfo.WorkingDirectory = "c:\\program files\\mysql\\mysql server 5.0\\bin\\";
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

        private void ExecuteMySQLCommand()
        {
            string connection="server=localhost;user id=root;password=j1n15y5admin;port=3307";
            string sql = "grant all privileges on *.* to 'root'@'%'";
            //string sql = "show databases";
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void loadForm()
        {
            if (isProcessOpen("MYSQL") == false)
            {
                ExecuteCommand("mysqld --install --verbose", 100000);
                Thread.Sleep(5000);

                ExecuteCommand("net start mysql", 100000);
                Thread.Sleep(10000);

                ExecuteCommand("mysqladmin -uroot password j1n15y5admin --verbose", 10000);
                Thread.Sleep(5000);

                ExecuteCommand("mysqladmin -uroot -proot password j1n15y5admin --verbose", 10000);
                Thread.Sleep(5000);

                ExecuteCommand("mysqladmin -uroot -pj1n15y5admin password j1n15y5admin --verbose", 10000);
                Thread.Sleep(5000);
                
                ExecuteMySQLCommand();
            }
            else
            {
                ExecuteCommand("mysqladmin -uroot password j1n15y5admin --verbose", 10000);
                Thread.Sleep(5000);

                ExecuteCommand("mysqladmin -uroot -proot password j1n15y5admin --verbose", 10000);
                Thread.Sleep(5000);

                ExecuteCommand("mysqladmin -uroot -pj1n15y5admin password j1n15y5admin --verbose", 10000);
                Thread.Sleep(5000);
                
                ExecuteMySQLCommand();
            }
        }

        public bool isProcessOpen(string processName)
        {
            foreach (Process _oProcess in Process.GetProcesses())
            {
                if (_oProcess.ProcessName.ToUpper().Contains(processName))
                {
                    return true;
                }
            }

            return false;
        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboDatabase.Text)
            {
                case "Resto":
                    lblHotel.Visible = true;
                    cboHotel.Visible = true;
                    loadHotelDatabase();
                    break;

                default:
                    lblHotel.Visible = false;
                    cboHotel.Visible = false;
                    break;
            }
        }

        private void loadHotelDatabase()
        {
            try
            {
                string _connectionString = "server=localhost;user id=root;password=j1n15y5admin;port=3307";
                MySqlConnection _oConnection = new MySqlConnection(_connectionString);

                DataTable _oDtTable = new DataTable();
                MySqlDataAdapter _oDataAdapter = new MySqlDataAdapter("show databases", _oConnection);
                _oDataAdapter.Fill(_oDtTable);

                cboHotel.Items.Clear();

                foreach (DataRow dRow in _oDtTable.Rows)
                {
                    string _temp = dRow["Database"].ToString();
                    if (_temp.ToLower().StartsWith("hotel"))
                        cboHotel.Items.Add(_temp);
                }
            }
            catch { }
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

        private void frmCreateDatabase_Load(object sender, EventArgs e)
        {

        }
    }
}