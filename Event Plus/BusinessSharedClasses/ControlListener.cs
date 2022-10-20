using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using C1.Win.C1FlexGrid;


namespace Jinisys.Hotel.BusinessSharedClasses
{
	public class ControlListener
	{

		public ControlListener()
		{
		}

        private enum OperationMode { LISTEN, STOP };
        private OperationMode mOperationMode;

		private Form activeForm = new Form();

		
		public void Listen(Control mControl)
		{
			Control ctrl;

            mOperationMode = OperationMode.LISTEN;
			
			if (mControl is System.Windows.Forms.Form)
			{
				activeForm = (Form)mControl;
			}
			
			foreach (Control tempLoopVar_ctrl in mControl.Controls)
			{
				ctrl = tempLoopVar_ctrl;
				
				if (ctrl is TextBox)
				{
					ctrl.TextChanged += new System.EventHandler(txtTextChanged);
					ctrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtKeyPress);
				}
				else if (ctrl is ComboBox)
				{
					ComboBox comboBox;
					
					comboBox = (ComboBox)ctrl;
					comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtKeyPress);
					comboBox.SelectedValueChanged += new System.EventHandler(cboSelectValueChanged);
					
				}
				else if (ctrl is NumericUpDown)
				{
					NumericUpDown nud;
					
					nud = (NumericUpDown)ctrl;
					nud.ValueChanged += new System.EventHandler(nudValueChanged);
                    //nud.TextChanged += new System.EventHandler(nudTextChanged);
					
				}
				else if (ctrl is CheckBox)
				{
					CheckBox chkBox;
					chkBox = (CheckBox)ctrl;

					chkBox.CheckedChanged += new System.EventHandler(chkCheckedChanged);
				}
				else if (ctrl is C1FlexGrid)
				{
					C1FlexGrid grid;
					grid = (C1FlexGrid)ctrl;

					grid.ChangeEdit += new System.EventHandler(grdChangeEdit);

				}
				else if (ctrl is DateTimePicker)
				{
					DateTimePicker dtpPicker;
					dtpPicker = (DateTimePicker)ctrl;

					dtpPicker.ValueChanged +=new System.EventHandler(dtpValueChanged);
				}
				else if (ctrl is Panel || ctrl is GroupBox || ctrl is TabControl)
				{
					Listen(ctrl);
				}

				
			}
			
		}
		
		
		public void StopListen(Control mControl)
		{
			Control ctrl;

            mOperationMode = OperationMode.STOP;
						
			foreach (Control tempLoopVar_ctrl in mControl.Controls)
			{
				ctrl = tempLoopVar_ctrl;
				
				if (ctrl is TextBox)
				{
					
					ctrl.TextChanged -= new System.EventHandler(txtTextChanged);
					ctrl.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(txtKeyPress);
				}
				else if (ctrl is ComboBox)
				{
					ComboBox comboBox;
					comboBox = (ComboBox)ctrl;
					
					comboBox.KeyPress -= new System.Windows.Forms.KeyPressEventHandler(txtKeyPress);
					comboBox.SelectedValueChanged -= new System.EventHandler(cboSelectValueChanged);
				}
				else if (ctrl is NumericUpDown)
				{
					NumericUpDown nud;
					nud = (NumericUpDown)ctrl;
					
					nud.ValueChanged -= new System.EventHandler(nudValueChanged);
					//nud.TextChanged -= new System.EventHandler(nudTextChanged);
				}
				else if (ctrl is CheckBox)
				{
					CheckBox chkBox;
					chkBox = (CheckBox)ctrl;

					chkBox.CheckedChanged -= new System.EventHandler(chkCheckedChanged);
				}
				else if (ctrl is C1FlexGrid)
				{
					C1FlexGrid grid;
					grid = (C1FlexGrid)ctrl;

					grid.ChangeEdit -= new System.EventHandler(grdChangeEdit);

				}
				else if (ctrl is DateTimePicker)
				{
					DateTimePicker dtpPicker;
					dtpPicker = (DateTimePicker)ctrl;

					dtpPicker.ValueChanged -= new System.EventHandler(dtpValueChanged);
				}

				else if (ctrl is Panel || ctrl is GroupBox || ctrl is TabControl)
				{
					StopListen(ctrl);
				}
				
			}
			
		}
		
		// >> HANDLERS
		private void txtKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( mOperationMode == OperationMode.LISTEN )
			{
				if (activeForm.Text.IndexOf("*") < 0)
				{
					activeForm.Text = activeForm.Text + "*";
				}
			}
		}
		
		private void txtTextChanged(System.Object sender, System.EventArgs e)
		{
            if (mOperationMode == OperationMode.LISTEN)
			{
				if (activeForm.Text.IndexOf("*") < 0)
				{
					activeForm.Text = activeForm.Text + "*";
				}
			}
		}
		
		private void cboSelectValueChanged(System.Object sender, System.EventArgs e)
		{
            if (mOperationMode == OperationMode.LISTEN)
			{
				if (activeForm.Text.IndexOf("*") < 0)
				{
					activeForm.Text = activeForm.Text + "*";
				}
			}
		}

		private void nudValueChanged(System.Object sender, System.EventArgs e)
		{
            if (mOperationMode == OperationMode.LISTEN)
			{
				if (activeForm.Text.IndexOf("*") < 0)
				{
					activeForm.Text = activeForm.Text + "*";
				}
			}
		}


		private void chkCheckedChanged(object sender, EventArgs e)
		{
			if (mOperationMode == OperationMode.LISTEN)
			{
				if (activeForm.Text.IndexOf("*") < 0)
				{
					activeForm.Text = activeForm.Text + "*";
				}
			}
		}
       

		//private void grdAfterEdit(object sender, RowColEventArgs e)
		//{
		//    if (mOperationMode == OperationMode.LISTEN)
		//    {
		//        if (activeForm.Text.IndexOf("*") < 0)
		//        {
		//            activeForm.Text = activeForm.Text + "*";
		//        }
		//    }
		//}

		private void grdChangeEdit(object sender, EventArgs e)
		{
			if (mOperationMode == OperationMode.LISTEN)
			{
				if (activeForm.Text.IndexOf("*") < 0)
				{
					activeForm.Text = activeForm.Text + "*";
				}
			}
		}

		private void dtpValueChanged(object sender, EventArgs e)
		{
			if (mOperationMode == OperationMode.LISTEN)
			{
				if (activeForm.Text.IndexOf("*") < 0)
				{
					activeForm.Text = activeForm.Text + "*";
				}
			}
		}

	}
	
}
