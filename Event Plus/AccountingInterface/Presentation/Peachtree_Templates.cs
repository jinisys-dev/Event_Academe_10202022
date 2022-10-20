using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Jinisys.Hotel.AccountingInterface.Peachtree_Interface;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    public partial class Peachtree_Templates : Form
    {
        public Peachtree_Templates()
        {
            InitializeComponent();
        }

        private void clearBoxes()
        {
            foreach (Control _ctrl in this.Controls)
            {
                if (_ctrl is TextBox)
                {
                    _ctrl.Text = "";
                }
            }
        }

        private void txtFilename_Click(object sender, EventArgs e)
        {
            OpenFileDialog _ofdBox = new OpenFileDialog();
            _ofdBox.DefaultExt = ".csv";
            if (_ofdBox.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = _ofdBox.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFilename.Text == "")
            {
                MessageBox.Show("Please select a file.", "Select a file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (!txtFilename.Text.ToLower().Contains(".csv"))
            {
                MessageBox.Show("You have chosen an invalid file.", "Invalid file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            importFile(this.txtFilename.Text);
            DialogResult _res = new DialogResult();
            _res = MessageBox.Show("Do you want to add more templates?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_res == DialogResult.No)
            {
                close();
            }
        }

        private void importFile(string pFilename)
        {
            string[] _temp = pFilename.Split('\\');
            string _template = _temp[_temp.Length - 1];
            _template = _template.Remove(_template.IndexOf('.'));
            try
            {
                using (StreamReader _sr = new StreamReader(pFilename))
                {
                    string _line;
                    while ((_line = _sr.ReadLine()) != null)
                    {
                        saveFile(_line.Split(','), _template);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void saveFile(string[] pFields, string pTemplate)
        {
            TemplateFacade _templateFacade = new TemplateFacade();
            DataTable _dataTable = new DataTable();
            try
            {
                _dataTable.Columns.Add("Template", typeof(string));
                _dataTable.Columns.Add("TemplateField", typeof(string));
                for (int i = 0; i < pFields.Length; i++)
                {
                    _dataTable.Rows.Add(pTemplate, pFields[i].Replace("\'","\\\'"));
                }
                _dataTable.AcceptChanges();

                _templateFacade.insertTemplates(_dataTable, pTemplate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void close()
        {
            this.Close();
            Peachtree_IntegrationSetup _IntergrationSetup = new Peachtree_IntegrationSetup();
            _IntergrationSetup.ShowDialog();
        }

        private void bntClose_Click(object sender, EventArgs e)
        {
            close();
        }

    }
}