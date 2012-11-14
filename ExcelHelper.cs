// Excel helper

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
	/// Summary description for ExcelHelper.
	/// </summary>
	public class ExcelHelper
	{
		public ExcelHelper()
		{
		}
        static EMDataSet.LocationTblRow[] GetCustomerLocationRows(EMDataSet.ContainerTblRow container)
        {
            EMDataSet dataSet = (EMDataSet)container.Table.DataSet;
            ArrayList listOfPOIDs = new ArrayList();
            foreach (EMDataSet.ContBundleTblRow bundle in container.GetContBundleTblRows())
            {
                listOfPOIDs.Add(bundle.POItemTblRow.POID);
            }
            listOfPOIDs.Sort();
            AdapterHelper.Unique(ref listOfPOIDs);
            ArrayList listOfCustomers = new ArrayList();
            foreach (int poid in listOfPOIDs)
            {
                EMDataSet.POHeaderTblRow header = dataSet.POHeaderTbl.FindByPOID(poid);
                if (!header.IsCustomerIDNull())
                    listOfCustomers.Add(header.CustomerLocationID);
            }
            listOfCustomers.Sort();
            AdapterHelper.Unique(ref listOfCustomers);
            EMDataSet.LocationTblRow[] locTblRows = 
                new EMDataSet.LocationTblRow[listOfCustomers.Count];
            for (int i = 0; i < locTblRows.Length; i++)
            {
                int locid = (int)listOfCustomers[i];
                locTblRows[i] = dataSet.LocationTbl.FindByLocID(locid);
            }
            return locTblRows;
        }

        static string ReplaceKeyWord(EMDataSet emDataSet, EMDataSet.ContainerTblRow headerRow, string totalKgEdt,
			string totalLbsEdt,string current)
		{
			string ret = null;
			switch(current)
			{
				case "<ATTN>":
				{
                    string attn = "";
                    EMDataSet.LocationTblRow[] locRows =
                        GetCustomerLocationRows(headerRow);
                    bool first = true;
                    foreach (EMDataSet.LocationTblRow row in locRows)
                    {
                        if (!row.IsATTNStringNull())
                        {
                            if (row.ATTNString== "")
                                continue;
                            if (row.ATTNString== "\n")
                                continue;
                            if (!first)
                                attn += "\n";
                            first = false;
                            attn += row.ATTNString;
                        }
                    }
                    return attn;
				}
				case "<CC>":
				{
                    string cc = "";
                    EMDataSet.LocationTblRow[] locRows =
                        GetCustomerLocationRows(headerRow);
                    bool first = true;
                    foreach (EMDataSet.LocationTblRow row in locRows)
                    {
                        if (!row.IsCCStringNull())
                        {
                            if (row.CCString == "")
                                continue;
                            if (row.CCString == "\n")
                                continue;
                            if (!first)
                                cc += "\n";
                            first = false;
                            cc += row.CCString;
                        }
                    }
                    return cc ;
                }
				case "<COMPANY_NAME>":
				{
					if (headerRow.IsCustomerIDNull())
						return "";
					EMDataSet.CompanyTblRow companyRow = 
						emDataSet.CompanyTbl.FindByCompID(headerRow.CustomerID);
					if (headerRow.IsCustomerLocationIDNull())
						return "";
					EMDataSet.LocationTblRow locRow = emDataSet.LocationTbl.FindByLocID(headerRow.CustomerLocationID);
					
					return companyRow.CompName + " " + locRow.LocName;
				}
				case "<ETA>":
				{
					if (headerRow.IsETANull())
						ret = "";
					else 
						ret = "ETA:"+HelperFunctions.ToDateText(headerRow.ETA);
					break;
				}
				case "<CONTNUMBER>":
				{
					if (headerRow.IsContNumberNull())
						ret = "";
					else
						ret = "Container:"+headerRow.ContNumber;
					break;
				}
				case "<SHIP_DATE>":
				{	
					ret = "DATE ";
					if (!headerRow.IsShipDateNull())
						ret += HelperFunctions.ToDateText(headerRow.ShipDate);
					
					break;
				}
				case "<NUMBER_OF_BUNDLES>":
				{
					int number_of_bundles = 0;
					foreach (EMDataSet.ContBundleTblRow row in emDataSet.ContBundleTbl.Rows)
					{
						if (DataInterface.IsRowAlive(row))
							number_of_bundles++;
					}
					ret = number_of_bundles.ToString();
					break;
				}
				case "<TOTAL_KGS>":
				{
					ret = totalKgEdt;
					break;
				}
				case "<TOTAL_LBS>":
				{
					ret = totalLbsEdt;
					break;
				}
			}
			return ret;
		}
		static string ExcelGetValue(object sheet,Type tSheet,int row,int column)
		{
			object range = null;
			range = tSheet.InvokeMember("Cells",
				BindingFlags.GetProperty,null,sheet,new object[]{row,column});
			Type tRange = range.GetType();
			object sObj = 
				tRange.InvokeMember("Value",BindingFlags.GetProperty,null,range,new object[]{});
			Marshal.ReleaseComObject(range);
			if (sObj == null)
				return "";
			string s = sObj.ToString();
			return s;
		}
        static string ExcelGetValue(object sheet, int row, int column)
        {
            return ExcelGetValue(sheet, sheet.GetType(), row, column);
        }

		static void ExcelPutValue(object sheet,Type tSheet,int row,int column,
			string value)
		{
			object range = null;
			range = tSheet.InvokeMember("Cells",BindingFlags.GetProperty,
				null,sheet,new object[]{row,column});
			Type tRange = range.GetType();
			tRange.InvokeMember("Value",BindingFlags.SetProperty,null,range,new object[]{value});
			Marshal.ReleaseComObject(range);
		}

        static void ExcelPutValue(object sheet, int row, int column, string value)
        {
            ExcelPutValue(sheet, sheet.GetType(), row, column, value);
        }

		static string RemoveChar(string str,char c)
		{
			int index;
			while ((index = str.IndexOf(c)) != -1)
			{
				str = str.Remove(index,1);
			}
			return str;
		}
		static void ExcelPutValueSplitLines(object sheet, Type tSheet,int row, int column,
			string value)
		{
			string [] lines = value.Split('\n');
			for (int i=0;i<lines.Length;i++)
			{
				lines[i] = RemoveChar(lines[i],'\r');
			}
			ExcelPutValue(sheet,tSheet,row,column,lines[0]);
			for (int i=1;i<lines.Length;i++)
			{
				ExcelInsertRow(sheet,tSheet,row+i);
				ExcelPutValue(sheet,tSheet,row+i,column,lines[i]);
			}
		}

		static void ExcelInsertRow(object sheet,Type tSheet,int row)
		{
			object range = null;
			range = tSheet.InvokeMember("Range",BindingFlags.GetProperty,
				null,sheet,new object[]{"A" + row.ToString(),"X" + row.ToString()});
			Type tRange = range.GetType();
			tRange.InvokeMember("Insert",BindingFlags.InvokeMethod,null,range,new object[]{});
			Marshal.ReleaseComObject(range);
		}
        static void ExcelInsertRow(object sheet, int row)
        {
            ExcelInsertRow(sheet, sheet.GetType(), row);
        }
		static void ExcelRemoveRow(object sheet,Type tSheet,int row)
		{
			object range = null;
			range = tSheet.InvokeMember("Range",BindingFlags.GetProperty,
				null,sheet,new object[]{"A" + row.ToString(),"X" + row.ToString()});
			Type tRange = range.GetType();
			tRange.InvokeMember("Delete",BindingFlags.InvokeMethod,null,range,new object[]{});
			Marshal.ReleaseComObject(range);
		}

		static string ReplaceRowTag(EMDataSet emDataSet,EMDataSet.ContBundleTblRow bundleRow,
			string tag)
		{
			switch (tag)
			{
				case "<BUNDLE_NUMBER>":
					return bundleRow.BundleSeqNumber.ToString();
				case "<PO_NUMBER>":
				{
					EMDataSet.POItemTblRow poItemRow = bundleRow.POItemTblRow;
					EMDataSet.POHeaderTblRow poHeaderRow = poItemRow.POHeaderTblRow;
					return poHeaderRow.PONumber;
				}
				case "<SIZE>":
				{
					EMDataSet.POItemTblRow poItemRow = bundleRow.POItemTblRow;
					if (!poItemRow.IsSizeOfItemNull())
						return poItemRow.SizeOfItem;
					return "";
				}
				case "<ITEM_NAME>":
				{
					EMDataSet.POItemTblRow poItemRow = bundleRow.POItemTblRow;
					return HelperFunctions.GetItemName(poItemRow);
				}
				case "<CODE>":
				{
					EMDataSet.POItemTblRow poItemRow = bundleRow.POItemTblRow;
					if (!poItemRow.IsItemAccessCodeNull())
						return poItemRow.ItemAccessCode;
					return "";
				}
            case "<BRANCH>":
                {
                    EMDataSet.POItemTblRow poItemRow = bundleRow.POItemTblRow;
                    if (poItemRow.POHeaderTblRow.IsCustomerLocationIDNull())
                        return "";
                    int custLocID = poItemRow.
                        POHeaderTblRow.CustomerLocationID;
                    return 
                        emDataSet.LocationTbl.FindByLocID(custLocID).LocName;
                }
				case "<WEIGHT_KGS>":
				{
					if (!bundleRow.IsMetricShipQtyNull())
						return bundleRow.MetricShipQty.ToString("N0");
					return "";
				}
				case "<WEIGHT_LBS>":
				{
					if (!bundleRow.IsEnglishShipQtyNull())
						return bundleRow.EnglishShipQty.ToString("N0");
					return "";
				}
				case "<HEAT>":
				{
					if (!bundleRow.IsHeatNull())
						return bundleRow.Heat;
					return "";
				}
				case "<INVOICE>":
				{
					if (!bundleRow.IsInvoiceNumberNull())
						return bundleRow.InvoiceNumber;
					return "";
				}
				case "<BAY>":
				{
					if (!bundleRow.IsBayNumberNull())
						return bundleRow.BayNumber;
					return "";
				}
			}
			Debug.Assert(false);
			return null;
		}


		public static void RemoveColumn(object sheet,System.Type tSheet,
			int headingRow,string columnTag)
		{
			for (int i=1;i<20;i++)
			{
				string val = ExcelGetValue(sheet,tSheet,headingRow,i);
				if (val == columnTag)
				{
					
					for (int j=0;j<5;j++) // move 5 headers
						
					{
						string next = ExcelGetValue(sheet,tSheet,headingRow,i+j+1);
						ExcelPutValue(sheet,tSheet,headingRow,i+j,next);
						// move the header as well.	
						string nextColumn = ExcelGetValue(sheet,tSheet,headingRow-1,i+j+1);
                        ExcelPutValue(sheet,tSheet,headingRow-1,i+j,nextColumn);
					}
				}
				
			}
		}
		public static void RemoveColumnIfDoesntExist(object sheet,System.Type tSheet,
			int headingRow,string columnTag,string fieldName,
			EMDataSet emDataSet,EMDataSet.ContainerTblRow headerRow)
		{
			foreach (EMDataSet.ContBundleTblRow row in headerRow.GetContBundleTblRows())
			{
				if (!row.IsNull(fieldName))
					return;
			}
			RemoveColumn(sheet,tSheet,headingRow,columnTag);
		}
        public static void RemoveBranchColumnIfNotUnique(object sheet, System.Type tSheet,
            int headingRow, EMDataSet emDataSet, EMDataSet.ContainerTblRow headerRow)
        {
            // customer location 
            ArrayList poList = new ArrayList();
            foreach (EMDataSet.ContBundleTblRow bundleRow in headerRow.GetContBundleTblRows())
            {
                int poid = bundleRow.POItemTblRow.POID;
                poList.Add(poid);
            }
            AdapterHelper.Unique(ref poList);
            ArrayList custLocList = new ArrayList();
            foreach (int poid in poList)
            {
                EMDataSet.POHeaderTblRow tblRow = emDataSet.POHeaderTbl.FindByPOID(poid);
                if (!tblRow.IsCustomerLocationIDNull())
                    custLocList.Add(tblRow.CustomerLocationID);
            }
            AdapterHelper.Unique(ref custLocList);
            if (custLocList.Count < 2)
            {
                RemoveColumn(sheet, tSheet, headingRow, "<BRANCH>");
            }
        }

		public static void RemoveIACColumnIfDoesntExist(object sheet,System.Type tSheet,
			int headingRow,EMDataSet emDataSet,EMDataSet.ContainerTblRow headerRow)
		{
			bool exist = false;
			foreach (EMDataSet.ContBundleTblRow row in headerRow.GetContBundleTblRows())
			{
				if (row.POItemTblRow.IsItemAccessCodeNull() ||
					row.POItemTblRow.ItemAccessCode == "")
					continue;
				// otherwise
				exist = true;
			}
			if (!exist)
				RemoveColumn(sheet,tSheet,headingRow,"<CODE>");
		}

		

		public static void OpenExcel(string filename)
		{
			Type tApp = Type.GetTypeFromProgID("Excel.Application");
			object application = Activator.CreateInstance(tApp);
			tApp.InvokeMember("Visible",BindingFlags.SetProperty,null,application,new object[]{true});
			object workbooks = tApp.InvokeMember("Workbooks",BindingFlags.GetProperty,null,application,new object[]{});
			Type tWorkbooks = workbooks.GetType();
			object workbook = tWorkbooks.InvokeMember("Open",BindingFlags.InvokeMethod,null,workbooks,
				new object[]{filename});
		}

		public static void PrintExcelTemplate(string fileName,
			EMDataSet emDataSet,EMDataSet.ContainerTblRow headerRow,string totalKgEdt,
			string totalLbsEdt,string filenameOut)
		{
			object application = null;
			object workbooks = null;
			object workbook = null;
			object sheet = null;
			try
			{


				//	string fileName = null;
				string tempDirectory = Path.GetTempPath();
				string tempXLS = tempDirectory + filenameOut;
				if (fileName == null || fileName == "")
					fileName = "default.xls";
				try
				{
					File.Copy("m:\\shipping_notices\\" + fileName,tempXLS,true);
				}
				catch (IOException ex)
				{
					string message = "You must close Excel before printing.\n\n" + ex.Message;
					throw new Exception(message,ex);
				}
				Type tApp = Type.GetTypeFromProgID("Excel.Application");
				application = Activator.CreateInstance(tApp);
				tApp.InvokeMember("Visible",BindingFlags.SetProperty,null,application,new object[]{true});
				workbooks = tApp.InvokeMember("Workbooks",BindingFlags.GetProperty,null,application,new object[]{});
				Type tWorkbooks = workbooks.GetType();
				workbook = tWorkbooks.InvokeMember("Open",BindingFlags.InvokeMethod,null,workbooks,
					new object[]{tempXLS});
				Type tWorkbook = workbook.GetType();
				sheet = 
					tWorkbook.InvokeMember("ActiveSheet",BindingFlags.GetProperty,null,workbook,new object[]{});
				Type tSheet = sheet.GetType();
				int bundleRow = 0;
				for (int row = 1;row<40;row++)
					for (int column=1;column<25;column++)
					{
						string value = ExcelGetValue(sheet,tSheet,row,column);
						if (value == "<BUNDLE_NUMBER>" || value == "<PO_NUMBER>")
							bundleRow = row;
						string replacement = ReplaceKeyWord(emDataSet,headerRow,totalKgEdt,totalLbsEdt,value);
					
						if (replacement != null)
						{
							ExcelPutValueSplitLines(sheet,tSheet,row,column,replacement);
						}
					}
				if (bundleRow != 0)
				{
					RemoveColumnIfDoesntExist(sheet,tSheet,bundleRow,"<HEAT>","Heat",emDataSet,headerRow);
					RemoveColumnIfDoesntExist(sheet,tSheet,bundleRow,"<INVOICE>","InvoiceNumber",emDataSet,headerRow);
					RemoveColumnIfDoesntExist(sheet,tSheet,bundleRow,"<BAY>","BayNumber",emDataSet,headerRow);
                    RemoveBranchColumnIfNotUnique(sheet, tSheet, bundleRow, emDataSet, headerRow);
                    RemoveIACColumnIfDoesntExist(sheet,tSheet,bundleRow,emDataSet,headerRow);

					int currentRow = bundleRow + 1;
					EMDataSet.ContBundleTblRow[] bundleRows = headerRow.GetContBundleTblRows();
					System.Array.Sort(bundleRows,new SortByBundleNum());
					foreach (EMDataSet.ContBundleTblRow row in bundleRows)
					{
						if (!DataInterface.IsRowAlive(row))
							continue;
						ExcelInsertRow(sheet,tSheet,currentRow);
						
						for (int column=1;;column++)
						{
							string tag = ExcelGetValue(sheet,tSheet,bundleRow,column);
							if (tag == null || tag == "")
								break;
							string value = ReplaceRowTag(emDataSet,row,tag);
							ExcelPutValue(sheet,tSheet,currentRow,column,value);
						}
						++currentRow;
					}
				}
				ExcelRemoveRow(sheet,tSheet,bundleRow);
			}
			catch(TargetInvocationException ex)
			{
				MessageBox.Show(ex.InnerException.Message);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				if (application!=null)
					Marshal.ReleaseComObject(application);
				if (workbooks!=null)
					Marshal.ReleaseComObject(workbooks);
				if (workbook!=null)
					Marshal.ReleaseComObject(workbook);
				if (sheet!=null)
					Marshal.ReleaseComObject(sheet);
			}
		}

        public static void ShowCustomerLog(DataRowCollection rows)
        {

            string tempDirectory = Path.GetTempPath();
		    string tmpFile = tempDirectory + "\\sales.xls";
            try
            {
                File.Copy("m:\\log.xls", tmpFile, true);
            }
            catch (IOException ex)
            {
                string message = "You must close Excel before printing.\n\n" + ex.Message;
                throw new Exception(message, ex);
            }

            Type tApp = Type.GetTypeFromProgID("Excel.Application");
            object application = Activator.CreateInstance(tApp);
            tApp.InvokeMember("Visible", BindingFlags.SetProperty, null, application, new object[] { true });
            object workbooks = application.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, application, null);
            object workbook = workbooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, workbooks, new object[] { tmpFile });
            object sheet = 
					workbook.GetType().
                    InvokeMember("ActiveSheet",BindingFlags.GetProperty,
                    null,workbook,new object[]{});
				
            int rowCount = rows.Count;
            // First grab the actually path information.. We assume that it is row 2
            int row = 2;
            ArrayList listOfPaths = new ArrayList();
            for (int column = 1; ; column++)
            {
                string val = ExcelGetValue(sheet, row, column);
                if (val == "")
                    break;
                listOfPaths.Add(val);
            }
            string[] paths = (string[])listOfPaths.ToArray(typeof(string));
            for (int i = 0; i < rowCount; i++)
            {
                ExcelInsertRow(sheet, i + row);
            }
            for (int i = 0; i < rowCount; i++)
            {
                DataRow dataRow = rows[i];
                if (!DataInterface.IsRowAlive(dataRow))
                    continue;
                for (int column = 1; column <= paths.Length; column++)
                
                {
                    string path = paths[column - 1];
                    bool isCurrency = false;
                    bool isKG = false;
                    bool isLbs = false;
                    if (path[0] == '$')
                    {
                        path = path.Substring(1);
                        isCurrency = true;
                    }
                    if (path[0] == '&')
                    {
                        path = path.Substring(1);
                        isKG = true;
                    }
                    if (path[0] == '*')
                    {
                        path = path.Substring(1);
                        isLbs = true;
                    }

                    string value = FieldExtractor.GetField(path, dataRow);
                    if (isCurrency && value != "")
                    {
                        decimal d = decimal.Parse(value);
                        EMDataSet.POItemTblRow itemRow = (EMDataSet.POItemTblRow)dataRow;
                        if (!itemRow.POHeaderTblRow.IsExchangeRateNull())
                        {
                            d *= itemRow.POHeaderTblRow.ExchangeRate;
                        }
                        value = d.ToString("N2");
                        
                    }
                    if (isKG  && value != "")
                    {
                        decimal d = decimal.Parse(value);
                        EMDataSet.POItemTblRow itemRow = (EMDataSet.POItemTblRow)dataRow;
                        if (!DataInterface.IsMetric(itemRow))
                        {
                            d = DataInterface.ConvertToKG(d);
                        }
                        value = d.ToString("N0");
                    }
                    if (isLbs && value != "")
                    {
                        decimal d = decimal.Parse(value);
                        EMDataSet.POItemTblRow itemRow = (EMDataSet.POItemTblRow)dataRow;
                        if (DataInterface.IsMetric(itemRow))
                        {
                            d = DataInterface.ConvertToLbs(d);
                        }
                        value = d.ToString("N0");
                    }
                    ExcelPutValue(sheet, i + row, column, value);
                }
                ExcelRemoveRow(sheet, sheet.GetType(), rowCount + row);
            }
        }

    }
}
