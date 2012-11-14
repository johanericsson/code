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
    class NewExcelHelper : IDisposable
    {
        public void Dispose()
        {
            Marshal.ReleaseComObject(sheet);
            


        }
        public NewExcelHelper(EMDataSet.ContainerTblRow headerRow)
        {
            Type tApp = Type.GetTypeFromProgID("Excel.Application");
            object application = Activator.CreateInstance(tApp);
            tApp.InvokeMember("Visible", BindingFlags.SetProperty, null, application, new object[] { true });
            object workbooks = tApp.InvokeMember("Workbooks", BindingFlags.GetProperty, null, application, new object[] { });
            Marshal.ReleaseComObject(application);
            Type tWorkbooks = workbooks.GetType();
            string tempDirectory = Path.GetTempPath();
            string tempXLS = tempDirectory + "\\tmpitl.xls";
            File.Copy("m:\\shipping_notices\\itl.xls", tempXLS, true);
            object workbook = tWorkbooks.InvokeMember("Open", BindingFlags.InvokeMethod, null, workbooks,
                new object[] { tempXLS });
            Marshal.ReleaseComObject(workbooks);
            Type tWorkbook = workbook.GetType();
            sheet =
                tWorkbook.InvokeMember("ActiveSheet", BindingFlags.GetProperty, null, workbook, new object[] { });
            Marshal.ReleaseComObject(workbook);
            tSheet = sheet.GetType();
            JoinContainerDatabase(headerRow);
        }
        ArrayList Join(DataRow[]  inRows,string[] fieldPath)
        {
            ArrayList listOfLists = new ArrayList();
            foreach (DataRow row in inRows)
            {
                ArrayList list = new ArrayList();
                for (int i = 0; i < fieldPath.Length; i++)
                {
                    string[] items = fieldPath[i].Split('+');
                    string val = "";
                    for (int j = 0; j < items.Length; j++)
                    {
                        if (val.Length != 0)
                            val += " ";
                        val += FieldExtractor.GetField(items[j], row);
                    }
                    list.Add(val);
                }
                listOfLists.Add(list);
            }
            return listOfLists;
        }
        string GetExcelCell(int row,int column)
        {
            object range = null;
            range = tSheet.InvokeMember("Cells",
                BindingFlags.GetProperty, null, sheet, new object[] { row, column });
            Type tRange = range.GetType();
            object sObj =
                tRange.InvokeMember("Value", BindingFlags.GetProperty, null, range, new object[] { });
            Marshal.ReleaseComObject(range);
            if (sObj == null)
                return "";
            string s = sObj.ToString();
            return s;
        }
        void SetExcellCell(int row,int column,string value)
        {
            object range = null;
            range = tSheet.InvokeMember("Cells", BindingFlags.GetProperty,
                null, sheet, new object[] { row, column });
            Type tRange = range.GetType();
            tRange.InvokeMember("Value", BindingFlags.SetProperty, null, range, new object[] { value });
            Marshal.ReleaseComObject(range);
        }
        object sheet;
        Type tSheet;
        void InsertRow(int row)
        {
            object range = null;
            range = tSheet.InvokeMember("Range", BindingFlags.GetProperty,
                null, sheet, new object[] { "A" + row.ToString(), "X" + row.ToString() });
            Type tRange = range.GetType();
            tRange.InvokeMember("Insert", BindingFlags.InvokeMethod, null, range, new object[] { });
            Marshal.ReleaseComObject(range);
        }
        void DeleteRow(int row)
        {
            object range = null;
            range = tSheet.InvokeMember("Range", BindingFlags.GetProperty,
                null, sheet, new object[] { "A" + row.ToString(), "X" + row.ToString() });
            Type tRange = range.GetType();
            tRange.InvokeMember("Delete", BindingFlags.InvokeMethod, null, range, new object[] { });
            Marshal.ReleaseComObject(range);
		
        }
        int Find(string[] names,string val)
        {
            for (int i=0;i<names.Length;i++)
            {
                if (names[i] == val)
                    return i;
            }
            return -1;
        }
        string AddBrackets(string val)
        {
            val = '<' + val + '>';
            return val;
        }
        void WriteExcelFile(
            string[] fieldNames,
            string[] fieldPaths,
            string firstRowName,
            ArrayList[] data)
        {
            for (int i=0;i<fieldNames.Length;i++)
            {
                fieldNames[i] = AddBrackets(fieldNames[i]);
            }
            firstRowName = AddBrackets(firstRowName);

            for (int row=1;row<45;row++)
                for (int column=1;column<25;column++)
                {
                    string content = GetExcelCell(row,column);
                    int index = Find(fieldNames,content);
                    if (index == -1)
                        continue;
                    if (content == firstRowName)
                    {
                        int firstRow = row;
                        for (int i=0;i<data.Length;i++)
                        {
                            InsertRow(row+1);
                            for (int repeatColumn=1;repeatColumn<25;repeatColumn++)
                            {
                                string contentVal = GetExcelCell(firstRow,repeatColumn);
                                int indexContent = Find(fieldNames, contentVal);
                                if (indexContent == -1)
                                    continue;
                                SetExcellCell(row + 1,repeatColumn,
                                    (string)data[i][indexContent]);

                            }
                            row++;
                        }
                        DeleteRow(firstRow);
                        continue;
                    }
                    SetExcellCell(row,column,(string)data[0][index]);
                }
        }

        class SortBasedOnBundle : IComparer
        {
            public int Compare(object x, object y)
            {
                EMDataSet.ContBundleTblRow left = (EMDataSet.ContBundleTblRow)x;
                EMDataSet.ContBundleTblRow right = (EMDataSet.ContBundleTblRow)y;
                if (left.BundleSeqNumber < right.BundleSeqNumber)
                    return -1;
                if (left.BundleSeqNumber == right.BundleSeqNumber)
                    return 0;
                return 1;
            }
        }

        void JoinContainerDatabase(EMDataSet.ContainerTblRow headerRow)
        {
            DataTable table = new DataTable();
            EMDataSet.ContBundleTblRow[] bundleRows = headerRow.GetContBundleTblRows();
			System.Array.Sort(bundleRows,new SortByBundleNum());
            string[] fieldsAndPaths= {
            "BUNDLE_NUMBER","BundleSeqNumber",
            "COMPANY_NAME","ContID>ContainerTbl.CustomerID>CompanyTbl.CompName",// +
                            //"ContID>ContainerTbl.CustomerID>CompanyTbl.CompName",
            "CONTNUMBER","ContID>ContainerTbl.ContNumber",
            "PO_NUMBER","POItemNumber>POItemTbl.POID>POHeaderTbl.PONumber",
            "SIZE","POItemNumber>POItemTbl.SizeOfItem",
            "ITEM_NAME","POItemNumber>POItemTbl.FinishID>FinishTbl.FinishType+" + 
                        "POItemNumber>POItemTbl.ItemID>ItemTbl.ItemName+"+
                        "POItemNumber>POItemTbl.TreatmentID>TreatmentTbl.TreatmentType",
            "CODE","POItemNumber>POItemTbl.ItemAccessCode",
            "WEIGHT_KGS","MetricShipQty",
            "WEIGHT_LBS","EnglishShipQty",
            "HEAT","Heat",
            "INVOICE","InvoiceNumber",
            "BAY","BayNumber",
            "ETA","ContID>ContainerTbl.ETA",
            "RATE","POItemNumber>POItemTbl.CustRate",
            "BRANCH","POItemNumber>POItemTbl.POID>POHeaderTbl.CustomerLocationID>LocationTbl.LocName"
            };
            string[] fields = new string[fieldsAndPaths.Length/2];
            string[] paths = new string[fieldsAndPaths.Length/2];
            for(int i =0;i<fields.Length;i++)
            {
                fields[i] = fieldsAndPaths[i*2];
                paths[i] = fieldsAndPaths[i*2+1];
            }
            string firstRowName = "BUNDLE_NUMBER";
            int contID = headerRow.ContID;
            EMDataSet.ContBundleTblRow[] rows = 
                (EMDataSet.ContBundleTblRow[])
                headerRow.Table.DataSet.Tables["ContBundleTbl"].
                Select("ContID = " + contID.ToString());
            // Sort rows based on bundle number
            Array.Sort(rows, new SortBasedOnBundle());
            ArrayList listOfLists = Join(rows, paths);
            ArrayList[] listOfLists2 = (ArrayList[])
                listOfLists.ToArray(typeof(ArrayList));

            WriteExcelFile(fields, paths, firstRowName, listOfLists2);
        }
    }
}
