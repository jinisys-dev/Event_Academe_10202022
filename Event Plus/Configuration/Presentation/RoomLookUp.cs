/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/


using System;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public class RoomLookUp : Jinisys.Hotel.UIFramework.LookUPUI
    {

        #region " Windows Form Designer generated code "

        public RoomLookUp()
        {

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add any initialization after the InitializeComponent() call

        }

        //Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.Container components = null;

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        internal System.Windows.Forms.GroupBox gbxRate;
        // Public WithEvents Label1 As System.Windows.Forms.Label
        public System.Windows.Forms.TextBox txtRateCode;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.GroupBox gbxRoomType;
        public System.Windows.Forms.Label Label8;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.TextBox txtRoomTypeId;
        internal System.Windows.Forms.Button Button2;
        public System.Windows.Forms.TextBox txtRoomTypeCode;
        public System.Windows.Forms.TextBox txtMaxOccupants;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomLookUp));
            this.gbxRate = new System.Windows.Forms.GroupBox();
            this.txtRateCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.gbxRoomType = new System.Windows.Forms.GroupBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtMaxOccupants = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtRoomTypeCode = new System.Windows.Forms.TextBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.gbxRate.SuspendLayout();
            this.gbxRoomType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwLookUp
            // 
            this.lvwLookUp.Location = new System.Drawing.Point(4, 98);
            this.lvwLookUp.Size = new System.Drawing.Size(373, 276);
            this.lvwLookUp.DoubleClick += new System.EventHandler(this.lvwLookUp_DoubleClick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Location = new System.Drawing.Point(408, -1);
            this.GroupBox1.Size = new System.Drawing.Size(375, 119);
            this.GroupBox1.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(280, 12);
            // 
            // cboCriteria
            // 
            this.cboCriteria.Size = new System.Drawing.Size(160, 22);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(25, 19);
            this.Label1.Size = new System.Drawing.Size(39, 16);
            this.Label1.Text = "ID :";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(312, 384);
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbxRate
            // 
            this.gbxRate.Controls.Add(this.txtRateCode);
            this.gbxRate.Controls.Add(this.txtDescription);
            this.gbxRate.Controls.Add(this.Label7);
            this.gbxRate.Controls.Add(this.Label1);
            this.gbxRate.Location = new System.Drawing.Point(4, -1);
            this.gbxRate.Name = "gbxRate";
            this.gbxRate.Size = new System.Drawing.Size(375, 97);
            this.gbxRate.TabIndex = 66;
            this.gbxRate.TabStop = false;
            this.gbxRate.Visible = false;
            this.gbxRate.Controls.SetChildIndex(this.Label1, 0);
            this.gbxRate.Controls.SetChildIndex(this.Label7, 0);
            this.gbxRate.Controls.SetChildIndex(this.txtDescription, 0);
            this.gbxRate.Controls.SetChildIndex(this.txtRateCode, 0);
            // 
            // txtRateCode
            // 
            this.txtRateCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtRateCode.Enabled = false;
            this.txtRateCode.Location = new System.Drawing.Point(96, 16);
            this.txtRateCode.Multiline = true;
            this.txtRateCode.Name = "txtRateCode";
            this.txtRateCode.Size = new System.Drawing.Size(99, 20);
            this.txtRateCode.TabIndex = 55;
            this.txtRateCode.TextChanged += new System.EventHandler(this.txtRateCode_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(96, 46);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(205, 40);
            this.txtDescription.TabIndex = 57;
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(25, 46);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(64, 17);
            this.Label7.TabIndex = 59;
            this.Label7.Text = "Description";
            // 
            // gbxRoomType
            // 
            this.gbxRoomType.Controls.Add(this.Label8);
            this.gbxRoomType.Controls.Add(this.txtMaxOccupants);
            this.gbxRoomType.Controls.Add(this.Label9);
            this.gbxRoomType.Controls.Add(this.txtRoomTypeCode);
            this.gbxRoomType.Location = new System.Drawing.Point(4, -1);
            this.gbxRoomType.Name = "gbxRoomType";
            this.gbxRoomType.Size = new System.Drawing.Size(375, 97);
            this.gbxRoomType.TabIndex = 67;
            this.gbxRoomType.TabStop = false;
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.Location = new System.Drawing.Point(16, 27);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(58, 17);
            this.Label8.TabIndex = 107;
            this.Label8.Text = "Type ID";
            // 
            // txtMaxOccupants
            // 
            this.txtMaxOccupants.BackColor = System.Drawing.Color.White;
            this.txtMaxOccupants.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxOccupants.Location = new System.Drawing.Point(112, 56);
            this.txtMaxOccupants.Name = "txtMaxOccupants";
            this.txtMaxOccupants.Size = new System.Drawing.Size(24, 20);
            this.txtMaxOccupants.TabIndex = 105;
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(16, 56);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(107, 17);
            this.Label9.TabIndex = 108;
            this.Label9.Text = "Max Occupants";
            // 
            // txtRoomTypeCode
            // 
            this.txtRoomTypeCode.BackColor = System.Drawing.Color.White;
            this.txtRoomTypeCode.Enabled = false;
            this.txtRoomTypeCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomTypeCode.Location = new System.Drawing.Point(80, 25);
            this.txtRoomTypeCode.Name = "txtRoomTypeCode";
            this.txtRoomTypeCode.Size = new System.Drawing.Size(231, 20);
            this.txtRoomTypeCode.TabIndex = 105;
            this.txtRoomTypeCode.TextChanged += new System.EventHandler(this.txtRoomTypeCode_TextChanged);
            // 
            // Button2
            // 
            this.Button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(232, 384);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(66, 31);
            this.Button2.TabIndex = 68;
            this.Button2.Text = "&Select";
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // RoomLookUp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(380, 421);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.gbxRate);
            this.Controls.Add(this.gbxRoomType);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoomLookUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ServicesLookUPUI_Load);
            this.Controls.SetChildIndex(this.gbxRoomType, 0);
            this.Controls.SetChildIndex(this.gbxRate, 0);
            this.Controls.SetChildIndex(this.lvwLookUp, 0);
            this.Controls.SetChildIndex(this.GroupBox1, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.Button2, 0);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.gbxRate.ResumeLayout(false);
            this.gbxRate.PerformLayout();
            this.gbxRoomType.ResumeLayout(false);
            this.gbxRoomType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// Local Variables are Camel Casing ( ex. camelCasing )
        /// Variables prefixed by "o" is an Object Instance ( ex. oCurrencyCode )
        /// </summary>
        #region " VARIABLES "

        private string lookUp;
        private TextBox txtLookUp;

        private DatasetBinder oDatasetBinder;
        private RateCode oRateCode;
        private RateCodeFacade oRateCodeFacade;
        private RoomType oRoomType;
        private RoomTypeFacade oRoomTypeFacade;

        #endregion

        #region " CONSTRUCTORS "

        public RoomLookUp(string LookUpName)
        {
            InitializeComponent();

            lookUp = LookUpName;
            oDatasetBinder = new DatasetBinder();
            txtLookUp = new TextBox();
        }

        public RoomLookUp(string LookUpName, TextBox TextBox)
        {
            InitializeComponent();

            oDatasetBinder = new DatasetBinder();
            txtLookUp = new TextBox();

            lookUp = LookUpName;
            txtLookUp = TextBox;
        }

        #endregion

        #region " METHODS "

        private bool load()
        {
            if (lookUp == "Rate Codes")
            {
                oRateCode = new RateCode();
                oRateCodeFacade = new RateCodeFacade();
                oRateCode = (RateCode)oRateCodeFacade.loadObject();
            }
            else
            {
                oRoomType = new RoomType();
                oRoomTypeFacade = new RoomTypeFacade();
                oRoomType = (RoomType)oRoomTypeFacade.loadObject();
            }

            this.Text = "Available " + lookUp;
            return true;
        }

        private bool loadDataToListView(DataTable dtTable)
        {
            try
            {
                int i = 0;
                this.lvwLookUp.Clear();
                foreach (DataColumn dc in dtTable.Columns)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = dc.ColumnName;
                    lvwLookUp.Columns.Add(ch);
                    lvwLookUp.Columns[i].Width = 90;

                    i++;
                }
                foreach (DataRow dr in dtTable.Rows)
                {
                    int Cols;

                    ListViewItem li = new ListViewItem();
                    li.Text = dr[0].ToString();

                    for (Cols = 1; Cols <= dtTable.Columns.Count - 1; Cols++)
                    {

                        ListViewItem.ListViewSubItem liSub = new ListViewItem.ListViewSubItem();
                        if (!dr[Cols].ToString().Equals(null))
                        {
                            liSub.Text = dr[Cols].ToString();
                        }
                        else
                        {
                            liSub.Text = "";
                        }
                        li.SubItems.Add(liSub);
                    }
                    lvwLookUp.Items.Add(li);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool displayDescription()
        {
            if (this.lvwLookUp.Items.Count > 0)
            {
                if (lookUp == "Rate Codes")
                {
                    this.BindingContext[oRateCode.Tables["RateCodes"]].Position = this.lvwLookUp.SelectedIndices[0];
                }
                else
                {
                    this.BindingContext[oRoomType.Tables["RoomTypes"]].Position = this.lvwLookUp.SelectedIndices[0];
                }
            }
            return true;
        }

        public bool assignRoomTypeAndExit()
        {
            if (lookUp == "RoomTypes")
            {
                RoomUI.RoomTypeCode = lvwLookUp.SelectedItems[0].Text;
                RoomUI.MaxOccupants = int.Parse(this.lvwLookUp.Items[lvwLookUp.SelectedIndices[0]].SubItems[1].Text);
                RoomUI.NoOfBeds = int.Parse(this.lvwLookUp.Items[lvwLookUp.SelectedIndices[0]].SubItems[2].Text);
                RoomUI.NoOfAdult = int.Parse(this.lvwLookUp.Items[lvwLookUp.SelectedIndices[0]].SubItems[3].Text);
                RoomUI.NoOfChild = int.Parse(this.lvwLookUp.Items[lvwLookUp.SelectedIndices[0]].SubItems[4].Text);
                RoomUI.ShareType = this.lvwLookUp.Items[lvwLookUp.SelectedIndices[0]].SubItems[5].Text;
            }
            this.Close();

            return true;
        }


        #endregion

        #region " EVENTS "

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ServicesLookUPUI_Load(object sender, System.EventArgs e)
        {
            if ( load() == true)
            {
                if (lookUp == "Rate Codes")
                {
                    loadDataToListView(oRateCode.Tables["RateCodes"]);

                    this.gbxRate.Visible = true;
                    gbxRoomType.Visible = false;

                    object obj = (object)oRateCode;
                    Control frm = this;
                    oDatasetBinder.BindControls(this, ref obj, new ArrayList());
                }
                else
                {
                    loadDataToListView(oRoomType.Tables["RoomTypes"]);

                    gbxRoomType.Visible = true;
                    this.gbxRate.Visible = false;

                    Control frm = this;
                    object obj = (object)oRoomType;
                    oDatasetBinder.BindControls(frm, ref obj, new ArrayList());
                }
            }


        }

        private void lvwLookUp_Click(System.Object sender, System.EventArgs e)
        {
            displayDescription();
        }

        private void Button2_Click(System.Object sender, System.EventArgs e)
        {

            assignRoomTypeAndExit();
        }

        private void lvwLookUp_DoubleClick(System.Object sender, System.EventArgs e)
        {
            Button2_Click(sender, e);
        }

        private void txtRoomTypeCode_TextChanged(object sender, System.EventArgs e)
        {
            this.txtLookUp.Text = this.txtRoomTypeCode.Text;
        }

        private void txtRateCode_TextChanged(object sender, System.EventArgs e)
        {
            this.txtLookUp.Text = this.txtRateCode.Text;
        }

        #endregion

        
    }
}