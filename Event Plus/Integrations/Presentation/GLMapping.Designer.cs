namespace Integrations.Presentation
{
    partial class GLMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMapping));
            this.grpContactPersons = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grdGLAccounts = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpContactPersons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGLAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // grpContactPersons
            // 
            this.grpContactPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpContactPersons.Controls.Add(this.btnRemove);
            this.grpContactPersons.Controls.Add(this.btnAdd);
            this.grpContactPersons.Controls.Add(this.grdGLAccounts);
            this.grpContactPersons.Location = new System.Drawing.Point(12, 12);
            this.grpContactPersons.Name = "grpContactPersons";
            this.grpContactPersons.Size = new System.Drawing.Size(565, 315);
            this.grpContactPersons.TabIndex = 8;
            this.grpContactPersons.TabStop = false;
            this.grpContactPersons.Text = "GL Accounts Mapping";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(484, 11);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(403, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdGLAccounts
            // 
            this.grdGLAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGLAccounts.AutoGenerateColumns = false;
            this.grdGLAccounts.ColumnInfo = resources.GetString("grdGLAccounts.ColumnInfo");
            this.grdGLAccounts.Location = new System.Drawing.Point(6, 40);
            this.grdGLAccounts.Name = "grdGLAccounts";
            this.grdGLAccounts.Rows.Count = 1;
            this.grdGLAccounts.Rows.DefaultSize = 17;
            this.grdGLAccounts.Size = new System.Drawing.Size(553, 270);
            this.grdGLAccounts.StyleInfo = resources.GetString("grdGLAccounts.StyleInfo");
            this.grdGLAccounts.TabIndex = 2;
            this.grdGLAccounts.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdGLAccounts_AfterEdit);
            this.grdGLAccounts.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdGLAccounts_BeforeEdit);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(483, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 33);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GLMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 372);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpContactPersons);
            this.Name = "GLMapping";
            this.Text = "GLMapping";
            this.Load += new System.EventHandler(this.GLMapping_Load);
            this.grpContactPersons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGLAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpContactPersons;
        private C1.Win.C1FlexGrid.C1FlexGrid grdGLAccounts;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
    }
}