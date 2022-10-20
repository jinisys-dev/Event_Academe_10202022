namespace Jinisys.Hotel.Accounts.Presentation
{
    partial class AgentUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgentUI));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAgentID = new System.Windows.Forms.Label();
            this.txtAgency = new System.Windows.Forms.TextBox();
            this.grdAgents = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.gbxCommands = new System.Windows.Forms.GroupBox();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgents)).BeginInit();
            this.gbxCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(463, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(6, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 31);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnSave.Location = new System.Drawing.Point(326, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 31);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(101, 163);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(192, 52);
            this.txtAddress.TabIndex = 6;
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(257, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(66, 31);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "&New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 62;
            this.label7.Text = "Travel Agency";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "Address";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(395, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.BackColor = System.Drawing.SystemColors.Info;
            this.txtContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPerson.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactPerson.Location = new System.Drawing.Point(101, 134);
            this.txtContactPerson.MaxLength = 50;
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(192, 20);
            this.txtContactPerson.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 56;
            this.label2.Text = "Contact Person";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 59);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(82, 17);
            this.Label1.TabIndex = 54;
            this.Label1.Text = "Agent ID";
            // 
            // grpMain
            // 
            this.grpMain.BackColor = System.Drawing.Color.Transparent;
            this.grpMain.Controls.Add(this.txtContactNo);
            this.grpMain.Controls.Add(this.label4);
            this.grpMain.Controls.Add(this.lblAgentID);
            this.grpMain.Controls.Add(this.txtAgency);
            this.grpMain.Controls.Add(this.label7);
            this.grpMain.Controls.Add(this.txtAddress);
            this.grpMain.Controls.Add(this.label3);
            this.grpMain.Controls.Add(this.txtContactPerson);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Controls.Add(this.Label1);
            this.grpMain.Location = new System.Drawing.Point(223, 7);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(315, 433);
            this.grpMain.TabIndex = 10;
            this.grpMain.TabStop = false;
            // 
            // txtContactNo
            // 
            this.txtContactNo.BackColor = System.Drawing.Color.White;
            this.txtContactNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(101, 224);
            this.txtContactNo.MaxLength = 50;
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(192, 20);
            this.txtContactNo.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 66;
            this.label4.Text = "Contact No.";
            // 
            // lblAgentID
            // 
            this.lblAgentID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAgentID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentID.Location = new System.Drawing.Point(101, 57);
            this.lblAgentID.Name = "lblAgentID";
            this.lblAgentID.Size = new System.Drawing.Size(84, 20);
            this.lblAgentID.TabIndex = 2;
            this.lblAgentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAgency
            // 
            this.txtAgency.BackColor = System.Drawing.SystemColors.Info;
            this.txtAgency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAgency.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgency.Location = new System.Drawing.Point(101, 105);
            this.txtAgency.MaxLength = 50;
            this.txtAgency.Name = "txtAgency";
            this.txtAgency.Size = new System.Drawing.Size(147, 20);
            this.txtAgency.TabIndex = 4;
            // 
            // grdAgents
            // 
            this.grdAgents.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            this.grdAgents.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:0;Caption:\"ID\";Visible:False;}\t1{Width:118;Caption:\"" +
                "Name\";}\t";
            this.grdAgents.ExtendLastCol = true;
            this.grdAgents.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdAgents.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grdAgents.Location = new System.Drawing.Point(3, 12);
            this.grdAgents.Name = "grdAgents";
            this.grdAgents.Rows.DefaultSize = 17;
            this.grdAgents.Size = new System.Drawing.Size(214, 428);
            this.grdAgents.StyleInfo = resources.GetString("grdAgents.StyleInfo");
            this.grdAgents.TabIndex = 9;
            this.grdAgents.RowColChange += new System.EventHandler(this.grdAgents_RowColChange);
            // 
            // gbxCommands
            // 
            this.gbxCommands.Controls.Add(this.btnClose);
            this.gbxCommands.Controls.Add(this.btnDelete);
            this.gbxCommands.Controls.Add(this.btnSave);
            this.gbxCommands.Controls.Add(this.btnNew);
            this.gbxCommands.Controls.Add(this.btnCancel);
            this.gbxCommands.Location = new System.Drawing.Point(3, 446);
            this.gbxCommands.Name = "gbxCommands";
            this.gbxCommands.Size = new System.Drawing.Size(535, 47);
            this.gbxCommands.TabIndex = 11;
            this.gbxCommands.TabStop = false;
            // 
            // AgentUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 503);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.grdAgents);
            this.Controls.Add(this.gbxCommands);
            this.Name = "AgentUI";
            this.Text = "Travel Agents";
            this.TextChanged += new System.EventHandler(this.AgentUI_TextChanged);
            this.Load += new System.EventHandler(this.AgentUI_Load);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgents)).EndInit();
            this.gbxCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtContactPerson;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.GroupBox grpMain;
        public System.Windows.Forms.TextBox txtContactNo;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblAgentID;
        public System.Windows.Forms.TextBox txtAgency;
        internal C1.Win.C1FlexGrid.C1FlexGrid grdAgents;
        internal System.Windows.Forms.GroupBox gbxCommands;
    }
}