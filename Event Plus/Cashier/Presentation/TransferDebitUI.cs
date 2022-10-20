using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;

namespace Jinisys.Hotel.Cashier.Presentation
{
	public partial class TransferDebitUI : Form
	{

		public TransferDebitUI()
		{
			InitializeComponent();
		}

		Folio lOriginFolio;
		string loriginFolioRoomNo;
		public TransferDebitUI(Folio poOriginFolio, string pOriginRoomNo)
		{
			InitializeComponent();

			lOriginFolio = poOriginFolio;
			loriginFolioRoomNo = pOriginRoomNo;

			initializeGrid();
			loadOriginFolio();
		}

        public TransferDebitUI(Folio poOriginFolio, string pOriginRoomNo, Folio poDestinationFolio)
        {
            InitializeComponent();

            lOriginFolio = poOriginFolio;
            loriginFolioRoomNo = pOriginRoomNo;

            loDestinationFolio = poDestinationFolio;

            initializeGrid();
            loadOriginFolio();

            if (loDestinationFolio != null)
            {
                FolioFacade oFolioFacade = new FolioFacade();
                CompanyFacade _oCompanyFacade = new CompanyFacade();
                loDestinationFolio.Company = _oCompanyFacade.getCompanyAccount(loDestinationFolio.CompanyID);
                loDestinationFolio.CreateSubFolio();
                //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                //used a constant parameter to avoid possible error/dependencies, no time to check
                loDestinationFolio.RoomNo = oFolioFacade.GetCurrentRoomOccupied(loDestinationFolio.FolioID, "INDIVIDUAL");
                SubFolio subF;
                foreach (SubFolio tempLoopVar_subF in loDestinationFolio.SubFolios)
                {
                    subF = tempLoopVar_subF;
                    subF.Folio.FolioTransactions = oFolioFacade.GetFolioTransactions(subF.Folio.FolioID, subF.SubFolio_Renamed);
                    subF.Ledger = oFolioFacade.GetFolioLedger(subF.Folio.FolioID, subF.SubFolio_Renamed);

                }// end foreach

                loadDestinationFolio();

                computeTotalAndBalanceAfterTransfer();
            }
        }

		private void initializeGrid()
		{
			this.gridOriginSubFolio.SetData(1, 0, "A - Personal");
			this.gridOriginSubFolio.SetData(2, 0, "B - Company");
			this.gridOriginSubFolio.SetData(3, 0, "C - Others");
			this.gridOriginSubFolio.SetData(4, 0, "D - Others");
			this.gridOriginSubFolio.SetData(5, 0, "Total");
			this.gridOriginSubFolio.Rows[5].Style = this.gridOriginSubFolio.Styles["totalStyle"];

			this.gridOriginSubFolio.SetData(1, 3, "A - Personal");
			this.gridOriginSubFolio.SetData(2, 3, "B - Company");
			this.gridOriginSubFolio.SetData(3, 3, "C - Others");
			this.gridOriginSubFolio.SetData(4, 3, "D - Others");

			this.gridDestinationSubFolio.SetData(1, 0, "A - Personal");
			this.gridDestinationSubFolio.SetData(2, 0, "B - Company");
			this.gridDestinationSubFolio.SetData(3, 0, "C - Others");
			this.gridDestinationSubFolio.SetData(4, 0, "D - Others");
			this.gridDestinationSubFolio.SetData(5, 0, "Total");
			this.gridDestinationSubFolio.Rows[5].Style = this.gridOriginSubFolio.Styles["totalStyle"];
		}

		private void loadOriginFolio()
		{
			if (this.lOriginFolio == null)
			{
				return;
			}
			
			this.txtOriginFolioId.Text = lOriginFolio.FolioID;
			this.txtOriginGuestName.Text = lOriginFolio.Guest.LastName + ", " + lOriginFolio.Guest.FirstName;
			this.txtOriginRoomNo.Text = loriginFolioRoomNo;

			try
			{
                if (lOriginFolio.FolioType == "DEPENDENT")
                {
                    txtOriginCompany.Text = lOriginFolio.GroupName;
                }
                else
                {
                    this.txtOriginCompany.Text = lOriginFolio.Company.CompanyName;
                }
			}
			catch { }

			int i = 1;
			decimal _totalSubFolio = 0;
			foreach (SubFolio _subFolio in lOriginFolio.SubFolios)
			{
				this.gridOriginSubFolio.SetData(i, 1, _subFolio.Ledger.BalanceNet);
				this.gridOriginSubFolio.SetData(i, 2, "0.00");

				i++;
				_totalSubFolio += _subFolio.Ledger.BalanceNet;
			}

			this.gridOriginSubFolio.SetData(5,1, _totalSubFolio);
		}


