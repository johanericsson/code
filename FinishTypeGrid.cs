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
	/// Summary description for FinishTypeGrid.
	/// </summary>
	public class FinishTypeGrid
	{
		static public void DoIt(QuickGrid grid,int poid,bool isMetric,EMDataSet emDataSet)
		{
			int[] finishKeys = HelperFunctions.GetFinishKeys("Finish");
			decimal[] totalWeight = new decimal[finishKeys.Length+1];// Last one has no key
			decimal[] totalAmount = new decimal[finishKeys.Length+1];
			foreach (EMDataSet.POItemTblRow itemRow in emDataSet.POItemTbl)
			{
				if (!DataInterface.IsRowAlive(itemRow))
					continue;
				decimal currentWeight;
				if (itemRow.IsQtyNull())
					currentWeight = 0;
				else
					currentWeight = itemRow.Qty;

				decimal currentAmount;
				if (itemRow.IsCustAmountNull())
					currentAmount = 0;
				else
					currentAmount = itemRow.CustAmount;

				if (itemRow.IsFinishIDNull())
				{
					totalWeight[totalWeight.Length-1] += currentWeight;
					totalAmount[totalAmount.Length-1] += currentAmount;
				}
				else
				{
					int index = Array.IndexOf(finishKeys,itemRow.FinishID);
					totalWeight[index] += currentWeight;
					totalAmount[index] += currentAmount;
				}


			}
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Heading",typeof(string));
			dataTable.Columns.Add("FinishWeight",typeof(decimal));
			dataTable.Columns.Add("FinishAmount",typeof(decimal));
			
			for (int i=0;i<totalWeight.Length;i++)
			{
				DataRow weightRow = dataTable.NewRow();
				weightRow["FinishWeight"] = totalWeight[i];
				weightRow["FinishAmount"] = totalAmount[i];
				if (i == finishKeys.Length) // should just happen here
				{
					weightRow["Heading"] = "Unknown";
				}
				else
					weightRow["Heading"] = 
						HelperFunctions.GetFinishType("Finish",finishKeys[i]);
				dataTable.Rows.Add(weightRow);
			}
			DataRow totalRow = dataTable.NewRow();
			totalRow["Heading"] = "Total";
			decimal totalTotal = 0;
			foreach (decimal current in totalWeight)
			{
				totalTotal += current;
			}
			decimal totalAmountTotal  =0;
			foreach (decimal current in totalAmount)
			{
				totalAmountTotal += current;
			}
			totalRow["FinishAmount"] = totalAmountTotal;
			totalRow["FinishWeight"] = totalTotal;
			dataTable.Rows.Add(totalRow);
			HelperFunctions.UpdateGrid(dataTable.DefaultView,grid,null,
				isMetric,IsNewAllowed.No,IsReadOnly.Yes,
				"Heading","FinishWeight","FinishAmount");
		}
	}
}
