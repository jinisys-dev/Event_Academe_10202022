namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	partial class SystemConfigurationUI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemConfigurationUI));
			this.grdSystemConfig = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grdSystemConfig)).BeginInit();
			this.SuspendLayout();
			// 
			// grdSystemConfig
			// 
			this.grdSystemConfig.AllowEditing = false;
			this.grdSystemConfig.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
			this.grdSystemConfig.ColumnInfo = resources.GetString("grdSystemConfig.ColumnInfo");
			this.grdSystemConfig.ExtendLastCol = true;
			this.grdSystemConfig.Location = new System.Drawing.Point(26, 121);
			this.grdSystemConfig.Name = "grdSystemConfig";
			this.grdSystemConfig.Rows.DefaultSize = 17;
			this.grdSystemConfig.Size = new System.Drawing.Size(820, 523);
			this.grdSystemConfig.StyleInfo = resources.GetString("grdSystemConfig.StyleInfo");
			this.grdSystemConfig.TabIndex = 0;
			this.grdSystemConfig.RowColChange += new System.EventHandler(this.grdSystemConfig_RowColChange);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(22, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(191, 22);
			this.label1.TabIndex = 1;
			this.label1.Text = "System Configuration";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(688, 62);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 31);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(760, 62);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 31);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// SystemConfigurationUI
			// 
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(860, 657);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grdSystemConfig);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "SystemConfigurationUI";
			this.Text = "System Configuration";
			this.Activated += new System.EventHandler(this.SystemConfigurationUI_Activated);
			this.Load += new System.EventHandler(this.SystemConfigurationUI_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdSystemConfig)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private C1.Win.C1FlexGrid.C1FlexGrid grdSystemConfig;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
	}
}