		private void TransferDebitUI_Load(object sender, EventArgs e)
		{
			
			

		}

		private void gridOriginSubFolio_Click(object sender, EventArgs e)
		{
			int _row = this.gridOriginSubFolio.Row;
			int _col = this.gridOriginSubFolio.Col;


			if (_row > 4)
			{
				this.gridOriginSubFolio.AllowEditing = false;
				return;
			}

			if (_col < 2)
			{
				this.gridOriginSubFolio.AllowEditing = false;
				return;
			}


			this.gridOriginSubFolio.AllowEditing = true;
			this.gridOriginSubFolio.StartEditing(_row,_col);
		}

		
		private void computeTotalAndBalanceAfterTransfer()
		{
			decimal _amountToTransferA = 0;
			decimal _amountToTransferB = 0;
			decimal _amountToTransferC = 0;
			decimal _amountToTransferD = 0;

			for (int i = 1; i < 5; i++)
			{
				decimal _originFolioCurrentBalance = 0;
				decimal _originAmountToTransfer = 0;
				string _destinationSubFolio = "";
				
				
				_originFolioCurrentBalance = decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(i, 1));
				try
				{
					_originAmountToTransfer = decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(i, 2));
				}
				catch { }

				if (_originFolioCurrentBalance < _originAmountToTransfer && _originFolioCurrentBalance > 0)
				{
					MessageBox.Show("Invalid amount to transfer.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.gridOriginSubFolio.SetData(i, 2, "0.00");

					return;
				}

				_destinationSubFolio = this.gridOriginSubFolio.GetDataDisplay(i, 3);

				switch (_destinationSubFolio)
				{ 
					case "A - Personal":
						_amountToTransferA += _originAmountToTransfer;
						break;
					case "B - Company":
						_amountToTransferB += _originAmountToTransfer;
						break;
					case "C - Others":
						_amountToTransferC += _originAmountToTransfer;
						break;
					case "D - Others":
						_amountToTransferD += _originAmountToTransfer;
						break;
				}

			}

			try
			{
				// update Destination/Origin Folio
				decimal _destinationFolioCurrentBalance = 0;
                decimal _originFolioCurrentBalance = 0;
				try
				{
                    _originFolioCurrentBalance = decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(1, 1));
                    _destinationFolioCurrentBalance = decimal.Parse(this.gridDestinationSubFolio.GetDataDisplay(1, 1));
				}
				catch { }
				decimal _destinationFolioBalanceAfterTransferA = _destinationFolioCurrentBalance + _amountToTransferA;
                decimal _originFolioBalanceAfterTransferA = _originFolioCurrentBalance - decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(1, 2));
				this.gridDestinationSubFolio.SetData(1, 2, _destinationFolioBalanceAfterTransferA);
                this.gridOriginSubFolio.SetData(1, 4, _originFolioBalanceAfterTransferA);

