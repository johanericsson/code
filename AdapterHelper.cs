using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace EM
{
	/// <summary>
	/// Summary description for AdapterHelper.
	/// </summary>
	public class AdapterHelper : System.Windows.Forms.Form
	{
		private System.Data.OleDb.OleDbConnection emConnection;
		private System.Data.OleDb.OleDbDataAdapter poItemAdapter;
		private System.Data.OleDb.OleDbDataAdapter containerAdapter;
		private System.Data.OleDb.OleDbDataAdapter companyAdapter;
		private System.Data.OleDb.OleDbDataAdapter poHeaderAdapter;
		private System.Data.OleDb.OleDbDataAdapter contBundleAdapter;
		private System.Data.OleDb.OleDbDataAdapter poItemAdapterPOItemNumber;
		private System.Data.OleDb.OleDbDataAdapter locationAdapter;
		private System.Data.OleDb.OleDbDataAdapter bundleFromItemAdapter;
		private System.Data.OleDb.OleDbDataAdapter containerTemplateAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand9;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand9;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand9;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand9;
		private System.Data.OleDb.OleDbDataAdapter billOfLadingAdapter;
		private System.Data.OleDb.OleDbDataAdapter billOfLadingItemAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand11;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand11;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand11;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand11;
		private System.Data.OleDb.OleDbDataAdapter contBundleFromBundleIDAdapter;
		private System.Data.OleDb.OleDbDataAdapter billOfLadingItemFromContBundleIDAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand13;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand13;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand13;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand13;
		private System.Data.OleDb.OleDbDataAdapter companyFromTypeAdapter;
		private System.Data.OleDb.OleDbDataAdapter poHeaderFromPONumber;
		private System.Data.OleDb.OleDbDataAdapter contactsAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand16;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand16;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand16;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand16;
		private System.Data.OleDb.OleDbDataAdapter countryAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand17;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand17;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand17;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand17;
		private System.Data.OleDb.OleDbDataAdapter temsAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand18;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand18;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand18;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand18;
		public System.Data.OleDb.OleDbDataAdapter shipCodeAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand19;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand19;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand19;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand19;
		private System.Data.OleDb.OleDbDataAdapter finishAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand20;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand20;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand20;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand20;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand8;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand8;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand8;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand8;
		private System.Data.OleDb.OleDbDataAdapter companyFromIDAdapter;
		private System.Data.OleDb.OleDbDataAdapter currencyAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand22;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand22;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand22;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand22;
		private System.Data.OleDb.OleDbDataAdapter itemAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand23;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand23;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand23;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand23;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand24;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand24;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand24;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand24;
		private System.Data.OleDb.OleDbDataAdapter itemFromItemIDAdapter;
		private System.Data.OleDb.OleDbDataAdapter poHeaderAllAdapter;
		private System.Data.OleDb.OleDbDataAdapter poItemAllAdapter;
		private System.Data.OleDb.OleDbDataAdapter itemFromCompIDAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand27;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand27;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand27;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand27;
		private System.Data.OleDb.OleDbDataAdapter locationAllAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand6;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand6;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand6;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand26;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand26;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand26;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand26;
		private System.Data.OleDb.OleDbDataAdapter treatmentAdapter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand29;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand29;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand29;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand29;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand21;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand21;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand21;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand21;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand5;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand5;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand5;
		private System.Data.OleDb.OleDbDataAdapter locationAdapterFromLocID;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand14;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand14;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand14;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand14;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand10;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand10;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand10;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand10;
		private System.Data.OleDb.OleDbDataAdapter billOfLadingFromStatus;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand31;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand31;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand31;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand31;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand7;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand7;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand7;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand7;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand28;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand28;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand28;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand28;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand30;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand30;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand30;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand30;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand12;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand12;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand12;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand12;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand15;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand15;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand15;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand15;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand25;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand25;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand25;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand25;
        private OleDbDataAdapter contAllAdapter;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand2;
        private OleDbCommand oleDbCommand3;
        private OleDbCommand oleDbCommand4;
        private OleDbDataAdapter itemFromItemNameAdapter;
        private OleDbCommand oleDbCommand5;
        private OleDbCommand oleDbCommand6;
        private OleDbCommand oleDbCommand7;
        private OleDbCommand oleDbCommand8;
        private OleDbDataAdapter contactsAllAdapter;
        private OleDbCommand oleDbCommand9;
        private OleDbCommand oleDbCommand10;
        private OleDbCommand oleDbCommand11;
        private OleDbCommand oleDbCommand12;
        private OleDbDataAdapter containerCheckForDuplicatesAdapter;
        private OleDbCommand oleDbCommand13;
        private OleDbCommand oleDbCommand14;
        private OleDbCommand oleDbCommand15;
        private OleDbCommand oleDbCommand16;
        private OleDbDataAdapter surchargeRateAdapter;
        private OleDbCommand oleDbCommand17;
        private OleDbCommand oleDbCommand18;
        private OleDbCommand oleDbCommand19;
        private OleDbCommand oleDbCommand20;
        private OleDbDataAdapter surchargeAllAdapter;
        private OleDbCommand oleDbCommand21;
        private OleDbCommand oleDbCommand22;
        private OleDbCommand oleDbCommand23;
        private OleDbCommand oleDbCommand24;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AdapterHelper()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DataInterface.InitializeAdapterWithParameter(containerAdapter,"ContID");
			DataInterface.InitializeAdapterWithParameter(contBundleAdapter,"ContID");
			DataInterface.InitializeAdapterWithParameter(poHeaderAdapter,"POID");
			DataInterface.InitializeAdapterWithParameter(poItemAdapter,"POID");
			DataInterface.InitializeAdapterWithParameter(poItemAdapterPOItemNumber,"POItemNumber");
			DataInterface.InitializeAdapterWithParameter(bundleFromItemAdapter,"POItemNumber");
			DataInterface.InitializeAdapterWithParameter(billOfLadingItemFromContBundleIDAdapter,"ContBundleID");
			DataInterface.InitializeAdapterWithStringParameter(companyFromTypeAdapter,"CompType");
			DataInterface.InitializeAdapterWithStringParameter(poHeaderFromPONumber,"PONumber");
			DataInterface.InitializeAdapterWithParameter(contactsAdapter,"CompID");
			DataInterface.InitializeAdapterWithParameter(locationAdapter,"CompID");
			DataInterface.InitializeAdapterWithParameter(companyFromIDAdapter,"CompID");
			DataInterface.InitializeAdapterWithParameter(itemFromItemIDAdapter,"ItemID");
			DataInterface.InitializeAdapterWithParameter(itemFromCompIDAdapter,"CompID");
			DataInterface.InitializeAdapterWithParameter(locationAdapterFromLocID,"LocID");
			DataInterface.InitializeAdapterWithStringParameter(this.billOfLadingFromStatus,
				"Status");
            DataInterface.InitializeAdapterWithStringParameter(this.itemFromItemNameAdapter,
                "ItemName");
            DataInterface.InitializeAdapterWithStringParameter(this.containerCheckForDuplicatesAdapter,
                "ContNumber");
            DataInterface.InitializeAdapterWithParameter(this.containerCheckForDuplicatesAdapter,
                "CustomerID");

            DataInterface.InitializeAdapterWithParameter(this.surchargeRateAdapter, "ItemID");
            DataInterface.InitializeAdapterWithParameter(this.surchargeRateAdapter, "FinishID");

		}

		public static AdapterHelper This = new AdapterHelper();
        public static void FillAllContacts(EMDataSet emDataSet)
        {
            This.contactsAllAdapter.Fill(emDataSet.ContactsTbl);
        }
        public static void FillBOLFromStatus(EMDataSet emDataSet,string status)
		{
			This.billOfLadingFromStatus.Fill(emDataSet.BOLTbl);
		}
		public static void FillContainerTemplate(DataTable table)
		{
			This.containerTemplateAdapter.Fill(table);
		}
		public static void FillItems(EMDataSet emDataSet)
		{
			This.itemAdapter.Fill(emDataSet.ItemTbl);
		}
		public static void FillItem(EMDataSet emDataSet, int itemID)
		{
			FillTable(emDataSet.ItemTbl,This.itemFromItemIDAdapter,itemID);
		}
		public static void FillAllPOHeaders(EMDataSet emDataSet)
		{
			FillAllPOHeaders(emDataSet,"");
		}
        static string poHeaderFields = "POID, PONumber, PODate, VendCompany, VendNameObsolete, VendPhone, VendFax, VendContact, VendEMail, VendAddressObsolete, VendCountryObsolete, "+
                         "ShipToCompanyObsolete, ShipToNameObsolete, ShipToPhone, ShipToFax, ShipToContact, ShipToEMail, ShipToAddressObsolete, ShipToCountryObsolete, "+
                         "Terms, ShipCode, FOB, Status, USTotal, OtherTotal, ExchangeRate, CancelDate, Comments, VendLocationNameObsolete, ShipToLocationNameObsolete, "+
                         "MillConfirmationNumber, MillAcknowledgeDate, ExchangeDate, CurrencyID, CustomerID, CustomerLocationID, MillID, MillLocationID, SurchargesInEffect,"+ 
                         "InvoiceNumber, InvoiceDate, MillAcknowledgeDateRevised, VendContactID, ShipToContactID, MillConfirmationAppliesToEntirePO";
		public static void FillAllPOHeaders(EMDataSet emDataSet,string constraints)
		{
			Debug.Assert(Connection.State == ConnectionState.Open);
			string query = "SELECT " + poHeaderFields + " FROM tblPOHeader2" + constraints;
			OleDbDataAdapter poAdapter = new OleDbDataAdapter();
			poAdapter.SelectCommand= new OleDbCommand();
			query += " ORDER BY PODate";
			poAdapter.SelectCommand.Connection = AdapterHelper.Connection;
			poAdapter.SelectCommand.CommandText = query;
			poAdapter.Fill(emDataSet.POHeaderTbl);
		}
        static string contHeaderFields = "ApplyClosingToEntireContainer, Comments, ContainerPickupDate, ContainerPickupTerminal, ContainerProofOfDelivery, ContID, ContNumber, CustomerID, CustomerLocationID, ETA, ShipDate, Status,ReleaseDate";
        public static void FillAllContHeaders(EMDataSet emDataSet, string constraints)
        {
            Debug.Assert(Connection.State == ConnectionState.Open);
            string query = "SELECT " + contHeaderFields + " FROM tblContainer" + constraints;
            OleDbDataAdapter poAdapter = new OleDbDataAdapter();
            poAdapter.SelectCommand = new OleDbCommand();
            poAdapter.SelectCommand.Connection = AdapterHelper.Connection;
            poAdapter.SelectCommand.CommandText = query;
            poAdapter.Fill(emDataSet.ContainerTbl);		
        }
        static string contBundleFields = "ContainerBundleID, ContID, POItemNumber, BundleSeqNumber, EnglishShipQty, InvoiceNumber, Heat, MetricShipQty, BayNumber, PickupDate," +
                         "PickupTerminal, ProofOfDelivery, EMInvoiceNumber, MillInvoiceDate," +
                        "BundleAlloySurcharge,BundleScrapSurcharge";
        public static void FillContBundles(EMDataSet emDataSet, string constraints)
        {
            Debug.Assert(Connection.State == ConnectionState.Open);
            string query = "SELECT " + contBundleFields + " FROM tblContBundle" + constraints;
            OleDbDataAdapter poAdapter = new OleDbDataAdapter();
            poAdapter.SelectCommand = new OleDbCommand();
            poAdapter.SelectCommand.Connection = AdapterHelper.Connection;
            poAdapter.SelectCommand.CommandText = query;
            poAdapter.Fill(emDataSet.ContBundleTbl);
        }
		static string poItemFields =   "POItemNumber, POID, SeqNumber, ItemNameObsolete, ItemDesc, Length, SizeOfItem, ItemAccessCode, Qty, UM, DateRequired, AcknowledgeDate,"+ 
                         "MillShipDate, CancelDate, CustRate, CommRate, CustAmount, CommAmount, Comments, FinishID, ItemID, TreatmentID, MillConfirmationNumber, "+
                         "MillAcknowledgeDate, InvoiceNumber, InvoiceDate";
            public static void FillPOItemsWithConstraints(EMDataSet emDataSet,string constraints)
		{
			Debug.Assert(Connection.State == ConnectionState.Open);
			string query = "SELECT " + poItemFields + " FROM tblPOItem2 " + constraints;
			OleDbDataAdapter poAdapter = new OleDbDataAdapter();
			poAdapter.SelectCommand= new OleDbCommand();
			query += " ORDER BY SeqNumber";
			poAdapter.SelectCommand.Connection = AdapterHelper.Connection;
			poAdapter.SelectCommand.CommandText = query;
			poAdapter.Fill(emDataSet.POItemTbl);
		}
		public static void FillAllPOItems(EMDataSet emDataSet)
		{
			This.poItemAllAdapter.Fill(emDataSet.POItemTbl);
		}

		public static void FillCompanyFromCompID(EMDataSet emDataSet,int key)
		{
			FillTable(emDataSet.CompanyTbl,This.companyFromIDAdapter,key);
		}

		public static void FillTable(DataTable table,OleDbDataAdapter adapter,int key)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.FillAdapterWithParameter(adapter,key);
			adapter.Fill(table);
		}
		public static void FillTable(DataTable table,OleDbDataAdapter adapter,string key)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.FillAdapterWithStringParameter(adapter,key);
			adapter.Fill(table);
		}
        public static void FillContainersWithSameName(DataTable table, string contNumber,
                                                    int customerID)
        {
            Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
            OleDbDataAdapter adapter = This.containerCheckForDuplicatesAdapter;
            DataInterface.FillAdapterWithParameters(adapter, contNumber,customerID);
            adapter.Fill(table);
        }

        public static void FillSurcharge(DataTable table, int itemID, int finishID,int month)
        {
            Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
            OleDbDataAdapter adapter = This.surchargeRateAdapter;
            DataInterface.FillAdapterWithParameters(adapter, itemID, finishID,month);
            adapter.Fill(table);
        }
        public static void FillAllSurcharges(DataTable table)
        {
            Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
            OleDbDataAdapter adapter = This.surchargeAllAdapter;
            adapter.Fill(table);
        }
		public static void FillPOHeader(EMDataSet emDataSet,int poid)
		{
			if (emDataSet.POHeaderTbl.FindByPOID(poid) != null)
				return;
			FillTable(emDataSet.POHeaderTbl,This.poHeaderAdapter,poid);
		}
		public static void FillPOItem(EMDataSet emDataSet,int poid)
		{
			FillTable(emDataSet.POItemTbl,This.poItemAdapter,poid);
		}
        public static void FillFromItemName(EMDataSet emDataSet, string itemName)
        {
            FillTable(emDataSet.ItemTbl, This.itemFromItemNameAdapter, itemName);
        }
		public static void UniqueStr(ref ArrayList arrayList)
		{
			ArrayList outList = new ArrayList();
			arrayList.Sort();
			string last = null;
			for (int i=0;i<arrayList.Count;i++)
			{
				string current = (string)arrayList[i];
				if (current != last)
				{
					outList.Add(current);
					last = current;
				}
			}
			arrayList = outList;
		
		}

        public delegate void MergeItems(object left,object right);
		public static void Unique(ref ArrayList arrayList,MergeItems m)
		{
			ArrayList outList = new ArrayList();
			arrayList.Sort();
			IComparable last = null;
			for (int i=0;i<arrayList.Count;i++)
			{
				IComparable current = (IComparable)arrayList[i];
                if (last == null ||
                    current.GetType() != last.GetType() ||
                    current.CompareTo(last) != 0) // not the same
                {
                    outList.Add(current);
                    last = current;
                }
                else
                {
                    if (m!= null)
                        m(last, current);
                }
			}
			arrayList = outList;
		}
        public static void Unique(ref ArrayList arrayList)
        {
            Unique(ref arrayList, null);
        }
		
		public static void FillOutConstraints(EMDataSet emDataSet)
		{
			ArrayList contHeaderList = new ArrayList();
			ArrayList poItemList = new ArrayList();
			foreach (EMDataSet.ContBundleTblRow bundleRow in emDataSet.ContBundleTbl)
			{

                if (!DataInterface.IsRowAlive(bundleRow))
                    continue;
				poItemList.Add(bundleRow.POItemNumber);
				contHeaderList.Add(bundleRow.ContID);
			}
			Unique(ref contHeaderList);
			foreach (int contID in contHeaderList)
			{
				AdapterHelper.FillContainerHeader(emDataSet,contID);
			}
			Unique(ref poItemList);
			foreach (int poItemID in poItemList)
			{
				AdapterHelper.FillPOItemFromPOItemNumber(emDataSet,poItemID);
			}
			ArrayList itemList = new ArrayList();
			ArrayList poHeaderList = new ArrayList();
			foreach (EMDataSet.POItemTblRow row in emDataSet.POItemTbl)
			{
				if (!row.IsItemIDNull())
				{
					itemList.Add(row.ItemID);
					poHeaderList.Add(row.POID);
				}
			}
			AdapterHelper.FillTreatment(emDataSet.TreatmentTbl);
			AdapterHelper.FillFinish(emDataSet.FinishTbl);

			Unique(ref poHeaderList);
			foreach (int poID in poHeaderList)
			{
				AdapterHelper.FillPOHeader(emDataSet,poID);
			}
			Unique(ref itemList);
			foreach (int itemID in itemList)
			{
				FillItem(emDataSet,itemID);
			}		
			ArrayList millList = new ArrayList();
			ArrayList customerList = new ArrayList();
			ArrayList millLocationList = new ArrayList();
			ArrayList customerLocationList = new ArrayList();

			foreach (EMDataSet.ContainerTblRow contRow in emDataSet.ContainerTbl)
			{
				if (!contRow.IsCustomerIDNull())
					customerList.Add(contRow.CustomerID);
				if (!contRow.IsCustomerLocationIDNull())
					customerLocationList.Add(contRow.CustomerLocationID);
			}
			foreach (EMDataSet.ItemTblRow itemRow in emDataSet.ItemTbl)
			{
				if (!itemRow.IsCompIDNull())
				{
					customerList.Add(itemRow.CompID);
				}
			}
			foreach (EMDataSet.POHeaderTblRow headerRow in emDataSet.POHeaderTbl)
			{
				if (!headerRow.IsMillIDNull())
				{
					millList.Add(headerRow.MillID);
				}
				if (!headerRow.IsCustomerIDNull())
				{
					customerList.Add(headerRow.CustomerID);
				}
				if (!headerRow.IsMillLocationIDNull())
				{
					millLocationList.Add(headerRow.MillLocationID);
				}
				if (!headerRow.IsCustomerLocationIDNull())
				{
					customerLocationList.Add(headerRow.CustomerLocationID);
				}
			}
			Unique(ref millList);
			Unique(ref customerList);
			Unique(ref millLocationList);
			Unique(ref customerLocationList);
			foreach (int id in millList)
			{
				FillCompanyFromCompID(emDataSet,id);
			}
			foreach (int id in customerList)
			{
				FillCompanyFromCompID(emDataSet,id);
			}
			foreach (int id in millLocationList)
			{
				FillLocationFromLocationID(emDataSet,id);
			}
			foreach (int id in customerLocationList)
			{
				FillLocationFromLocationID(emDataSet,id);
			}
			AdapterHelper.FillCountry(emDataSet); 
			FillCurrency(emDataSet);
		}
		public static void FillContainerHeader(EMDataSet emDataSet,int contID)
		{
			FillTable(emDataSet.ContainerTbl,This.containerAdapter,contID);
		}
		public static void FillContBundle(EMDataSet emDataSet,int contID)
		{
			FillTable(emDataSet.ContBundleTbl,This.contBundleAdapter,contID);
		}
		public static void FillItemsFromCompID(EMDataSet emDataSet,int compID)
		{
			FillTable(emDataSet.ItemTbl,This.itemFromCompIDAdapter,compID);
		}
		public static void UpdateItemsFromCompID(EMDataSet emDataSet)
		{
			DataInterface.UpdateTable(This.itemFromCompIDAdapter,emDataSet.ItemTbl);
		}
		public static void FillPOItemFromPOItemNumber(EMDataSet emDataSet,int poItemNumber)
		{
			if (emDataSet.POItemTbl.FindByPOItemNumber(poItemNumber) != null)
				return;
			FillTable(emDataSet.POItemTbl,This.poItemAdapterPOItemNumber,poItemNumber);
		}
		public static void FillContBundleFromPOItemNumber(EMDataSet emDataSet,int poItemNumber)
		{
			FillTable(emDataSet.ContBundleTbl,This.bundleFromItemAdapter,poItemNumber);
		}
		public static void FillCurrency(EMDataSet emDataSet)
		{
			This.currencyAdapter.Fill(emDataSet.CurrencyTbl);
		}
		public static void FillBillOfLading(EMDataSet emDataSet, int bolID)
		{
			FillTable(emDataSet.BOLTbl,This.billOfLadingAdapter,bolID);
		}
		public static void FillBillOfLadingItem(EMDataSet emDataSet,int bolID)
		{
			FillTable(emDataSet.BOLItemTbl,This.billOfLadingItemAdapter,bolID);
		}
		public static void FillContBundleFromContBundleID(EMDataSet emDataSet,int bundleID)
		{
			FillTable(emDataSet.ContBundleTbl,This.contBundleFromBundleIDAdapter,bundleID);
		}
		public static void FillBOLFromContBundleID(EMDataSet emDataSet,int bundleID)
		{
			FillTable(emDataSet.BOLItemTbl,This.billOfLadingItemFromContBundleIDAdapter,bundleID);
		}
		public static void FillCompanyFromType(DataTable companyTable,string compType)
		{
			FillTable(companyTable,This.companyFromTypeAdapter,compType);
		}
		public static void FillCompany(EMDataSet emDataSet)
		{
			This.companyAdapter.Fill(emDataSet.CompanyTbl);
		}
		public static void FillCountry(EMDataSet emDataSet)
		{
			This.countryAdapter.Fill(emDataSet.CountryTbl);
		}
		public static void FillTerms(EMDataSet emDataSet)
		{
			This.temsAdapter.Fill(emDataSet.PaymentTermsTbl);
		}
		public static void FillShippingCode(EMDataSet emDataSet)
		{
			This.shipCodeAdapter.Fill(emDataSet.ShippingCodeTbl);
		}
		public static void FillLocations(EMDataSet emDataSet,int compID)
		{
			FillTable(emDataSet.LocationTbl,This.locationAdapter,compID);
		}
		public static void FillLocationFromLocationID(EMDataSet emDataSet,int locID)
		{
			FillTable(emDataSet.LocationTbl,This.locationAdapterFromLocID,locID);
		}
		public static void FillAllLocations(EMDataSet emDataSet)
		{
			This.locationAllAdapter.Fill(emDataSet.LocationTbl);
		}
		public static void FillContacts(EMDataSet emDataSet,int compID)
		{
			FillTable(emDataSet.ContactsTbl,This.contactsAdapter,compID);
		}
		public static void FillFinish(EMDataSet.FinishTblDataTable table)
		{
			This.finishAdapter.Fill(table);
		}
		public static void FillTreatment(EMDataSet.TreatmentTblDataTable table)
		{
			This.treatmentAdapter.Fill(table);
		}

		public static OleDbConnection Connection
		{
			get
			{
				return This.emConnection;
			}
		}

		public static void CommitBOLChanges(EMDataSet emDataSet)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.UpdateTableAdd(This.billOfLadingAdapter,emDataSet.BOLTbl);
			DataInterface.UpdateTableDelete(This.billOfLadingItemAdapter,emDataSet.BOLItemTbl);
			DataInterface.UpdateTableDelete(This.billOfLadingAdapter,emDataSet.BOLTbl);
			DataInterface.UpdateTableAdd(This.billOfLadingItemAdapter,emDataSet.BOLItemTbl);
		}
		public static void CommitContainerChanges(EMDataSet emDataSet)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.UpdateTableAdd(This.containerAdapter,emDataSet.ContainerTbl);
			DataInterface.UpdateTableDelete(This.contBundleAdapter,emDataSet.ContBundleTbl);
			DataInterface.UpdateTableDelete(This.containerAdapter,emDataSet.ContainerTbl);
			DataInterface.UpdateTableAdd(This.contBundleAdapter,emDataSet.ContBundleTbl);
		}

		public static void CommitLocationChanges(EMDataSet emDataSet)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.UpdateTableDelete(This.locationAdapter,emDataSet.LocationTbl);
			DataInterface.UpdateTableAdd(This.locationAdapter,emDataSet.LocationTbl);
		}
		public static void CommitPOChanges(EMDataSet emDataSet)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.UpdateTableAdd(This.poHeaderAdapter,emDataSet.POHeaderTbl);
			DataInterface.UpdateTableDelete(This.poItemAdapter,emDataSet.POItemTbl);
			DataInterface.UpdateTableDelete(This.poHeaderAdapter,emDataSet.POHeaderTbl);
			DataInterface.UpdateTableAdd(This.poItemAdapter,emDataSet.POItemTbl);					
		}
        public static void CommitFinishChanges(EMDataSet emDataSet)
        {
            Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
            DataInterface.UpdateTableAdd(This.finishAdapter, emDataSet.FinishTbl);
        }

        public static void CommitSurchargeChanges(EMDataSet emDataSet)
        {
            Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
            DataInterface.UpdateTableDelete(This.surchargeRateAdapter, emDataSet.SurchargeRateTbl);
            DataInterface.UpdateTableAdd(This.surchargeRateAdapter, emDataSet.SurchargeRateTbl);
        }

        public static void CommitItemChanges(EMDataSet emDataSet)
        {
            Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
            DataInterface.UpdateTableAdd(This.itemFromItemIDAdapter, emDataSet.ItemTbl);
        }

		public static void CommitAllPOItems(EMDataSet emDataSet)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.UpdateTable(This.poItemAllAdapter,emDataSet.POItemTbl,
									DataRowState.Modified);
		}
        public static void CommitContacts(EMDataSet emDataSet)
        {
            Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
            DataInterface.UpdateTableDelete(This.contactsAllAdapter, emDataSet.ContactsTbl);
            DataInterface.UpdateTableAdd(This.contactsAllAdapter, emDataSet.ContactsTbl);
        }

		public static void CommitAllPOHeaders(EMDataSet emDataSet)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.UpdateTable(This.poHeaderAllAdapter,emDataSet.POHeaderTbl,
				DataRowState.Modified);
		}

		public static void CommitCompanyChanges(EMDataSet emDataSet)
		{
			Debug.Assert(AdapterHelper.Connection.State == ConnectionState.Open);
			DataInterface.UpdateTableDelete(This.companyAdapter,emDataSet.CompanyTbl);
			DataInterface.UpdateTableAdd(This.companyAdapter,emDataSet.CompanyTbl);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdapterHelper));
            this.emConnection = new System.Data.OleDb.OleDbConnection();
            this.poHeaderAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.poItemAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.containerAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.contBundleAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
            this.companyAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand5 = new System.Data.OleDb.OleDbCommand();
            this.poItemAdapterPOItemNumber = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand6 = new System.Data.OleDb.OleDbCommand();
            this.locationAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand7 = new System.Data.OleDb.OleDbCommand();
            this.bundleFromItemAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand8 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand8 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand8 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand8 = new System.Data.OleDb.OleDbCommand();
            this.containerTemplateAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand9 = new System.Data.OleDb.OleDbCommand();
            this.billOfLadingAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand10 = new System.Data.OleDb.OleDbCommand();
            this.billOfLadingItemAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand11 = new System.Data.OleDb.OleDbCommand();
            this.contBundleFromBundleIDAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand12 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand12 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand12 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand12 = new System.Data.OleDb.OleDbCommand();
            this.billOfLadingItemFromContBundleIDAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand13 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand13 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand13 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand13 = new System.Data.OleDb.OleDbCommand();
            this.companyFromTypeAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand14 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand14 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand14 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand14 = new System.Data.OleDb.OleDbCommand();
            this.poHeaderFromPONumber = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand15 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand15 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand15 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand15 = new System.Data.OleDb.OleDbCommand();
            this.contactsAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand16 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand16 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand16 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand16 = new System.Data.OleDb.OleDbCommand();
            this.countryAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand17 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand17 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand17 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand17 = new System.Data.OleDb.OleDbCommand();
            this.temsAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand18 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand18 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand18 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand18 = new System.Data.OleDb.OleDbCommand();
            this.shipCodeAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand19 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand19 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand19 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand19 = new System.Data.OleDb.OleDbCommand();
            this.finishAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand20 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand20 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand20 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand20 = new System.Data.OleDb.OleDbCommand();
            this.companyFromIDAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand21 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand21 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand21 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand21 = new System.Data.OleDb.OleDbCommand();
            this.currencyAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand22 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand22 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand22 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand22 = new System.Data.OleDb.OleDbCommand();
            this.itemAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand23 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand23 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand23 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand23 = new System.Data.OleDb.OleDbCommand();
            this.itemFromItemIDAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand24 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand24 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand24 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand24 = new System.Data.OleDb.OleDbCommand();
            this.poHeaderAllAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand25 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand25 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand25 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand25 = new System.Data.OleDb.OleDbCommand();
            this.poItemAllAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand26 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand26 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand26 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand26 = new System.Data.OleDb.OleDbCommand();
            this.itemFromCompIDAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand27 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand27 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand27 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand27 = new System.Data.OleDb.OleDbCommand();
            this.locationAllAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand28 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand28 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand28 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand28 = new System.Data.OleDb.OleDbCommand();
            this.treatmentAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand29 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand29 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand29 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand29 = new System.Data.OleDb.OleDbCommand();
            this.locationAdapterFromLocID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand30 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand30 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand30 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand30 = new System.Data.OleDb.OleDbCommand();
            this.billOfLadingFromStatus = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand31 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand31 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand31 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand31 = new System.Data.OleDb.OleDbCommand();
            this.contAllAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.itemFromItemNameAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.contactsAllAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand12 = new System.Data.OleDb.OleDbCommand();
            this.containerCheckForDuplicatesAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand13 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand14 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand15 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand16 = new System.Data.OleDb.OleDbCommand();
            this.surchargeRateAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand17 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand18 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand19 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand20 = new System.Data.OleDb.OleDbCommand();
            this.surchargeAllAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand21 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand22 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand23 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand24 = new System.Data.OleDb.OleDbCommand();
            this.SuspendLayout();
            // 
            // emConnection
            // 
            this.emConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=M:\\em_prog_2002.mdb";
            // 
            // poHeaderAdapter
            // 
            this.poHeaderAdapter.DeleteCommand = this.oleDbDeleteCommand1;
            this.poHeaderAdapter.InsertCommand = this.oleDbInsertCommand1;
            this.poHeaderAdapter.SelectCommand = this.oleDbSelectCommand1;
            this.poHeaderAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblPOHeader2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("POID", "POID"),
                        new System.Data.Common.DataColumnMapping("PONumber", "PONumber"),
                        new System.Data.Common.DataColumnMapping("PODate", "PODate"),
                        new System.Data.Common.DataColumnMapping("VendCompany", "VendCompany"),
                        new System.Data.Common.DataColumnMapping("VendNameObsolete", "VendNameObsolete"),
                        new System.Data.Common.DataColumnMapping("VendPhone", "VendPhone"),
                        new System.Data.Common.DataColumnMapping("VendFax", "VendFax"),
                        new System.Data.Common.DataColumnMapping("VendContact", "VendContact"),
                        new System.Data.Common.DataColumnMapping("VendEMail", "VendEMail"),
                        new System.Data.Common.DataColumnMapping("VendAddressObsolete", "VendAddressObsolete"),
                        new System.Data.Common.DataColumnMapping("VendCountryObsolete", "VendCountryObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToCompanyObsolete", "ShipToCompanyObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToNameObsolete", "ShipToNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToPhone", "ShipToPhone"),
                        new System.Data.Common.DataColumnMapping("ShipToFax", "ShipToFax"),
                        new System.Data.Common.DataColumnMapping("ShipToContact", "ShipToContact"),
                        new System.Data.Common.DataColumnMapping("ShipToEMail", "ShipToEMail"),
                        new System.Data.Common.DataColumnMapping("ShipToAddressObsolete", "ShipToAddressObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToCountryObsolete", "ShipToCountryObsolete"),
                        new System.Data.Common.DataColumnMapping("Terms", "Terms"),
                        new System.Data.Common.DataColumnMapping("ShipCode", "ShipCode"),
                        new System.Data.Common.DataColumnMapping("FOB", "FOB"),
                        new System.Data.Common.DataColumnMapping("Status", "Status"),
                        new System.Data.Common.DataColumnMapping("USTotal", "USTotal"),
                        new System.Data.Common.DataColumnMapping("OtherTotal", "OtherTotal"),
                        new System.Data.Common.DataColumnMapping("ExchangeRate", "ExchangeRate"),
                        new System.Data.Common.DataColumnMapping("CancelDate", "CancelDate"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("VendLocationNameObsolete", "VendLocationNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToLocationNameObsolete", "ShipToLocationNameObsolete"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationNumber", "MillConfirmationNumber"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDate", "MillAcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("ExchangeDate", "ExchangeDate"),
                        new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("CustomerLocationID", "CustomerLocationID"),
                        new System.Data.Common.DataColumnMapping("MillID", "MillID"),
                        new System.Data.Common.DataColumnMapping("MillLocationID", "MillLocationID"),
                        new System.Data.Common.DataColumnMapping("SurchargesInEffect", "SurchargesInEffect"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("InvoiceDate", "InvoiceDate"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDateRevised", "MillAcknowledgeDateRevised"),
                        new System.Data.Common.DataColumnMapping("VendContactID", "VendContactID"),
                        new System.Data.Common.DataColumnMapping("ShipToContactID", "ShipToContactID"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationAppliesToEntirePO", "MillConfirmationAppliesToEntirePO")})});
            this.poHeaderAdapter.UpdateCommand = this.oleDbUpdateCommand1;
            this.poHeaderAdapter.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.poHeaderAdapter_RowUpdated);
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.emConnection;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PONumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PODate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PODate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCompany", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Terms", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FOB", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FOB", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_USTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_USTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_OtherTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargesInEffect", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.emConnection;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, "PONumber"),
            new System.Data.OleDb.OleDbParameter("PODate", System.Data.OleDb.OleDbType.Date, 0, "PODate"),
            new System.Data.OleDb.OleDbParameter("VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCompany"),
            new System.Data.OleDb.OleDbParameter("VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendNameObsolete"),
            new System.Data.OleDb.OleDbParameter("VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "VendPhone"),
            new System.Data.OleDb.OleDbParameter("VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, "VendFax"),
            new System.Data.OleDb.OleDbParameter("VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, "VendContact"),
            new System.Data.OleDb.OleDbParameter("VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "VendEMail"),
            new System.Data.OleDb.OleDbParameter("VendAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "VendAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCompanyObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToPhone"),
            new System.Data.OleDb.OleDbParameter("ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToFax"),
            new System.Data.OleDb.OleDbParameter("ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToContact"),
            new System.Data.OleDb.OleDbParameter("ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToEMail"),
            new System.Data.OleDb.OleDbParameter("ShipToAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ShipToAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("Terms", System.Data.OleDb.OleDbType.VarWChar, 0, "Terms"),
            new System.Data.OleDb.OleDbParameter("ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipCode"),
            new System.Data.OleDb.OleDbParameter("FOB", System.Data.OleDb.OleDbType.VarWChar, 0, "FOB"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("USTotal", System.Data.OleDb.OleDbType.Currency, 0, "USTotal"),
            new System.Data.OleDb.OleDbParameter("OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, "OtherTotal"),
            new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, "ExchangeRate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, "ExchangeDate"),
            new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, "CurrencyID"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("MillID", System.Data.OleDb.OleDbType.Integer, 0, "MillID"),
            new System.Data.OleDb.OleDbParameter("MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, "MillLocationID"),
            new System.Data.OleDb.OleDbParameter("SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, "SurchargesInEffect"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDateRevised"),
            new System.Data.OleDb.OleDbParameter("VendContactID", System.Data.OleDb.OleDbType.Integer, 0, "VendContactID"),
            new System.Data.OleDb.OleDbParameter("ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, "ShipToContactID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, "MillConfirmationAppliesToEntirePO")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.emConnection;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.emConnection;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, "PONumber"),
            new System.Data.OleDb.OleDbParameter("PODate", System.Data.OleDb.OleDbType.Date, 0, "PODate"),
            new System.Data.OleDb.OleDbParameter("VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCompany"),
            new System.Data.OleDb.OleDbParameter("VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendNameObsolete"),
            new System.Data.OleDb.OleDbParameter("VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "VendPhone"),
            new System.Data.OleDb.OleDbParameter("VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, "VendFax"),
            new System.Data.OleDb.OleDbParameter("VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, "VendContact"),
            new System.Data.OleDb.OleDbParameter("VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "VendEMail"),
            new System.Data.OleDb.OleDbParameter("VendAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "VendAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCompanyObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToPhone"),
            new System.Data.OleDb.OleDbParameter("ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToFax"),
            new System.Data.OleDb.OleDbParameter("ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToContact"),
            new System.Data.OleDb.OleDbParameter("ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToEMail"),
            new System.Data.OleDb.OleDbParameter("ShipToAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ShipToAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("Terms", System.Data.OleDb.OleDbType.VarWChar, 0, "Terms"),
            new System.Data.OleDb.OleDbParameter("ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipCode"),
            new System.Data.OleDb.OleDbParameter("FOB", System.Data.OleDb.OleDbType.VarWChar, 0, "FOB"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("USTotal", System.Data.OleDb.OleDbType.Currency, 0, "USTotal"),
            new System.Data.OleDb.OleDbParameter("OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, "OtherTotal"),
            new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, "ExchangeRate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, "ExchangeDate"),
            new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, "CurrencyID"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("MillID", System.Data.OleDb.OleDbType.Integer, 0, "MillID"),
            new System.Data.OleDb.OleDbParameter("MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, "MillLocationID"),
            new System.Data.OleDb.OleDbParameter("SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, "SurchargesInEffect"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDateRevised"),
            new System.Data.OleDb.OleDbParameter("VendContactID", System.Data.OleDb.OleDbType.Integer, 0, "VendContactID"),
            new System.Data.OleDb.OleDbParameter("ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, "ShipToContactID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, "MillConfirmationAppliesToEntirePO"),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PONumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PODate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PODate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCompany", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Terms", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FOB", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FOB", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_USTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_USTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_OtherTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargesInEffect", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, null)});
            // 
            // poItemAdapter
            // 
            this.poItemAdapter.DeleteCommand = this.oleDbDeleteCommand2;
            this.poItemAdapter.InsertCommand = this.oleDbInsertCommand2;
            this.poItemAdapter.SelectCommand = this.oleDbSelectCommand2;
            this.poItemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblPOItem2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
                        new System.Data.Common.DataColumnMapping("POID", "POID"),
                        new System.Data.Common.DataColumnMapping("SeqNumber", "SeqNumber"),
                        new System.Data.Common.DataColumnMapping("ItemNameObsolete", "ItemNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
                        new System.Data.Common.DataColumnMapping("Length", "Length"),
                        new System.Data.Common.DataColumnMapping("SizeOfItem", "SizeOfItem"),
                        new System.Data.Common.DataColumnMapping("ItemAccessCode", "ItemAccessCode"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("UM", "UM"),
                        new System.Data.Common.DataColumnMapping("DateRequired", "DateRequired"),
                        new System.Data.Common.DataColumnMapping("AcknowledgeDate", "AcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("MillShipDate", "MillShipDate"),
                        new System.Data.Common.DataColumnMapping("CancelDate", "CancelDate"),
                        new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
                        new System.Data.Common.DataColumnMapping("CommRate", "CommRate"),
                        new System.Data.Common.DataColumnMapping("CustAmount", "CustAmount"),
                        new System.Data.Common.DataColumnMapping("CommAmount", "CommAmount"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("FinishID", "FinishID"),
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("TreatmentID", "TreatmentID"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationNumber", "MillConfirmationNumber"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDate", "MillAcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("InvoiceDate", "InvoiceDate")})});
            this.poItemAdapter.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText");
            this.oleDbDeleteCommand2.Connection = this.emConnection;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SizeOfItem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemAccessCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Qty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Qty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_UM", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_UM", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DateRequired", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DateRequired", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = this.emConnection;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "SeqNumber"),
            new System.Data.OleDb.OleDbParameter("ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.VarWChar, 0, "Length"),
            new System.Data.OleDb.OleDbParameter("SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, "SizeOfItem"),
            new System.Data.OleDb.OleDbParameter("ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemAccessCode"),
            new System.Data.OleDb.OleDbParameter("Qty", System.Data.OleDb.OleDbType.Currency, 0, "Qty"),
            new System.Data.OleDb.OleDbParameter("UM", System.Data.OleDb.OleDbType.VarWChar, 0, "UM"),
            new System.Data.OleDb.OleDbParameter("DateRequired", System.Data.OleDb.OleDbType.Date, 0, "DateRequired"),
            new System.Data.OleDb.OleDbParameter("AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "AcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("MillShipDate", System.Data.OleDb.OleDbType.Date, 0, "MillShipDate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CustAmount", System.Data.OleDb.OleDbType.Currency, 0, "CustAmount"),
            new System.Data.OleDb.OleDbParameter("CommAmount", System.Data.OleDb.OleDbType.Currency, 0, "CommAmount"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, "TreatmentID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.emConnection;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.emConnection;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "SeqNumber"),
            new System.Data.OleDb.OleDbParameter("ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.VarWChar, 0, "Length"),
            new System.Data.OleDb.OleDbParameter("SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, "SizeOfItem"),
            new System.Data.OleDb.OleDbParameter("ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemAccessCode"),
            new System.Data.OleDb.OleDbParameter("Qty", System.Data.OleDb.OleDbType.Currency, 0, "Qty"),
            new System.Data.OleDb.OleDbParameter("UM", System.Data.OleDb.OleDbType.VarWChar, 0, "UM"),
            new System.Data.OleDb.OleDbParameter("DateRequired", System.Data.OleDb.OleDbType.Date, 0, "DateRequired"),
            new System.Data.OleDb.OleDbParameter("AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "AcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("MillShipDate", System.Data.OleDb.OleDbType.Date, 0, "MillShipDate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CustAmount", System.Data.OleDb.OleDbType.Currency, 0, "CustAmount"),
            new System.Data.OleDb.OleDbParameter("CommAmount", System.Data.OleDb.OleDbType.Currency, 0, "CommAmount"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, "TreatmentID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SizeOfItem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemAccessCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Qty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Qty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_UM", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_UM", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DateRequired", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DateRequired", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null)});
            // 
            // containerAdapter
            // 
            this.containerAdapter.DeleteCommand = this.oleDbDeleteCommand3;
            this.containerAdapter.InsertCommand = this.oleDbInsertCommand3;
            this.containerAdapter.SelectCommand = this.oleDbSelectCommand3;
            this.containerAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContainer", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContID", "ContID"),
                        new System.Data.Common.DataColumnMapping("ContNumber", "ContNumber"),
                        new System.Data.Common.DataColumnMapping("ShipDate", "ShipDate"),
                        new System.Data.Common.DataColumnMapping("ETA", "ETA"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("Status", "Status"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("CustomerLocationID", "CustomerLocationID"),
                        new System.Data.Common.DataColumnMapping("ApplyClosingToEntireContainer", "ApplyClosingToEntireContainer"),
                        new System.Data.Common.DataColumnMapping("ContainerPickupDate", "ContainerPickupDate"),
                        new System.Data.Common.DataColumnMapping("ContainerPickupTerminal", "ContainerPickupTerminal"),
                        new System.Data.Common.DataColumnMapping("ContainerProofOfDelivery", "ContainerProofOfDelivery"),
                        new System.Data.Common.DataColumnMapping("ReleaseDate", "ReleaseDate"),
                        new System.Data.Common.DataColumnMapping("MillID", "MillID")})});
            this.containerAdapter.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = resources.GetString("oleDbDeleteCommand3.CommandText");
            this.oleDbDeleteCommand3.Connection = this.emConnection;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ETA", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ReleaseDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = resources.GetString("oleDbInsertCommand3.CommandText");
            this.oleDbInsertCommand3.Connection = this.emConnection;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "ContNumber"),
            new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.Date, 0, "ShipDate"),
            new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.Date, 0, "ETA"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, "ApplyClosingToEntireContainer"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, "ContainerPickupDate"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerPickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, "ReleaseDate"),
            new System.Data.OleDb.OleDbParameter("MillID", System.Data.OleDb.OleDbType.Integer, 0, "MillID")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT *  FROM tblContainer WHERE (ContID = ?)";
            this.oleDbSelectCommand3.Connection = this.emConnection;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = resources.GetString("oleDbUpdateCommand3.CommandText");
            this.oleDbUpdateCommand3.Connection = this.emConnection;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "ContNumber"),
            new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.Date, 0, "ShipDate"),
            new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.Date, 0, "ETA"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, "ApplyClosingToEntireContainer"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, "ContainerPickupDate"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerPickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, "ReleaseDate"),
            new System.Data.OleDb.OleDbParameter("MillID", System.Data.OleDb.OleDbType.Integer, 0, "MillID"),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ETA", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ReleaseDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, null)});
            // 
            // contBundleAdapter
            // 
            this.contBundleAdapter.DeleteCommand = this.oleDbDeleteCommand4;
            this.contBundleAdapter.InsertCommand = this.oleDbInsertCommand4;
            this.contBundleAdapter.SelectCommand = this.oleDbSelectCommand4;
            this.contBundleAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContBundle", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContainerBundleID", "ContainerBundleID"),
                        new System.Data.Common.DataColumnMapping("ContID", "ContID"),
                        new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
                        new System.Data.Common.DataColumnMapping("BundleSeqNumber", "BundleSeqNumber"),
                        new System.Data.Common.DataColumnMapping("EnglishShipQty", "EnglishShipQty"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("Heat", "Heat"),
                        new System.Data.Common.DataColumnMapping("MetricShipQty", "MetricShipQty"),
                        new System.Data.Common.DataColumnMapping("BayNumber", "BayNumber"),
                        new System.Data.Common.DataColumnMapping("PickupDate", "PickupDate"),
                        new System.Data.Common.DataColumnMapping("PickupTerminal", "PickupTerminal"),
                        new System.Data.Common.DataColumnMapping("ProofOfDelivery", "ProofOfDelivery"),
                        new System.Data.Common.DataColumnMapping("EMInvoiceNumber", "EMInvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("AuxKey1", "AuxKey1"),
                        new System.Data.Common.DataColumnMapping("AuxKey2", "AuxKey2"),
                        new System.Data.Common.DataColumnMapping("MillInvoiceDate", "MillInvoiceDate"),
                        new System.Data.Common.DataColumnMapping("BundleAlloySurcharge", "BundleAlloySurcharge"),
                        new System.Data.Common.DataColumnMapping("BundleScrapSurcharge", "BundleScrapSurcharge")})});
            this.contBundleAdapter.UpdateCommand = this.oleDbUpdateCommand4;
            // 
            // oleDbDeleteCommand4
            // 
            this.oleDbDeleteCommand4.CommandText = resources.GetString("oleDbDeleteCommand4.CommandText");
            this.oleDbDeleteCommand4.Connection = this.emConnection;
            this.oleDbDeleteCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EnglishShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Heat", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Heat", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MetricShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BayNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMInvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillInvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand4
            // 
            this.oleDbInsertCommand4.CommandText = resources.GetString("oleDbInsertCommand4.CommandText");
            this.oleDbInsertCommand4.Connection = this.emConnection;
            this.oleDbInsertCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID"),
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "BundleSeqNumber"),
            new System.Data.OleDb.OleDbParameter("EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, "EnglishShipQty"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("Heat", System.Data.OleDb.OleDbType.VarWChar, 0, "Heat"),
            new System.Data.OleDb.OleDbParameter("MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricShipQty"),
            new System.Data.OleDb.OleDbParameter("BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "BayNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.Date, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "PickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "EMInvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey1"),
            new System.Data.OleDb.OleDbParameter("AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey2"),
            new System.Data.OleDb.OleDbParameter("MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "MillInvoiceDate"),
            new System.Data.OleDb.OleDbParameter("BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleAlloySurcharge"),
            new System.Data.OleDb.OleDbParameter("BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleScrapSurcharge")});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = resources.GetString("oleDbSelectCommand4.CommandText");
            this.oleDbSelectCommand4.Connection = this.emConnection;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID")});
            // 
            // oleDbUpdateCommand4
            // 
            this.oleDbUpdateCommand4.CommandText = resources.GetString("oleDbUpdateCommand4.CommandText");
            this.oleDbUpdateCommand4.Connection = this.emConnection;
            this.oleDbUpdateCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID"),
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "BundleSeqNumber"),
            new System.Data.OleDb.OleDbParameter("EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, "EnglishShipQty"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("Heat", System.Data.OleDb.OleDbType.VarWChar, 0, "Heat"),
            new System.Data.OleDb.OleDbParameter("MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricShipQty"),
            new System.Data.OleDb.OleDbParameter("BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "BayNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.Date, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "PickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "EMInvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey1"),
            new System.Data.OleDb.OleDbParameter("AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey2"),
            new System.Data.OleDb.OleDbParameter("MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "MillInvoiceDate"),
            new System.Data.OleDb.OleDbParameter("BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleAlloySurcharge"),
            new System.Data.OleDb.OleDbParameter("BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleScrapSurcharge"),
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EnglishShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Heat", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Heat", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MetricShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BayNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMInvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillInvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, null)});
            // 
            // companyAdapter
            // 
            this.companyAdapter.DeleteCommand = this.oleDbDeleteCommand5;
            this.companyAdapter.InsertCommand = this.oleDbInsertCommand5;
            this.companyAdapter.SelectCommand = this.oleDbSelectCommand5;
            this.companyAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblCompany", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CompName", "CompName"),
                        new System.Data.Common.DataColumnMapping("CompType", "CompType"),
                        new System.Data.Common.DataColumnMapping("ContainerExcelFile", "ContainerExcelFile"),
                        new System.Data.Common.DataColumnMapping("CompNameAbbreviation", "CompNameAbbreviation")})});
            this.companyAdapter.UpdateCommand = this.oleDbUpdateCommand5;
            // 
            // oleDbDeleteCommand5
            // 
            this.oleDbDeleteCommand5.CommandText = resources.GetString("oleDbDeleteCommand5.CommandText");
            this.oleDbDeleteCommand5.Connection = this.emConnection;
            this.oleDbDeleteCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompType", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerExcelFile", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompNameAbbreviation", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand5
            // 
            this.oleDbInsertCommand5.CommandText = "INSERT INTO `tblCompany` (`CompID`, `CompName`, `CompType`, `ContainerExcelFile`," +
                " `CompNameAbbreviation`) VALUES (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand5.Connection = this.emConnection;
            this.oleDbInsertCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 0, "CompName"),
            new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 0, "CompType"),
            new System.Data.OleDb.OleDbParameter("ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerExcelFile"),
            new System.Data.OleDb.OleDbParameter("CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, "CompNameAbbreviation")});
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.CommandText = "SELECT *  FROM tblCompany ORDER BY CompType, CompName";
            this.oleDbSelectCommand5.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand5
            // 
            this.oleDbUpdateCommand5.CommandText = resources.GetString("oleDbUpdateCommand5.CommandText");
            this.oleDbUpdateCommand5.Connection = this.emConnection;
            this.oleDbUpdateCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 0, "CompName"),
            new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 0, "CompType"),
            new System.Data.OleDb.OleDbParameter("ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerExcelFile"),
            new System.Data.OleDb.OleDbParameter("CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, "CompNameAbbreviation"),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompType", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerExcelFile", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompNameAbbreviation", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, null)});
            // 
            // poItemAdapterPOItemNumber
            // 
            this.poItemAdapterPOItemNumber.DeleteCommand = this.oleDbDeleteCommand6;
            this.poItemAdapterPOItemNumber.InsertCommand = this.oleDbInsertCommand6;
            this.poItemAdapterPOItemNumber.SelectCommand = this.oleDbSelectCommand6;
            this.poItemAdapterPOItemNumber.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblPOItem2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
                        new System.Data.Common.DataColumnMapping("POID", "POID"),
                        new System.Data.Common.DataColumnMapping("SeqNumber", "SeqNumber"),
                        new System.Data.Common.DataColumnMapping("ItemNameObsolete", "ItemNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
                        new System.Data.Common.DataColumnMapping("Length", "Length"),
                        new System.Data.Common.DataColumnMapping("SizeOfItem", "SizeOfItem"),
                        new System.Data.Common.DataColumnMapping("ItemAccessCode", "ItemAccessCode"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("UM", "UM"),
                        new System.Data.Common.DataColumnMapping("DateRequired", "DateRequired"),
                        new System.Data.Common.DataColumnMapping("AcknowledgeDate", "AcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("MillShipDate", "MillShipDate"),
                        new System.Data.Common.DataColumnMapping("CancelDate", "CancelDate"),
                        new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
                        new System.Data.Common.DataColumnMapping("CommRate", "CommRate"),
                        new System.Data.Common.DataColumnMapping("CustAmount", "CustAmount"),
                        new System.Data.Common.DataColumnMapping("CommAmount", "CommAmount"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("FinishID", "FinishID"),
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("TreatmentID", "TreatmentID"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationNumber", "MillConfirmationNumber"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDate", "MillAcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("InvoiceDate", "InvoiceDate")})});
            this.poItemAdapterPOItemNumber.UpdateCommand = this.oleDbUpdateCommand6;
            // 
            // oleDbDeleteCommand6
            // 
            this.oleDbDeleteCommand6.CommandText = resources.GetString("oleDbDeleteCommand6.CommandText");
            this.oleDbDeleteCommand6.Connection = this.emConnection;
            this.oleDbDeleteCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SizeOfItem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemAccessCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Qty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Qty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_UM", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_UM", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DateRequired", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DateRequired", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand6
            // 
            this.oleDbInsertCommand6.CommandText = resources.GetString("oleDbInsertCommand6.CommandText");
            this.oleDbInsertCommand6.Connection = this.emConnection;
            this.oleDbInsertCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "SeqNumber"),
            new System.Data.OleDb.OleDbParameter("ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.VarWChar, 0, "Length"),
            new System.Data.OleDb.OleDbParameter("SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, "SizeOfItem"),
            new System.Data.OleDb.OleDbParameter("ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemAccessCode"),
            new System.Data.OleDb.OleDbParameter("Qty", System.Data.OleDb.OleDbType.Currency, 0, "Qty"),
            new System.Data.OleDb.OleDbParameter("UM", System.Data.OleDb.OleDbType.VarWChar, 0, "UM"),
            new System.Data.OleDb.OleDbParameter("DateRequired", System.Data.OleDb.OleDbType.Date, 0, "DateRequired"),
            new System.Data.OleDb.OleDbParameter("AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "AcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("MillShipDate", System.Data.OleDb.OleDbType.Date, 0, "MillShipDate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CustAmount", System.Data.OleDb.OleDbType.Currency, 0, "CustAmount"),
            new System.Data.OleDb.OleDbParameter("CommAmount", System.Data.OleDb.OleDbType.Currency, 0, "CommAmount"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, "TreatmentID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate")});
            // 
            // oleDbSelectCommand6
            // 
            this.oleDbSelectCommand6.CommandText = resources.GetString("oleDbSelectCommand6.CommandText");
            this.oleDbSelectCommand6.Connection = this.emConnection;
            this.oleDbSelectCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber")});
            // 
            // oleDbUpdateCommand6
            // 
            this.oleDbUpdateCommand6.CommandText = resources.GetString("oleDbUpdateCommand6.CommandText");
            this.oleDbUpdateCommand6.Connection = this.emConnection;
            this.oleDbUpdateCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "SeqNumber"),
            new System.Data.OleDb.OleDbParameter("ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.VarWChar, 0, "Length"),
            new System.Data.OleDb.OleDbParameter("SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, "SizeOfItem"),
            new System.Data.OleDb.OleDbParameter("ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemAccessCode"),
            new System.Data.OleDb.OleDbParameter("Qty", System.Data.OleDb.OleDbType.Currency, 0, "Qty"),
            new System.Data.OleDb.OleDbParameter("UM", System.Data.OleDb.OleDbType.VarWChar, 0, "UM"),
            new System.Data.OleDb.OleDbParameter("DateRequired", System.Data.OleDb.OleDbType.Date, 0, "DateRequired"),
            new System.Data.OleDb.OleDbParameter("AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "AcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("MillShipDate", System.Data.OleDb.OleDbType.Date, 0, "MillShipDate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CustAmount", System.Data.OleDb.OleDbType.Currency, 0, "CustAmount"),
            new System.Data.OleDb.OleDbParameter("CommAmount", System.Data.OleDb.OleDbType.Currency, 0, "CommAmount"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, "TreatmentID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SizeOfItem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemAccessCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Qty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Qty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_UM", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_UM", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DateRequired", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DateRequired", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null)});
            // 
            // locationAdapter
            // 
            this.locationAdapter.DeleteCommand = this.oleDbDeleteCommand7;
            this.locationAdapter.InsertCommand = this.oleDbInsertCommand7;
            this.locationAdapter.SelectCommand = this.oleDbSelectCommand7;
            this.locationAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblLocation2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Address", "Address"),
                        new System.Data.Common.DataColumnMapping("ATTNString", "ATTNString"),
                        new System.Data.Common.DataColumnMapping("CCString", "CCString"),
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CountryID", "CountryID"),
                        new System.Data.Common.DataColumnMapping("ExcelFile", "ExcelFile"),
                        new System.Data.Common.DataColumnMapping("LocID", "LocID"),
                        new System.Data.Common.DataColumnMapping("LocName", "LocName")})});
            this.locationAdapter.UpdateCommand = this.oleDbUpdateCommand7;
            // 
            // oleDbDeleteCommand7
            // 
            this.oleDbDeleteCommand7.CommandText = "DELETE FROM tblLocation2 WHERE (LocID = ?) AND (CompID = ?) AND (CountryID = ?) A" +
                "ND (ExcelFile = ? OR ? IS NULL AND ExcelFile IS NULL) AND (LocName = ?)";
            this.oleDbDeleteCommand7.Connection = this.emConnection;
            this.oleDbDeleteCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_LocID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LocName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocName", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand7
            // 
            this.oleDbInsertCommand7.CommandText = "INSERT INTO tblLocation2(Address, ATTNString, CCString, CompID, CountryID, ExcelF" +
                "ile, LocID, LocName) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand7.Connection = this.emConnection;
            this.oleDbInsertCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 0, "Address"),
            new System.Data.OleDb.OleDbParameter("ATTNString", System.Data.OleDb.OleDbType.VarWChar, 0, "ATTNString"),
            new System.Data.OleDb.OleDbParameter("CCString", System.Data.OleDb.OleDbType.VarWChar, 0, "CCString"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"),
            new System.Data.OleDb.OleDbParameter("ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, "ExcelFile"),
            new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID"),
            new System.Data.OleDb.OleDbParameter("LocName", System.Data.OleDb.OleDbType.VarWChar, 50, "LocName")});
            // 
            // oleDbSelectCommand7
            // 
            this.oleDbSelectCommand7.CommandText = "SELECT Address, ATTNString, CCString, CompID, CountryID, ExcelFile, LocID, LocNam" +
                "e FROM tblLocation2 WHERE (CompID = ?) ORDER BY LocName";
            this.oleDbSelectCommand7.Connection = this.emConnection;
            this.oleDbSelectCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID")});
            // 
            // oleDbUpdateCommand7
            // 
            this.oleDbUpdateCommand7.CommandText = resources.GetString("oleDbUpdateCommand7.CommandText");
            this.oleDbUpdateCommand7.Connection = this.emConnection;
            this.oleDbUpdateCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 0, "Address"),
            new System.Data.OleDb.OleDbParameter("ATTNString", System.Data.OleDb.OleDbType.VarWChar, 0, "ATTNString"),
            new System.Data.OleDb.OleDbParameter("CCString", System.Data.OleDb.OleDbType.VarWChar, 0, "CCString"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"),
            new System.Data.OleDb.OleDbParameter("ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, "ExcelFile"),
            new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID"),
            new System.Data.OleDb.OleDbParameter("LocName", System.Data.OleDb.OleDbType.VarWChar, 50, "LocName"),
            new System.Data.OleDb.OleDbParameter("Original_LocID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LocName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocName", System.Data.DataRowVersion.Original, null)});
            // 
            // bundleFromItemAdapter
            // 
            this.bundleFromItemAdapter.DeleteCommand = this.oleDbDeleteCommand8;
            this.bundleFromItemAdapter.InsertCommand = this.oleDbInsertCommand8;
            this.bundleFromItemAdapter.SelectCommand = this.oleDbSelectCommand8;
            this.bundleFromItemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContBundle", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContainerBundleID", "ContainerBundleID"),
                        new System.Data.Common.DataColumnMapping("ContID", "ContID"),
                        new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
                        new System.Data.Common.DataColumnMapping("BundleSeqNumber", "BundleSeqNumber"),
                        new System.Data.Common.DataColumnMapping("EnglishShipQty", "EnglishShipQty"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("Heat", "Heat"),
                        new System.Data.Common.DataColumnMapping("MetricShipQty", "MetricShipQty"),
                        new System.Data.Common.DataColumnMapping("BayNumber", "BayNumber"),
                        new System.Data.Common.DataColumnMapping("PickupDate", "PickupDate"),
                        new System.Data.Common.DataColumnMapping("PickupTerminal", "PickupTerminal"),
                        new System.Data.Common.DataColumnMapping("ProofOfDelivery", "ProofOfDelivery"),
                        new System.Data.Common.DataColumnMapping("EMInvoiceNumber", "EMInvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("AuxKey1", "AuxKey1"),
                        new System.Data.Common.DataColumnMapping("AuxKey2", "AuxKey2"),
                        new System.Data.Common.DataColumnMapping("MillInvoiceDate", "MillInvoiceDate"),
                        new System.Data.Common.DataColumnMapping("BundleAlloySurcharge", "BundleAlloySurcharge"),
                        new System.Data.Common.DataColumnMapping("BundleScrapSurcharge", "BundleScrapSurcharge")})});
            this.bundleFromItemAdapter.UpdateCommand = this.oleDbUpdateCommand8;
            // 
            // oleDbDeleteCommand8
            // 
            this.oleDbDeleteCommand8.CommandText = resources.GetString("oleDbDeleteCommand8.CommandText");
            this.oleDbDeleteCommand8.Connection = this.emConnection;
            this.oleDbDeleteCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EnglishShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Heat", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Heat", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MetricShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BayNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMInvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillInvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand8
            // 
            this.oleDbInsertCommand8.CommandText = resources.GetString("oleDbInsertCommand8.CommandText");
            this.oleDbInsertCommand8.Connection = this.emConnection;
            this.oleDbInsertCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID"),
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "BundleSeqNumber"),
            new System.Data.OleDb.OleDbParameter("EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, "EnglishShipQty"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("Heat", System.Data.OleDb.OleDbType.VarWChar, 0, "Heat"),
            new System.Data.OleDb.OleDbParameter("MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricShipQty"),
            new System.Data.OleDb.OleDbParameter("BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "BayNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.Date, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "PickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "EMInvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey1"),
            new System.Data.OleDb.OleDbParameter("AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey2"),
            new System.Data.OleDb.OleDbParameter("MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "MillInvoiceDate"),
            new System.Data.OleDb.OleDbParameter("BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleAlloySurcharge"),
            new System.Data.OleDb.OleDbParameter("BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleScrapSurcharge")});
            // 
            // oleDbSelectCommand8
            // 
            this.oleDbSelectCommand8.CommandText = resources.GetString("oleDbSelectCommand8.CommandText");
            this.oleDbSelectCommand8.Connection = this.emConnection;
            this.oleDbSelectCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber")});
            // 
            // oleDbUpdateCommand8
            // 
            this.oleDbUpdateCommand8.CommandText = resources.GetString("oleDbUpdateCommand8.CommandText");
            this.oleDbUpdateCommand8.Connection = this.emConnection;
            this.oleDbUpdateCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID"),
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "BundleSeqNumber"),
            new System.Data.OleDb.OleDbParameter("EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, "EnglishShipQty"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("Heat", System.Data.OleDb.OleDbType.VarWChar, 0, "Heat"),
            new System.Data.OleDb.OleDbParameter("MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricShipQty"),
            new System.Data.OleDb.OleDbParameter("BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "BayNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.Date, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "PickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "EMInvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey1"),
            new System.Data.OleDb.OleDbParameter("AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey2"),
            new System.Data.OleDb.OleDbParameter("MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "MillInvoiceDate"),
            new System.Data.OleDb.OleDbParameter("BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleAlloySurcharge"),
            new System.Data.OleDb.OleDbParameter("BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleScrapSurcharge"),
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EnglishShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Heat", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Heat", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MetricShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BayNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMInvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillInvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, null)});
            // 
            // containerTemplateAdapter
            // 
            this.containerTemplateAdapter.DeleteCommand = this.oleDbDeleteCommand9;
            this.containerTemplateAdapter.InsertCommand = this.oleDbInsertCommand9;
            this.containerTemplateAdapter.SelectCommand = this.oleDbSelectCommand9;
            this.containerTemplateAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContainerTemplate", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContainerTemplateID", "ContainerTemplateID"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("ExcelFile", "ExcelFile")})});
            this.containerTemplateAdapter.UpdateCommand = this.oleDbUpdateCommand9;
            // 
            // oleDbDeleteCommand9
            // 
            this.oleDbDeleteCommand9.CommandText = "DELETE FROM tblContainerTemplate WHERE (ContainerTemplateID = ?) AND (Description" +
                " = ? OR ? IS NULL AND Description IS NULL) AND (ExcelFile = ? OR ? IS NULL AND E" +
                "xcelFile IS NULL)";
            this.oleDbDeleteCommand9.Connection = this.emConnection;
            this.oleDbDeleteCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContainerTemplateID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerTemplateID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Description", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Description1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand9
            // 
            this.oleDbInsertCommand9.CommandText = "INSERT INTO tblContainerTemplate(ContainerTemplateID, Description, ExcelFile) VAL" +
                "UES (?, ?, ?)";
            this.oleDbInsertCommand9.Connection = this.emConnection;
            this.oleDbInsertCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerTemplateID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerTemplateID"),
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 50, "Description"),
            new System.Data.OleDb.OleDbParameter("ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, "ExcelFile")});
            // 
            // oleDbSelectCommand9
            // 
            this.oleDbSelectCommand9.CommandText = "SELECT ContainerTemplateID, Description, ExcelFile FROM tblContainerTemplate";
            this.oleDbSelectCommand9.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand9
            // 
            this.oleDbUpdateCommand9.CommandText = resources.GetString("oleDbUpdateCommand9.CommandText");
            this.oleDbUpdateCommand9.Connection = this.emConnection;
            this.oleDbUpdateCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerTemplateID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerTemplateID"),
            new System.Data.OleDb.OleDbParameter("Description", System.Data.OleDb.OleDbType.VarWChar, 50, "Description"),
            new System.Data.OleDb.OleDbParameter("ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, "ExcelFile"),
            new System.Data.OleDb.OleDbParameter("Original_ContainerTemplateID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerTemplateID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Description", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Description1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null)});
            // 
            // billOfLadingAdapter
            // 
            this.billOfLadingAdapter.DeleteCommand = this.oleDbDeleteCommand10;
            this.billOfLadingAdapter.InsertCommand = this.oleDbInsertCommand10;
            this.billOfLadingAdapter.SelectCommand = this.oleDbSelectCommand10;
            this.billOfLadingAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblBOL", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("BOLID", "BOLID"),
                        new System.Data.Common.DataColumnMapping("BOLNumber", "BOLNumber"),
                        new System.Data.Common.DataColumnMapping("PickupDate", "PickupDate"),
                        new System.Data.Common.DataColumnMapping("Status", "Status")})});
            this.billOfLadingAdapter.UpdateCommand = this.oleDbUpdateCommand10;
            // 
            // oleDbDeleteCommand10
            // 
            this.oleDbDeleteCommand10.CommandText = "DELETE FROM tblBOL WHERE (BOLID = ?) AND (BOLNumber = ? OR ? IS NULL AND BOLNumbe" +
                "r IS NULL) AND (PickupDate = ? OR ? IS NULL AND PickupDate IS NULL) AND (Status " +
                "= ? OR ? IS NULL AND Status IS NULL)";
            this.oleDbDeleteCommand10.Connection = this.emConnection;
            this.oleDbDeleteCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_BOLID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BOLNumber", System.Data.OleDb.OleDbType.VarWChar, 200, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BOLNumber1", System.Data.OleDb.OleDbType.VarWChar, 200, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Status1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand10
            // 
            this.oleDbInsertCommand10.CommandText = "INSERT INTO tblBOL(BOLID, BOLNumber, PickupDate, Status) VALUES (?, ?, ?, ?)";
            this.oleDbInsertCommand10.Connection = this.emConnection;
            this.oleDbInsertCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID"),
            new System.Data.OleDb.OleDbParameter("BOLNumber", System.Data.OleDb.OleDbType.VarWChar, 200, "BOLNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.DBDate, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 50, "Status")});
            // 
            // oleDbSelectCommand10
            // 
            this.oleDbSelectCommand10.CommandText = "SELECT BOLID, BOLNumber, PickupDate, Status FROM tblBOL WHERE (BOLID = ?)";
            this.oleDbSelectCommand10.Connection = this.emConnection;
            this.oleDbSelectCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID")});
            // 
            // oleDbUpdateCommand10
            // 
            this.oleDbUpdateCommand10.CommandText = resources.GetString("oleDbUpdateCommand10.CommandText");
            this.oleDbUpdateCommand10.Connection = this.emConnection;
            this.oleDbUpdateCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID"),
            new System.Data.OleDb.OleDbParameter("BOLNumber", System.Data.OleDb.OleDbType.VarWChar, 200, "BOLNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.DBDate, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 50, "Status"),
            new System.Data.OleDb.OleDbParameter("Original_BOLID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BOLNumber", System.Data.OleDb.OleDbType.VarWChar, 200, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BOLNumber1", System.Data.OleDb.OleDbType.VarWChar, 200, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Status1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null)});
            // 
            // billOfLadingItemAdapter
            // 
            this.billOfLadingItemAdapter.DeleteCommand = this.oleDbDeleteCommand11;
            this.billOfLadingItemAdapter.InsertCommand = this.oleDbInsertCommand11;
            this.billOfLadingItemAdapter.SelectCommand = this.oleDbSelectCommand11;
            this.billOfLadingItemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblBOLItem", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("BOLID", "BOLID"),
                        new System.Data.Common.DataColumnMapping("ContainerBundleID", "ContainerBundleID")})});
            this.billOfLadingItemAdapter.UpdateCommand = this.oleDbUpdateCommand11;
            // 
            // oleDbDeleteCommand11
            // 
            this.oleDbDeleteCommand11.CommandText = "DELETE FROM tblBOLItem WHERE (BOLID = ?) AND (ContainerBundleID = ?)";
            this.oleDbDeleteCommand11.Connection = this.emConnection;
            this.oleDbDeleteCommand11.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_BOLID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand11
            // 
            this.oleDbInsertCommand11.CommandText = "INSERT INTO tblBOLItem(BOLID, ContainerBundleID) VALUES (?, ?)";
            this.oleDbInsertCommand11.Connection = this.emConnection;
            this.oleDbInsertCommand11.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID"),
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID")});
            // 
            // oleDbSelectCommand11
            // 
            this.oleDbSelectCommand11.CommandText = "SELECT BOLID, ContainerBundleID FROM tblBOLItem WHERE (BOLID = ?)";
            this.oleDbSelectCommand11.Connection = this.emConnection;
            this.oleDbSelectCommand11.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID")});
            // 
            // oleDbUpdateCommand11
            // 
            this.oleDbUpdateCommand11.CommandText = "UPDATE tblBOLItem SET BOLID = ?, ContainerBundleID = ? WHERE (BOLID = ?) AND (Con" +
                "tainerBundleID = ?)";
            this.oleDbUpdateCommand11.Connection = this.emConnection;
            this.oleDbUpdateCommand11.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID"),
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID"),
            new System.Data.OleDb.OleDbParameter("Original_BOLID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null)});
            // 
            // contBundleFromBundleIDAdapter
            // 
            this.contBundleFromBundleIDAdapter.DeleteCommand = this.oleDbDeleteCommand12;
            this.contBundleFromBundleIDAdapter.InsertCommand = this.oleDbInsertCommand12;
            this.contBundleFromBundleIDAdapter.SelectCommand = this.oleDbSelectCommand12;
            this.contBundleFromBundleIDAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContBundle", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContainerBundleID", "ContainerBundleID"),
                        new System.Data.Common.DataColumnMapping("ContID", "ContID"),
                        new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
                        new System.Data.Common.DataColumnMapping("BundleSeqNumber", "BundleSeqNumber"),
                        new System.Data.Common.DataColumnMapping("EnglishShipQty", "EnglishShipQty"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("Heat", "Heat"),
                        new System.Data.Common.DataColumnMapping("MetricShipQty", "MetricShipQty"),
                        new System.Data.Common.DataColumnMapping("BayNumber", "BayNumber"),
                        new System.Data.Common.DataColumnMapping("PickupDate", "PickupDate"),
                        new System.Data.Common.DataColumnMapping("PickupTerminal", "PickupTerminal"),
                        new System.Data.Common.DataColumnMapping("ProofOfDelivery", "ProofOfDelivery"),
                        new System.Data.Common.DataColumnMapping("EMInvoiceNumber", "EMInvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("AuxKey1", "AuxKey1"),
                        new System.Data.Common.DataColumnMapping("AuxKey2", "AuxKey2"),
                        new System.Data.Common.DataColumnMapping("MillInvoiceDate", "MillInvoiceDate"),
                        new System.Data.Common.DataColumnMapping("BundleAlloySurcharge", "BundleAlloySurcharge"),
                        new System.Data.Common.DataColumnMapping("BundleScrapSurcharge", "BundleScrapSurcharge")})});
            this.contBundleFromBundleIDAdapter.UpdateCommand = this.oleDbUpdateCommand12;
            // 
            // oleDbDeleteCommand12
            // 
            this.oleDbDeleteCommand12.CommandText = resources.GetString("oleDbDeleteCommand12.CommandText");
            this.oleDbDeleteCommand12.Connection = this.emConnection;
            this.oleDbDeleteCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EnglishShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Heat", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Heat", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MetricShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BayNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMInvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillInvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand12
            // 
            this.oleDbInsertCommand12.CommandText = resources.GetString("oleDbInsertCommand12.CommandText");
            this.oleDbInsertCommand12.Connection = this.emConnection;
            this.oleDbInsertCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID"),
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "BundleSeqNumber"),
            new System.Data.OleDb.OleDbParameter("EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, "EnglishShipQty"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("Heat", System.Data.OleDb.OleDbType.VarWChar, 0, "Heat"),
            new System.Data.OleDb.OleDbParameter("MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricShipQty"),
            new System.Data.OleDb.OleDbParameter("BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "BayNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.Date, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "PickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "EMInvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey1"),
            new System.Data.OleDb.OleDbParameter("AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey2"),
            new System.Data.OleDb.OleDbParameter("MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "MillInvoiceDate"),
            new System.Data.OleDb.OleDbParameter("BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleAlloySurcharge"),
            new System.Data.OleDb.OleDbParameter("BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleScrapSurcharge")});
            // 
            // oleDbSelectCommand12
            // 
            this.oleDbSelectCommand12.CommandText = resources.GetString("oleDbSelectCommand12.CommandText");
            this.oleDbSelectCommand12.Connection = this.emConnection;
            this.oleDbSelectCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID")});
            // 
            // oleDbUpdateCommand12
            // 
            this.oleDbUpdateCommand12.CommandText = resources.GetString("oleDbUpdateCommand12.CommandText");
            this.oleDbUpdateCommand12.Connection = this.emConnection;
            this.oleDbUpdateCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID"),
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "BundleSeqNumber"),
            new System.Data.OleDb.OleDbParameter("EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, "EnglishShipQty"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("Heat", System.Data.OleDb.OleDbType.VarWChar, 0, "Heat"),
            new System.Data.OleDb.OleDbParameter("MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, "MetricShipQty"),
            new System.Data.OleDb.OleDbParameter("BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "BayNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.Date, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "PickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "EMInvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey1"),
            new System.Data.OleDb.OleDbParameter("AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, "AuxKey2"),
            new System.Data.OleDb.OleDbParameter("MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "MillInvoiceDate"),
            new System.Data.OleDb.OleDbParameter("BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleAlloySurcharge"),
            new System.Data.OleDb.OleDbParameter("BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, "BundleScrapSurcharge"),
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleSeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleSeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EnglishShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EnglishShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EnglishShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Heat", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Heat", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Heat", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MetricShipQty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MetricShipQty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MetricShipQty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BayNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BayNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BayNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMInvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMInvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMInvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey1", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AuxKey2", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AuxKey2", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillInvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillInvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillInvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleAlloySurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleAlloySurcharge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_BundleScrapSurcharge", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BundleScrapSurcharge", System.Data.DataRowVersion.Original, null)});
            // 
            // billOfLadingItemFromContBundleIDAdapter
            // 
            this.billOfLadingItemFromContBundleIDAdapter.DeleteCommand = this.oleDbDeleteCommand13;
            this.billOfLadingItemFromContBundleIDAdapter.InsertCommand = this.oleDbInsertCommand13;
            this.billOfLadingItemFromContBundleIDAdapter.SelectCommand = this.oleDbSelectCommand13;
            this.billOfLadingItemFromContBundleIDAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblBOLItem", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("BOLID", "BOLID"),
                        new System.Data.Common.DataColumnMapping("ContainerBundleID", "ContainerBundleID")})});
            this.billOfLadingItemFromContBundleIDAdapter.UpdateCommand = this.oleDbUpdateCommand13;
            // 
            // oleDbDeleteCommand13
            // 
            this.oleDbDeleteCommand13.CommandText = "DELETE FROM tblBOLItem WHERE (BOLID = ?) AND (ContainerBundleID = ?)";
            this.oleDbDeleteCommand13.Connection = this.emConnection;
            this.oleDbDeleteCommand13.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_BOLID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand13
            // 
            this.oleDbInsertCommand13.CommandText = "INSERT INTO tblBOLItem(BOLID, ContainerBundleID) VALUES (?, ?)";
            this.oleDbInsertCommand13.Connection = this.emConnection;
            this.oleDbInsertCommand13.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID"),
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID")});
            // 
            // oleDbSelectCommand13
            // 
            this.oleDbSelectCommand13.CommandText = "SELECT BOLID, ContainerBundleID FROM tblBOLItem WHERE (ContainerBundleID = ?)";
            this.oleDbSelectCommand13.Connection = this.emConnection;
            this.oleDbSelectCommand13.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID")});
            // 
            // oleDbUpdateCommand13
            // 
            this.oleDbUpdateCommand13.CommandText = "UPDATE tblBOLItem SET BOLID = ?, ContainerBundleID = ? WHERE (BOLID = ?) AND (Con" +
                "tainerBundleID = ?)";
            this.oleDbUpdateCommand13.Connection = this.emConnection;
            this.oleDbUpdateCommand13.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID"),
            new System.Data.OleDb.OleDbParameter("ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, "ContainerBundleID"),
            new System.Data.OleDb.OleDbParameter("Original_BOLID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerBundleID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerBundleID", System.Data.DataRowVersion.Original, null)});
            // 
            // companyFromTypeAdapter
            // 
            this.companyFromTypeAdapter.DeleteCommand = this.oleDbDeleteCommand14;
            this.companyFromTypeAdapter.InsertCommand = this.oleDbInsertCommand14;
            this.companyFromTypeAdapter.SelectCommand = this.oleDbSelectCommand14;
            this.companyFromTypeAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblCompany", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CompName", "CompName"),
                        new System.Data.Common.DataColumnMapping("CompType", "CompType"),
                        new System.Data.Common.DataColumnMapping("ContainerExcelFile", "ContainerExcelFile"),
                        new System.Data.Common.DataColumnMapping("CompNameAbbreviation", "CompNameAbbreviation")})});
            this.companyFromTypeAdapter.UpdateCommand = this.oleDbUpdateCommand14;
            // 
            // oleDbDeleteCommand14
            // 
            this.oleDbDeleteCommand14.CommandText = resources.GetString("oleDbDeleteCommand14.CommandText");
            this.oleDbDeleteCommand14.Connection = this.emConnection;
            this.oleDbDeleteCommand14.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompType", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerExcelFile", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompNameAbbreviation", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand14
            // 
            this.oleDbInsertCommand14.CommandText = "INSERT INTO `tblCompany` (`CompID`, `CompName`, `CompType`, `ContainerExcelFile`," +
                " `CompNameAbbreviation`) VALUES (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand14.Connection = this.emConnection;
            this.oleDbInsertCommand14.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 0, "CompName"),
            new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 0, "CompType"),
            new System.Data.OleDb.OleDbParameter("ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerExcelFile"),
            new System.Data.OleDb.OleDbParameter("CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, "CompNameAbbreviation")});
            // 
            // oleDbSelectCommand14
            // 
            this.oleDbSelectCommand14.CommandText = "SELECT * FROM tblCompany WHERE (CompType = ?) ORDER BY CompName";
            this.oleDbSelectCommand14.Connection = this.emConnection;
            this.oleDbSelectCommand14.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.WChar, 15, "CompType")});
            // 
            // oleDbUpdateCommand14
            // 
            this.oleDbUpdateCommand14.CommandText = resources.GetString("oleDbUpdateCommand14.CommandText");
            this.oleDbUpdateCommand14.Connection = this.emConnection;
            this.oleDbUpdateCommand14.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 0, "CompName"),
            new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 0, "CompType"),
            new System.Data.OleDb.OleDbParameter("ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerExcelFile"),
            new System.Data.OleDb.OleDbParameter("CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, "CompNameAbbreviation"),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompType", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerExcelFile", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompNameAbbreviation", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, null)});
            // 
            // poHeaderFromPONumber
            // 
            this.poHeaderFromPONumber.DeleteCommand = this.oleDbDeleteCommand15;
            this.poHeaderFromPONumber.InsertCommand = this.oleDbInsertCommand15;
            this.poHeaderFromPONumber.SelectCommand = this.oleDbSelectCommand15;
            this.poHeaderFromPONumber.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblPOHeader2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("POID", "POID"),
                        new System.Data.Common.DataColumnMapping("PONumber", "PONumber"),
                        new System.Data.Common.DataColumnMapping("PODate", "PODate"),
                        new System.Data.Common.DataColumnMapping("VendCompany", "VendCompany"),
                        new System.Data.Common.DataColumnMapping("VendNameObsolete", "VendNameObsolete"),
                        new System.Data.Common.DataColumnMapping("VendPhone", "VendPhone"),
                        new System.Data.Common.DataColumnMapping("VendFax", "VendFax"),
                        new System.Data.Common.DataColumnMapping("VendContact", "VendContact"),
                        new System.Data.Common.DataColumnMapping("VendEMail", "VendEMail"),
                        new System.Data.Common.DataColumnMapping("VendAddressObsolete", "VendAddressObsolete"),
                        new System.Data.Common.DataColumnMapping("VendCountryObsolete", "VendCountryObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToCompanyObsolete", "ShipToCompanyObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToNameObsolete", "ShipToNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToPhone", "ShipToPhone"),
                        new System.Data.Common.DataColumnMapping("ShipToFax", "ShipToFax"),
                        new System.Data.Common.DataColumnMapping("ShipToContact", "ShipToContact"),
                        new System.Data.Common.DataColumnMapping("ShipToEMail", "ShipToEMail"),
                        new System.Data.Common.DataColumnMapping("ShipToAddressObsolete", "ShipToAddressObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToCountryObsolete", "ShipToCountryObsolete"),
                        new System.Data.Common.DataColumnMapping("Terms", "Terms"),
                        new System.Data.Common.DataColumnMapping("ShipCode", "ShipCode"),
                        new System.Data.Common.DataColumnMapping("FOB", "FOB"),
                        new System.Data.Common.DataColumnMapping("Status", "Status"),
                        new System.Data.Common.DataColumnMapping("USTotal", "USTotal"),
                        new System.Data.Common.DataColumnMapping("OtherTotal", "OtherTotal"),
                        new System.Data.Common.DataColumnMapping("ExchangeRate", "ExchangeRate"),
                        new System.Data.Common.DataColumnMapping("CancelDate", "CancelDate"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("VendLocationNameObsolete", "VendLocationNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToLocationNameObsolete", "ShipToLocationNameObsolete"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationNumber", "MillConfirmationNumber"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDate", "MillAcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("ExchangeDate", "ExchangeDate"),
                        new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("CustomerLocationID", "CustomerLocationID"),
                        new System.Data.Common.DataColumnMapping("MillID", "MillID"),
                        new System.Data.Common.DataColumnMapping("MillLocationID", "MillLocationID"),
                        new System.Data.Common.DataColumnMapping("SurchargesInEffect", "SurchargesInEffect"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("InvoiceDate", "InvoiceDate"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDateRevised", "MillAcknowledgeDateRevised"),
                        new System.Data.Common.DataColumnMapping("VendContactID", "VendContactID"),
                        new System.Data.Common.DataColumnMapping("ShipToContactID", "ShipToContactID"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationAppliesToEntirePO", "MillConfirmationAppliesToEntirePO")})});
            this.poHeaderFromPONumber.UpdateCommand = this.oleDbUpdateCommand15;
            // 
            // oleDbDeleteCommand15
            // 
            this.oleDbDeleteCommand15.CommandText = resources.GetString("oleDbDeleteCommand15.CommandText");
            this.oleDbDeleteCommand15.Connection = this.emConnection;
            this.oleDbDeleteCommand15.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PONumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PODate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PODate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCompany", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Terms", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FOB", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FOB", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_USTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_USTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_OtherTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargesInEffect", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand15
            // 
            this.oleDbInsertCommand15.CommandText = resources.GetString("oleDbInsertCommand15.CommandText");
            this.oleDbInsertCommand15.Connection = this.emConnection;
            this.oleDbInsertCommand15.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, "PONumber"),
            new System.Data.OleDb.OleDbParameter("PODate", System.Data.OleDb.OleDbType.Date, 0, "PODate"),
            new System.Data.OleDb.OleDbParameter("VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCompany"),
            new System.Data.OleDb.OleDbParameter("VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendNameObsolete"),
            new System.Data.OleDb.OleDbParameter("VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "VendPhone"),
            new System.Data.OleDb.OleDbParameter("VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, "VendFax"),
            new System.Data.OleDb.OleDbParameter("VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, "VendContact"),
            new System.Data.OleDb.OleDbParameter("VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "VendEMail"),
            new System.Data.OleDb.OleDbParameter("VendAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "VendAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCompanyObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToPhone"),
            new System.Data.OleDb.OleDbParameter("ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToFax"),
            new System.Data.OleDb.OleDbParameter("ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToContact"),
            new System.Data.OleDb.OleDbParameter("ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToEMail"),
            new System.Data.OleDb.OleDbParameter("ShipToAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ShipToAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("Terms", System.Data.OleDb.OleDbType.VarWChar, 0, "Terms"),
            new System.Data.OleDb.OleDbParameter("ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipCode"),
            new System.Data.OleDb.OleDbParameter("FOB", System.Data.OleDb.OleDbType.VarWChar, 0, "FOB"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("USTotal", System.Data.OleDb.OleDbType.Currency, 0, "USTotal"),
            new System.Data.OleDb.OleDbParameter("OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, "OtherTotal"),
            new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, "ExchangeRate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, "ExchangeDate"),
            new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, "CurrencyID"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("MillID", System.Data.OleDb.OleDbType.Integer, 0, "MillID"),
            new System.Data.OleDb.OleDbParameter("MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, "MillLocationID"),
            new System.Data.OleDb.OleDbParameter("SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, "SurchargesInEffect"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDateRevised"),
            new System.Data.OleDb.OleDbParameter("VendContactID", System.Data.OleDb.OleDbType.Integer, 0, "VendContactID"),
            new System.Data.OleDb.OleDbParameter("ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, "ShipToContactID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, "MillConfirmationAppliesToEntirePO")});
            // 
            // oleDbSelectCommand15
            // 
            this.oleDbSelectCommand15.CommandText = resources.GetString("oleDbSelectCommand15.CommandText");
            this.oleDbSelectCommand15.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand15
            // 
            this.oleDbUpdateCommand15.CommandText = resources.GetString("oleDbUpdateCommand15.CommandText");
            this.oleDbUpdateCommand15.Connection = this.emConnection;
            this.oleDbUpdateCommand15.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, "PONumber"),
            new System.Data.OleDb.OleDbParameter("PODate", System.Data.OleDb.OleDbType.Date, 0, "PODate"),
            new System.Data.OleDb.OleDbParameter("VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCompany"),
            new System.Data.OleDb.OleDbParameter("VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendNameObsolete"),
            new System.Data.OleDb.OleDbParameter("VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "VendPhone"),
            new System.Data.OleDb.OleDbParameter("VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, "VendFax"),
            new System.Data.OleDb.OleDbParameter("VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, "VendContact"),
            new System.Data.OleDb.OleDbParameter("VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "VendEMail"),
            new System.Data.OleDb.OleDbParameter("VendAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "VendAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCompanyObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToPhone"),
            new System.Data.OleDb.OleDbParameter("ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToFax"),
            new System.Data.OleDb.OleDbParameter("ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToContact"),
            new System.Data.OleDb.OleDbParameter("ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToEMail"),
            new System.Data.OleDb.OleDbParameter("ShipToAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ShipToAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("Terms", System.Data.OleDb.OleDbType.VarWChar, 0, "Terms"),
            new System.Data.OleDb.OleDbParameter("ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipCode"),
            new System.Data.OleDb.OleDbParameter("FOB", System.Data.OleDb.OleDbType.VarWChar, 0, "FOB"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("USTotal", System.Data.OleDb.OleDbType.Currency, 0, "USTotal"),
            new System.Data.OleDb.OleDbParameter("OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, "OtherTotal"),
            new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, "ExchangeRate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, "ExchangeDate"),
            new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, "CurrencyID"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("MillID", System.Data.OleDb.OleDbType.Integer, 0, "MillID"),
            new System.Data.OleDb.OleDbParameter("MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, "MillLocationID"),
            new System.Data.OleDb.OleDbParameter("SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, "SurchargesInEffect"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDateRevised"),
            new System.Data.OleDb.OleDbParameter("VendContactID", System.Data.OleDb.OleDbType.Integer, 0, "VendContactID"),
            new System.Data.OleDb.OleDbParameter("ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, "ShipToContactID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, "MillConfirmationAppliesToEntirePO"),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PONumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PODate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PODate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCompany", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Terms", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FOB", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FOB", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_USTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_USTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_OtherTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargesInEffect", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, null)});
            // 
            // contactsAdapter
            // 
            this.contactsAdapter.DeleteCommand = this.oleDbDeleteCommand16;
            this.contactsAdapter.InsertCommand = this.oleDbInsertCommand16;
            this.contactsAdapter.SelectCommand = this.oleDbSelectCommand16;
            this.contactsAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContacts", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("EMail", "EMail"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                        new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
                        new System.Data.Common.DataColumnMapping("LastName", "LastName"),
                        new System.Data.Common.DataColumnMapping("Phone", "Phone")})});
            this.contactsAdapter.UpdateCommand = this.oleDbUpdateCommand16;
            // 
            // oleDbDeleteCommand16
            // 
            this.oleDbDeleteCommand16.CommandText = resources.GetString("oleDbDeleteCommand16.CommandText");
            this.oleDbDeleteCommand16.Connection = this.emConnection;
            this.oleDbDeleteCommand16.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Fax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Fax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FirstName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LastName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Phone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Phone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Phone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Phone", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand16
            // 
            this.oleDbInsertCommand16.CommandText = "INSERT INTO `tblContacts` (`CompID`, `ContactID`, `EMail`, `Fax`, `FirstName`, `L" +
                "astName`, `Phone`) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand16.Connection = this.emConnection;
            this.oleDbInsertCommand16.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"),
            new System.Data.OleDb.OleDbParameter("EMail", System.Data.OleDb.OleDbType.VarWChar, 0, "EMail"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 0, "Fax"),
            new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarWChar, 0, "FirstName"),
            new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarWChar, 0, "LastName"),
            new System.Data.OleDb.OleDbParameter("Phone", System.Data.OleDb.OleDbType.VarWChar, 0, "Phone")});
            // 
            // oleDbSelectCommand16
            // 
            this.oleDbSelectCommand16.CommandText = "SELECT CompID, ContactID, EMail, Fax, FirstName, LastName, Phone FROM tblContacts" +
                " where compid = ?";
            this.oleDbSelectCommand16.Connection = this.emConnection;
            this.oleDbSelectCommand16.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID")});
            // 
            // oleDbUpdateCommand16
            // 
            this.oleDbUpdateCommand16.CommandText = resources.GetString("oleDbUpdateCommand16.CommandText");
            this.oleDbUpdateCommand16.Connection = this.emConnection;
            this.oleDbUpdateCommand16.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"),
            new System.Data.OleDb.OleDbParameter("EMail", System.Data.OleDb.OleDbType.VarWChar, 0, "EMail"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 0, "Fax"),
            new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarWChar, 0, "FirstName"),
            new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarWChar, 0, "LastName"),
            new System.Data.OleDb.OleDbParameter("Phone", System.Data.OleDb.OleDbType.VarWChar, 0, "Phone"),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Fax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Fax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FirstName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LastName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Phone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Phone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Phone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Phone", System.Data.DataRowVersion.Original, null)});
            // 
            // countryAdapter
            // 
            this.countryAdapter.DeleteCommand = this.oleDbDeleteCommand17;
            this.countryAdapter.InsertCommand = this.oleDbInsertCommand17;
            this.countryAdapter.SelectCommand = this.oleDbSelectCommand17;
            this.countryAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblCountry", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CountryID", "CountryID"),
                        new System.Data.Common.DataColumnMapping("CountryName", "CountryName")})});
            this.countryAdapter.UpdateCommand = this.oleDbUpdateCommand17;
            // 
            // oleDbDeleteCommand17
            // 
            this.oleDbDeleteCommand17.CommandText = "DELETE FROM tblCountry WHERE (CountryID = ?) AND (CountryName = ?)";
            this.oleDbDeleteCommand17.Connection = this.emConnection;
            this.oleDbDeleteCommand17.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryName", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand17
            // 
            this.oleDbInsertCommand17.CommandText = "INSERT INTO tblCountry(CountryID, CountryName) VALUES (?, ?)";
            this.oleDbInsertCommand17.Connection = this.emConnection;
            this.oleDbInsertCommand17.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"),
            new System.Data.OleDb.OleDbParameter("CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, "CountryName")});
            // 
            // oleDbSelectCommand17
            // 
            this.oleDbSelectCommand17.CommandText = "SELECT CountryID, CountryName FROM tblCountry";
            this.oleDbSelectCommand17.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand17
            // 
            this.oleDbUpdateCommand17.CommandText = "UPDATE tblCountry SET CountryID = ?, CountryName = ? WHERE (CountryID = ?) AND (C" +
                "ountryName = ?)";
            this.oleDbUpdateCommand17.Connection = this.emConnection;
            this.oleDbUpdateCommand17.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"),
            new System.Data.OleDb.OleDbParameter("CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, "CountryName"),
            new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CountryName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryName", System.Data.DataRowVersion.Original, null)});
            // 
            // temsAdapter
            // 
            this.temsAdapter.DeleteCommand = this.oleDbDeleteCommand18;
            this.temsAdapter.InsertCommand = this.oleDbInsertCommand18;
            this.temsAdapter.SelectCommand = this.oleDbSelectCommand18;
            this.temsAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblPaymentTerms", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Terms", "Terms"),
                        new System.Data.Common.DataColumnMapping("TermsDesc", "TermsDesc"),
                        new System.Data.Common.DataColumnMapping("TermsID", "TermsID")})});
            this.temsAdapter.UpdateCommand = this.oleDbUpdateCommand18;
            // 
            // oleDbDeleteCommand18
            // 
            this.oleDbDeleteCommand18.CommandText = "DELETE FROM tblPaymentTerms WHERE (TermsID = ?) AND (Terms = ? OR ? IS NULL AND T" +
                "erms IS NULL) AND (TermsDesc = ? OR ? IS NULL AND TermsDesc IS NULL)";
            this.oleDbDeleteCommand18.Connection = this.emConnection;
            this.oleDbDeleteCommand18.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_TermsID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TermsID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TermsDesc", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TermsDesc", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TermsDesc1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TermsDesc", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand18
            // 
            this.oleDbInsertCommand18.CommandText = "INSERT INTO tblPaymentTerms(Terms, TermsDesc, TermsID) VALUES (?, ?, ?)";
            this.oleDbInsertCommand18.Connection = this.emConnection;
            this.oleDbInsertCommand18.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Terms", System.Data.OleDb.OleDbType.VarWChar, 20, "Terms"),
            new System.Data.OleDb.OleDbParameter("TermsDesc", System.Data.OleDb.OleDbType.VarWChar, 30, "TermsDesc"),
            new System.Data.OleDb.OleDbParameter("TermsID", System.Data.OleDb.OleDbType.Integer, 0, "TermsID")});
            // 
            // oleDbSelectCommand18
            // 
            this.oleDbSelectCommand18.CommandText = "SELECT Terms, TermsDesc, TermsID FROM tblPaymentTerms";
            this.oleDbSelectCommand18.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand18
            // 
            this.oleDbUpdateCommand18.CommandText = "UPDATE tblPaymentTerms SET Terms = ?, TermsDesc = ?, TermsID = ? WHERE (TermsID =" +
                " ?) AND (Terms = ? OR ? IS NULL AND Terms IS NULL) AND (TermsDesc = ? OR ? IS NU" +
                "LL AND TermsDesc IS NULL)";
            this.oleDbUpdateCommand18.Connection = this.emConnection;
            this.oleDbUpdateCommand18.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Terms", System.Data.OleDb.OleDbType.VarWChar, 20, "Terms"),
            new System.Data.OleDb.OleDbParameter("TermsDesc", System.Data.OleDb.OleDbType.VarWChar, 30, "TermsDesc"),
            new System.Data.OleDb.OleDbParameter("TermsID", System.Data.OleDb.OleDbType.Integer, 0, "TermsID"),
            new System.Data.OleDb.OleDbParameter("Original_TermsID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TermsID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TermsDesc", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TermsDesc", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TermsDesc1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TermsDesc", System.Data.DataRowVersion.Original, null)});
            // 
            // shipCodeAdapter
            // 
            this.shipCodeAdapter.DeleteCommand = this.oleDbDeleteCommand19;
            this.shipCodeAdapter.InsertCommand = this.oleDbInsertCommand19;
            this.shipCodeAdapter.SelectCommand = this.oleDbSelectCommand19;
            this.shipCodeAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblShippingCode", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ShipCode", "ShipCode"),
                        new System.Data.Common.DataColumnMapping("ShipCodeID", "ShipCodeID"),
                        new System.Data.Common.DataColumnMapping("ShipDesc", "ShipDesc")})});
            this.shipCodeAdapter.UpdateCommand = this.oleDbUpdateCommand19;
            // 
            // oleDbDeleteCommand19
            // 
            this.oleDbDeleteCommand19.CommandText = "DELETE FROM tblShippingCode WHERE (ShipCodeID = ?) AND (ShipCode = ? OR ? IS NULL" +
                " AND ShipCode IS NULL) AND (ShipDesc = ? OR ? IS NULL AND ShipDesc IS NULL)";
            this.oleDbDeleteCommand19.Connection = this.emConnection;
            this.oleDbDeleteCommand19.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ShipCodeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCodeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDesc", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDesc", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDesc1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDesc", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand19
            // 
            this.oleDbInsertCommand19.CommandText = "INSERT INTO tblShippingCode(ShipCode, ShipCodeID, ShipDesc) VALUES (?, ?, ?)";
            this.oleDbInsertCommand19.Connection = this.emConnection;
            this.oleDbInsertCommand19.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ShipCode", System.Data.OleDb.OleDbType.VarWChar, 10, "ShipCode"),
            new System.Data.OleDb.OleDbParameter("ShipCodeID", System.Data.OleDb.OleDbType.Integer, 0, "ShipCodeID"),
            new System.Data.OleDb.OleDbParameter("ShipDesc", System.Data.OleDb.OleDbType.VarWChar, 30, "ShipDesc")});
            // 
            // oleDbSelectCommand19
            // 
            this.oleDbSelectCommand19.CommandText = "SELECT ShipCode, ShipCodeID, ShipDesc FROM tblShippingCode";
            this.oleDbSelectCommand19.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand19
            // 
            this.oleDbUpdateCommand19.CommandText = "UPDATE tblShippingCode SET ShipCode = ?, ShipCodeID = ?, ShipDesc = ? WHERE (Ship" +
                "CodeID = ?) AND (ShipCode = ? OR ? IS NULL AND ShipCode IS NULL) AND (ShipDesc =" +
                " ? OR ? IS NULL AND ShipDesc IS NULL)";
            this.oleDbUpdateCommand19.Connection = this.emConnection;
            this.oleDbUpdateCommand19.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ShipCode", System.Data.OleDb.OleDbType.VarWChar, 10, "ShipCode"),
            new System.Data.OleDb.OleDbParameter("ShipCodeID", System.Data.OleDb.OleDbType.Integer, 0, "ShipCodeID"),
            new System.Data.OleDb.OleDbParameter("ShipDesc", System.Data.OleDb.OleDbType.VarWChar, 30, "ShipDesc"),
            new System.Data.OleDb.OleDbParameter("Original_ShipCodeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCodeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDesc", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDesc", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDesc1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDesc", System.Data.DataRowVersion.Original, null)});
            // 
            // finishAdapter
            // 
            this.finishAdapter.DeleteCommand = this.oleDbDeleteCommand20;
            this.finishAdapter.InsertCommand = this.oleDbInsertCommand20;
            this.finishAdapter.SelectCommand = this.oleDbSelectCommand20;
            this.finishAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "TblFinish", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("FinishID", "FinishID"),
                        new System.Data.Common.DataColumnMapping("FinishType", "FinishType"),
                        new System.Data.Common.DataColumnMapping("CommissionRate", "CommissionRate")})});
            this.finishAdapter.UpdateCommand = this.oleDbUpdateCommand20;
            // 
            // oleDbDeleteCommand20
            // 
            this.oleDbDeleteCommand20.CommandText = "DELETE FROM `TblFinish` WHERE ((`FinishID` = ?) AND ((? = 1 AND `FinishType` IS N" +
                "ULL) OR (`FinishType` = ?)) AND ((? = 1 AND `CommissionRate` IS NULL) OR (`Commi" +
                "ssionRate` = ?)))";
            this.oleDbDeleteCommand20.Connection = this.emConnection;
            this.oleDbDeleteCommand20.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishType", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishType", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishType", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommissionRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommissionRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommissionRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommissionRate", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand20
            // 
            this.oleDbInsertCommand20.CommandText = "INSERT INTO `TblFinish` (`FinishID`, `FinishType`, `CommissionRate`) VALUES (?, ?" +
                ", ?)";
            this.oleDbInsertCommand20.Connection = this.emConnection;
            this.oleDbInsertCommand20.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("FinishType", System.Data.OleDb.OleDbType.VarWChar, 0, "FinishType"),
            new System.Data.OleDb.OleDbParameter("CommissionRate", System.Data.OleDb.OleDbType.Currency, 0, "CommissionRate")});
            // 
            // oleDbSelectCommand20
            // 
            this.oleDbSelectCommand20.CommandText = "SELECT FinishID, FinishType, CommissionRate FROM TblFinish";
            this.oleDbSelectCommand20.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand20
            // 
            this.oleDbUpdateCommand20.CommandText = resources.GetString("oleDbUpdateCommand20.CommandText");
            this.oleDbUpdateCommand20.Connection = this.emConnection;
            this.oleDbUpdateCommand20.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("FinishType", System.Data.OleDb.OleDbType.VarWChar, 0, "FinishType"),
            new System.Data.OleDb.OleDbParameter("CommissionRate", System.Data.OleDb.OleDbType.Currency, 0, "CommissionRate"),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishType", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishType", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishType", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommissionRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommissionRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommissionRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommissionRate", System.Data.DataRowVersion.Original, null)});
            // 
            // companyFromIDAdapter
            // 
            this.companyFromIDAdapter.DeleteCommand = this.oleDbDeleteCommand21;
            this.companyFromIDAdapter.InsertCommand = this.oleDbInsertCommand21;
            this.companyFromIDAdapter.SelectCommand = this.oleDbSelectCommand21;
            this.companyFromIDAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblCompany", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CompName", "CompName"),
                        new System.Data.Common.DataColumnMapping("CompType", "CompType"),
                        new System.Data.Common.DataColumnMapping("ContainerExcelFile", "ContainerExcelFile"),
                        new System.Data.Common.DataColumnMapping("CompNameAbbreviation", "CompNameAbbreviation")})});
            this.companyFromIDAdapter.UpdateCommand = this.oleDbUpdateCommand21;
            // 
            // oleDbDeleteCommand21
            // 
            this.oleDbDeleteCommand21.CommandText = resources.GetString("oleDbDeleteCommand21.CommandText");
            this.oleDbDeleteCommand21.Connection = this.emConnection;
            this.oleDbDeleteCommand21.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompType", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerExcelFile", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompNameAbbreviation", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand21
            // 
            this.oleDbInsertCommand21.CommandText = "INSERT INTO `tblCompany` (`CompID`, `CompName`, `CompType`, `ContainerExcelFile`," +
                " `CompNameAbbreviation`) VALUES (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand21.Connection = this.emConnection;
            this.oleDbInsertCommand21.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 0, "CompName"),
            new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 0, "CompType"),
            new System.Data.OleDb.OleDbParameter("ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerExcelFile"),
            new System.Data.OleDb.OleDbParameter("CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, "CompNameAbbreviation")});
            // 
            // oleDbSelectCommand21
            // 
            this.oleDbSelectCommand21.CommandText = "SELECT * FROM tblCompany WHERE (CompID = ?)";
            this.oleDbSelectCommand21.Connection = this.emConnection;
            this.oleDbSelectCommand21.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID")});
            // 
            // oleDbUpdateCommand21
            // 
            this.oleDbUpdateCommand21.CommandText = resources.GetString("oleDbUpdateCommand21.CommandText");
            this.oleDbUpdateCommand21.Connection = this.emConnection;
            this.oleDbUpdateCommand21.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CompName", System.Data.OleDb.OleDbType.VarWChar, 0, "CompName"),
            new System.Data.OleDb.OleDbParameter("CompType", System.Data.OleDb.OleDbType.VarWChar, 0, "CompType"),
            new System.Data.OleDb.OleDbParameter("ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerExcelFile"),
            new System.Data.OleDb.OleDbParameter("CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, "CompNameAbbreviation"),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompType", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompType", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerExcelFile", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerExcelFile", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompNameAbbreviation", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompNameAbbreviation", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompNameAbbreviation", System.Data.DataRowVersion.Original, null)});
            // 
            // currencyAdapter
            // 
            this.currencyAdapter.DeleteCommand = this.oleDbDeleteCommand22;
            this.currencyAdapter.InsertCommand = this.oleDbInsertCommand22;
            this.currencyAdapter.SelectCommand = this.oleDbSelectCommand22;
            this.currencyAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblCurrency", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
                        new System.Data.Common.DataColumnMapping("CurrencyName", "CurrencyName")})});
            this.currencyAdapter.UpdateCommand = this.oleDbUpdateCommand22;
            // 
            // oleDbDeleteCommand22
            // 
            this.oleDbDeleteCommand22.CommandText = "DELETE FROM tblCurrency WHERE (CurrencyID = ?) AND (CurrencyName = ? OR ? IS NULL" +
                " AND CurrencyName IS NULL)";
            this.oleDbDeleteCommand22.Connection = this.emConnection;
            this.oleDbDeleteCommand22.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyName", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand22
            // 
            this.oleDbInsertCommand22.CommandText = "INSERT INTO tblCurrency(CurrencyID, CurrencyName) VALUES (?, ?)";
            this.oleDbInsertCommand22.Connection = this.emConnection;
            this.oleDbInsertCommand22.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, "CurrencyID"),
            new System.Data.OleDb.OleDbParameter("CurrencyName", System.Data.OleDb.OleDbType.VarWChar, 50, "CurrencyName")});
            // 
            // oleDbSelectCommand22
            // 
            this.oleDbSelectCommand22.CommandText = "SELECT CurrencyID, CurrencyName FROM tblCurrency";
            this.oleDbSelectCommand22.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand22
            // 
            this.oleDbUpdateCommand22.CommandText = "UPDATE tblCurrency SET CurrencyID = ?, CurrencyName = ? WHERE (CurrencyID = ?) AN" +
                "D (CurrencyName = ? OR ? IS NULL AND CurrencyName IS NULL)";
            this.oleDbUpdateCommand22.Connection = this.emConnection;
            this.oleDbUpdateCommand22.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, "CurrencyID"),
            new System.Data.OleDb.OleDbParameter("CurrencyName", System.Data.OleDb.OleDbType.VarWChar, 50, "CurrencyName"),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyName1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyName", System.Data.DataRowVersion.Original, null)});
            // 
            // itemAdapter
            // 
            this.itemAdapter.DeleteCommand = this.oleDbDeleteCommand23;
            this.itemAdapter.InsertCommand = this.oleDbInsertCommand23;
            this.itemAdapter.SelectCommand = this.oleDbSelectCommand23;
            this.itemAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblItem", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CommRate", "CommRate"),
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
                        new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("ItemName", "ItemName")})});
            this.itemAdapter.UpdateCommand = this.oleDbUpdateCommand23;
            // 
            // oleDbDeleteCommand23
            // 
            this.oleDbDeleteCommand23.CommandText = resources.GetString("oleDbDeleteCommand23.CommandText");
            this.oleDbDeleteCommand23.Connection = this.emConnection;
            this.oleDbDeleteCommand23.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand23
            // 
            this.oleDbInsertCommand23.CommandText = "INSERT INTO `tblItem` (`CommRate`, `CompID`, `CustRate`, `ItemDesc`, `ItemID`, `I" +
                "temName`) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand23.Connection = this.emConnection;
            this.oleDbInsertCommand23.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemName")});
            // 
            // oleDbSelectCommand23
            // 
            this.oleDbSelectCommand23.CommandText = "SELECT CommRate, CompID, CustRate, ItemDesc, ItemID, ItemName\r\nFROM   tblItem\r\nOR" +
                "DER BY CompID, ItemName";
            this.oleDbSelectCommand23.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand23
            // 
            this.oleDbUpdateCommand23.CommandText = resources.GetString("oleDbUpdateCommand23.CommandText");
            this.oleDbUpdateCommand23.Connection = this.emConnection;
            this.oleDbUpdateCommand23.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemName"),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null)});
            // 
            // itemFromItemIDAdapter
            // 
            this.itemFromItemIDAdapter.DeleteCommand = this.oleDbDeleteCommand24;
            this.itemFromItemIDAdapter.InsertCommand = this.oleDbInsertCommand24;
            this.itemFromItemIDAdapter.SelectCommand = this.oleDbSelectCommand24;
            this.itemFromItemIDAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblItem", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CommRate", "CommRate"),
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
                        new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("ItemName", "ItemName")})});
            this.itemFromItemIDAdapter.UpdateCommand = this.oleDbUpdateCommand24;
            // 
            // oleDbDeleteCommand24
            // 
            this.oleDbDeleteCommand24.CommandText = resources.GetString("oleDbDeleteCommand24.CommandText");
            this.oleDbDeleteCommand24.Connection = this.emConnection;
            this.oleDbDeleteCommand24.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand24
            // 
            this.oleDbInsertCommand24.CommandText = "INSERT INTO `tblItem` (`CommRate`, `CompID`, `CustRate`, `ItemDesc`, `ItemID`, `I" +
                "temName`) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand24.Connection = this.emConnection;
            this.oleDbInsertCommand24.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemName")});
            // 
            // oleDbSelectCommand24
            // 
            this.oleDbSelectCommand24.CommandText = "SELECT CommRate, CompID, CustRate, ItemDesc, ItemID, ItemName\r\nFROM   tblItem\r\nWH" +
                "ERE (ItemID = ?)";
            this.oleDbSelectCommand24.Connection = this.emConnection;
            this.oleDbSelectCommand24.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID")});
            // 
            // oleDbUpdateCommand24
            // 
            this.oleDbUpdateCommand24.CommandText = resources.GetString("oleDbUpdateCommand24.CommandText");
            this.oleDbUpdateCommand24.Connection = this.emConnection;
            this.oleDbUpdateCommand24.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemName"),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null)});
            // 
            // poHeaderAllAdapter
            // 
            this.poHeaderAllAdapter.DeleteCommand = this.oleDbDeleteCommand25;
            this.poHeaderAllAdapter.InsertCommand = this.oleDbInsertCommand25;
            this.poHeaderAllAdapter.SelectCommand = this.oleDbSelectCommand25;
            this.poHeaderAllAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblPOHeader2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("POID", "POID"),
                        new System.Data.Common.DataColumnMapping("PONumber", "PONumber"),
                        new System.Data.Common.DataColumnMapping("PODate", "PODate"),
                        new System.Data.Common.DataColumnMapping("VendCompany", "VendCompany"),
                        new System.Data.Common.DataColumnMapping("VendNameObsolete", "VendNameObsolete"),
                        new System.Data.Common.DataColumnMapping("VendPhone", "VendPhone"),
                        new System.Data.Common.DataColumnMapping("VendFax", "VendFax"),
                        new System.Data.Common.DataColumnMapping("VendContact", "VendContact"),
                        new System.Data.Common.DataColumnMapping("VendEMail", "VendEMail"),
                        new System.Data.Common.DataColumnMapping("VendAddressObsolete", "VendAddressObsolete"),
                        new System.Data.Common.DataColumnMapping("VendCountryObsolete", "VendCountryObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToCompanyObsolete", "ShipToCompanyObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToNameObsolete", "ShipToNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToPhone", "ShipToPhone"),
                        new System.Data.Common.DataColumnMapping("ShipToFax", "ShipToFax"),
                        new System.Data.Common.DataColumnMapping("ShipToContact", "ShipToContact"),
                        new System.Data.Common.DataColumnMapping("ShipToEMail", "ShipToEMail"),
                        new System.Data.Common.DataColumnMapping("ShipToAddressObsolete", "ShipToAddressObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToCountryObsolete", "ShipToCountryObsolete"),
                        new System.Data.Common.DataColumnMapping("Terms", "Terms"),
                        new System.Data.Common.DataColumnMapping("ShipCode", "ShipCode"),
                        new System.Data.Common.DataColumnMapping("FOB", "FOB"),
                        new System.Data.Common.DataColumnMapping("Status", "Status"),
                        new System.Data.Common.DataColumnMapping("USTotal", "USTotal"),
                        new System.Data.Common.DataColumnMapping("OtherTotal", "OtherTotal"),
                        new System.Data.Common.DataColumnMapping("ExchangeRate", "ExchangeRate"),
                        new System.Data.Common.DataColumnMapping("CancelDate", "CancelDate"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("VendLocationNameObsolete", "VendLocationNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ShipToLocationNameObsolete", "ShipToLocationNameObsolete"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationNumber", "MillConfirmationNumber"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDate", "MillAcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("ExchangeDate", "ExchangeDate"),
                        new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("CustomerLocationID", "CustomerLocationID"),
                        new System.Data.Common.DataColumnMapping("MillID", "MillID"),
                        new System.Data.Common.DataColumnMapping("MillLocationID", "MillLocationID"),
                        new System.Data.Common.DataColumnMapping("SurchargesInEffect", "SurchargesInEffect"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("InvoiceDate", "InvoiceDate"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDateRevised", "MillAcknowledgeDateRevised"),
                        new System.Data.Common.DataColumnMapping("VendContactID", "VendContactID"),
                        new System.Data.Common.DataColumnMapping("ShipToContactID", "ShipToContactID"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationAppliesToEntirePO", "MillConfirmationAppliesToEntirePO")})});
            this.poHeaderAllAdapter.UpdateCommand = this.oleDbUpdateCommand25;
            // 
            // oleDbDeleteCommand25
            // 
            this.oleDbDeleteCommand25.CommandText = resources.GetString("oleDbDeleteCommand25.CommandText");
            this.oleDbDeleteCommand25.Connection = this.emConnection;
            this.oleDbDeleteCommand25.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PONumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PODate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PODate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCompany", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Terms", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FOB", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FOB", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_USTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_USTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_OtherTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargesInEffect", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand25
            // 
            this.oleDbInsertCommand25.CommandText = resources.GetString("oleDbInsertCommand25.CommandText");
            this.oleDbInsertCommand25.Connection = this.emConnection;
            this.oleDbInsertCommand25.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, "PONumber"),
            new System.Data.OleDb.OleDbParameter("PODate", System.Data.OleDb.OleDbType.Date, 0, "PODate"),
            new System.Data.OleDb.OleDbParameter("VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCompany"),
            new System.Data.OleDb.OleDbParameter("VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendNameObsolete"),
            new System.Data.OleDb.OleDbParameter("VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "VendPhone"),
            new System.Data.OleDb.OleDbParameter("VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, "VendFax"),
            new System.Data.OleDb.OleDbParameter("VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, "VendContact"),
            new System.Data.OleDb.OleDbParameter("VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "VendEMail"),
            new System.Data.OleDb.OleDbParameter("VendAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "VendAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCompanyObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToPhone"),
            new System.Data.OleDb.OleDbParameter("ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToFax"),
            new System.Data.OleDb.OleDbParameter("ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToContact"),
            new System.Data.OleDb.OleDbParameter("ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToEMail"),
            new System.Data.OleDb.OleDbParameter("ShipToAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ShipToAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("Terms", System.Data.OleDb.OleDbType.VarWChar, 0, "Terms"),
            new System.Data.OleDb.OleDbParameter("ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipCode"),
            new System.Data.OleDb.OleDbParameter("FOB", System.Data.OleDb.OleDbType.VarWChar, 0, "FOB"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("USTotal", System.Data.OleDb.OleDbType.Currency, 0, "USTotal"),
            new System.Data.OleDb.OleDbParameter("OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, "OtherTotal"),
            new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, "ExchangeRate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, "ExchangeDate"),
            new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, "CurrencyID"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("MillID", System.Data.OleDb.OleDbType.Integer, 0, "MillID"),
            new System.Data.OleDb.OleDbParameter("MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, "MillLocationID"),
            new System.Data.OleDb.OleDbParameter("SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, "SurchargesInEffect"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDateRevised"),
            new System.Data.OleDb.OleDbParameter("VendContactID", System.Data.OleDb.OleDbType.Integer, 0, "VendContactID"),
            new System.Data.OleDb.OleDbParameter("ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, "ShipToContactID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, "MillConfirmationAppliesToEntirePO")});
            // 
            // oleDbSelectCommand25
            // 
            this.oleDbSelectCommand25.CommandText = resources.GetString("oleDbSelectCommand25.CommandText");
            this.oleDbSelectCommand25.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand25
            // 
            this.oleDbUpdateCommand25.CommandText = resources.GetString("oleDbUpdateCommand25.CommandText");
            this.oleDbUpdateCommand25.Connection = this.emConnection;
            this.oleDbUpdateCommand25.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, "PONumber"),
            new System.Data.OleDb.OleDbParameter("PODate", System.Data.OleDb.OleDbType.Date, 0, "PODate"),
            new System.Data.OleDb.OleDbParameter("VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCompany"),
            new System.Data.OleDb.OleDbParameter("VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendNameObsolete"),
            new System.Data.OleDb.OleDbParameter("VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "VendPhone"),
            new System.Data.OleDb.OleDbParameter("VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, "VendFax"),
            new System.Data.OleDb.OleDbParameter("VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, "VendContact"),
            new System.Data.OleDb.OleDbParameter("VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "VendEMail"),
            new System.Data.OleDb.OleDbParameter("VendAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "VendAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCompanyObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToPhone"),
            new System.Data.OleDb.OleDbParameter("ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToFax"),
            new System.Data.OleDb.OleDbParameter("ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToContact"),
            new System.Data.OleDb.OleDbParameter("ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToEMail"),
            new System.Data.OleDb.OleDbParameter("ShipToAddressObsolete", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ShipToAddressObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToCountryObsolete"),
            new System.Data.OleDb.OleDbParameter("Terms", System.Data.OleDb.OleDbType.VarWChar, 0, "Terms"),
            new System.Data.OleDb.OleDbParameter("ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipCode"),
            new System.Data.OleDb.OleDbParameter("FOB", System.Data.OleDb.OleDbType.VarWChar, 0, "FOB"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("USTotal", System.Data.OleDb.OleDbType.Currency, 0, "USTotal"),
            new System.Data.OleDb.OleDbParameter("OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, "OtherTotal"),
            new System.Data.OleDb.OleDbParameter("ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, "ExchangeRate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "VendLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ShipToLocationNameObsolete"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, "ExchangeDate"),
            new System.Data.OleDb.OleDbParameter("CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, "CurrencyID"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("MillID", System.Data.OleDb.OleDbType.Integer, 0, "MillID"),
            new System.Data.OleDb.OleDbParameter("MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, "MillLocationID"),
            new System.Data.OleDb.OleDbParameter("SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, "SurchargesInEffect"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDateRevised"),
            new System.Data.OleDb.OleDbParameter("VendContactID", System.Data.OleDb.OleDbType.Integer, 0, "VendContactID"),
            new System.Data.OleDb.OleDbParameter("ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, "ShipToContactID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, "MillConfirmationAppliesToEntirePO"),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PONumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PONumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PONumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PODate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PODate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PODate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCompany", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCompany", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCompany", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCompanyObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCompanyObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToPhone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToPhone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToPhone", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToFax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToFax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToFax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContact", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContact", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContact", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToEMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToEMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToEMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToCountryObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToCountryObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToCountryObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Terms", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Terms", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Terms", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FOB", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FOB", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FOB", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_USTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_USTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "USTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_OtherTotal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_OtherTotal", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OtherTotal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToLocationNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToLocationNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ExchangeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ExchangeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExchangeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CurrencyID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CurrencyID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargesInEffect", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargesInEffect", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargesInEffect", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDateRevised", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDateRevised", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_VendContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "VendContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipToContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipToContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationAppliesToEntirePO", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationAppliesToEntirePO", System.Data.DataRowVersion.Original, null)});
            // 
            // poItemAllAdapter
            // 
            this.poItemAllAdapter.DeleteCommand = this.oleDbDeleteCommand26;
            this.poItemAllAdapter.InsertCommand = this.oleDbInsertCommand26;
            this.poItemAllAdapter.SelectCommand = this.oleDbSelectCommand26;
            this.poItemAllAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblPOItem2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("POItemNumber", "POItemNumber"),
                        new System.Data.Common.DataColumnMapping("POID", "POID"),
                        new System.Data.Common.DataColumnMapping("SeqNumber", "SeqNumber"),
                        new System.Data.Common.DataColumnMapping("ItemNameObsolete", "ItemNameObsolete"),
                        new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
                        new System.Data.Common.DataColumnMapping("Length", "Length"),
                        new System.Data.Common.DataColumnMapping("SizeOfItem", "SizeOfItem"),
                        new System.Data.Common.DataColumnMapping("ItemAccessCode", "ItemAccessCode"),
                        new System.Data.Common.DataColumnMapping("Qty", "Qty"),
                        new System.Data.Common.DataColumnMapping("UM", "UM"),
                        new System.Data.Common.DataColumnMapping("DateRequired", "DateRequired"),
                        new System.Data.Common.DataColumnMapping("AcknowledgeDate", "AcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("MillShipDate", "MillShipDate"),
                        new System.Data.Common.DataColumnMapping("CancelDate", "CancelDate"),
                        new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
                        new System.Data.Common.DataColumnMapping("CommRate", "CommRate"),
                        new System.Data.Common.DataColumnMapping("CustAmount", "CustAmount"),
                        new System.Data.Common.DataColumnMapping("CommAmount", "CommAmount"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("FinishID", "FinishID"),
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("TreatmentID", "TreatmentID"),
                        new System.Data.Common.DataColumnMapping("MillConfirmationNumber", "MillConfirmationNumber"),
                        new System.Data.Common.DataColumnMapping("MillAcknowledgeDate", "MillAcknowledgeDate"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("InvoiceDate", "InvoiceDate")})});
            this.poItemAllAdapter.UpdateCommand = this.oleDbUpdateCommand26;
            // 
            // oleDbDeleteCommand26
            // 
            this.oleDbDeleteCommand26.CommandText = resources.GetString("oleDbDeleteCommand26.CommandText");
            this.oleDbDeleteCommand26.Connection = this.emConnection;
            this.oleDbDeleteCommand26.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SizeOfItem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemAccessCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Qty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Qty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_UM", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_UM", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DateRequired", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DateRequired", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand26
            // 
            this.oleDbInsertCommand26.CommandText = resources.GetString("oleDbInsertCommand26.CommandText");
            this.oleDbInsertCommand26.Connection = this.emConnection;
            this.oleDbInsertCommand26.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "SeqNumber"),
            new System.Data.OleDb.OleDbParameter("ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.VarWChar, 0, "Length"),
            new System.Data.OleDb.OleDbParameter("SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, "SizeOfItem"),
            new System.Data.OleDb.OleDbParameter("ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemAccessCode"),
            new System.Data.OleDb.OleDbParameter("Qty", System.Data.OleDb.OleDbType.Currency, 0, "Qty"),
            new System.Data.OleDb.OleDbParameter("UM", System.Data.OleDb.OleDbType.VarWChar, 0, "UM"),
            new System.Data.OleDb.OleDbParameter("DateRequired", System.Data.OleDb.OleDbType.Date, 0, "DateRequired"),
            new System.Data.OleDb.OleDbParameter("AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "AcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("MillShipDate", System.Data.OleDb.OleDbType.Date, 0, "MillShipDate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CustAmount", System.Data.OleDb.OleDbType.Currency, 0, "CustAmount"),
            new System.Data.OleDb.OleDbParameter("CommAmount", System.Data.OleDb.OleDbType.Currency, 0, "CommAmount"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, "TreatmentID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate")});
            // 
            // oleDbSelectCommand26
            // 
            this.oleDbSelectCommand26.CommandText = resources.GetString("oleDbSelectCommand26.CommandText");
            this.oleDbSelectCommand26.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand26
            // 
            this.oleDbUpdateCommand26.CommandText = resources.GetString("oleDbUpdateCommand26.CommandText");
            this.oleDbUpdateCommand26.Connection = this.emConnection;
            this.oleDbUpdateCommand26.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, "POItemNumber"),
            new System.Data.OleDb.OleDbParameter("POID", System.Data.OleDb.OleDbType.Integer, 0, "POID"),
            new System.Data.OleDb.OleDbParameter("SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, "SeqNumber"),
            new System.Data.OleDb.OleDbParameter("ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemNameObsolete"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("Length", System.Data.OleDb.OleDbType.VarWChar, 0, "Length"),
            new System.Data.OleDb.OleDbParameter("SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, "SizeOfItem"),
            new System.Data.OleDb.OleDbParameter("ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemAccessCode"),
            new System.Data.OleDb.OleDbParameter("Qty", System.Data.OleDb.OleDbType.Currency, 0, "Qty"),
            new System.Data.OleDb.OleDbParameter("UM", System.Data.OleDb.OleDbType.VarWChar, 0, "UM"),
            new System.Data.OleDb.OleDbParameter("DateRequired", System.Data.OleDb.OleDbType.Date, 0, "DateRequired"),
            new System.Data.OleDb.OleDbParameter("AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "AcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("MillShipDate", System.Data.OleDb.OleDbType.Date, 0, "MillShipDate"),
            new System.Data.OleDb.OleDbParameter("CancelDate", System.Data.OleDb.OleDbType.Date, 0, "CancelDate"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CustAmount", System.Data.OleDb.OleDbType.Currency, 0, "CustAmount"),
            new System.Data.OleDb.OleDbParameter("CommAmount", System.Data.OleDb.OleDbType.Currency, 0, "CommAmount"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, "TreatmentID"),
            new System.Data.OleDb.OleDbParameter("MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "MillConfirmationNumber"),
            new System.Data.OleDb.OleDbParameter("MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, "MillAcknowledgeDate"),
            new System.Data.OleDb.OleDbParameter("InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "InvoiceNumber"),
            new System.Data.OleDb.OleDbParameter("InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, "InvoiceDate"),
            new System.Data.OleDb.OleDbParameter("Original_POItemNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POItemNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_POID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "POID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SeqNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SeqNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemNameObsolete", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemNameObsolete", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemNameObsolete", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Length", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SizeOfItem", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SizeOfItem", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SizeOfItem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemAccessCode", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemAccessCode", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemAccessCode", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Qty", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Qty", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Qty", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_UM", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_UM", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "UM", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DateRequired", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DateRequired", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DateRequired", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_AcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_AcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "AcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CancelDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CancelDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CancelDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommAmount", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommAmount", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommAmount", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillConfirmationNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillConfirmationNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillConfirmationNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_MillAcknowledgeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "MillAcknowledgeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_InvoiceDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_InvoiceDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "InvoiceDate", System.Data.DataRowVersion.Original, null)});
            // 
            // itemFromCompIDAdapter
            // 
            this.itemFromCompIDAdapter.DeleteCommand = this.oleDbDeleteCommand27;
            this.itemFromCompIDAdapter.InsertCommand = this.oleDbInsertCommand27;
            this.itemFromCompIDAdapter.SelectCommand = this.oleDbSelectCommand27;
            this.itemFromCompIDAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblItem", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CommRate", "CommRate"),
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
                        new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("ItemName", "ItemName")})});
            this.itemFromCompIDAdapter.UpdateCommand = this.oleDbUpdateCommand27;
            // 
            // oleDbDeleteCommand27
            // 
            this.oleDbDeleteCommand27.CommandText = resources.GetString("oleDbDeleteCommand27.CommandText");
            this.oleDbDeleteCommand27.Connection = this.emConnection;
            this.oleDbDeleteCommand27.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand27
            // 
            this.oleDbInsertCommand27.CommandText = "INSERT INTO `tblItem` (`CommRate`, `CompID`, `CustRate`, `ItemDesc`, `ItemID`, `I" +
                "temName`) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand27.Connection = this.emConnection;
            this.oleDbInsertCommand27.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemName")});
            // 
            // oleDbSelectCommand27
            // 
            this.oleDbSelectCommand27.CommandText = "SELECT CommRate, CompID, CustRate, ItemDesc, ItemID, ItemName\r\nFROM   tblItem\r\nWH" +
                "ERE (CompID = ?)\r\nORDER BY ItemName";
            this.oleDbSelectCommand27.Connection = this.emConnection;
            this.oleDbSelectCommand27.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID")});
            // 
            // oleDbUpdateCommand27
            // 
            this.oleDbUpdateCommand27.CommandText = resources.GetString("oleDbUpdateCommand27.CommandText");
            this.oleDbUpdateCommand27.Connection = this.emConnection;
            this.oleDbUpdateCommand27.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemName"),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null)});
            // 
            // locationAllAdapter
            // 
            this.locationAllAdapter.DeleteCommand = this.oleDbDeleteCommand28;
            this.locationAllAdapter.InsertCommand = this.oleDbInsertCommand28;
            this.locationAllAdapter.SelectCommand = this.oleDbSelectCommand28;
            this.locationAllAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblLocation2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Address", "Address"),
                        new System.Data.Common.DataColumnMapping("ATTNString", "ATTNString"),
                        new System.Data.Common.DataColumnMapping("CCString", "CCString"),
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CountryID", "CountryID"),
                        new System.Data.Common.DataColumnMapping("ExcelFile", "ExcelFile"),
                        new System.Data.Common.DataColumnMapping("LocID", "LocID"),
                        new System.Data.Common.DataColumnMapping("LocName", "LocName")})});
            this.locationAllAdapter.UpdateCommand = this.oleDbUpdateCommand28;
            // 
            // oleDbDeleteCommand28
            // 
            this.oleDbDeleteCommand28.CommandText = "DELETE FROM tblLocation2 WHERE (LocID = ?) AND (CompID = ?) AND (CountryID = ?) A" +
                "ND (ExcelFile = ? OR ? IS NULL AND ExcelFile IS NULL) AND (LocName = ?)";
            this.oleDbDeleteCommand28.Connection = this.emConnection;
            this.oleDbDeleteCommand28.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_LocID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LocName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocName", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand28
            // 
            this.oleDbInsertCommand28.CommandText = "INSERT INTO tblLocation2(Address, ATTNString, CCString, CompID, CountryID, ExcelF" +
                "ile, LocID, LocName) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand28.Connection = this.emConnection;
            this.oleDbInsertCommand28.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 0, "Address"),
            new System.Data.OleDb.OleDbParameter("ATTNString", System.Data.OleDb.OleDbType.VarWChar, 0, "ATTNString"),
            new System.Data.OleDb.OleDbParameter("CCString", System.Data.OleDb.OleDbType.VarWChar, 0, "CCString"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"),
            new System.Data.OleDb.OleDbParameter("ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, "ExcelFile"),
            new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID"),
            new System.Data.OleDb.OleDbParameter("LocName", System.Data.OleDb.OleDbType.VarWChar, 50, "LocName")});
            // 
            // oleDbSelectCommand28
            // 
            this.oleDbSelectCommand28.CommandText = "SELECT Address, ATTNString, CCString, CompID, CountryID, ExcelFile, LocID, LocNam" +
                "e FROM tblLocation2";
            this.oleDbSelectCommand28.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand28
            // 
            this.oleDbUpdateCommand28.CommandText = resources.GetString("oleDbUpdateCommand28.CommandText");
            this.oleDbUpdateCommand28.Connection = this.emConnection;
            this.oleDbUpdateCommand28.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 0, "Address"),
            new System.Data.OleDb.OleDbParameter("ATTNString", System.Data.OleDb.OleDbType.VarWChar, 0, "ATTNString"),
            new System.Data.OleDb.OleDbParameter("CCString", System.Data.OleDb.OleDbType.VarWChar, 0, "CCString"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"),
            new System.Data.OleDb.OleDbParameter("ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, "ExcelFile"),
            new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID"),
            new System.Data.OleDb.OleDbParameter("LocName", System.Data.OleDb.OleDbType.VarWChar, 50, "LocName"),
            new System.Data.OleDb.OleDbParameter("Original_LocID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LocName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocName", System.Data.DataRowVersion.Original, null)});
            // 
            // treatmentAdapter
            // 
            this.treatmentAdapter.DeleteCommand = this.oleDbDeleteCommand29;
            this.treatmentAdapter.InsertCommand = this.oleDbInsertCommand29;
            this.treatmentAdapter.SelectCommand = this.oleDbSelectCommand29;
            this.treatmentAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblTreatment", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TreatmentID", "TreatmentID"),
                        new System.Data.Common.DataColumnMapping("TreatmentType", "TreatmentType")})});
            this.treatmentAdapter.UpdateCommand = this.oleDbUpdateCommand29;
            // 
            // oleDbDeleteCommand29
            // 
            this.oleDbDeleteCommand29.CommandText = "DELETE FROM tblTreatment WHERE (TreatmentID = ?) AND (TreatmentType = ? OR ? IS N" +
                "ULL AND TreatmentType IS NULL)";
            this.oleDbDeleteCommand29.Connection = this.emConnection;
            this.oleDbDeleteCommand29.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentType", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentType1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentType", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand29
            // 
            this.oleDbInsertCommand29.CommandText = "INSERT INTO tblTreatment(TreatmentID, TreatmentType) VALUES (?, ?)";
            this.oleDbInsertCommand29.Connection = this.emConnection;
            this.oleDbInsertCommand29.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, "TreatmentID"),
            new System.Data.OleDb.OleDbParameter("TreatmentType", System.Data.OleDb.OleDbType.VarWChar, 50, "TreatmentType")});
            // 
            // oleDbSelectCommand29
            // 
            this.oleDbSelectCommand29.CommandText = "SELECT TreatmentID, TreatmentType FROM tblTreatment";
            this.oleDbSelectCommand29.Connection = this.emConnection;
            // 
            // oleDbUpdateCommand29
            // 
            this.oleDbUpdateCommand29.CommandText = "UPDATE tblTreatment SET TreatmentID = ?, TreatmentType = ? WHERE (TreatmentID = ?" +
                ") AND (TreatmentType = ? OR ? IS NULL AND TreatmentType IS NULL)";
            this.oleDbUpdateCommand29.Connection = this.emConnection;
            this.oleDbUpdateCommand29.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, "TreatmentID"),
            new System.Data.OleDb.OleDbParameter("TreatmentType", System.Data.OleDb.OleDbType.VarWChar, 50, "TreatmentType"),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentType", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentType", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_TreatmentType1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "TreatmentType", System.Data.DataRowVersion.Original, null)});
            // 
            // locationAdapterFromLocID
            // 
            this.locationAdapterFromLocID.DeleteCommand = this.oleDbDeleteCommand30;
            this.locationAdapterFromLocID.InsertCommand = this.oleDbInsertCommand30;
            this.locationAdapterFromLocID.SelectCommand = this.oleDbSelectCommand30;
            this.locationAdapterFromLocID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblLocation2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Address", "Address"),
                        new System.Data.Common.DataColumnMapping("ATTNString", "ATTNString"),
                        new System.Data.Common.DataColumnMapping("CCString", "CCString"),
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("CountryID", "CountryID"),
                        new System.Data.Common.DataColumnMapping("ExcelFile", "ExcelFile"),
                        new System.Data.Common.DataColumnMapping("LocID", "LocID"),
                        new System.Data.Common.DataColumnMapping("LocName", "LocName")})});
            this.locationAdapterFromLocID.UpdateCommand = this.oleDbUpdateCommand30;
            // 
            // oleDbDeleteCommand30
            // 
            this.oleDbDeleteCommand30.CommandText = "DELETE FROM tblLocation2 WHERE (LocID = ?) AND (CompID = ?) AND (CountryID = ?) A" +
                "ND (ExcelFile = ? OR ? IS NULL AND ExcelFile IS NULL) AND (LocName = ?)";
            this.oleDbDeleteCommand30.Connection = this.emConnection;
            this.oleDbDeleteCommand30.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_LocID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LocName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocName", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand30
            // 
            this.oleDbInsertCommand30.CommandText = "INSERT INTO tblLocation2(Address, ATTNString, CCString, CompID, CountryID, ExcelF" +
                "ile, LocID, LocName) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand30.Connection = this.emConnection;
            this.oleDbInsertCommand30.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 0, "Address"),
            new System.Data.OleDb.OleDbParameter("ATTNString", System.Data.OleDb.OleDbType.VarWChar, 0, "ATTNString"),
            new System.Data.OleDb.OleDbParameter("CCString", System.Data.OleDb.OleDbType.VarWChar, 0, "CCString"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"),
            new System.Data.OleDb.OleDbParameter("ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, "ExcelFile"),
            new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID"),
            new System.Data.OleDb.OleDbParameter("LocName", System.Data.OleDb.OleDbType.VarWChar, 50, "LocName")});
            // 
            // oleDbSelectCommand30
            // 
            this.oleDbSelectCommand30.CommandText = "SELECT Address, ATTNString, CCString, CompID, CountryID, ExcelFile, LocID, LocNam" +
                "e FROM tblLocation2 WHERE (LocID = ?) ORDER BY LocName";
            this.oleDbSelectCommand30.Connection = this.emConnection;
            this.oleDbSelectCommand30.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID")});
            // 
            // oleDbUpdateCommand30
            // 
            this.oleDbUpdateCommand30.CommandText = resources.GetString("oleDbUpdateCommand30.CommandText");
            this.oleDbUpdateCommand30.Connection = this.emConnection;
            this.oleDbUpdateCommand30.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 0, "Address"),
            new System.Data.OleDb.OleDbParameter("ATTNString", System.Data.OleDb.OleDbType.VarWChar, 0, "ATTNString"),
            new System.Data.OleDb.OleDbParameter("CCString", System.Data.OleDb.OleDbType.VarWChar, 0, "CCString"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("CountryID", System.Data.OleDb.OleDbType.Integer, 0, "CountryID"),
            new System.Data.OleDb.OleDbParameter("ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, "ExcelFile"),
            new System.Data.OleDb.OleDbParameter("LocID", System.Data.OleDb.OleDbType.Integer, 0, "LocID"),
            new System.Data.OleDb.OleDbParameter("LocName", System.Data.OleDb.OleDbType.VarWChar, 50, "LocName"),
            new System.Data.OleDb.OleDbParameter("Original_LocID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_CountryID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CountryID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ExcelFile1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ExcelFile", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LocName", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LocName", System.Data.DataRowVersion.Original, null)});
            // 
            // billOfLadingFromStatus
            // 
            this.billOfLadingFromStatus.DeleteCommand = this.oleDbDeleteCommand31;
            this.billOfLadingFromStatus.InsertCommand = this.oleDbInsertCommand31;
            this.billOfLadingFromStatus.SelectCommand = this.oleDbSelectCommand31;
            this.billOfLadingFromStatus.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblBOL", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("BOLID", "BOLID"),
                        new System.Data.Common.DataColumnMapping("BOLNumber", "BOLNumber"),
                        new System.Data.Common.DataColumnMapping("PickupDate", "PickupDate"),
                        new System.Data.Common.DataColumnMapping("Status", "Status")})});
            this.billOfLadingFromStatus.UpdateCommand = this.oleDbUpdateCommand31;
            // 
            // oleDbDeleteCommand31
            // 
            this.oleDbDeleteCommand31.CommandText = "DELETE FROM tblBOL WHERE (BOLID = ?) AND (BOLNumber = ? OR ? IS NULL AND BOLNumbe" +
                "r IS NULL) AND (PickupDate = ? OR ? IS NULL AND PickupDate IS NULL) AND (Status " +
                "= ? OR ? IS NULL AND Status IS NULL)";
            this.oleDbDeleteCommand31.Connection = this.emConnection;
            this.oleDbDeleteCommand31.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_BOLID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BOLNumber", System.Data.OleDb.OleDbType.VarWChar, 200, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BOLNumber1", System.Data.OleDb.OleDbType.VarWChar, 200, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Status1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand31
            // 
            this.oleDbInsertCommand31.CommandText = "INSERT INTO tblBOL(BOLID, BOLNumber, PickupDate, Status) VALUES (?, ?, ?, ?)";
            this.oleDbInsertCommand31.Connection = this.emConnection;
            this.oleDbInsertCommand31.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID"),
            new System.Data.OleDb.OleDbParameter("BOLNumber", System.Data.OleDb.OleDbType.VarWChar, 200, "BOLNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.DBDate, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 50, "Status")});
            // 
            // oleDbSelectCommand31
            // 
            this.oleDbSelectCommand31.CommandText = "SELECT BOLID, BOLNumber, PickupDate, Status FROM tblBOL WHERE (Status = ?)";
            this.oleDbSelectCommand31.Connection = this.emConnection;
            this.oleDbSelectCommand31.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 50, "Status")});
            // 
            // oleDbUpdateCommand31
            // 
            this.oleDbUpdateCommand31.CommandText = resources.GetString("oleDbUpdateCommand31.CommandText");
            this.oleDbUpdateCommand31.Connection = this.emConnection;
            this.oleDbUpdateCommand31.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("BOLID", System.Data.OleDb.OleDbType.Integer, 0, "BOLID"),
            new System.Data.OleDb.OleDbParameter("BOLNumber", System.Data.OleDb.OleDbType.VarWChar, 200, "BOLNumber"),
            new System.Data.OleDb.OleDbParameter("PickupDate", System.Data.OleDb.OleDbType.DBDate, 0, "PickupDate"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 50, "Status"),
            new System.Data.OleDb.OleDbParameter("Original_BOLID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BOLNumber", System.Data.OleDb.OleDbType.VarWChar, 200, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_BOLNumber1", System.Data.OleDb.OleDbType.VarWChar, 200, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "BOLNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PickupDate1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Status1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null)});
            // 
            // contAllAdapter
            // 
            this.contAllAdapter.DeleteCommand = this.oleDbCommand1;
            this.contAllAdapter.InsertCommand = this.oleDbCommand2;
            this.contAllAdapter.SelectCommand = this.oleDbCommand3;
            this.contAllAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContainer", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ContID", "ContID"),
                        new System.Data.Common.DataColumnMapping("ContNumber", "ContNumber"),
                        new System.Data.Common.DataColumnMapping("ShipDate", "ShipDate"),
                        new System.Data.Common.DataColumnMapping("ETA", "ETA"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("Status", "Status"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("CustomerLocationID", "CustomerLocationID"),
                        new System.Data.Common.DataColumnMapping("ApplyClosingToEntireContainer", "ApplyClosingToEntireContainer"),
                        new System.Data.Common.DataColumnMapping("ContainerPickupDate", "ContainerPickupDate"),
                        new System.Data.Common.DataColumnMapping("ContainerPickupTerminal", "ContainerPickupTerminal"),
                        new System.Data.Common.DataColumnMapping("ContainerProofOfDelivery", "ContainerProofOfDelivery"),
                        new System.Data.Common.DataColumnMapping("ReleaseDate", "ReleaseDate")})});
            this.contAllAdapter.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.emConnection;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ETA", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ReleaseDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.emConnection;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "ContNumber"),
            new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.Date, 0, "ShipDate"),
            new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.Date, 0, "ETA"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, "ApplyClosingToEntireContainer"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, "ContainerPickupDate"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerPickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, "ReleaseDate")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT * FROM tblContainer";
            this.oleDbCommand3.Connection = this.emConnection;
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.emConnection;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "ContNumber"),
            new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.Date, 0, "ShipDate"),
            new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.Date, 0, "ETA"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, "ApplyClosingToEntireContainer"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, "ContainerPickupDate"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerPickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, "ReleaseDate"),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ETA", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ReleaseDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, null)});
            // 
            // itemFromItemNameAdapter
            // 
            this.itemFromItemNameAdapter.DeleteCommand = this.oleDbCommand5;
            this.itemFromItemNameAdapter.InsertCommand = this.oleDbCommand6;
            this.itemFromItemNameAdapter.SelectCommand = this.oleDbCommand7;
            this.itemFromItemNameAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblItem", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("ItemName", "ItemName"),
                        new System.Data.Common.DataColumnMapping("ItemDesc", "ItemDesc"),
                        new System.Data.Common.DataColumnMapping("CustRate", "CustRate"),
                        new System.Data.Common.DataColumnMapping("CommRate", "CommRate")})});
            this.itemFromItemNameAdapter.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = resources.GetString("oleDbCommand5.CommandText");
            this.oleDbCommand5.Connection = this.emConnection;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = "INSERT INTO `tblItem` (`ItemID`, `CompID`, `ItemName`, `ItemDesc`, `CustRate`, `C" +
                "ommRate`) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbCommand6.Connection = this.emConnection;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemName"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT ItemID, CompID, ItemName, ItemDesc, CustRate, CommRate\r\nFROM   tblItem\r\nWH" +
                "ERE (ItemName = ?)";
            this.oleDbCommand7.Connection = this.emConnection;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.WChar, 30, "ItemName")});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = resources.GetString("oleDbCommand8.CommandText");
            this.oleDbCommand8.Connection = this.emConnection;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, "ItemName"),
            new System.Data.OleDb.OleDbParameter("ItemDesc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "ItemDesc"),
            new System.Data.OleDb.OleDbParameter("CustRate", System.Data.OleDb.OleDbType.Currency, 0, "CustRate"),
            new System.Data.OleDb.OleDbParameter("CommRate", System.Data.OleDb.OleDbType.Currency, 0, "CommRate"),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CommRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CommRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CommRate", System.Data.DataRowVersion.Original, null)});
            // 
            // contactsAllAdapter
            // 
            this.contactsAllAdapter.DeleteCommand = this.oleDbCommand9;
            this.contactsAllAdapter.InsertCommand = this.oleDbCommand10;
            this.contactsAllAdapter.SelectCommand = this.oleDbCommand11;
            this.contactsAllAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContacts", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("CompID", "CompID"),
                        new System.Data.Common.DataColumnMapping("ContactID", "ContactID"),
                        new System.Data.Common.DataColumnMapping("EMail", "EMail"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                        new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
                        new System.Data.Common.DataColumnMapping("LastName", "LastName"),
                        new System.Data.Common.DataColumnMapping("Phone", "Phone")})});
            this.contactsAllAdapter.UpdateCommand = this.oleDbCommand12;
            // 
            // oleDbCommand9
            // 
            this.oleDbCommand9.CommandText = resources.GetString("oleDbCommand9.CommandText");
            this.oleDbCommand9.Connection = this.emConnection;
            this.oleDbCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Fax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Fax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FirstName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LastName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Phone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Phone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Phone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Phone", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand10
            // 
            this.oleDbCommand10.CommandText = "INSERT INTO `tblContacts` (`CompID`, `ContactID`, `EMail`, `Fax`, `FirstName`, `L" +
                "astName`, `Phone`) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand10.Connection = this.emConnection;
            this.oleDbCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"),
            new System.Data.OleDb.OleDbParameter("EMail", System.Data.OleDb.OleDbType.VarWChar, 0, "EMail"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 0, "Fax"),
            new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarWChar, 0, "FirstName"),
            new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarWChar, 0, "LastName"),
            new System.Data.OleDb.OleDbParameter("Phone", System.Data.OleDb.OleDbType.VarWChar, 0, "Phone")});
            // 
            // oleDbCommand11
            // 
            this.oleDbCommand11.CommandText = "SELECT CompID, ContactID, EMail, Fax, FirstName, LastName, Phone FROM tblContacts" +
                "";
            this.oleDbCommand11.Connection = this.emConnection;
            // 
            // oleDbCommand12
            // 
            this.oleDbCommand12.CommandText = resources.GetString("oleDbCommand12.CommandText");
            this.oleDbCommand12.Connection = this.emConnection;
            this.oleDbCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("CompID", System.Data.OleDb.OleDbType.Integer, 0, "CompID"),
            new System.Data.OleDb.OleDbParameter("ContactID", System.Data.OleDb.OleDbType.Integer, 0, "ContactID"),
            new System.Data.OleDb.OleDbParameter("EMail", System.Data.OleDb.OleDbType.VarWChar, 0, "EMail"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 0, "Fax"),
            new System.Data.OleDb.OleDbParameter("FirstName", System.Data.OleDb.OleDbType.VarWChar, 0, "FirstName"),
            new System.Data.OleDb.OleDbParameter("LastName", System.Data.OleDb.OleDbType.VarWChar, 0, "LastName"),
            new System.Data.OleDb.OleDbParameter("Phone", System.Data.OleDb.OleDbType.VarWChar, 0, "Phone"),
            new System.Data.OleDb.OleDbParameter("IsNull_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CompID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CompID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContactID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContactID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EMail", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EMail", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EMail", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Fax", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Fax", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Fax", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FirstName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FirstName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FirstName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LastName", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LastName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LastName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Phone", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Phone", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Phone", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Phone", System.Data.DataRowVersion.Original, null)});
            // 
            // containerCheckForDuplicatesAdapter
            // 
            this.containerCheckForDuplicatesAdapter.DeleteCommand = this.oleDbCommand13;
            this.containerCheckForDuplicatesAdapter.InsertCommand = this.oleDbCommand14;
            this.containerCheckForDuplicatesAdapter.SelectCommand = this.oleDbCommand15;
            this.containerCheckForDuplicatesAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblContainer", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ApplyClosingToEntireContainer", "ApplyClosingToEntireContainer"),
                        new System.Data.Common.DataColumnMapping("Comments", "Comments"),
                        new System.Data.Common.DataColumnMapping("ContainerPickupDate", "ContainerPickupDate"),
                        new System.Data.Common.DataColumnMapping("ContainerPickupTerminal", "ContainerPickupTerminal"),
                        new System.Data.Common.DataColumnMapping("ContainerProofOfDelivery", "ContainerProofOfDelivery"),
                        new System.Data.Common.DataColumnMapping("ContID", "ContID"),
                        new System.Data.Common.DataColumnMapping("ContNumber", "ContNumber"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("CustomerLocationID", "CustomerLocationID"),
                        new System.Data.Common.DataColumnMapping("ETA", "ETA"),
                        new System.Data.Common.DataColumnMapping("ShipDate", "ShipDate"),
                        new System.Data.Common.DataColumnMapping("Status", "Status"),
                        new System.Data.Common.DataColumnMapping("ReleaseDate", "ReleaseDate")})});
            this.containerCheckForDuplicatesAdapter.UpdateCommand = this.oleDbCommand16;
            // 
            // oleDbCommand13
            // 
            this.oleDbCommand13.CommandText = resources.GetString("oleDbCommand13.CommandText");
            this.oleDbCommand13.Connection = this.emConnection;
            this.oleDbCommand13.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IsNull_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ETA", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ReleaseDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand14
            // 
            this.oleDbCommand14.CommandText = resources.GetString("oleDbCommand14.CommandText");
            this.oleDbCommand14.Connection = this.emConnection;
            this.oleDbCommand14.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, "ApplyClosingToEntireContainer"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, "ContainerPickupDate"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerPickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "ContNumber"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.Date, 0, "ETA"),
            new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.Date, 0, "ShipDate"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, "ReleaseDate")});
            // 
            // oleDbCommand15
            // 
            this.oleDbCommand15.CommandText = resources.GetString("oleDbCommand15.CommandText");
            this.oleDbCommand15.Connection = this.emConnection;
            this.oleDbCommand15.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.WChar, 20, "ContNumber"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID")});
            // 
            // oleDbCommand16
            // 
            this.oleDbCommand16.CommandText = resources.GetString("oleDbCommand16.CommandText");
            this.oleDbCommand16.Connection = this.emConnection;
            this.oleDbCommand16.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, "ApplyClosingToEntireContainer"),
            new System.Data.OleDb.OleDbParameter("Comments", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Comments"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, "ContainerPickupDate"),
            new System.Data.OleDb.OleDbParameter("ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerPickupTerminal"),
            new System.Data.OleDb.OleDbParameter("ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, "ContainerProofOfDelivery"),
            new System.Data.OleDb.OleDbParameter("ContID", System.Data.OleDb.OleDbType.Integer, 0, "ContID"),
            new System.Data.OleDb.OleDbParameter("ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, "ContNumber"),
            new System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerID"),
            new System.Data.OleDb.OleDbParameter("CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, "CustomerLocationID"),
            new System.Data.OleDb.OleDbParameter("ETA", System.Data.OleDb.OleDbType.Date, 0, "ETA"),
            new System.Data.OleDb.OleDbParameter("ShipDate", System.Data.OleDb.OleDbType.Date, 0, "ShipDate"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.VarWChar, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, "ReleaseDate"),
            new System.Data.OleDb.OleDbParameter("IsNull_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ApplyClosingToEntireContainer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ApplyClosingToEntireContainer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerPickupTerminal", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerPickupTerminal", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerPickupTerminal", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContainerProofOfDelivery", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContainerProofOfDelivery", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ContID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ContNumber", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ContNumber", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ContNumber", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_CustomerLocationID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "CustomerLocationID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ETA", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ETA", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ETA", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ShipDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ShipDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ShipDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Status", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Status", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Status", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ReleaseDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ReleaseDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ReleaseDate", System.Data.DataRowVersion.Original, null)});
            // 
            // surchargeRateAdapter
            // 
            this.surchargeRateAdapter.DeleteCommand = this.oleDbCommand17;
            this.surchargeRateAdapter.InsertCommand = this.oleDbCommand18;
            this.surchargeRateAdapter.SelectCommand = this.oleDbCommand19;
            this.surchargeRateAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblSurchargeRate", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("SurchargeID", "SurchargeID"),
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("FinishID", "FinishID"),
                        new System.Data.Common.DataColumnMapping("SurchargeRate", "SurchargeRate"),
                        new System.Data.Common.DataColumnMapping("SurchargeDate", "SurchargeDate"),
                        new System.Data.Common.DataColumnMapping("SurchargeMonth", "SurchargeMonth")})});
            this.surchargeRateAdapter.UpdateCommand = this.oleDbCommand20;
            // 
            // oleDbCommand17
            // 
            this.oleDbCommand17.CommandText = resources.GetString("oleDbCommand17.CommandText");
            this.oleDbCommand17.Connection = this.emConnection;
            this.oleDbCommand17.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_SurchargeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeMonth", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeMonth", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand18
            // 
            this.oleDbCommand18.CommandText = "INSERT INTO `tblSurchargeRate` (`SurchargeID`, `ItemID`, `FinishID`, `SurchargeRa" +
                "te`, `SurchargeDate`, `SurchargeMonth`) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbCommand18.Connection = this.emConnection;
            this.oleDbCommand18.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("SurchargeID", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("SurchargeRate", System.Data.OleDb.OleDbType.Currency, 0, "SurchargeRate"),
            new System.Data.OleDb.OleDbParameter("SurchargeDate", System.Data.OleDb.OleDbType.Date, 0, "SurchargeDate"),
            new System.Data.OleDb.OleDbParameter("SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeMonth")});
            // 
            // oleDbCommand19
            // 
            this.oleDbCommand19.CommandText = "SELECT        SurchargeID, ItemID, FinishID, SurchargeRate, SurchargeDate, Surcha" +
                "rgeMonth\r\nFROM            tblSurchargeRate\r\nWHERE        (ItemID = ?) AND (Finis" +
                "hID = ?) AND (SurchargeMonth = ?)";
            this.oleDbCommand19.Connection = this.emConnection;
            this.oleDbCommand19.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeMonth")});
            // 
            // oleDbCommand20
            // 
            this.oleDbCommand20.CommandText = resources.GetString("oleDbCommand20.CommandText");
            this.oleDbCommand20.Connection = this.emConnection;
            this.oleDbCommand20.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("SurchargeID", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("SurchargeRate", System.Data.OleDb.OleDbType.Currency, 0, "SurchargeRate"),
            new System.Data.OleDb.OleDbParameter("SurchargeDate", System.Data.OleDb.OleDbType.Date, 0, "SurchargeDate"),
            new System.Data.OleDb.OleDbParameter("SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeMonth"),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeMonth", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeMonth", System.Data.DataRowVersion.Original, null)});
            // 
            // surchargeAllAdapter
            // 
            this.surchargeAllAdapter.DeleteCommand = this.oleDbCommand21;
            this.surchargeAllAdapter.InsertCommand = this.oleDbCommand22;
            this.surchargeAllAdapter.SelectCommand = this.oleDbCommand23;
            this.surchargeAllAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblSurchargeRate", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("SurchargeID", "SurchargeID"),
                        new System.Data.Common.DataColumnMapping("ItemID", "ItemID"),
                        new System.Data.Common.DataColumnMapping("FinishID", "FinishID"),
                        new System.Data.Common.DataColumnMapping("SurchargeRate", "SurchargeRate"),
                        new System.Data.Common.DataColumnMapping("SurchargeDate", "SurchargeDate"),
                        new System.Data.Common.DataColumnMapping("SurchargeMonth", "SurchargeMonth")})});
            this.surchargeAllAdapter.UpdateCommand = this.oleDbCommand24;
            // 
            // oleDbCommand21
            // 
            this.oleDbCommand21.CommandText = resources.GetString("oleDbCommand21.CommandText");
            this.oleDbCommand21.Connection = this.emConnection;
            this.oleDbCommand21.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_SurchargeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeMonth", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeMonth", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand22
            // 
            this.oleDbCommand22.CommandText = "INSERT INTO `tblSurchargeRate` (`SurchargeID`, `ItemID`, `FinishID`, `SurchargeRa" +
                "te`, `SurchargeDate`, `SurchargeMonth`) VALUES (?, ?, ?, ?, ?, ?)";
            this.oleDbCommand22.Connection = this.emConnection;
            this.oleDbCommand22.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("SurchargeID", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("SurchargeRate", System.Data.OleDb.OleDbType.Currency, 0, "SurchargeRate"),
            new System.Data.OleDb.OleDbParameter("SurchargeDate", System.Data.OleDb.OleDbType.Date, 0, "SurchargeDate"),
            new System.Data.OleDb.OleDbParameter("SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeMonth")});
            // 
            // oleDbCommand23
            // 
            this.oleDbCommand23.CommandText = "SELECT        SurchargeID, ItemID, FinishID, SurchargeRate, SurchargeDate, Surcha" +
                "rgeMonth\r\nFROM            tblSurchargeRate";
            this.oleDbCommand23.Connection = this.emConnection;
            // 
            // oleDbCommand24
            // 
            this.oleDbCommand24.CommandText = resources.GetString("oleDbCommand24.CommandText");
            this.oleDbCommand24.Connection = this.emConnection;
            this.oleDbCommand24.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("SurchargeID", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeID"),
            new System.Data.OleDb.OleDbParameter("ItemID", System.Data.OleDb.OleDbType.Integer, 0, "ItemID"),
            new System.Data.OleDb.OleDbParameter("FinishID", System.Data.OleDb.OleDbType.Integer, 0, "FinishID"),
            new System.Data.OleDb.OleDbParameter("SurchargeRate", System.Data.OleDb.OleDbType.Currency, 0, "SurchargeRate"),
            new System.Data.OleDb.OleDbParameter("SurchargeDate", System.Data.OleDb.OleDbType.Date, 0, "SurchargeDate"),
            new System.Data.OleDb.OleDbParameter("SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, "SurchargeMonth"),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ItemID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ItemID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_FinishID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "FinishID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeRate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeRate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeRate", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeRate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeDate", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeDate", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeDate", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeDate", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "SurchargeMonth", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_SurchargeMonth", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SurchargeMonth", System.Data.DataRowVersion.Original, null)});
            // 
            // AdapterHelper
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "AdapterHelper";
            this.Text = "AdapterHelper";
            this.ResumeLayout(false);

		}
		#endregion

		private void oleDbConnection1_InfoMessage(object sender, System.Data.OleDb.OleDbInfoMessageEventArgs e)
		{
		
		}

		private void oleDbConnection1_InfoMessage_1(object sender, System.Data.OleDb.OleDbInfoMessageEventArgs e)
		{
		
		}

        private void poHeaderAdapter_RowUpdated(object sender, OleDbRowUpdatedEventArgs e)
        {

        }

	}
}
