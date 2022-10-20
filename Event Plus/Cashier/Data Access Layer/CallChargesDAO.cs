using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using System.Windows.Forms;

using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Cashier.BusinessLayer;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Accounts.BusinessLayer;


namespace Jinisys.Hotel.Cashier
{
	namespace DataAccessLayer
	{
		public class CallChargesDAO : IDisposable
		{
			
			
			public CallChargesDAO()
			{
				
			}
			
			private MySqlConnection localConnection;
			public CallChargesDAO(MySqlConnection connection)
			{
				localConnection = connection;
			}
			
			private CallCharge oCallCharge;
			public CallCharge GetCallCharges()
			{
				try
				{
					oCallCharge = new CallCharge();
					MySqlCommand cmd = new MySqlCommand("call spGetCalls()", localConnection);
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
					dataAdapter.Fill(oCallCharge, "Calls");
					
					return oCallCharge;
					
				}
				catch (Exception ex)
				{
                    MessageBox.Show(ex.Message, "Call Charge DAO Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return null;
				}
				finally
				{
					if ( oCallCharge != null)
					{
						oCallCharge.Dispose();
					}
				}
			}
			
			public void InsertCallCharges(CallCharge oCallCharge)
			{
				try
				{
					DataRow dt;
					
					int count = oCallCharge.Tables[0].Rows.Count;
					
					foreach (DataRow tempLoopVar_dt in oCallCharge.Tables[0].Rows)
					{
						dt = tempLoopVar_dt;
						PostToFolioTransaction(dt);
					}
					
				}
				catch (MySqlException ex)
				{
                    MessageBox.Show(ex.Message, "InsertCallCharges EXCEPTION ",MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
				}
			}
			
			private Company oCompany;
			private Folio oFolio;
			private CompanyFacade oCompanyFacade;
			private FolioFacade oFolioFacade;
			private Folio GetFolioInfo(string folioId)
			{
				try
				{
					oFolio = new Folio();
					oFolioFacade = new FolioFacade();
					oFolio = oFolioFacade.GetGuestFolioInfo(folioId);
					
					switch (oFolio.FolioType)
					{
						case "DEPENDENT":
							
							oCompany = new Company();
							oCompanyFacade = new CompanyFacade();
							oCompany = oCompanyFacade.getCompanyInfo(oFolio.MasterFolio);
							
							oFolio.CompanyID = oCompany.CompanyId;
							break;
					}
					
					return oFolio;
					
				}
				catch (Exception)
				{
				}
				return null;
			}
			
			private FolioTransactionFacade oFolioTransactionFACADE;
			private FolioTransaction oFolioTransaction;
			private FolioTransactions oFolioTransCollection;
			private Jinisys.Hotel.ConfigurationHotel.BusinessLayer.TransactionCode callTranCode;
			private void PostToFolioTransaction(DataRow dtRow)
			{
                MySqlTransaction myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

				try
				{
					MySqlCommand folioCommand = new MySqlCommand("call spGetFolioToCharge(\'" + dtRow["extension"] + "\',\'" + GlobalVariables.gHotelId + "\')", GlobalVariables.gPersistentConnection);
					oFolio = GetFolioInfo(folioCommand.ExecuteScalar().ToString());
					
					callTranCode = GetCallTranCode(dtRow["CallType"].ToString());
					
					oFolioTransaction = new FolioTransaction();
					AssignFolioTransValues(oFolioTransaction, dtRow, oFolio);
					
					
					oFolioTransCollection = new FolioTransactions();
					ApplyPackage(oFolioTransaction, dtRow);
					
					ApplyRouting(oFolioTransaction, oFolio);
					
					ApplyPrivileges(oFolioTransaction);
					
					// > saves in database
					if (oFolioTransCollection.Count == 0)
					{
						oFolioTransCollection.Add(oFolioTransaction);
					}
					
					// > saves in database
					oFolioTransactionFACADE = new FolioTransactionFacade( );
                    if (oFolioTransactionFACADE.InsertFolioTransaction(oFolioTransCollection, ref myTransaction))
                    {
                        myTransaction.Commit();
                    }
                    else
                    {
                        myTransaction.Rollback();
                    }
					
					// ============================================================================================
					
					// >> UPDATE LOGS in CALLMGTSYSTEM
					MySqlCommand updateCommand = new MySqlCommand("call spUpdateLog(" + dtRow["CallNumber"] + ")", GlobalVariables.gCallAcctgConnection);
					updateCommand.ExecuteNonQuery();
					
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Post Call Charge to Folio Transaction Exception",MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
                    myTransaction.Rollback();
				}
				
			}
			
			private void AssignFolioTransValues(FolioTransaction oFolioTrans, DataRow dtRow, Folio oGuestFolio)
			{
				FolioTransaction with_1 = oFolioTrans;
				
				with_1.HotelID = GlobalVariables.gHotelId;
				with_1.FolioID = oGuestFolio.FolioID;
				with_1.SubFolio = "A";
				with_1.AccountID = oGuestFolio.AccountID;
				with_1.TransactionCode = callTranCode.TranCode;
				with_1.ReferenceNo = "";
				with_1.Memo = callTranCode.Memo + "(" + dtRow["extension"] + ")";
				with_1.AcctSide = callTranCode.AcctSide;
				with_1.CurrencyCode = "PHP";
				with_1.ConversionRate = 1;
				with_1.CurrencyAmount = decimal.Parse(dtRow["cost"].ToString());
				with_1.BaseAmount = decimal.Parse(dtRow["cost"].ToString());
				with_1.Discount = 0;
				
				with_1.GovernmentTax = callTranCode.GovtTax;
				if (System.Convert.ToDouble(with_1.GovernmentTax) > 0.0)
				{
					with_1.GovernmentTax = ComputeTaxSrvCharge(with_1.BaseAmount , with_1.GovernmentTax);
				}
				
				with_1.LocalTax = callTranCode.LocalTax;
				if (System.Convert.ToDouble(with_1.LocalTax) > 0.0)
				{
					with_1.LocalTax = ComputeTaxSrvCharge( (with_1.BaseAmount - with_1.GovernmentTax), with_1.LocalTax);
				}
				
				with_1.ServiceCharge = callTranCode.ServiceCharge;
				if (System.Convert.ToDouble(with_1.ServiceCharge) > 0.0)
				{
					with_1.ServiceCharge = ComputeTaxSrvCharge( with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax , with_1.ServiceCharge);
				}
				
				with_1.NetBaseAmount = with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax - with_1.ServiceCharge;
				
				with_1.RouteSequence = "";
				with_1.SourceFolio = "";
				with_1.SourceSubFolio = "";
				with_1.TerminalID = GlobalVariables.gTerminalID.ToString();
				with_1.CreatedBy = GlobalVariables.gLoggedOnUser;
			}
			
			// >> APPLY PACKAGE
			private FolioPackage oPackage;
			private void ApplyPackage(FolioTransaction oFolioTrans, DataRow dtRow)
			{
				try
				{
					oFolioFacade = new FolioFacade();
					oPackage = new FolioPackage();
					oPackage = oFolioFacade.GetFolioTransPackage(oFolioTrans.FolioID, oFolioTrans.TransactionCode);
					
					if ( oPackage != null)
					{
						FolioTransaction with_1 = oFolioTrans;
						with_1.BaseAmount = decimal.Parse(dtRow["cost"].ToString());
						
						if (oPackage.Basis == "A")
						{
							oFolioTrans.Discount = oPackage.AmountOff;
						}
						else
						{
							oFolioTrans.Discount = with_1.BaseAmount * ( oPackage.PercentOff / 100 );
						}
						
						with_1.BaseAmount = with_1.BaseAmount - with_1.Discount;
						
						with_1.GovernmentTax = callTranCode.GovtTax;
						if (System.Convert.ToDouble(with_1.GovernmentTax) > 0.0)
						{
							with_1.GovernmentTax = ComputeTaxSrvCharge( with_1.BaseAmount, with_1.GovernmentTax);
						}
						
						with_1.LocalTax = callTranCode.LocalTax;
						if (System.Convert.ToDouble(with_1.LocalTax) > 0.0)
						{
							with_1.LocalTax = ComputeTaxSrvCharge(with_1.BaseAmount - with_1.GovernmentTax, with_1.LocalTax);
						}
						
						with_1.ServiceCharge = callTranCode.ServiceCharge;
						if (System.Convert.ToDouble(with_1.ServiceCharge) > 0.0)
						{
							with_1.ServiceCharge = ComputeTaxSrvCharge( with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax , with_1.ServiceCharge);
						}
						
						with_1.NetBaseAmount = with_1.BaseAmount - with_1.GovernmentTax - with_1.LocalTax - with_1.ServiceCharge;
						
					}
				}
				catch (Exception)
				{
					//MsgBox("No Package was applied..")
				}
			}
			
			private FolioRoutingCollection oFolioRoutingCollection;
			private void ApplyRouting(FolioTransaction oFTrans, Folio oFolio)
			{
				//oFolioTransCollection = New FolioTransactions
				oFolioRoutingCollection = new FolioRoutingCollection();
				oFolioRoutingCollection = oFolioFacade.GetFolioTransRouting(oFTrans.FolioID, oFTrans.TransactionCode);
				
				//If Not IsNothing(oFolioRoutingCollection) Then
				FolioRouting oRouting;
				foreach (FolioRouting tempLoopVar_oRouting in oFolioRoutingCollection)
				{
					oRouting = tempLoopVar_oRouting;
					
					FolioTransaction oFolioTrans = new FolioTransaction();
					oFolioTrans.HotelID = oFTrans.HotelID;
					oFolioTrans.FolioID = oFolio.FolioID;
					oFolioTrans.AccountID = oFolio.AccountID;
					oFolioTrans.TransactionCode = oFTrans.TransactionCode;
					oFolioTrans.ReferenceNo = oFTrans.ReferenceNo;
					oFolioTrans.TransactionSource = oFTrans.TransactionSource;
					oFolioTrans.Memo = oFTrans.Memo;
					oFolioTrans.AcctSide = oFTrans.AcctSide;
					oFolioTrans.CurrencyCode = oFTrans.CurrencyCode;
					oFolioTrans.ConversionRate = oFTrans.ConversionRate;
					oFolioTrans.CurrencyAmount = oFTrans.CurrencyAmount;
					oFolioTrans.BaseAmount = oFTrans.BaseAmount;
					oFolioTrans.Discount = oFTrans.Discount;
					
					oFolioTrans.GovernmentTax = oFTrans.GovernmentTax;
					oFolioTrans.GovernmentTaxInclusive = oFTrans.GovernmentTaxInclusive;
					oFolioTrans.LocalTax = oFTrans.LocalTax;
					oFolioTrans.LocalTaxInclusive = oFTrans.LocalTaxInclusive;
					oFolioTrans.ServiceCharge = oFTrans.ServiceCharge;
					oFolioTrans.ServiceChargeInclusive = oFTrans.ServiceChargeInclusive;
					
					oFolioTrans.NetBaseAmount = oFTrans.NetBaseAmount;
					oFolioTrans.TerminalID= oFTrans.TerminalID;
					oFolioTrans.CreatedBy = oFTrans.CreatedBy;
					
					// -- changed --------------------------
					oFolioTrans.SubFolio = oRouting.SubFolio;
					if (oFolioTrans.SubFolio == "B")
					{
						oFolioTrans.AccountID = oFolio.CompanyID;
						oFolioTrans.FolioID = oFolio.MasterFolio;
						oFolioTrans.SubFolio = "A";
						oFolioTrans.SourceFolio = oFolio.FolioID;
						oFolioTrans.SourceSubFolio = "B";
						oFolioTrans.Discount = oFolioTrans.Discount;
					}
					else
					{
						oFolioTrans.AccountID = oFolio.AccountID;
						if (oFolio.MasterFolio != "")
						{
							oFolioTrans.Discount = 0;
						}
						else
						{
							oFolioTrans.Discount = oFolioTrans.Discount;
						}
					}

					oFolioTrans.Discount = oFolioTrans.Discount * (oRouting.PercentCharged / 100);
					oFolioTrans.CurrencyAmount = oFolioTrans.CurrencyAmount * (oRouting.PercentCharged / 100);
					oFolioTrans.BaseAmount = oFolioTrans.BaseAmount * (oRouting.PercentCharged / 100);

                    oFolioTrans.GovernmentTax = oFolioTrans.GovernmentTax * (oRouting.PercentCharged / 100);
                    oFolioTrans.LocalTax = oFolioTrans.LocalTax * (oRouting.PercentCharged / 100);
                    oFolioTrans.ServiceCharge = oFolioTrans.ServiceCharge * (oRouting.PercentCharged / 100);
					oFolioTrans.NetAmount = oFolioTrans.NetAmount * (oRouting.PercentCharged / 100);
                    oFolioTrans.NetBaseAmount = oFolioTrans.NetBaseAmount * (oRouting.PercentCharged / 100);

					this.oFolioTransCollection.Add(oFolioTrans);
				}
				//End If
			}
			
			private void ApplyPrivileges(FolioTransaction oFolioTrans)
			{
				try
				{
					oFolioFacade = new FolioFacade();
					
					if (oFolioTransCollection.Count == 0)
					{
						oFolioTransCollection.Add(oFolioTrans);
					}
					
					FolioTransaction fTrans;
					foreach (FolioTransaction tempLoopVar_fTrans in oFolioTransCollection)
					{
						fTrans = tempLoopVar_fTrans;
						
						DataRow dtPrivileges = oFolioFacade.GetFolioTransPrivilege(ref fTrans);
						
						if ( dtPrivileges != null )
						{
							decimal disc = 0;
							if ((string) dtPrivileges["Basis"] == "A")
							{
								disc = decimal.Parse(dtPrivileges["AmountOff"].ToString());
							}
							else
							{
								disc = fTrans.BaseAmount * decimal.Parse(dtPrivileges["PercentOff"].ToString());
							}
							
							fTrans.BaseAmount = fTrans.BaseAmount - disc;
							fTrans.Discount  = fTrans.Discount + disc;
							
							fTrans.GovernmentTax = callTranCode.GovtTax;
							if (System.Convert.ToDouble(fTrans.GovernmentTax) > 0.0)
							{
								fTrans.GovernmentTax = ComputeTaxSrvCharge( fTrans.BaseAmount, fTrans.GovernmentTax);
							}
							
							fTrans.LocalTax = callTranCode.LocalTax;
							if (System.Convert.ToDouble(fTrans.LocalTax) > 0.0)
							{
								fTrans.LocalTax = ComputeTaxSrvCharge(fTrans.BaseAmount - fTrans.GovernmentTax, fTrans.LocalTax);
							}
							
							fTrans.ServiceCharge = callTranCode.ServiceCharge;
							if (System.Convert.ToDouble(fTrans.ServiceCharge) > 0.0)
							{
								fTrans.ServiceCharge = ComputeTaxSrvCharge(fTrans.BaseAmount - fTrans.GovernmentTax - fTrans.LocalTax, fTrans.ServiceCharge);
							}
							
							fTrans.NetBaseAmount = fTrans.BaseAmount - fTrans.GovernmentTax - fTrans.LocalTax - fTrans.ServiceCharge;
							
						}
					}
					
				}
				catch (Exception)
				{
					//MsgBox("No Privilege was applied..")
				}
			}
			
			private decimal ComputeTaxSrvCharge(decimal BaseAmount, decimal Tax)
			{
				decimal TaxAmount;
				
				//TaxAmount = BaseAmount - (BaseAmount / (1 + Tax))
				TaxAmount = BaseAmount * Tax;
				
				return TaxAmount;
			}
			
			private Jinisys.Hotel.ConfigurationHotel.BusinessLayer.TransactionCode oTranCode;
			public Jinisys.Hotel.ConfigurationHotel.BusinessLayer.TransactionCode GetCallTranCode(string trans)
			{
				try
				{
					oTranCode = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.TransactionCode();
					
					MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
					switch (trans.ToUpper())
					{
						case "LOCAL":
							
							dataAdapter = new MySqlDataAdapter("call spGetTranCodeLocalCall(\'" + GlobalVariables.gHotelId + "\')", localConnection);
							break;
						case "NDD":
							
							dataAdapter = new MySqlDataAdapter("call spGetTranCodeNDDCall(\'" + GlobalVariables.gHotelId + "\')", localConnection);
							break;
						case "IDD":
							
							dataAdapter = new MySqlDataAdapter("call spGetTranCodeLongDistanceCall(\'" + GlobalVariables.gHotelId + "\')", localConnection);
							break;
					}
					
					dataAdapter.Fill(oTranCode, "TranCode");
					dataAdapter.Dispose();
					
					oTranCode.TranCode = oTranCode.Tables[0].Rows[0]["TranCode"].ToString();
					oTranCode.TranTypeId = oTranCode.Tables[0].Rows[0]["TranTypeId"].ToString();
					//oTranCode.AcctGroupId = oTranCode.Tables[0].Rows[0]["AcctGroupId"].ToString();
					oTranCode.Memo = oTranCode.Tables[0].Rows[0]["Memo"].ToString();
					oTranCode.AcctSide = oTranCode.Tables[0].Rows[0]["AcctSide"].ToString();
					oTranCode.ServiceCharge = decimal.Parse(oTranCode.Tables[0].Rows[0]["ServiceCharge"].ToString());
					oTranCode.GovtTax = decimal.Parse(oTranCode.Tables[0].Rows[0]["GovtTax"].ToString());
					oTranCode.LocalTax = decimal.Parse(oTranCode.Tables[0].Rows[0]["LocalTax"].ToString());
					
					return oTranCode;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Get Call TransactonCode Exception",MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
					return null;
				}
				
			}
			
			#region "iDisposable"
			protected virtual void Dispose(bool disposing)
			{
				if (disposing)
				{
					localConnection = null;
				}
				// Free your own state (unmanaged objects).
				// Set large fields to null.
			}
			
			~CallChargesDAO()
			{
				// Simply call Dispose(False).
				Dispose(false);
			}
			
			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			#endregion
			
		}
	}
}
