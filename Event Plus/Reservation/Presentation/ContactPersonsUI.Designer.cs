namespace Jinisys.Hotel.Reservation.Presentation
{
    partial class ContactPersonsUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactPersonsUI));
            this.grdGLAccounts = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpContactPersons = new System.Windows.Forms.GroupBox();
            this.cmsContactPersons = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContactPersonAddFromList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContactPersonsAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContactPersonsRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdGLAccounts)).BeginInit();
            this.grpContactPersons.SuspendLayout();
            this.cmsContactPersons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdGLAccounts
            // 
            this.grdGLAccounts.AutoGenerateColumns = false;
            this.grdGLAccounts.ColumnInfo = resources.GetString("grdGLAccounts.ColumnInfo");
            this.grdGLAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGLAccounts.Location = new System.Drawing.Point(3, 16);
            this.grdGLAccounts.Name = "grdGLAccounts";
            this.grdGLAccounts.Rows.Count = 1;
            this.grdGLAccounts.Rows.DefaultSize = 17;
            this.grdGLAccounts.Size = new System.Drawing.Size(361, 278);
            this.grdGLAccounts.StyleInfo = resources.GetString("grdGLAccounts.StyleInfo");
            this.grdGLAccounts.TabIndex = 2;
            this.grdGLAccounts.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdContactPersons_BeforeEdit);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(271, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 39);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Ok";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(332, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 39);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpContactPersons
            // 
            this.grpContactPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpContactPersons.Controls.Add(this.grdGLAccounts);
            this.grpContactPersons.Location = new System.Drawing.Point(12, 37);
            this.grpContactPersons.Name = "grpContactPersons";
            this.grpContactPersons.Size = new System.Drawing.Size(367, 297);
            this.grpContactPersons.TabIndex = 7;
            this.grpContactPersons.TabStop = false;
            // 
            // cmsContactPersons
            // 
            this.cmsContactPersons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContactPersonAddFromList,
            this.mnuContactPersonsAddNew,
            this.mnuContactPersonsRemove});
            this.cmsContactPersons.Name = "cmsContactPersons";
            this.cmsContactPersons.Size = new System.Drawing.Size(144, 70);
            // 
            // mnuContactPersonAddFromList
            // 
            this.mnuContactPersonAddFromList.Name = "mnuContactPersonAddFromList";
            this.mnuContactPersonAddFromList.Size = new System.Drawing.Size(143, 22);
            this.mnuContactPersonAddFromList.Text = "Add from list";
            this.mnuContactPersonAddFromList.Click += new System.EventHandler(this.mnuContactPersonAddFromList_Click);
            // 
            // mnuContactPersonsAddNew
            // 
            this.mnuContactPersonsAddNew.Name = "mnuContactPersonsAddNew";
            this.mnuContactPersonsAddNew.Size = new System.Drawing.Size(143, 22);
            this.mnuContactPersonsAddNew.Text = "Add New";
            this.mnuContactPersonsAddNew.Click += new System.EventHandler(this.mnuContactPersonsAddNew_Click);
            // 
            // mnuContactPersonsRemove
            // 
            this.mnuContactPersonsRemove.Name = "mnuContactPersonsRemove";
            this.mnuContactPersonsRemove.Size = new System.Drawing.Size(143, 22);
            this.mnuContactPersonsRemove.Text = "Remove";
            this.mnuContactPersonsRemove.Click += new System.EventHandler(this.mnuContactPersonsRemove_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 337);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 45);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(12, 19);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(217, 15);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "* Please mark included contact person";
            // 
            // ContactPersonsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 382);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.grpContactPersons);
            this.Name = "ContactPersonsUI";
            this.Text = "Reservation Form";
            this.Load += new System.EventHandler(this.ContactPersonsUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdGLAccounts)).EndInit();
            this.grpContactPersons.ResumeLayout(false);
            this.cmsContactPersons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid grdGLAccounts;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpContactPersons;
        private System.Windows.Forms.ContextMenuStrip cmsContactPersons;
        private System.Windows.Forms.ToolStripMenuItem mnuContactPersonAddFromList;
        private System.Windows.Forms.ToolStripMenuItem mnuContactPersonsAddNew;
        private System.Windows.Forms.ToolStripMenuItem mnuContactPersonsRemove;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDescription;
    }
}