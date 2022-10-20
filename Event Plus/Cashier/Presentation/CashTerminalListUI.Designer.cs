namespace Jinisys.Hotel.Cashier.Presentation
{
    partial class CashTerminalListUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashTerminalListUI));
this.grdCashTerminalList = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.btnSelect = new System.Windows.Forms.Button();
this.btnEdit = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.btnInsert = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnForceCloseCashDrawer = new System.Windows.Forms.Button();
((System.ComponentModel.ISupportInitialize)(this.grdCashTerminalList)).BeginInit();
this.SuspendLayout();
// 
// grdCashTerminalList
// 
this.grdCashTerminalList.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdCashTerminalList.BackColorAlternate = System.Drawing.Color.WhiteSmoke;
this.grdCashTerminalList.BackColorSel = System.Drawing.SystemColors.Info;
this.grdCashTerminalList.Cols = 4;
this.grdCashTerminalList.ColumnInfo = resources.GetString("grdCashTerminalList.ColumnInfo");
this.grdCashTerminalList.ExplorerBar = ((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings)(((C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExMove) 
            | C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSort)));
this.grdCashTerminalList.ExtendLastCol = true;
this.grdCashTerminalList.FixedCols = 0;
this.grdCashTerminalList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdCashTerminalList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.grdCashTerminalList.ForeColorSel = System.Drawing.Color.Black;
this.grdCashTerminalList.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdCashTerminalList.Location = new System.Drawing.Point(8, 10);
this.grdCashTerminalList.Name = "grdCashTerminalList";
this.grdCashTerminalList.NodeClosedPicture = null;
this.grdCashTerminalList.NodeOpenPicture = null;
this.grdCashTerminalList.OutlineCol = -1;
this.grdCashTerminalList.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdCashTerminalList.Size = new System.Drawing.Size(334, 390);
this.grdCashTerminalList.StyleInfo = resources.GetString("grdCashTerminalList.StyleInfo");
this.grdCashTerminalList.TabIndex = 0;
this.grdCashTerminalList.TreeColor = System.Drawing.Color.DarkGray;
this.grdCashTerminalList.DoubleClick += new System.EventHandler(this.grdCashTerminalList_DoubleClick);
// 
// btnSelect
// 
this.btnSelect.Location = new System.Drawing.Point(362, 16);
this.btnSelect.Name = "btnSelect";
this.btnSelect.Size = new System.Drawing.Size(90, 33);
this.btnSelect.TabIndex = 1;
this.btnSelect.Text = "&Select";
this.btnSelect.UseVisualStyleBackColor = true;
this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
// 
// btnEdit
// 
this.btnEdit.Enabled = false;
this.btnEdit.Location = new System.Drawing.Point(362, 326);
this.btnEdit.Name = "btnEdit";
this.btnEdit.Size = new System.Drawing.Size(90, 33);
this.btnEdit.TabIndex = 2;
this.btnEdit.Text = "&Edit";
this.btnEdit.UseVisualStyleBackColor = true;
this.btnEdit.Visible = false;
// 
// btnCancel
// 
this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnCancel.Location = new System.Drawing.Point(362, 84);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(90, 33);
this.btnCancel.TabIndex = 3;
this.btnCancel.Text = "Cl&ose";
this.btnCancel.UseVisualStyleBackColor = true;
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// btnInsert
// 
this.btnInsert.Enabled = false;
this.btnInsert.Location = new System.Drawing.Point(362, 284);
this.btnInsert.Name = "btnInsert";
this.btnInsert.Size = new System.Drawing.Size(90, 33);
this.btnInsert.TabIndex = 4;
this.btnInsert.Text = "&Insert";
this.btnInsert.UseVisualStyleBackColor = true;
this.btnInsert.Visible = false;
// 
// btnDelete
// 
this.btnDelete.Enabled = false;
this.btnDelete.Location = new System.Drawing.Point(362, 367);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(90, 33);
this.btnDelete.TabIndex = 6;
this.btnDelete.Text = "&Delete";
this.btnDelete.UseVisualStyleBackColor = true;
this.btnDelete.Visible = false;
// 
// btnForceCloseCashDrawer
// 
this.btnForceCloseCashDrawer.Location = new System.Drawing.Point(362, 16);
this.btnForceCloseCashDrawer.Name = "btnForceCloseCashDrawer";
this.btnForceCloseCashDrawer.Size = new System.Drawing.Size(90, 59);
this.btnForceCloseCashDrawer.TabIndex = 8;
this.btnForceCloseCashDrawer.Text = "&Forcibly Close Cash Drawer";
this.btnForceCloseCashDrawer.UseVisualStyleBackColor = true;
this.btnForceCloseCashDrawer.Visible = false;
this.btnForceCloseCashDrawer.Click += new System.EventHandler(this.btnForceCloseCashDrawer_Click);
// 
// CashTerminalListUI
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.CancelButton = this.btnCancel;
this.ClientSize = new System.Drawing.Size(467, 413);
this.Controls.Add(this.btnForceCloseCashDrawer);
this.Controls.Add(this.btnDelete);
this.Controls.Add(this.btnInsert);
this.Controls.Add(this.btnCancel);
this.Controls.Add(this.btnEdit);
this.Controls.Add(this.btnSelect);
this.Controls.Add(this.grdCashTerminalList);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.Name = "CashTerminalListUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Please Select Cash Terminal";
this.Activated += new System.EventHandler(this.CashTerminalListUI_Activated);
this.Load += new System.EventHandler(this.CashTerminalListUI_Load);
((System.ComponentModel.ISupportInitialize)(this.grdCashTerminalList)).EndInit();
this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdCashTerminalList;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnForceCloseCashDrawer;
    }
}