				// update Destination Folio
				_destinationFolioCurrentBalance = 0;
                _originFolioCurrentBalance = 0;
				try
				{
                    _originFolioCurrentBalance = decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(2, 1));
                    _destinationFolioCurrentBalance = decimal.Parse(this.gridDestinationSubFolio.GetDataDisplay(2, 1));
				}
				catch { }

				decimal _destinationFolioBalanceAfterTransferB = _destinationFolioCurrentBalance + _amountToTransferB;
                decimal _originFolioBalanceAfterTransferB = _originFolioCurrentBalance - decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(2, 2));
				this.gridDestinationSubFolio.SetData(2, 2, _destinationFolioBalanceAfterTransferB);
                this.gridOriginSubFolio.SetData(2, 4, _originFolioBalanceAfterTransferB);


				// update Destination Folio
				_destinationFolioCurrentBalance = 0;
                _originFolioCurrentBalance = 0;
                try
				{
                    _originFolioCurrentBalance = decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(3, 1));
                    _destinationFolioCurrentBalance = decimal.Parse(this.gridDestinationSubFolio.GetDataDisplay(3, 1));
                }
				catch { }

				decimal _destinationFolioBalanceAfterTransferC = _destinationFolioCurrentBalance + _amountToTransferC;
                decimal _originFolioBalanceAfterTransferC = _originFolioCurrentBalance - decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(3, 2));
                this.gridDestinationSubFolio.SetData(3, 2, _destinationFolioBalanceAfterTransferC);
                this.gridOriginSubFolio.SetData(3, 4, _originFolioBalanceAfterTransferC);

				// update Destination Folio
				_destinationFolioCurrentBalance = 0;
                _originFolioCurrentBalance = 0;
				try
				{
                    _originFolioCurrentBalance = decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(4, 1));
                    _destinationFolioCurrentBalance = decimal.Parse(this.gridDestinationSubFolio.GetDataDisplay(4, 1));
                }
				catch { }

				decimal _destinationFolioBalanceAfterTransferD = _destinationFolioCurrentBalance + _amountToTransferD;
                decimal _originFolioBalanceAfterTransferD = _originFolioCurrentBalance - decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(4, 2));
                this.gridDestinationSubFolio.SetData(4, 2, _destinationFolioBalanceAfterTransferD);
                this.gridOriginSubFolio.SetData(4, 4, _originFolioBalanceAfterTransferD);

				decimal _runningTotal = _destinationFolioBalanceAfterTransferA + _destinationFolioBalanceAfterTransferB + _destinationFolioBalanceAfterTransferC + _destinationFolioBalanceAfterTransferD;
                decimal _runningTotalOrigin = _originFolioBalanceAfterTransferA + _originFolioBalanceAfterTransferB + _originFolioBalanceAfterTransferC + _originFolioBalanceAfterTransferD;
				this.gridDestinationSubFolio.SetData(5, 2, _runningTotal);
                this.gridOriginSubFolio.SetData(5, 4, _runningTotalOrigin);

				decimal _totalAmountToTransfer = 0;
				_totalAmountToTransfer = _amountToTransferA + _amountToTransferB + _amountToTransferC + _amountToTransferD;
				this.gridOriginSubFolio.SetData(5, 2, _totalAmountToTransfer);
			}
			catch { }


            //for same room transferring
            try
            {
                if (txtOriginRoomNo.Text == txtDestinationRoomNo.Text && txtOriginFolioId.Text == txtDestinationFolioId.Text)
                {
                    decimal _amt = decimal.Parse(gridOriginSubFolio.GetDataDisplay(gridOriginSubFolio.Row, 2));
                    string _transferFolio = gridOriginSubFolio.GetDataDisplay(gridOriginSubFolio.Row, 3);
                    string _originFolio = gridOriginSubFolio.GetDataDisplay(gridOriginSubFolio.Row, 0);
                    decimal _originTotal = 0;

                    foreach (C1.Win.C1FlexGrid.Row _row in gridOriginSubFolio.Rows)
                    {
                        if (_row.Index != 0 && _row.Index != 5)
                        {
                            string _subFolio = gridOriginSubFolio.GetDataDisplay(_row.Index, 0);
                            if (_subFolio == _transferFolio)
                            {
                                decimal _originalAmount = decimal.Parse(gridOriginSubFolio.GetDataDisplay(_row.Index, 4));
                                gridOriginSubFolio.SetData(_row.Index, 4, _originalAmount + _amt);
                            }
                            _originTotal += decimal.Parse(gridOriginSubFolio.GetDataDisplay(_row.Index, 4));
                        }
                        else if (_row.Index == 5)
                        {
                            gridOriginSubFolio.SetData(_row.Index, 4, _originTotal);
                            _originTotal = 0;
                        }
                    }

                    foreach (C1.Win.C1FlexGrid.Row _destRow in gridDestinationSubFolio.Rows)
                    {
                        if (_destRow.Index != 0 && _destRow.Index != 5)
                        {
                            string _subFolio = gridOriginSubFolio.GetDataDisplay(_destRow.Index, 0);
                            if (_subFolio == _originFolio)
                            {
                                decimal _originalAmount = decimal.Parse(gridDestinationSubFolio.GetDataDisplay(_destRow.Index, 2));
                                gridDestinationSubFolio.SetData(_destRow.Index, 2, _originalAmount - _amt);
                            }
                            _originTotal += decimal.Parse(gridDestinationSubFolio.GetDataDisplay(_destRow.Index, 2));
                        }
                        else if (_destRow.Index == 5)
                        {
                            gridDestinationSubFolio.SetData(_destRow.Index, 2, _originTotal);
                            _originTotal = 0;
                        }
                    }
                }
            }
            catch { }
		}

		Folio loDestinationFolio;

		private void btnBrowseDestinationFolio_Click(object sender, EventArgs e)
		{
			BrowseFolioUI _browseFolioUI = new BrowseFolioUI();
			loDestinationFolio = _browseFolioUI.showDialog(this);

			if (loDestinationFolio != null)
			{
				loadDestinationFolio();

				computeTotalAndBalanceAfterTransfer();
			}


		}


		private void loadDestinationFolio()
		{
			if (this.loDestinationFolio == null)
			{
				return;
			}

			this.txtDestinationFolioId.Text = loDestinationFolio.FolioID;
			if (loDestinationFolio.FolioType == "INDIVIDUAL" || loDestinationFolio.FolioType == "DEPENDENT" || loDestinationFolio.FolioType == "SHARE")
			{
				this.txtDestinationGuestName.Text = loDestinationFolio.Guest.LastName + ", " + loDestinationFolio.Guest.FirstName;
			}
			else
			{
				this.txtDestinationGuestName.Text = loDestinationFolio.GroupName;

                foreach (C1.Win.C1FlexGrid.Row _row in gridDestinationSubFolio.Rows)
                {
                    if (_row.Index == 2 || _row.Index == 3 || _row.Index == 4)//to clear the other sub-folios
                    {
                        gridDestinationSubFolio.SetData(_row.Index, 0, "");
                        gridDestinationSubFolio.SetData(_row.Index, 1, "");
                        gridDestinationSubFolio.SetData(_row.Index, 2, "");
                    }
                }
			}

			this.txtDestinationRoomNo.Text = loDestinationFolio.RoomNo;

			try
			{
				this.txtDestinationCompany.Text = loDestinationFolio.Company.CompanyName;
			}
			catch { }

			int i = 1;
			decimal _totalSubFolio = 0;
			foreach (SubFolio _subFolio in loDestinationFolio.SubFolios)
			{
				decimal _balance = 0;
				decimal _totalPayment = 0;
				decimal _totalCharges = 0;

				_totalPayment += _subFolio.Ledger.PayCash + _subFolio.Ledger.PayCard + _subFolio.Ledger.PayCheque + _subFolio.Ledger.PayGiftCheque + _subFolio.Ledger.BalanceForwarded;
				_totalCharges += _subFolio.Ledger.Charges;

				_balance = _totalCharges - _totalPayment;

				_totalSubFolio += _balance;
				this.gridDestinationSubFolio.SetData(i, 1, _balance);
				this.gridDestinationSubFolio.SetData(i, 2, _balance);

				i++;
				
			}

			this.gridDestinationSubFolio.SetData(5, 1, _totalSubFolio);
		}


        private void gridOriginSubFolio_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            computeTotalAndBalanceAfterTransfer();
        }

		private bool isValidDestinationSubFolio()
		{
			if (loDestinationFolio == null)
			{
				this.txtDestinationFolioId.Focus();
				return false;
			}

			switch (loDestinationFolio.FolioType)
			{ 
                case "SHARE":
				case "INDIVIDUAL":
                case "DEPENDENT":
					break;
				case "GROUP":
					for (int i = 1; i < 5; i++)
					{
						decimal _amount = decimal.Parse( this.gridOriginSubFolio.GetDataDisplay(i, 2) );
						if (_amount != 0)
						{
							string _destinationSubFolio = this.gridOriginSubFolio.GetDataDisplay(i, 3);
							if (_destinationSubFolio.Substring(0, 1) != "A")
							{
								return false;
							}
						}

					}

					break;

				default:
					return false;
			}

			return true;
		}


		private void btnSave_Click(object sender, EventArgs e)
		{
			
			if (!hasAmountToTransfer())
			{
				MessageBox.Show("Transaction failed.\r\nPlease input amount to transfer.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!isValidDestinationSubFolio())
			{
				MessageBox.Show("Transaction failed.\r\nGroup folio can only have sub-folio A.\r\nPlease change your destination sub-folio.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.gridOriginSubFolio.Focus();
				return;
			}


			DialogResult rsp = MessageBox.Show("Are you sure you want to continue ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (rsp == DialogResult.No)
			{
				return;
			}


			FolioTransactions _oFolioTransactionCollection = new FolioTransactions();
            Sequence _oSequence = new Sequence();

			for (int i = 1; i < 5; i++)
			{
				decimal _amountToTransfer = 0;
				string _originSubFolio = "A";
				string _destinationSubFolio = "A";
				try
				{
					_amountToTransfer = decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(i, 2));
				}
				catch { }

				_originSubFolio = this.gridOriginSubFolio.GetDataDisplay(i, 0).Substring(0, 1);
				_destinationSubFolio = this.gridOriginSubFolio.GetDataDisplay(i, 3).Substring(0, 1); 

				if (_amountToTransfer > 0)
				{
					// create FolioTransaction object
					FolioTransaction _FolioTransferCredit = new FolioTransaction();
					//_FolioTransferDebit.FolioTransactionNo = "";
					_FolioTransferCredit.HotelID = GlobalVariables.gHotelId;
					_FolioTransferCredit.FolioID = lOriginFolio.FolioID;
					_FolioTransferCredit.SubFolio = _originSubFolio;
					_FolioTransferCredit.AccountID = lOriginFolio.AccountID;
					_FolioTransferCredit.TransactionDate = DateTime.Parse(GlobalVariables.gAuditDate);
					_FolioTransferCredit.PostingDate = DateTime.Now;
					_FolioTransferCredit.TransactionCode = "4100";
					_FolioTransferCredit.SubAccount = "";
                    _FolioTransferCredit.ReferenceNo = _oSequence.GetSequenceLongId("seq_autopost").ToString();
					_FolioTransferCredit.TransactionSource = "VOUCHER";
					_FolioTransferCredit.Memo = "FOLIO TRANSFER TO " + this.txtDestinationRoomNo.Text + "(" + _destinationSubFolio + " " + txtDestinationFolioId.Text + ")";
					_FolioTransferCredit.AcctSide = "CREDIT";
					_FolioTransferCredit.CurrencyCode = "PHP";
					_FolioTransferCredit.ConversionRate = 1;
					_FolioTransferCredit.CurrencyAmount = _amountToTransfer;
					_FolioTransferCredit.BaseAmount = _amountToTransfer;
					_FolioTransferCredit.GrossAmount = _amountToTransfer;
					_FolioTransferCredit.Discount = 0;
					_FolioTransferCredit.ServiceCharge = 0;
					_FolioTransferCredit.ServiceChargeInclusive = 1;
					_FolioTransferCredit.GovernmentTax = 0;
					_FolioTransferCredit.GovernmentTaxInclusive = 1;
					_FolioTransferCredit.LocalTax = 0;
					_FolioTransferCredit.LocalTaxInclusive = 1;
					_FolioTransferCredit.NetBaseAmount = _amountToTransfer;
					_FolioTransferCredit.NetAmount = _amountToTransfer;
					_FolioTransferCredit.CreditCardNo = "";
					_FolioTransferCredit.ChequeNo = "";
					_FolioTransferCredit.AccountName = "";
					_FolioTransferCredit.BankName = "";
					_FolioTransferCredit.ChequeDate = GlobalVariables.gAuditDate;
					_FolioTransferCredit.FOCGrantedBy = "";
					_FolioTransferCredit.CreditCardType = "";
					_FolioTransferCredit.ApprovalSlip = "";
					_FolioTransferCredit.CreditCardExpiry = "1900-01-01";
					_FolioTransferCredit.RouteSequence = "";
					_FolioTransferCredit.SourceFolio = "";
					_FolioTransferCredit.SourceSubFolio = "";
					_FolioTransferCredit.TerminalID = GlobalVariables.gTerminalID.ToString();
					_FolioTransferCredit.ShiftCode = GlobalVariables.gShiftCode.ToString();
					_FolioTransferCredit.Status = "ACTIVE";
					_FolioTransferCredit.PostToLedger = "0";
					_FolioTransferCredit.CreatedBy = GlobalVariables.gLoggedOnUser;
					_FolioTransferCredit.UpdatedBy = GlobalVariables.gLoggedOnUser;
					_FolioTransferCredit.AuditFlag = "0";
					_FolioTransferCredit.SummaryFlag = 0;
					_FolioTransferCredit.PackageName = "";
					_FolioTransferCredit.MealAmount = 0;


					// create FolioTransaction object
					FolioTransaction _FolioTransferDebit = new FolioTransaction();
					//_FolioTransferDebit.FolioTransactionNo = "";
					_FolioTransferDebit.HotelID = GlobalVariables.gHotelId;
					_FolioTransferDebit.FolioID = loDestinationFolio.FolioID;
					_FolioTransferDebit.SubFolio = _destinationSubFolio;
					_FolioTransferDebit.AccountID = loDestinationFolio.AccountID;
					_FolioTransferDebit.TransactionDate = DateTime.Parse(GlobalVariables.gAuditDate);
					_FolioTransferDebit.PostingDate = DateTime.Now;
					_FolioTransferDebit.TransactionCode = "4100";
					_FolioTransferDebit.SubAccount = "";
                    _FolioTransferDebit.ReferenceNo = _oSequence.GetSequenceLongId("seq_autopost").ToString();
					_FolioTransferDebit.TransactionSource = "VOUCHER";
					_FolioTransferDebit.Memo = "FOLIO TRANSFER FROM " + this.txtOriginRoomNo.Text + "(" + _originSubFolio + " " + txtOriginFolioId.Text + ")";
					_FolioTransferDebit.AcctSide = "DEBIT";
					_FolioTransferDebit.CurrencyCode = "PHP";
					_FolioTransferDebit.ConversionRate = 1;
					_FolioTransferDebit.CurrencyAmount = _amountToTransfer;
					_FolioTransferDebit.BaseAmount = _amountToTransfer;
					_FolioTransferDebit.GrossAmount = _amountToTransfer;
					_FolioTransferDebit.Discount = 0;
					_FolioTransferDebit.ServiceCharge = 0;
					_FolioTransferDebit.ServiceChargeInclusive = 1;
					_FolioTransferDebit.GovernmentTax = 0;
					_FolioTransferDebit.GovernmentTaxInclusive = 1;
					_FolioTransferDebit.LocalTax = 0;
					_FolioTransferDebit.LocalTaxInclusive = 1;
					_FolioTransferDebit.NetBaseAmount = _amountToTransfer;
					_FolioTransferDebit.NetAmount = _amountToTransfer;
					_FolioTransferDebit.CreditCardNo = "";
					_FolioTransferDebit.ChequeNo = "";
					_FolioTransferDebit.AccountName = "";
					_FolioTransferDebit.BankName = "";
					_FolioTransferDebit.ChequeDate = GlobalVariables.gAuditDate;
					_FolioTransferDebit.FOCGrantedBy = "";
					_FolioTransferDebit.CreditCardType = "";
					_FolioTransferDebit.ApprovalSlip = "";
					_FolioTransferDebit.CreditCardExpiry = "1900-01-01";
					_FolioTransferDebit.RouteSequence = "";
					_FolioTransferDebit.SourceFolio = "";
					_FolioTransferDebit.SourceSubFolio = "";
					_FolioTransferDebit.TerminalID = GlobalVariables.gTerminalID.ToString();
					_FolioTransferDebit.ShiftCode = GlobalVariables.gShiftCode.ToString();
					_FolioTransferDebit.Status = "ACTIVE";
					_FolioTransferDebit.PostToLedger = "0";
					_FolioTransferDebit.CreatedBy = GlobalVariables.gLoggedOnUser;
					_FolioTransferDebit.UpdatedBy = GlobalVariables.gLoggedOnUser;
					_FolioTransferDebit.AuditFlag = "0";
					_FolioTransferDebit.SummaryFlag = 0;
					_FolioTransferDebit.PackageName = "";
					_FolioTransferDebit.MealAmount = 0;


					_oFolioTransactionCollection.Add(_FolioTransferCredit);
					_oFolioTransactionCollection.Add(_FolioTransferDebit);
				}
                else if (_amountToTransfer < 0)
                {
                    // create FolioTransaction object
                    FolioTransaction _FolioTransferCredit = new FolioTransaction();
                    //_FolioTransferDebit.FolioTransactionNo = "";
                    _FolioTransferCredit.HotelID = GlobalVariables.gHotelId;
                    _FolioTransferCredit.FolioID = lOriginFolio.FolioID;
                    _FolioTransferCredit.SubFolio = _originSubFolio;
                    _FolioTransferCredit.AccountID = lOriginFolio.AccountID;
                    _FolioTransferCredit.TransactionDate = DateTime.Parse(GlobalVariables.gAuditDate);
                    _FolioTransferCredit.PostingDate = DateTime.Now;
                    _FolioTransferCredit.TransactionCode = "4100";
                    _FolioTransferCredit.SubAccount = "";
                    _FolioTransferCredit.ReferenceNo = _oSequence.GetSequenceLongId("seq_autopost").ToString();
                    _FolioTransferCredit.TransactionSource = "VOUCHER";
                    _FolioTransferCredit.Memo = "FOLIO TRANSFER TO " + this.txtDestinationRoomNo.Text + "(" + _destinationSubFolio + " " + txtDestinationFolioId.Text + ")";
                    _FolioTransferCredit.AcctSide = "DEBIT";
                    _FolioTransferCredit.CurrencyCode = "PHP";
                    _FolioTransferCredit.ConversionRate = 1;
                    _FolioTransferCredit.CurrencyAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferCredit.BaseAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferCredit.GrossAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferCredit.Discount = 0;
                    _FolioTransferCredit.ServiceCharge = 0;
                    _FolioTransferCredit.ServiceChargeInclusive = 1;
                    _FolioTransferCredit.GovernmentTax = 0;
                    _FolioTransferCredit.GovernmentTaxInclusive = 1;
                    _FolioTransferCredit.LocalTax = 0;
                    _FolioTransferCredit.LocalTaxInclusive = 1;
                    _FolioTransferCredit.NetBaseAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferCredit.NetAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferCredit.CreditCardNo = "";
                    _FolioTransferCredit.ChequeNo = "";
                    _FolioTransferCredit.AccountName = "";
                    _FolioTransferCredit.BankName = "";
                    _FolioTransferCredit.ChequeDate = GlobalVariables.gAuditDate;
                    _FolioTransferCredit.FOCGrantedBy = "";
                    _FolioTransferCredit.CreditCardType = "";
                    _FolioTransferCredit.ApprovalSlip = "";
                    _FolioTransferCredit.CreditCardExpiry = "1900-01-01";
                    _FolioTransferCredit.RouteSequence = "";
                    _FolioTransferCredit.SourceFolio = "";
                    _FolioTransferCredit.SourceSubFolio = "";
                    _FolioTransferCredit.TerminalID = GlobalVariables.gTerminalID.ToString();
                    _FolioTransferCredit.ShiftCode = GlobalVariables.gShiftCode.ToString();
                    _FolioTransferCredit.Status = "ACTIVE";
                    _FolioTransferCredit.PostToLedger = "0";
                    _FolioTransferCredit.CreatedBy = GlobalVariables.gLoggedOnUser;
                    _FolioTransferCredit.UpdatedBy = GlobalVariables.gLoggedOnUser;
                    _FolioTransferCredit.AuditFlag = "0";
                    _FolioTransferCredit.SummaryFlag = 0;
                    _FolioTransferCredit.PackageName = "";
                    _FolioTransferCredit.MealAmount = 0;


                    // create FolioTransaction object
                    FolioTransaction _FolioTransferDebit = new FolioTransaction();
                    //_FolioTransferDebit.FolioTransactionNo = "";
                    _FolioTransferDebit.HotelID = GlobalVariables.gHotelId;
                    _FolioTransferDebit.FolioID = loDestinationFolio.FolioID;
                    _FolioTransferDebit.SubFolio = _destinationSubFolio;
                    _FolioTransferDebit.AccountID = loDestinationFolio.AccountID;
                    _FolioTransferDebit.TransactionDate = DateTime.Parse(GlobalVariables.gAuditDate);
                    _FolioTransferDebit.PostingDate = DateTime.Now;
                    _FolioTransferDebit.TransactionCode = "4100";
                    _FolioTransferDebit.SubAccount = "";
                    _FolioTransferDebit.ReferenceNo = _oSequence.GetSequenceLongId("seq_autopost").ToString();
                    _FolioTransferDebit.TransactionSource = "VOUCHER";
                    _FolioTransferDebit.Memo = "FOLIO TRANSFER FROM " + this.txtOriginRoomNo.Text + "(" + _originSubFolio + " " + txtOriginFolioId.Text + ")";
                    _FolioTransferDebit.AcctSide = "CREDIT";
                    _FolioTransferDebit.CurrencyCode = "PHP";
                    _FolioTransferDebit.ConversionRate = 1;
                    _FolioTransferDebit.CurrencyAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferDebit.BaseAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferDebit.GrossAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferDebit.Discount = 0;
                    _FolioTransferDebit.ServiceCharge = 0;
                    _FolioTransferDebit.ServiceChargeInclusive = 1;
                    _FolioTransferDebit.GovernmentTax = 0;
                    _FolioTransferDebit.GovernmentTaxInclusive = 1;
                    _FolioTransferDebit.LocalTax = 0;
                    _FolioTransferDebit.LocalTaxInclusive = 1;
                    _FolioTransferDebit.NetBaseAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferDebit.NetAmount = Math.Abs(_amountToTransfer);
                    _FolioTransferDebit.CreditCardNo = "";
                    _FolioTransferDebit.ChequeNo = "";
                    _FolioTransferDebit.AccountName = "";
                    _FolioTransferDebit.BankName = "";
                    _FolioTransferDebit.ChequeDate = GlobalVariables.gAuditDate;
                    _FolioTransferDebit.FOCGrantedBy = "";
                    _FolioTransferDebit.CreditCardType = "";
                    _FolioTransferDebit.ApprovalSlip = "";
                    _FolioTransferDebit.CreditCardExpiry = "1900-01-01";
                    _FolioTransferDebit.RouteSequence = "";
                    _FolioTransferDebit.SourceFolio = "";
                    _FolioTransferDebit.SourceSubFolio = "";
                    _FolioTransferDebit.TerminalID = GlobalVariables.gTerminalID.ToString();
                    _FolioTransferDebit.ShiftCode = GlobalVariables.gShiftCode.ToString();
                    _FolioTransferDebit.Status = "ACTIVE";
                    _FolioTransferDebit.PostToLedger = "0";
                    _FolioTransferDebit.CreatedBy = GlobalVariables.gLoggedOnUser;
                    _FolioTransferDebit.UpdatedBy = GlobalVariables.gLoggedOnUser;
                    _FolioTransferDebit.AuditFlag = "0";
                    _FolioTransferDebit.SummaryFlag = 0;
                    _FolioTransferDebit.PackageName = "";
                    _FolioTransferDebit.MealAmount = 0;


                    _oFolioTransactionCollection.Add(_FolioTransferCredit);
                    _oFolioTransactionCollection.Add(_FolioTransferDebit);
                }

			}

			if (_oFolioTransactionCollection.Count > 0)
			{
				
				FolioTransactionFacade oFolioTransactionFacade = new FolioTransactionFacade();

				MySql.Data.MySqlClient.MySqlTransaction _trans = GlobalVariables.gPersistentConnection.BeginTransaction();
				try
				{
					if (oFolioTransactionFacade.InsertFolioTransaction(_oFolioTransactionCollection, ref _trans))
					{

						MessageBox.Show("Transaction successful.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
						_trans.Commit();
						this.Close();
					}
					else
					{
						_trans.Rollback();
					}
				}
				catch(Exception ex)
				{
					_trans.Rollback();
					MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				
			}
		}


		private bool hasAmountToTransfer()
		{
			decimal _amount = 0;
			try
			{
				_amount = decimal.Parse(this.gridOriginSubFolio.GetDataDisplay(5, 2));
			}
			catch { }


			if (_amount != 0)
			{
				return true;
			}
			else 
			{
				return false;
			}

		}

        private void gridOriginSubFolio_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            //computeTotalAndBalanceAfterTransfer();
        }

	}
}