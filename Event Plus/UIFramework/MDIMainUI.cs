using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;

namespace Jinisys.Hotel.UIFramework
{
	public class MDIMainUI : System.Windows.Forms.Form
	{
		
		
		#region " Windows Form Designer generated code "
		
		public MDIMainUI()
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
		public System.Windows.Forms.MenuItem MenuItem14;
		public System.Windows.Forms.MainMenu MNU;
		public System.Windows.Forms.ImageList imgMain;
		public System.Windows.Forms.MenuItem MenuItemNew;
		public System.Windows.Forms.MenuItem MenuItemOpen;
		public System.Windows.Forms.MenuItem MenuItemClose;
		public System.Windows.Forms.MenuItem MenuItemSave;
		public System.Windows.Forms.MenuItem MenuItemSearch;
		public System.Windows.Forms.MenuItem MenuItemPageSetup;
		public System.Windows.Forms.MenuItem MenuItemPrintPreview;
		public System.Windows.Forms.MenuItem MenuItemPrint;
		public System.Windows.Forms.MenuItem MenuItemSendTo;
		public System.Windows.Forms.MenuItem MenuItemExit;
		public System.Windows.Forms.MenuItem MenuItemFile;
		public System.Windows.Forms.MenuItem MenuItemEdit;
		public System.Windows.Forms.MenuItem MenuItemUndo;
		public System.Windows.Forms.MenuItem MenuItemRepeat;
		public System.Windows.Forms.MenuItem MenuItemCut;
		public System.Windows.Forms.MenuItem MenuItemCopy;
		public System.Windows.Forms.MenuItem MenuItemPaste;
		public System.Windows.Forms.MenuItem MenuItemClear;
		public System.Windows.Forms.MenuItem MenuItemDelete;
		public System.Windows.Forms.MenuItem MenuItemFind;
		public System.Windows.Forms.MenuItem MenuItemReplace;
		public System.Windows.Forms.MenuItem MenuItemView;
		public System.Windows.Forms.MenuItem MenuItemWIndow;
		public System.Windows.Forms.MenuItem MenuItemHelp;
		public System.Windows.Forms.MenuItem MenuItemRecipient;
		public System.Windows.Forms.MenuItem MenuItemSeparator1;
		public System.Windows.Forms.MenuItem MenuItemSeparator3;
		public System.Windows.Forms.MenuItem MenuItemSeparator4;
		public System.Windows.Forms.MenuItem MenuItemSeparator5;
		public System.Windows.Forms.MenuItem MenuItemSeparator6;
		internal System.Windows.Forms.MenuItem MenuItem9;
		
