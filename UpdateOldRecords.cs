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
	/// Summary description for UpdateOldRecords.
	/// </summary>
	public class UpdateOldRecords
	{
		public UpdateOldRecords()
		{}
		static public void Update()
		{
			EMDataSet emDataSet = new EMDataSet();
			using (new OpenConnection(EM.IsWrite.Yes,AdapterHelper.Connection))
			using (new TurnOffConstraints(emDataSet))
			{
				AdapterHelper.FillAllPOHeaders(emDataSet);
				foreach( EMDataSet.POHeaderTblRow row in emDataSet.POHeaderTbl)
				{
					row.InvoiceNumber = "";
				}
				AdapterHelper.CommitAllPOHeaders(emDataSet);
			}

		}
	}
}