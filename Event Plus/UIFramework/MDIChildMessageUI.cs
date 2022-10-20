using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Reflection;



namespace Jinisys.Hotel.UIFramework
{
	namespace Presentation
	{
		public class MDIChildMessageUI : System.Windows.Forms.Form
		{
			
			public System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
			public System.Windows.Forms.Button btn_1 = new System.Windows.Forms.Button();
			public System.Windows.Forms.Button btn_2 = new System.Windows.Forms.Button();
			public int btnClick;
			public MessageButtons btntype;
			private System.Windows.Forms.Button btn1 = new System.Windows.Forms.Button();
			private System.Windows.Forms.Button btn2 = new System.Windows.Forms.Button();
			private System.Windows.Forms.Button btn3 = new System.Windows.Forms.Button();
			
			#region " Windows Form Designer generated code "
			
			public MDIChildMessageUI()
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
			public System.Windows.Forms.Label LabelErrorMessage;
			public System.Windows.Forms.Button ButtonClose;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.ButtonClose = new System.Windows.Forms.Button();
				this.ButtonClose.Click += new System.EventHandler(ButtonClose_Click);
				base.Load += new System.EventHandler(UIF_FRM_MDIChildMessage_Load);
				this.LabelErrorMessage = new System.Windows.Forms.Label();
				this.SuspendLayout();
				//
				//ButtonClose
				//
				this.ButtonClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.ButtonClose.Location = new System.Drawing.Point(291, 129);
				this.ButtonClose.Name = "ButtonClose";
				this.ButtonClose.TabIndex = 2;
				this.ButtonClose.Text = "Closes";
				//
				//LabelErrorMessage
				//
				this.LabelErrorMessage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.LabelErrorMessage.Location = new System.Drawing.Point(24, 29);
				this.LabelErrorMessage.Name = "LabelErrorMessage";
				this.LabelErrorMessage.Size = new System.Drawing.Size(340, 79);
				this.LabelErrorMessage.TabIndex = 3;
				//
				//MDIChildMessageUI
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.ClientSize = new System.Drawing.Size(392, 166);
				this.ControlBox = false;
				this.Controls.Add(this.LabelErrorMessage);
				this.Controls.Add(this.ButtonClose);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
				this.MaximizeBox = false;
				this.MinimizeBox = false;
				this.Name = "MDIChildMessageUI";
				this.Text = "MDIChildMessageUI";
				this.TopMost = true;
				this.ResumeLayout(false);
				
			}
			