		internal System.Windows.Forms.MenuItem MenuItem11;
		internal System.Windows.Forms.MenuItem MenuItem12;
		internal System.Windows.Forms.MenuItem MenuItem13;
		internal System.Windows.Forms.MenuItem MenuItem15;
		internal System.Windows.Forms.MenuItem MenuItem16;
		internal System.Windows.Forms.MenuItem MenuItem17;
		internal System.Windows.Forms.Panel Panel1;
		public System.Windows.Forms.ToolBar toolbarMain;
		public System.Windows.Forms.ToolBarButton tbBtnNew;
		public System.Windows.Forms.ToolBarButton tbBtnSave;
		public System.Windows.Forms.ToolBarButton tbBtnCopy;
		public System.Windows.Forms.ToolBarButton tbBtnPaste;
		public System.Windows.Forms.ToolBarButton tbBtnCut;
		internal System.Windows.Forms.MenuItem MenuItem23;
		internal System.Windows.Forms.MenuItem MenuItem24;
		internal System.Windows.Forms.MenuItem MenuItem25;
		internal System.Windows.Forms.MenuItem MenuItem26;
		internal System.Windows.Forms.MenuItem MenuItem27;
		public System.Windows.Forms.NotifyIcon NtIHotel;
		internal System.Windows.Forms.ContextMenu ContextMenu1;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MDIMainUI));
			this.MNU = new System.Windows.Forms.MainMenu();
			this.MenuItemFile = new System.Windows.Forms.MenuItem();
			this.MenuItemNew = new System.Windows.Forms.MenuItem();
			this.MenuItemOpen = new System.Windows.Forms.MenuItem();
			this.MenuItemClose = new System.Windows.Forms.MenuItem();
			this.MenuItemSeparator1 = new System.Windows.Forms.MenuItem();
			this.MenuItemSave = new System.Windows.Forms.MenuItem();
			this.MenuItemSearch = new System.Windows.Forms.MenuItem();
			this.MenuItemPageSetup = new System.Windows.Forms.MenuItem();
			this.MenuItemPrintPreview = new System.Windows.Forms.MenuItem();
			this.MenuItemPrint = new System.Windows.Forms.MenuItem();
			this.MenuItemSendTo = new System.Windows.Forms.MenuItem();
			this.MenuItemRecipient = new System.Windows.Forms.MenuItem();
			this.MenuItem14 = new System.Windows.Forms.MenuItem();
			this.MenuItemSeparator3 = new System.Windows.Forms.MenuItem();
			this.MenuItemExit = new System.Windows.Forms.MenuItem();
			this.MenuItemEdit = new System.Windows.Forms.MenuItem();
			this.MenuItemUndo = new System.Windows.Forms.MenuItem();
			this.MenuItemRepeat = new System.Windows.Forms.MenuItem();
			this.MenuItemSeparator4 = new System.Windows.Forms.MenuItem();
			this.MenuItemCut = new System.Windows.Forms.MenuItem();
			this.MenuItemCopy = new System.Windows.Forms.MenuItem();
			this.MenuItemPaste = new System.Windows.Forms.MenuItem();
			this.MenuItemSeparator5 = new System.Windows.Forms.MenuItem();
			this.MenuItemClear = new System.Windows.Forms.MenuItem();
			this.MenuItemDelete = new System.Windows.Forms.MenuItem();
			this.MenuItemSeparator6 = new System.Windows.Forms.MenuItem();
			this.MenuItemFind = new System.Windows.Forms.MenuItem();
			this.MenuItemReplace = new System.Windows.Forms.MenuItem();
			this.MenuItemView = new System.Windows.Forms.MenuItem();
			this.MenuItemWIndow = new System.Windows.Forms.MenuItem();
			this.MenuItem23 = new System.Windows.Forms.MenuItem();
			this.MenuItem24 = new System.Windows.Forms.MenuItem();
			this.MenuItem25 = new System.Windows.Forms.MenuItem();
			this.MenuItem26 = new System.Windows.Forms.MenuItem();
			this.MenuItem27 = new System.Windows.Forms.MenuItem();
			this.MenuItemHelp = new System.Windows.Forms.MenuItem();
			this.MenuItem9 = new System.Windows.Forms.MenuItem();
			this.MenuItem11 = new System.Windows.Forms.MenuItem();
			this.MenuItem12 = new System.Windows.Forms.MenuItem();
			this.MenuItem13 = new System.Windows.Forms.MenuItem();
			this.MenuItem15 = new System.Windows.Forms.MenuItem();
			this.MenuItem16 = new System.Windows.Forms.MenuItem();
			this.MenuItem17 = new System.Windows.Forms.MenuItem();
			this.imgMain = new System.Windows.Forms.ImageList(this.components);
			this.Panel1 = new System.Windows.Forms.Panel();
			this.toolbarMain = new System.Windows.Forms.ToolBar();
			this.tbBtnNew = new System.Windows.Forms.ToolBarButton();
			this.tbBtnSave = new System.Windows.Forms.ToolBarButton();
			this.tbBtnCopy = new System.Windows.Forms.ToolBarButton();
			this.tbBtnPaste = new System.Windows.Forms.ToolBarButton();
			this.tbBtnCut = new System.Windows.Forms.ToolBarButton();
			this.NtIHotel = new System.Windows.Forms.NotifyIcon(this.components);
			this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			//
			//MNU
			//
			this.MNU.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("MNU.RightToLeft");
			//
			//MenuItemFile
			//
			this.MenuItemFile.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemFile.Enabled"));
			this.MenuItemFile.Index = - 1;
			this.MenuItemFile.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemFile.Shortcut");
			this.MenuItemFile.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemFile.ShowShortcut"));
			this.MenuItemFile.Text = resources.GetString("MenuItemFile.Text");
			this.MenuItemFile.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemFile.Visible"));
			//
			//MenuItemNew
			//
			this.MenuItemNew.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemNew.Enabled"));
			this.MenuItemNew.Index = - 1;
			this.MenuItemNew.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemNew.Shortcut");
			this.MenuItemNew.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemNew.ShowShortcut"));
			this.MenuItemNew.Text = resources.GetString("MenuItemNew.Text");
			this.MenuItemNew.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemNew.Visible"));
			//
			//MenuItemOpen
			//
			this.MenuItemOpen.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemOpen.Enabled"));
			this.MenuItemOpen.Index = - 1;
			this.MenuItemOpen.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemOpen.Shortcut");
			this.MenuItemOpen.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemOpen.ShowShortcut"));
			this.MenuItemOpen.Text = resources.GetString("MenuItemOpen.Text");
			this.MenuItemOpen.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemOpen.Visible"));
			//
			//MenuItemClose
			//
			this.MenuItemClose.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemClose.Enabled"));
			this.MenuItemClose.Index = - 1;
			this.MenuItemClose.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemClose.Shortcut");
			this.MenuItemClose.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemClose.ShowShortcut"));
			this.MenuItemClose.Text = resources.GetString("MenuItemClose.Text");
			this.MenuItemClose.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemClose.Visible"));
			//
			//MenuItemSeparator1
			//
			this.MenuItemSeparator1.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator1.Enabled"));
			this.MenuItemSeparator1.Index = - 1;
			this.MenuItemSeparator1.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemSeparator1.Shortcut");
			this.MenuItemSeparator1.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator1.ShowShortcut"));
			this.MenuItemSeparator1.Text = resources.GetString("MenuItemSeparator1.Text");
			this.MenuItemSeparator1.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator1.Visible"));
			//
			//MenuItemSave
			//
			this.MenuItemSave.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemSave.Enabled"));
			this.MenuItemSave.Index = - 1;
			this.MenuItemSave.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemSave.Shortcut");
			this.MenuItemSave.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemSave.ShowShortcut"));
			this.MenuItemSave.Text = resources.GetString("MenuItemSave.Text");
			this.MenuItemSave.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemSave.Visible"));
			//
			//MenuItemSearch
			//
			this.MenuItemSearch.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemSearch.Enabled"));
			this.MenuItemSearch.Index = - 1;
			this.MenuItemSearch.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemSearch.Shortcut");
			this.MenuItemSearch.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemSearch.ShowShortcut"));
			this.MenuItemSearch.Text = resources.GetString("MenuItemSearch.Text");
			this.MenuItemSearch.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemSearch.Visible"));
			//
			//MenuItemPageSetup
			//
			this.MenuItemPageSetup.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemPageSetup.Enabled"));
			this.MenuItemPageSetup.Index = - 1;
			this.MenuItemPageSetup.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemPageSetup.Shortcut");
			this.MenuItemPageSetup.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemPageSetup.ShowShortcut"));
			this.MenuItemPageSetup.Text = resources.GetString("MenuItemPageSetup.Text");
			this.MenuItemPageSetup.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemPageSetup.Visible"));
			//
			//MenuItemPrintPreview
			//
			this.MenuItemPrintPreview.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemPrintPreview.Enabled"));
			this.MenuItemPrintPreview.Index = - 1;
			this.MenuItemPrintPreview.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemPrintPreview.Shortcut");
			this.MenuItemPrintPreview.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemPrintPreview.ShowShortcut"));
			this.MenuItemPrintPreview.Text = resources.GetString("MenuItemPrintPreview.Text");
			this.MenuItemPrintPreview.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemPrintPreview.Visible"));
			//
			//MenuItemPrint
			//
			this.MenuItemPrint.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemPrint.Enabled"));
			this.MenuItemPrint.Index = - 1;
			this.MenuItemPrint.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemPrint.Shortcut");
			this.MenuItemPrint.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemPrint.ShowShortcut"));
			this.MenuItemPrint.Text = resources.GetString("MenuItemPrint.Text");
			this.MenuItemPrint.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemPrint.Visible"));
			//
			//MenuItemSendTo
			//
			this.MenuItemSendTo.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemSendTo.Enabled"));
			this.MenuItemSendTo.Index = - 1;
			this.MenuItemSendTo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemRecipient, this.MenuItem14 });
			this.MenuItemSendTo.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemSendTo.Shortcut");
			this.MenuItemSendTo.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemSendTo.ShowShortcut"));
			this.MenuItemSendTo.Text = resources.GetString("MenuItemSendTo.Text");
			this.MenuItemSendTo.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemSendTo.Visible"));
			//
			//MenuItemRecipient
			//
			this.MenuItemRecipient.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemRecipient.Enabled"));
			this.MenuItemRecipient.Index = 0;
			this.MenuItemRecipient.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemRecipient.Shortcut");
			this.MenuItemRecipient.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemRecipient.ShowShortcut"));
			this.MenuItemRecipient.Text = resources.GetString("MenuItemRecipient.Text");
			this.MenuItemRecipient.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemRecipient.Visible"));
			//
			//MenuItem14
			//
			this.MenuItem14.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem14.Enabled"));
			this.MenuItem14.Index = 1;
			this.MenuItem14.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem14.Shortcut");
			this.MenuItem14.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem14.ShowShortcut"));
			this.MenuItem14.Text = resources.GetString("MenuItem14.Text");
			this.MenuItem14.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem14.Visible"));
			//
			//MenuItemSeparator3
			//
			this.MenuItemSeparator3.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator3.Enabled"));
			this.MenuItemSeparator3.Index = - 1;
			this.MenuItemSeparator3.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemSeparator3.Shortcut");
			this.MenuItemSeparator3.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator3.ShowShortcut"));
			this.MenuItemSeparator3.Text = resources.GetString("MenuItemSeparator3.Text");
			this.MenuItemSeparator3.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator3.Visible"));
			//
			//MenuItemExit
			//
			this.MenuItemExit.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemExit.Enabled"));
			this.MenuItemExit.Index = - 1;
			this.MenuItemExit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemExit.Shortcut");
			this.MenuItemExit.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemExit.ShowShortcut"));
			this.MenuItemExit.Text = resources.GetString("MenuItemExit.Text");
			this.MenuItemExit.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemExit.Visible"));
			//
			//MenuItemEdit
			//
			this.MenuItemEdit.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemEdit.Enabled"));
			this.MenuItemEdit.Index = - 1;
			this.MenuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItemUndo, this.MenuItemRepeat, this.MenuItemSeparator4, this.MenuItemCut, this.MenuItemCopy, this.MenuItemPaste, this.MenuItemSeparator5, this.MenuItemClear, this.MenuItemDelete, this.MenuItemSeparator6, this.MenuItemFind, this.MenuItemReplace });
			this.MenuItemEdit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemEdit.Shortcut");
			this.MenuItemEdit.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemEdit.ShowShortcut"));
			this.MenuItemEdit.Text = resources.GetString("MenuItemEdit.Text");
			this.MenuItemEdit.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemEdit.Visible"));
			//
			//MenuItemUndo
			//
			this.MenuItemUndo.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemUndo.Enabled"));
			this.MenuItemUndo.Index = 0;
			this.MenuItemUndo.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemUndo.Shortcut");
			this.MenuItemUndo.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemUndo.ShowShortcut"));
			this.MenuItemUndo.Text = resources.GetString("MenuItemUndo.Text");
			this.MenuItemUndo.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemUndo.Visible"));
			//
			//MenuItemRepeat
			//
			this.MenuItemRepeat.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemRepeat.Enabled"));
			this.MenuItemRepeat.Index = 1;
			this.MenuItemRepeat.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemRepeat.Shortcut");
			this.MenuItemRepeat.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemRepeat.ShowShortcut"));
			this.MenuItemRepeat.Text = resources.GetString("MenuItemRepeat.Text");
			this.MenuItemRepeat.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemRepeat.Visible"));
			//
			//MenuItemSeparator4
			//
			this.MenuItemSeparator4.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator4.Enabled"));
			this.MenuItemSeparator4.Index = 2;
			this.MenuItemSeparator4.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemSeparator4.Shortcut");
			this.MenuItemSeparator4.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator4.ShowShortcut"));
			this.MenuItemSeparator4.Text = resources.GetString("MenuItemSeparator4.Text");
			this.MenuItemSeparator4.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator4.Visible"));
			//
			//MenuItemCut
			//
			this.MenuItemCut.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemCut.Enabled"));
			this.MenuItemCut.Index = 3;
			this.MenuItemCut.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemCut.Shortcut");
			this.MenuItemCut.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemCut.ShowShortcut"));
			this.MenuItemCut.Text = resources.GetString("MenuItemCut.Text");
			this.MenuItemCut.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemCut.Visible"));
			//
			//MenuItemCopy
			//
			this.MenuItemCopy.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemCopy.Enabled"));
			this.MenuItemCopy.Index = 4;
			this.MenuItemCopy.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemCopy.Shortcut");
			this.MenuItemCopy.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemCopy.ShowShortcut"));
			this.MenuItemCopy.Text = resources.GetString("MenuItemCopy.Text");
			this.MenuItemCopy.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemCopy.Visible"));
			//
			//MenuItemPaste
			//
			this.MenuItemPaste.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemPaste.Enabled"));
			this.MenuItemPaste.Index = 5;
			this.MenuItemPaste.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemPaste.Shortcut");
			this.MenuItemPaste.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemPaste.ShowShortcut"));
			this.MenuItemPaste.Text = resources.GetString("MenuItemPaste.Text");
			this.MenuItemPaste.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemPaste.Visible"));
			//
			//MenuItemSeparator5
			//
			this.MenuItemSeparator5.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator5.Enabled"));
			this.MenuItemSeparator5.Index = 6;
			this.MenuItemSeparator5.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemSeparator5.Shortcut");
			this.MenuItemSeparator5.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator5.ShowShortcut"));
			this.MenuItemSeparator5.Text = resources.GetString("MenuItemSeparator5.Text");
			this.MenuItemSeparator5.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator5.Visible"));
			//
			//MenuItemClear
			//
			this.MenuItemClear.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemClear.Enabled"));
			this.MenuItemClear.Index = 7;
			this.MenuItemClear.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemClear.Shortcut");
			this.MenuItemClear.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemClear.ShowShortcut"));
			this.MenuItemClear.Text = resources.GetString("MenuItemClear.Text");
			this.MenuItemClear.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemClear.Visible"));
			//
			//MenuItemDelete
			//
			this.MenuItemDelete.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemDelete.Enabled"));
			this.MenuItemDelete.Index = 8;
			this.MenuItemDelete.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemDelete.Shortcut");
			this.MenuItemDelete.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemDelete.ShowShortcut"));
			this.MenuItemDelete.Text = resources.GetString("MenuItemDelete.Text");
			this.MenuItemDelete.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemDelete.Visible"));
			//
			//MenuItemSeparator6
			//
			this.MenuItemSeparator6.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator6.Enabled"));
			this.MenuItemSeparator6.Index = 9;
			this.MenuItemSeparator6.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemSeparator6.Shortcut");
			this.MenuItemSeparator6.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator6.ShowShortcut"));
			this.MenuItemSeparator6.Text = resources.GetString("MenuItemSeparator6.Text");
			this.MenuItemSeparator6.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemSeparator6.Visible"));
			//
			//MenuItemFind
			//
			this.MenuItemFind.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemFind.Enabled"));
			this.MenuItemFind.Index = 10;
			this.MenuItemFind.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemFind.Shortcut");
			this.MenuItemFind.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemFind.ShowShortcut"));
			this.MenuItemFind.Text = resources.GetString("MenuItemFind.Text");
			this.MenuItemFind.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemFind.Visible"));
			//
			//MenuItemReplace
			//
			this.MenuItemReplace.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemReplace.Enabled"));
			this.MenuItemReplace.Index = 11;
			this.MenuItemReplace.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemReplace.Shortcut");
			this.MenuItemReplace.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemReplace.ShowShortcut"));
			this.MenuItemReplace.Text = resources.GetString("MenuItemReplace.Text");
			this.MenuItemReplace.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemReplace.Visible"));
			//
			//MenuItemView
			//
			this.MenuItemView.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemView.Enabled"));
			this.MenuItemView.Index = - 1;
			this.MenuItemView.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemView.Shortcut");
			this.MenuItemView.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemView.ShowShortcut"));
			this.MenuItemView.Text = resources.GetString("MenuItemView.Text");
			this.MenuItemView.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemView.Visible"));
			//
			//MenuItemWIndow
			//
			this.MenuItemWIndow.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemWIndow.Enabled"));
			this.MenuItemWIndow.Index = - 1;
			this.MenuItemWIndow.MdiList = true;
			this.MenuItemWIndow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem23, this.MenuItem26, this.MenuItem27 });
			this.MenuItemWIndow.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemWIndow.Shortcut");
			this.MenuItemWIndow.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemWIndow.ShowShortcut"));
			this.MenuItemWIndow.Text = resources.GetString("MenuItemWIndow.Text");
			this.MenuItemWIndow.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemWIndow.Visible"));
			//
			//MenuItem23
			//
			this.MenuItem23.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem23.Enabled"));
			this.MenuItem23.Index = 0;
			this.MenuItem23.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.MenuItem24, this.MenuItem25 });
			this.MenuItem23.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem23.Shortcut");
			this.MenuItem23.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem23.ShowShortcut"));
			this.MenuItem23.Text = resources.GetString("MenuItem23.Text");
			this.MenuItem23.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem23.Visible"));
			//
			//MenuItem24
			//
			this.MenuItem24.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem24.Enabled"));
			this.MenuItem24.Index = 0;
			this.MenuItem24.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem24.Shortcut");
			this.MenuItem24.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem24.ShowShortcut"));
			this.MenuItem24.Text = resources.GetString("MenuItem24.Text");
			this.MenuItem24.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem24.Visible"));
			//
			//MenuItem25
			//
			this.MenuItem25.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem25.Enabled"));
			this.MenuItem25.Index = 1;
			this.MenuItem25.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem25.Shortcut");
			this.MenuItem25.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem25.ShowShortcut"));
			this.MenuItem25.Text = resources.GetString("MenuItem25.Text");
			this.MenuItem25.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem25.Visible"));
			//
			//MenuItem26
			//
			this.MenuItem26.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem26.Enabled"));
			this.MenuItem26.Index = 1;
			this.MenuItem26.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem26.Shortcut");
			this.MenuItem26.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem26.ShowShortcut"));
			this.MenuItem26.Text = resources.GetString("MenuItem26.Text");
			this.MenuItem26.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem26.Visible"));
			//
			//MenuItem27
			//
			this.MenuItem27.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem27.Enabled"));
			this.MenuItem27.Index = 2;
			this.MenuItem27.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem27.Shortcut");
			this.MenuItem27.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem27.ShowShortcut"));
			this.MenuItem27.Text = resources.GetString("MenuItem27.Text");
			this.MenuItem27.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem27.Visible"));
			//
			//MenuItemHelp
			//
			this.MenuItemHelp.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItemHelp.Enabled"));
			this.MenuItemHelp.Index = - 1;
			this.MenuItemHelp.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItemHelp.Shortcut");
			this.MenuItemHelp.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItemHelp.ShowShortcut"));
			this.MenuItemHelp.Text = resources.GetString("MenuItemHelp.Text");
			this.MenuItemHelp.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItemHelp.Visible"));
			//
			//MenuItem9
			//
			this.MenuItem9.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem9.Enabled"));
			this.MenuItem9.Index = - 1;
			this.MenuItem9.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem9.Shortcut");
			this.MenuItem9.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem9.ShowShortcut"));
			this.MenuItem9.Text = resources.GetString("MenuItem9.Text");
			this.MenuItem9.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem9.Visible"));
			//
			//MenuItem11
			//
			this.MenuItem11.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem11.Enabled"));
			this.MenuItem11.Index = - 1;
			this.MenuItem11.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem11.Shortcut");
			this.MenuItem11.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem11.ShowShortcut"));
			this.MenuItem11.Text = resources.GetString("MenuItem11.Text");
			this.MenuItem11.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem11.Visible"));
			//
			//MenuItem12
			//
			this.MenuItem12.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem12.Enabled"));
			this.MenuItem12.Index = - 1;
			this.MenuItem12.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem12.Shortcut");
			this.MenuItem12.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem12.ShowShortcut"));
			this.MenuItem12.Text = resources.GetString("MenuItem12.Text");
			this.MenuItem12.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem12.Visible"));
			//
			//MenuItem13
			//
			this.MenuItem13.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem13.Enabled"));
			this.MenuItem13.Index = - 1;
			this.MenuItem13.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem13.Shortcut");
			this.MenuItem13.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem13.ShowShortcut"));
			this.MenuItem13.Text = resources.GetString("MenuItem13.Text");
			this.MenuItem13.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem13.Visible"));
			//
			//MenuItem15
			//
			this.MenuItem15.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem15.Enabled"));
			this.MenuItem15.Index = - 1;
			this.MenuItem15.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem15.Shortcut");
			this.MenuItem15.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem15.ShowShortcut"));
			this.MenuItem15.Text = resources.GetString("MenuItem15.Text");
			this.MenuItem15.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem15.Visible"));
			//
			//MenuItem16
			//
			this.MenuItem16.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem16.Enabled"));
			this.MenuItem16.Index = - 1;
			this.MenuItem16.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem16.Shortcut");
			this.MenuItem16.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem16.ShowShortcut"));
			this.MenuItem16.Text = resources.GetString("MenuItem16.Text");
			this.MenuItem16.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem16.Visible"));
			//
			//MenuItem17
			//
			this.MenuItem17.Enabled = System.Convert.ToBoolean(resources.GetObject("MenuItem17.Enabled"));
			this.MenuItem17.Index = - 1;
			this.MenuItem17.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem17.Shortcut");
			this.MenuItem17.ShowShortcut = System.Convert.ToBoolean(resources.GetObject("MenuItem17.ShowShortcut"));
			this.MenuItem17.Text = resources.GetString("MenuItem17.Text");
			this.MenuItem17.Visible = System.Convert.ToBoolean(resources.GetObject("MenuItem17.Visible"));
			//
			//imgMain
			//
			this.imgMain.ImageSize = (System.Drawing.Size) resources.GetObject("imgMain.ImageSize");
			this.imgMain.ImageStream = (System.Windows.Forms.ImageListStreamer) resources.GetObject("imgMain.ImageStream");
			this.imgMain.TransparentColor = System.Drawing.Color.Transparent;
			//
			//Panel1
			//
			this.Panel1.AccessibleDescription = resources.GetString("Panel1.AccessibleDescription");
			this.Panel1.AccessibleName = resources.GetString("Panel1.AccessibleName");
			this.Panel1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Panel1.Anchor");
			this.Panel1.AutoScroll = System.Convert.ToBoolean(resources.GetObject("Panel1.AutoScroll"));
			this.Panel1.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("Panel1.AutoScrollMargin");
			this.Panel1.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("Panel1.AutoScrollMinSize");
			this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
			this.Panel1.BackgroundImage = (System.Drawing.Image) resources.GetObject("Panel1.BackgroundImage");
			this.Panel1.Controls.Add(this.toolbarMain);
			this.Panel1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Panel1.Dock");
			this.Panel1.Enabled = System.Convert.ToBoolean(resources.GetObject("Panel1.Enabled"));
			this.Panel1.Font = (System.Drawing.Font) resources.GetObject("Panel1.Font");
			this.Panel1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Panel1.ImeMode");
			this.Panel1.Location = (System.Drawing.Point) resources.GetObject("Panel1.Location");
			this.Panel1.Name = "Panel1";
			this.Panel1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Panel1.RightToLeft");
			this.Panel1.Size = (System.Drawing.Size) resources.GetObject("Panel1.Size");
			this.Panel1.TabIndex = System.Convert.ToInt32(resources.GetObject("Panel1.TabIndex"));
			this.Panel1.Text = resources.GetString("Panel1.Text");
			this.Panel1.Visible = System.Convert.ToBoolean(resources.GetObject("Panel1.Visible"));
			//
			//toolbarMain
			//
			this.toolbarMain.AccessibleDescription = resources.GetString("toolbarMain.AccessibleDescription");
			this.toolbarMain.AccessibleName = resources.GetString("toolbarMain.AccessibleName");
			this.toolbarMain.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("toolbarMain.Anchor");
			this.toolbarMain.Appearance = (System.Windows.Forms.ToolBarAppearance) resources.GetObject("toolbarMain.Appearance");
			this.toolbarMain.AutoSize = System.Convert.ToBoolean(resources.GetObject("toolbarMain.AutoSize"));
			this.toolbarMain.BackgroundImage = (System.Drawing.Image) resources.GetObject("toolbarMain.BackgroundImage");
			this.toolbarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] { this.tbBtnNew, this.tbBtnSave, this.tbBtnCopy, this.tbBtnPaste, this.tbBtnCut });
			this.toolbarMain.ButtonSize = (System.Drawing.Size) resources.GetObject("toolbarMain.ButtonSize");
			this.toolbarMain.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("toolbarMain.Dock");
			this.toolbarMain.DropDownArrows = System.Convert.ToBoolean(resources.GetObject("toolbarMain.DropDownArrows"));
			this.toolbarMain.Enabled = System.Convert.ToBoolean(resources.GetObject("toolbarMain.Enabled"));
			this.toolbarMain.Font = (System.Drawing.Font) resources.GetObject("toolbarMain.Font");
			this.toolbarMain.ImageList = this.imgMain;
			this.toolbarMain.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("toolbarMain.ImeMode");
			this.toolbarMain.Location = (System.Drawing.Point) resources.GetObject("toolbarMain.Location");
			this.toolbarMain.Name = "toolbarMain";
			this.toolbarMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("toolbarMain.RightToLeft");
			this.toolbarMain.ShowToolTips = System.Convert.ToBoolean(resources.GetObject("toolbarMain.ShowToolTips"));
			this.toolbarMain.Size = (System.Drawing.Size) resources.GetObject("toolbarMain.Size");
			this.toolbarMain.TabIndex = System.Convert.ToInt32(resources.GetObject("toolbarMain.TabIndex"));
			this.toolbarMain.TextAlign = (System.Windows.Forms.ToolBarTextAlign) resources.GetObject("toolbarMain.TextAlign");
			this.toolbarMain.Visible = System.Convert.ToBoolean(resources.GetObject("toolbarMain.Visible"));
			this.toolbarMain.Wrappable = System.Convert.ToBoolean(resources.GetObject("toolbarMain.Wrappable"));
			//
			//tbBtnNew
			//
			this.tbBtnNew.Enabled = System.Convert.ToBoolean(resources.GetObject("tbBtnNew.Enabled"));
			this.tbBtnNew.ImageIndex = System.Convert.ToInt32(resources.GetObject("tbBtnNew.ImageIndex"));
			this.tbBtnNew.Text = resources.GetString("tbBtnNew.Text");
			this.tbBtnNew.ToolTipText = resources.GetString("tbBtnNew.ToolTipText");
			this.tbBtnNew.Visible = System.Convert.ToBoolean(resources.GetObject("tbBtnNew.Visible"));
			//
			//tbBtnSave
			//
			this.tbBtnSave.Enabled = System.Convert.ToBoolean(resources.GetObject("tbBtnSave.Enabled"));
			this.tbBtnSave.ImageIndex = System.Convert.ToInt32(resources.GetObject("tbBtnSave.ImageIndex"));
			this.tbBtnSave.Text = resources.GetString("tbBtnSave.Text");
			this.tbBtnSave.ToolTipText = resources.GetString("tbBtnSave.ToolTipText");
			this.tbBtnSave.Visible = System.Convert.ToBoolean(resources.GetObject("tbBtnSave.Visible"));
			//
			//tbBtnCopy
			//
			this.tbBtnCopy.Enabled = System.Convert.ToBoolean(resources.GetObject("tbBtnCopy.Enabled"));
			this.tbBtnCopy.ImageIndex = System.Convert.ToInt32(resources.GetObject("tbBtnCopy.ImageIndex"));
			this.tbBtnCopy.Text = resources.GetString("tbBtnCopy.Text");
			this.tbBtnCopy.ToolTipText = resources.GetString("tbBtnCopy.ToolTipText");
			this.tbBtnCopy.Visible = System.Convert.ToBoolean(resources.GetObject("tbBtnCopy.Visible"));
			//
			//tbBtnPaste
			//
			this.tbBtnPaste.Enabled = System.Convert.ToBoolean(resources.GetObject("tbBtnPaste.Enabled"));
			this.tbBtnPaste.ImageIndex = System.Convert.ToInt32(resources.GetObject("tbBtnPaste.ImageIndex"));
			this.tbBtnPaste.Text = resources.GetString("tbBtnPaste.Text");
			this.tbBtnPaste.ToolTipText = resources.GetString("tbBtnPaste.ToolTipText");
			this.tbBtnPaste.Visible = System.Convert.ToBoolean(resources.GetObject("tbBtnPaste.Visible"));
			//
			//tbBtnCut
			//
			this.tbBtnCut.Enabled = System.Convert.ToBoolean(resources.GetObject("tbBtnCut.Enabled"));
			this.tbBtnCut.ImageIndex = System.Convert.ToInt32(resources.GetObject("tbBtnCut.ImageIndex"));
			this.tbBtnCut.Text = resources.GetString("tbBtnCut.Text");
			this.tbBtnCut.ToolTipText = resources.GetString("tbBtnCut.ToolTipText");
			this.tbBtnCut.Visible = System.Convert.ToBoolean(resources.GetObject("tbBtnCut.Visible"));
			//
			//NtIHotel
			//
			this.NtIHotel.Icon = (System.Drawing.Icon) resources.GetObject("NtIHotel.Icon");
			this.NtIHotel.Text = resources.GetString("NtIHotel.Text");
			this.NtIHotel.Visible = System.Convert.ToBoolean(resources.GetObject("NtIHotel.Visible"));
			//
			//ContextMenu1
			//
			this.ContextMenu1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("ContextMenu1.RightToLeft");
			//
			//MDIMainUI
			//
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");
			this.AutoScroll = System.Convert.ToBoolean(resources.GetObject("$this.AutoScroll"));
			this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");
			this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");
			this.BackColor = System.Drawing.SystemColors.Desktop;
			this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");
			this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");
			this.Controls.Add(this.Panel1);
			this.Enabled = System.Convert.ToBoolean(resources.GetObject("$this.Enabled"));
			this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
			this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");
			this.IsMdiContainer = true;
			this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");
			this.MaximizeBox = false;
			this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");
			this.Menu = this.MNU;
			this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");
			this.Name = "MDIMainUI";
			this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");
			this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");
			this.Text = resources.GetString("$this.Text");
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		
		#endregion
		
	}
}
