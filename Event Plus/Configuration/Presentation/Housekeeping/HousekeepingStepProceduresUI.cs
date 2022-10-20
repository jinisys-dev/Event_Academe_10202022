using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	
		public class HousekeepingStepProcedureUI : System.Windows.Forms.Form
		{
			
			
			#region " Windows Form Designer generated code "
			
		
			
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
			public System.Windows.Forms.GroupBox GroupBox2;
            public System.Windows.Forms.TextBox txtId;
            public System.Windows.Forms.TextBox txtName;
			public System.Windows.Forms.Label Label9;
            public System.Windows.Forms.Label Label8;
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.ListView lvwStepProcedures;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
            internal System.Windows.Forms.ColumnHeader ColumnHeader3;
			internal System.Windows.Forms.Panel pnlSearch;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.Label Label16;
            internal System.Windows.Forms.Button btnSearch;
            public TextBox txtTextToSpeak;
            public Label label3;
            private Button btnOpen;
            public TextBox txtSoundFile;
            public Label label2;
            private CheckBox chkUseSoundFile;
            public Label label6;
            public Label label5;
            private CheckBox chkIsBefore;
            public Label label4;
            private OpenFileDialog ofdFileDialog;
            private NumericUpDown nudExpectedDigit;
            private NumericUpDown nudMaxDigit;
            private NumericUpDown nudRank;
			internal System.Windows.Forms.Label picClose;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                this.GroupBox2 = new System.Windows.Forms.GroupBox();
                this.nudExpectedDigit = new System.Windows.Forms.NumericUpDown();
                this.nudMaxDigit = new System.Windows.Forms.NumericUpDown();
                this.nudRank = new System.Windows.Forms.NumericUpDown();
                this.label6 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.chkIsBefore = new System.Windows.Forms.CheckBox();
                this.label4 = new System.Windows.Forms.Label();
                this.txtTextToSpeak = new System.Windows.Forms.TextBox();
                this.label3 = new System.Windows.Forms.Label();
                this.btnOpen = new System.Windows.Forms.Button();
                this.txtSoundFile = new System.Windows.Forms.TextBox();
                this.label2 = new System.Windows.Forms.Label();
                this.chkUseSoundFile = new System.Windows.Forms.CheckBox();
                this.txtId = new System.Windows.Forms.TextBox();
                this.txtName = new System.Windows.Forms.TextBox();
                this.Label9 = new System.Windows.Forms.Label();
                this.Label8 = new System.Windows.Forms.Label();
                this.gbxCommands = new System.Windows.Forms.GroupBox();
                this.btnSearch = new System.Windows.Forms.Button();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnNew = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnDelete = new System.Windows.Forms.Button();
                this.lvwStepProcedures = new System.Windows.Forms.ListView();
                this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.pnlSearch = new System.Windows.Forms.Panel();
                this.picClose = new System.Windows.Forms.Label();
                this.Label1 = new System.Windows.Forms.Label();
                this.txtSearch = new System.Windows.Forms.TextBox();
                this.Label16 = new System.Windows.Forms.Label();
                this.ofdFileDialog = new System.Windows.Forms.OpenFileDialog();
                this.GroupBox2.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.nudExpectedDigit)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.nudMaxDigit)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.nudRank)).BeginInit();
                this.gbxCommands.SuspendLayout();
                this.pnlSearch.SuspendLayout();
                this.SuspendLayout();
                // 
                // GroupBox2
                // 
                this.GroupBox2.Controls.Add(this.nudExpectedDigit);
                this.GroupBox2.Controls.Add(this.nudMaxDigit);
                this.GroupBox2.Controls.Add(this.nudRank);
                this.GroupBox2.Controls.Add(this.label6);
                this.GroupBox2.Controls.Add(this.label5);
                this.GroupBox2.Controls.Add(this.chkIsBefore);
                this.GroupBox2.Controls.Add(this.label4);
                this.GroupBox2.Controls.Add(this.txtTextToSpeak);
                this.GroupBox2.Controls.Add(this.label3);
                this.GroupBox2.Controls.Add(this.btnOpen);
                this.GroupBox2.Controls.Add(this.txtSoundFile);
                this.GroupBox2.Controls.Add(this.label2);
                this.GroupBox2.Controls.Add(this.chkUseSoundFile);
                this.GroupBox2.Controls.Add(this.txtId);
                this.GroupBox2.Controls.Add(this.txtName);
                this.GroupBox2.Controls.Add(this.Label9);
                this.GroupBox2.Controls.Add(this.Label8);
                this.GroupBox2.Location = new System.Drawing.Point(219, -4);
                this.GroupBox2.Name = "GroupBox2";
                this.GroupBox2.Size = new System.Drawing.Size(309, 311);
                this.GroupBox2.TabIndex = 34;
                this.GroupBox2.TabStop = false;
                // 
                // nudExpectedDigit
                // 
                this.nudExpectedDigit.Location = new System.Drawing.Point(165, 254);
                this.nudExpectedDigit.Name = "nudExpectedDigit";
                this.nudExpectedDigit.Size = new System.Drawing.Size(54, 20);
                this.nudExpectedDigit.TabIndex = 59;
                // 
                // nudMaxDigit
                // 
                this.nudMaxDigit.Location = new System.Drawing.Point(232, 212);
                this.nudMaxDigit.Name = "nudMaxDigit";
                this.nudMaxDigit.Size = new System.Drawing.Size(54, 20);
                this.nudMaxDigit.TabIndex = 58;
                // 
                // nudRank
                // 
                this.nudRank.Location = new System.Drawing.Point(83, 212);
                this.nudRank.Name = "nudRank";
                this.nudRank.Size = new System.Drawing.Size(54, 20);
                this.nudRank.TabIndex = 57;
                // 
                // label6
                // 
                this.label6.Location = new System.Drawing.Point(83, 258);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(83, 19);
                this.label6.TabIndex = 52;
                this.label6.Text = "Expected Digit:";
                // 
                // label5
                // 
                this.label5.Location = new System.Drawing.Point(168, 216);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(67, 19);
                this.label5.TabIndex = 50;
                this.label5.Text = "Max Digit:";
                // 
                // chkIsBefore
                // 
                this.chkIsBefore.AutoSize = true;
                this.chkIsBefore.Location = new System.Drawing.Point(84, 184);
                this.chkIsBefore.Name = "chkIsBefore";
                this.chkIsBefore.Size = new System.Drawing.Size(76, 18);
                this.chkIsBefore.TabIndex = 49;
                this.chkIsBefore.Text = "Is Before?";
                this.chkIsBefore.UseVisualStyleBackColor = true;
                // 
                // label4
                // 
                this.label4.Location = new System.Drawing.Point(12, 216);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(67, 19);
                this.label4.TabIndex = 47;
                this.label4.Text = "Rank:";
                // 
                // txtTextToSpeak
                // 
                this.txtTextToSpeak.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtTextToSpeak.Location = new System.Drawing.Point(84, 131);
                this.txtTextToSpeak.MaxLength = 30;
                this.txtTextToSpeak.Multiline = true;
                this.txtTextToSpeak.Name = "txtTextToSpeak";
                this.txtTextToSpeak.Size = new System.Drawing.Size(220, 45);
                this.txtTextToSpeak.TabIndex = 44;
                // 
                // label3
                // 
                this.label3.Location = new System.Drawing.Point(10, 133);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(87, 19);
                this.label3.TabIndex = 45;
                this.label3.Text = "Text to Speak:";
                // 
                // btnOpen
                // 
                this.btnOpen.Location = new System.Drawing.Point(273, 101);
                this.btnOpen.Name = "btnOpen";
                this.btnOpen.Size = new System.Drawing.Size(30, 20);
                this.btnOpen.TabIndex = 43;
                this.btnOpen.Text = "...";
                this.btnOpen.UseVisualStyleBackColor = true;
                this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
                // 
                // txtSoundFile
                // 
                this.txtSoundFile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtSoundFile.Location = new System.Drawing.Point(85, 101);
                this.txtSoundFile.MaxLength = 30;
                this.txtSoundFile.Name = "txtSoundFile";
                this.txtSoundFile.Size = new System.Drawing.Size(182, 20);
                this.txtSoundFile.TabIndex = 41;
                // 
                // label2
                // 
                this.label2.Location = new System.Drawing.Point(11, 103);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(67, 19);
                this.label2.TabIndex = 42;
                this.label2.Text = "Sound File:";
                // 
                // chkUseSoundFile
                // 
                this.chkUseSoundFile.AutoSize = true;
                this.chkUseSoundFile.Location = new System.Drawing.Point(85, 75);
                this.chkUseSoundFile.Name = "chkUseSoundFile";
                this.chkUseSoundFile.Size = new System.Drawing.Size(98, 18);
                this.chkUseSoundFile.TabIndex = 40;
                this.chkUseSoundFile.Text = "Use Sound File";
                this.chkUseSoundFile.UseVisualStyleBackColor = true;
                // 
                // txtId
                // 
                this.txtId.BackColor = System.Drawing.SystemColors.Info;
                this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtId.Enabled = false;
                this.txtId.Location = new System.Drawing.Point(85, 18);
                this.txtId.MaxLength = 11;
                this.txtId.Name = "txtId";
                this.txtId.Size = new System.Drawing.Size(99, 20);
                this.txtId.TabIndex = 1;
                this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
                // 
                // txtName
                // 
                this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtName.Location = new System.Drawing.Point(85, 45);
                this.txtName.MaxLength = 30;
                this.txtName.Name = "txtName";
                this.txtName.Size = new System.Drawing.Size(214, 20);
                this.txtName.TabIndex = 2;
                // 
                // Label9
                // 
                this.Label9.Location = new System.Drawing.Point(11, 21);
                this.Label9.Name = "Label9";
                this.Label9.Size = new System.Drawing.Size(106, 11);
                this.Label9.TabIndex = 39;
                this.Label9.Text = "ID:";
                // 
                // Label8
                // 
                this.Label8.Location = new System.Drawing.Point(11, 47);
                this.Label8.Name = "Label8";
                this.Label8.Size = new System.Drawing.Size(67, 19);
                this.Label8.TabIndex = 35;
                this.Label8.Text = "Name:";
                // 
                // gbxCommands
                // 
                this.gbxCommands.Controls.Add(this.btnSearch);
                this.gbxCommands.Controls.Add(this.btnSave);
                this.gbxCommands.Controls.Add(this.btnNew);
                this.gbxCommands.Controls.Add(this.btnCancel);
                this.gbxCommands.Controls.Add(this.btnDelete);
                this.gbxCommands.Location = new System.Drawing.Point(2, 307);
                this.gbxCommands.Name = "gbxCommands";
                this.gbxCommands.Size = new System.Drawing.Size(526, 47);
                this.gbxCommands.TabIndex = 35;
                this.gbxCommands.TabStop = false;
                // 
                // btnSearch
                // 
                this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSearch.Location = new System.Drawing.Point(248, 11);
                this.btnSearch.Name = "btnSearch";
                this.btnSearch.Size = new System.Drawing.Size(66, 31);
                this.btnSearch.TabIndex = 10;
                this.btnSearch.Text = "Search";
                this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
                // 
                // btnSave
                // 
                this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSave.Location = new System.Drawing.Point(386, 11);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(66, 31);
                this.btnSave.TabIndex = 8;
                this.btnSave.Text = "Save";
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnNew
                // 
                this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnNew.Location = new System.Drawing.Point(317, 11);
                this.btnNew.Name = "btnNew";
                this.btnNew.Size = new System.Drawing.Size(66, 31);
                this.btnNew.TabIndex = 5;
                this.btnNew.Text = "New";
                this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
                // 
                // btnCancel
                // 
                this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCancel.Location = new System.Drawing.Point(455, 11);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(66, 31);
                this.btnCancel.TabIndex = 9;
                this.btnCancel.Text = "Cancel";
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // btnDelete
                // 
                this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnDelete.Location = new System.Drawing.Point(6, 11);
                this.btnDelete.Name = "btnDelete";
                this.btnDelete.Size = new System.Drawing.Size(66, 31);
                this.btnDelete.TabIndex = 4;
                this.btnDelete.Text = "Delete";
                this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                // 
                // lvwStepProcedures
                // 
                this.lvwStepProcedures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader2,
            this.ColumnHeader3});
                this.lvwStepProcedures.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lvwStepProcedures.FullRowSelect = true;
                this.lvwStepProcedures.GridLines = true;
                this.lvwStepProcedures.Location = new System.Drawing.Point(2, 1);
                this.lvwStepProcedures.Name = "lvwStepProcedures";
                this.lvwStepProcedures.Size = new System.Drawing.Size(214, 306);
                this.lvwStepProcedures.TabIndex = 127;
                this.lvwStepProcedures.UseCompatibleStateImageBehavior = false;
                this.lvwStepProcedures.View = System.Windows.Forms.View.Details;
                this.lvwStepProcedures.SelectedIndexChanged += new System.EventHandler(this.lvwStepProcedures_SelectedIndexChanged);
                this.lvwStepProcedures.Click += new System.EventHandler(this.lvwStepProcedures_Click);
                // 
                // ColumnHeader2
                // 
                this.ColumnHeader2.Text = "ID";
                this.ColumnHeader2.Width = 54;
                // 
                // ColumnHeader3
                // 
                this.ColumnHeader3.Text = "Name";
                this.ColumnHeader3.Width = 137;
                // 
                // pnlSearch
                // 
                this.pnlSearch.BackColor = System.Drawing.SystemColors.Info;
                this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.pnlSearch.Controls.Add(this.picClose);
                this.pnlSearch.Controls.Add(this.Label1);
                this.pnlSearch.Controls.Add(this.txtSearch);
                this.pnlSearch.Controls.Add(this.Label16);
                this.pnlSearch.Location = new System.Drawing.Point(108, 21);
                this.pnlSearch.Name = "pnlSearch";
                this.pnlSearch.Size = new System.Drawing.Size(271, 105);
                this.pnlSearch.TabIndex = 183;
                this.pnlSearch.Visible = false;
                // 
                // picClose
                // 
                this.picClose.BackColor = System.Drawing.Color.SteelBlue;
                this.picClose.Location = new System.Drawing.Point(247, 4);
                this.picClose.Name = "picClose";
                this.picClose.Size = new System.Drawing.Size(18, 16);
                this.picClose.TabIndex = 5;
                this.picClose.Click += new System.EventHandler(this.Close_Click);
                // 
                // Label1
                // 
                this.Label1.Location = new System.Drawing.Point(11, 38);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(240, 15);
                this.Label1.TabIndex = 4;
                this.Label1.Text = "Input Search String here";
                // 
                // txtSearch
                // 
                this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtSearch.Location = new System.Drawing.Point(11, 62);
                this.txtSearch.Name = "txtSearch";
                this.txtSearch.Size = new System.Drawing.Size(248, 22);
                this.txtSearch.TabIndex = 3;
                this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
                // 
                // Label16
                // 
                this.Label16.BackColor = System.Drawing.Color.SteelBlue;
                this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Label16.Location = new System.Drawing.Point(1, 1);
                this.Label16.Name = "Label16";
                this.Label16.Size = new System.Drawing.Size(267, 20);
                this.Label16.TabIndex = 0;
                this.Label16.Text = "      Search";
                this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // ofdFileDialog
                // 
                this.ofdFileDialog.FileName = "StepProcedure";
                this.ofdFileDialog.Filter = "*.wav| Wav Files";
                // 
                // HousekeepingStepProcedureUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.ClientSize = new System.Drawing.Size(530, 356);
                this.Controls.Add(this.pnlSearch);
                this.Controls.Add(this.lvwStepProcedures);
                this.Controls.Add(this.gbxCommands);
                this.Controls.Add(this.GroupBox2);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.MaximizeBox = false;
                this.Name = "HousekeepingStepProcedureUI";
                this.Text = "Step Procedures";
                this.Closing += new System.ComponentModel.CancelEventHandler(this.HousekeepingTypeUI_Closing);
                this.TextChanged += new System.EventHandler(this.StoredProceduresUI_TextChanged);
                this.Load += new System.EventHandler(this.StepProceduresUI_Load);
                this.GroupBox2.ResumeLayout(false);
                this.GroupBox2.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.nudExpectedDigit)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.nudMaxDigit)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.nudRank)).EndInit();
                this.gbxCommands.ResumeLayout(false);
                this.pnlSearch.ResumeLayout(false);
                this.pnlSearch.PerformLayout();
                this.ResumeLayout(false);

			}
			
			#endregion

            #region Variables and Constants

            private OperationMode mOperationMode;

            private ControlListener oControlListener ;
            private DatasetBinder oDataSetBinder ;

            private HousekeepingStepProcedure oStepProcedure ;
			private HousekeepingStepProcedureFacade oStepProcedureFacade;

            #endregion

            #region Constructor

            public HousekeepingStepProcedureUI()
            {

                oControlListener = new ControlListener();
                oDataSetBinder = new DatasetBinder();
                oStepProcedure = new HousekeepingStepProcedure();
                oStepProcedureFacade = new HousekeepingStepProcedureFacade();
                InitializeComponent();
            }

            #endregion

            #region Methods

            private void populateDataGrid()
            {
               for (int i = 0; i <= oStepProcedure.Tables[0].Rows.Count - 1; i++)
                {
                    ListViewItem lst = new ListViewItem(oStepProcedure.Tables[0].Rows[i]["Id"].ToString());
                    string name = oStepProcedure.Tables[0].Rows[i]["Name"].ToString();
                    lst.SubItems.Add(name);

                    this.lvwStepProcedures.Items.Add(lst);
                }

               
            }

            private bool hasChanges()
            {
                if (this.Text.IndexOf("*") > 0)
                    return true;
                else
                    return false;
            }

            private void bindRowToControls()
            {
                
                try
                {
                   oControlListener.StopListen(this);

                    this.BindingContext[oStepProcedure.Tables[0]].Position = findItemInDataSet(this.lvwStepProcedures.SelectedItems[0].Text);

                    oControlListener.Listen(this);

                }
                catch (Exception)
                {
                  
                }
            }

            private void assignEntityValues()
            {
                oStepProcedure.Id = this.txtId.Text;
                oStepProcedure.Name = this.txtName.Text;
                oStepProcedure.UseSoundFile = this.chkUseSoundFile.Checked;
                oStepProcedure.SoundFile = this.txtSoundFile.Text;
                oStepProcedure.isBefore = this.chkIsBefore.Checked;
                oStepProcedure.Rank = (int)nudRank.Value;
                oStepProcedure.maxDigit=  (int)nudMaxDigit.Value;
                oStepProcedure.ExpectedDigit = (int)nudExpectedDigit.Value;
                
            }

            private bool isRequiredEntriesFilled()
            {
                if (this.txtId.Text.Length == 0 || this.txtName.Text.Length == 0 ) return false;
                return true;
            }

            private void setActionButtonStates(bool a_stat)
            {
                btnDelete.Enabled = a_stat;
                btnNew.Enabled = a_stat;
                this.btnOpen.Enabled = !a_stat ;
                btnSave.Enabled = !a_stat;
                btnCancel.Enabled = !a_stat;
            }

            private void deselectItem()
            {
                for (int i = 0; i <= this.lvwStepProcedures.Items.Count - 1; i++)
                {
                    this.lvwStepProcedures.Items[i].Selected = false;
                }
            }

            private int findItemInDataSet(string key)
            {
               int i = 0;
               foreach (DataRow drRoom in oStepProcedure.Tables[0].Rows)
                {

                   if (drRoom["Id"].ToString() == key)
                    {
                        
                        return i;
                    }
                    else
                    {
                        i++;
                    }
                }
                return 0;
            }
            private bool isChecked(string val,string key)
            {
               
                foreach (DataRow drRoom in oStepProcedure.Tables[0].Rows)
                {

                    if (drRoom["Id"].ToString() == key)
                    {
                        if(drRoom[val].ToString()=="1")
                            return true;
                    }
                   
                }
                return false;
            }


            private void setOperationMode(OperationMode a_OperationMode)
            {
                mOperationMode = a_OperationMode;
            }
		
            #endregion			

            #region Data Access Methods

            public bool load()
            {
                try
                {
                    oStepProcedureFacade = new HousekeepingStepProcedureFacade();
                    oStepProcedure = new HousekeepingStepProcedure();
                    oStepProcedure = oStepProcedureFacade.getStepProcedure();
                    return true;
                }
                catch (Exception) { return false; }
            }

            public int insert()
            {
                try
                {
                    int rowsAffected = 0;
                    oStepProcedureFacade = new HousekeepingStepProcedureFacade();
                    rowsAffected = oStepProcedureFacade.insertStepProcedure(oStepProcedure);
                    return rowsAffected;
                }
                catch (Exception) { return 0; }
            }

            public int update()
            {
                try
                {
                    int rowsAffected = 0;
                    oStepProcedureFacade = new HousekeepingStepProcedureFacade();
                    rowsAffected = oStepProcedureFacade.updateStepProcedure(ref oStepProcedure);
                    return rowsAffected;
                }
                catch (Exception) { return 0; }
            }

            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oStepProcedureFacade = new HousekeepingStepProcedureFacade();
                    rowsAffected = oStepProcedureFacade.deleteStepProcedure(ref oStepProcedure);
                    return rowsAffected;
                }
                catch (Exception) { return 0; }
            }

            #endregion

            #region Events

            private void StepProceduresUI_Load(object sender, System.EventArgs e)
            {
               
                if (load() == true)
                {

                    if (oStepProcedure != null)
                    {
                        oControlListener.Listen(this);
                        object temp_object = oStepProcedure;
                        populateDataGrid();
                        oDataSetBinder.BindControls(this, ref temp_object, new ArrayList());
                      
                    }

                }
                             
                this.btnCancel_Click(sender,e);
                
                }
                    

            private void grdHousekeepingType_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (hasChanges() == true)
                {
                    if (MessageBox.Show("Save changes made to StepProcedure \'" + this.txtId.Text + "\'", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (update() > 0)
                        {
                            this.lvwStepProcedures.Items[findItemInDataSet(this.txtId.Text)].SubItems[1].Text = oStepProcedure.Name;

                            this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                            this.txtId.Enabled = false;

                            this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                            this.Text = "Step Procedures*";

                            oControlListener.Listen(this);

                        }
                        else
                        {
                            MessageBox.Show("No rows updated", "Database Update Error");
                        }
                    }
                    else
                    {
                        this.BindingContext[oStepProcedure.Tables["StepProcedures"]].CancelCurrentEdit();
                        this.Text = "Step Procedures*";

                    }
                }
            }

            private void btnNew_Click(System.Object sender, System.EventArgs e)
            {
                setOperationMode(OperationMode.Add);
                oControlListener.StopListen(this);

                this.BindingContext[oStepProcedure.Tables["StepProcedures"]].SuspendBinding();

                this.txtId.Enabled = true;
                this.txtId.Focus();

                setActionButtonStates(false);
            }

            private void HousekeepingTypeUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                //if (hasChanges() == true)
                //{
                //    if (MessageBox.Show("Save changes made to StepProcedure \'" + this.txtId.Text + "\'", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                //    {
                //        if (update() > 0)
                //        {
                //            this.lvwStepProcedures.Items[findItemInDataSet(this.txtId.Text)].SubItems[1].Text = oStepProcedure.Name ;

                //            this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                //            this.txtId.Enabled = false;

                //            this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                //            this.Text = "Step Procedures";

                //            oControlListener.Listen(this);

                //        }
                //        else
                //        {
                //            MessageBox.Show("No rows updated", "Database Update Error");
                //        }
                //    }
                //    else
                //    {
                //        this.BindingContext[oStepProcedure.Tables["StepProcedures"]].CancelCurrentEdit();
                //        this.Text = "Step Procedures";

                //    }
                //}
            }

            private void btnSave_Click(System.Object sender, System.EventArgs e)
            {
                if (isRequiredEntriesFilled())
                {
                    assignEntityValues();

                    switch (mOperationMode)
                    {

                        case OperationMode.Add:
                            if (insert() > 0)
                            {
                                ListViewItem lst = new ListViewItem(oStepProcedure.Id);
                                lst.SubItems.Add(oStepProcedure.Name);

                                this.lvwStepProcedures.Items.Add(lst);

                                this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                                this.txtId.Enabled = false;

                                this.Text = "Step Procedures";

                                setActionButtonStates(true);

                                oControlListener.Listen(this);
                            }
                            else
                            {
                                MessageBox.Show("No rows added", "Database Insert Error");
                            }

                            break;
                        case OperationMode.Edit:
                            if (update() > 0)
                            {
                                this.lvwStepProcedures.Items[findItemInDataSet(this.txtId.Text)].SubItems[1].Text = oStepProcedure.Name;

                                this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                                this.txtId.Enabled = false;

                                this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                                this.Text = "Step Procedures";

                                oControlListener.Listen(this);
                            }
                            else
                            {
                                MessageBox.Show("No rows updated", "Database Update Error");
                            }
                            break;
                        default:
                            MessageBox.Show("Invalid operation mode", "Abort operation");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Please input necessary field(s)");
                    return;
                }
            }

            private void btnCancel_Click(System.Object sender, System.EventArgs e)
            {
                if (mOperationMode.Equals(OperationMode.Add))
                {
                    if (this.lvwStepProcedures.Items.Count > 0)
                    {
                        this.lvwStepProcedures.Items[0].Selected = true;
                    }
                }
                else
                {
                    this.BindingContext[oStepProcedure.Tables["StepProcedures"]].CancelCurrentEdit();
                }

                this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                setActionButtonStates(true);
                oControlListener.Listen(this);
                this.Text = "Step Procedures";
                
            }

            private void btnDelete_Click(System.Object sender, System.EventArgs e)
            {

                if (MessageBox.Show("Delete StepProcedure \'" + this.txtName.Text + "\'", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    

                    oControlListener.StopListen(this);

                    oStepProcedure.Id = this.txtId.Text;
                    
                    if (delete() > 0)
                    {
                        this.lvwStepProcedures.SelectedItems[0].Remove();

                        if (this.lvwStepProcedures.Items.Count > 0)
                        {
                            this.lvwStepProcedures.Items[0].Selected = true;
                        }

                        this.BindingContext[oStepProcedure.Tables["StepProcedures"]].ResumeBinding();
                        oControlListener.Listen(this);
                        this.Text = "Step Procedures";

                    }
                }
            }

            private void StoredProceduresUI_TextChanged(object sender, System.EventArgs e)
            {
                if (this.Text.IndexOf("*") > 0)
                {
                    setOperationMode(OperationMode.Edit);
                    setActionButtonStates(false);
                }
                else
                {
                    setActionButtonStates(true);
                }
            }

         
            private void btnSearch_Click(System.Object sender, System.EventArgs e)
            {

                this.oControlListener.StopListen(this);
                this.pnlSearch.Visible = true;
                this.txtSearch.Focus();
            }

            private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    this.lvwStepProcedures.Focus();

                    deselectItem();

                    for (int i = 0; i <= this.lvwStepProcedures.Items.Count - 1; i++)
                    {
                        if (this.lvwStepProcedures.Items[i].SubItems[1].Text.ToUpper().Contains(this.txtSearch.Text.ToUpper()) || this.lvwStepProcedures.Items[i].Text.ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.lvwStepProcedures.Items[i].Selected = true;

                            this.pnlSearch.Visible = false;

                            this.oControlListener.Listen(this);
                            return;
                        }
                    }
                }
            }

            private void Close_Click(System.Object sender, System.EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            #endregion

            private void txtId_TextChanged(object sender, EventArgs e)
            {
                this.chkUseSoundFile.Checked = isChecked("UseSoundFile", this.txtId.Text);
                this.chkIsBefore.Checked = isChecked("isBefore", this.txtId.Text);
            }

            private void btnOpen_Click(object sender, EventArgs e)
            {
                if (this.ofdFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtSoundFile.Text = ofdFileDialog.FileName;
                }
            }

            private void lvwStepProcedures_Click(object sender, EventArgs e)
            {
                this.bindRowToControls();
            }

            private void lvwStepProcedures_SelectedIndexChanged(object sender, EventArgs e)
            {
                bindRowToControls();
            }

         

          

       

         
       
		}
	}