			#endregion
			public enum MessageButtons
			{
				Ok = 0,
				OkCancel,
				RetryCancel,
				YesNo,
				AbortRetryIgnore,
				YesNoCancel
			}
			private void createButton()
			{
				this.Controls.Add(btn);
				switch (btntype)
				{
					case MessageButtons.OkCancel:
						this.Controls.Add(btn_1);
						break;
						
					case MessageButtons.RetryCancel:
						this.Controls.Add(btn_1);
						break;
						
					case MessageButtons.YesNo:
						
						this.Controls.Add(btn_1);
						break;
					case MessageButtons.AbortRetryIgnore:
						this.Controls.Add(btn_1);
						this.Controls.Add(btn_2);
						break;
						
					case MessageButtons.YesNoCancel:
						
						this.Controls.Add(btn_1);
						this.Controls.Add(btn_2);
						break;
				}
			}
			public MDIChildMessageUI(string text, string caption, MessageButtons btns)
			{
				btntype = btns;
				System.Windows.Forms.Control ctrl;
				
				switch (btns)
				{
					case MessageButtons.Ok:
						
						//  btn()
						btn1.Name = "btnOk";
						btn1.Text = "Ok";
						btn1.DialogResult = getDialogResult(btn1);
						btn1.Left = (this.Width / 2) - btn1.Width;
						btn = btn1;
						break;
					case MessageButtons.OkCancel:
						
						create_2_buttons("OK", "Cancel");
						break;
					case MessageButtons.RetryCancel:
						
						create_2_buttons("Retry", "Cancel");
						break;
					case MessageButtons.YesNo:
						
						create_2_buttons("Yes", "No");
						break;
					case MessageButtons.AbortRetryIgnore:
						
						create_3_buttons("Abort", "Retry", "Ignore");
						break;
					case MessageButtons.YesNoCancel:
						
						create_3_buttons("Yes", "No", "Cancel");
						break;
				}
				
				InitializeComponent();
				createButton();
				foreach (System.Windows.Forms.Control tempLoopVar_ctrl in this.Controls)
				{
					ctrl = tempLoopVar_ctrl;
					if (ctrl is System.Windows.Forms.Button)
					{
						ctrl.Top = 129;
					}
				}
				LabelErrorMessage.Text = text;
				this.Text = caption;
				btn.Click += new System.EventHandler(buttonClick);
				btn_1.Click += new System.EventHandler(buttonClick);
				btn_2.Click += new System.EventHandler(buttonClick);
				
			}
			private object create_2_buttons(string btn1Text, string btn2Text)
			{
				btn1.Name = "btn" + btn1Text;
				btn2.Name = "btn" + btn2Text;
				btn1.Text = btn1Text;
				btn1.DialogResult = getDialogResult(btn1);
				btn2.Text = btn2Text;
				btn2.DialogResult = getDialogResult(btn2);
				btn1.Left = (this.Width / 2) -(150 / 2) + 25;
				btn2.Left = btn1.Left + btn1.Width + 25;
				btn = btn1;
				btn_1 = btn2;
				return null;
			}
			private DialogResult getDialogResult(Button btn)
			{
				DialogResult dlgRes = 0;
				switch (btn.Text)
				{
					case "Ok":
						
						dlgRes = DialogResult.OK;
						break;
					case "Cancel":
						
						dlgRes = DialogResult.Cancel;
						break;
					case "Abort":
						
						dlgRes = DialogResult.Abort;
						break;
					case "Retry":
						
						dlgRes = DialogResult.Retry;
						break;
					case "Yes":
						
						dlgRes = DialogResult.Yes;
						break;
					case "No":
						
						dlgRes = DialogResult.No;
						break;
					case "Ignore":
						
						dlgRes = DialogResult.Ignore;
						break;
				}
				return dlgRes;
			}
			private object create_3_buttons(string btn1Text, string btn2Text, string btn3text)
			{
				btn1.Name = "btn" + btn1Text;
				
				btn2.Name = "btn" + btn2Text;
				btn3.Name = "btn" + btn3text;
				btn1.Text = btn1Text;
				btn1.DialogResult = getDialogResult(btn1);
				btn2.Text = btn2Text;
				btn2.DialogResult = getDialogResult(btn2);
				btn3.Text = btn3text;
				btn3.DialogResult = getDialogResult(btn3);
				
				btn1.Left = (Width / 2) -((225) / 2) + 25; // - btn1.Width
				btn2.Left = btn1.Left + btn1.Width + 25;
				btn3.Left = btn2.Left + btn2.Width + 25;
				btn = btn1;
				btn_1 = btn2;
				btn_2 = btn3;
				return null;
			}
			private void ButtonClose_Click(System.Object sender, System.EventArgs e)
			{
				this.Close();
			}
			
			private void buttonClick(System.Object sender, System.EventArgs e)
			{
				
				Type ty = sender.GetType();
				PropertyInfo[] pInfo = ty.GetProperties();
				PropertyInfo info;
				foreach (PropertyInfo tempLoopVar_info in pInfo)
				{
					info = tempLoopVar_info;
					if (info.Name.ToUpper() == "TEXT")
					{
						switch (System.Convert.ToString(info.GetValue(sender, null)))
						{
							case "Ok":
								
								btnClick = 1;
								break;
							case "Cancel":
								
								btnClick = 0;
								this.Close();
								break;
							case "Yes":
								
								btnClick = 2;
								break;
							case "No":
								
								btnClick = 0;
								this.Close();
								break;
							case "Retry":
								
								btnClick = 0;
								break;
							case "Ignore":
								
								btnClick = 0;
								this.Close();
								break;
							case "Abort":
								
								btnClick = 0;
								this.Close();
								break;
						}
					}
				}
				
			}
			
			private void UIF_FRM_MDIChildMessage_Load(System.Object sender, System.EventArgs e)
			{
				
			}
		}
	}
	
}
