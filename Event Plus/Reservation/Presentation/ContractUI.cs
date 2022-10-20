using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Diagnostics;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class ContractUI : Form
    {
        public ContractUI()
        {
            InitializeComponent();
        }
        string lFolioID = "";
        public ContractUI(string pFolioID)
        {
            lFolioID = pFolioID;
            InitializeComponent();
        }
        


        private void ContractUI_Load(object sender, EventArgs e)
        {

        }

        private void btnUploadLOP_Click(object sender, EventArgs e)
        {
            if (lFolioID != "")
            {
                //string strFileName = "LOP - " + txtGroupName.Text;
                ContractUploadFileDialog.Filter = "Word Files (*.doc)|*.doc|Excel Files (*.xls)|*.xls|PDF Files (*.pdf)|*.pdf";
                ContractUploadFileDialog.FileName = "";
                DialogResult _result = ContractUploadFileDialog.ShowDialog();
                if (_result == DialogResult.OK)
                {
                    try
                    {
                        string _ext = Path.GetExtension(ContractUploadFileDialog.FileName);
                        string _fileName = getDestFileName(ConfigVariables.gServerUploadPath.Replace("\\\\", "\\"), lFolioID, _ext);
                        // File.Copy(ofdUpload.FileName, ConfigVariables.gServerUploadPath + loFolio.FolioID + "" + ofdUpload.Filter, true);
                        File.Copy(ContractUploadFileDialog.FileName, _fileName, false);
                        MessageBox.Show("Upload successful!", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a problem uploading the document!\r\nError: " + ex.Message, "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnViewLOP_Click(object sender, EventArgs e)
        {
            try
            {
                if (lFolioID != null && lFolioID !="")
                {

                    // string _file = ConfigVariables.gServerUploadPath + loFolio.FolioID + ".doc";
                    //_file = _file.Replace("\\\\", "\\");
                    string _path = ConfigVariables.gServerUploadPath.Replace("\\\\", "\\");
                    string[] _files = GetFileNames(_path, lFolioID + " CONTRACT");

                    string _file = ConfigVariables.gServerUploadPath.Replace("\\\\", "\\") + "\\" + _files[_files.Length - 1];
                    Process.Start(_file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem viewing the Contract.\r\nError: File Not Found", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public string getDestFileName(string pServerPath, string pFileName, string pExt)
        {
            string _lFileName = "";
            int _cnt = 0;
            while (true)
            {
                _lFileName = pServerPath + "\\" + pFileName + " CONTRACT " + DateTime.Now.ToString("yyy-dd-MM") + " " + "[" + _cnt + "]" + pExt;
                if (System.IO.File.Exists(_lFileName))
                {
                    _cnt++;
                    continue;
                }
                return _lFileName;
            }
        }
        private static string[] GetFileNames(string pPath, string pFilter)
        {
            string[] _files = Directory.GetFiles(pPath, "*" + pFilter + "*");
            for (int i = 0; i < _files.Length; i++)
                _files[i] = Path.GetFileName(_files[i]);
            return _files;
        }
       
    }
}