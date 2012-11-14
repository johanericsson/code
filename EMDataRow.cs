using System;
using System.Data;

namespace EM
{
	/// <summary>
	/// Summary description for EMDataRow.
	/// </summary>
	public class EMDataRow :  DataRow
	{
		internal EMDataRow(DataRowBuilder builder):
			base(builder)
		{
		}
		new public object this[string fieldName]
		{			
			get
			{
				return this[base.Table.Columns[fieldName].Ordinal];
			}
			set
			{
				this[base.Table.Columns[fieldName].Ordinal] = value;
			}
		}
		new public object this[DataColumn column]
		{
			get
			{
				return this[column.Ordinal];
			}
			set
			{
				this[column.Ordinal] = value;
			}
		}
		new public object this[int fieldNumber]
		{
			get
			{
				return base[fieldNumber];
			}
			set
			{
				DataColumn col = base.Table.Columns[fieldNumber];
				if (value.GetType() == typeof(System.DBNull))
				{
					if (base.IsNull(fieldNumber))
						return;
					base[fieldNumber] = value;
					return;
				}
				if (base.IsNull(fieldNumber))
				{
/*					if (value.GetType() == typeof(System.String))
					{
						string sValue = (string)value;
						if (sValue.Length == 0)
							return;
					}*/
					base[fieldNumber] = value;
					return;
				}

				object converted = System.Convert.ChangeType(value,col.DataType);
				object databaseValue = base[fieldNumber];
				if (converted.Equals(databaseValue))
					return;
				if (col.DataType == typeof(decimal))
				{
					// The database truncates the given decimal value. We don't
					// want to unnecessarily update the database with the truncated value
					// If the value is the same at the level of precision that the 
					// database keeps the value, then we consider it to be equal.
					decimal convDecimal = (decimal)converted;
					decimal dataDecimal = (decimal)databaseValue;
					decimal difference = convDecimal - dataDecimal;
					if (difference < 0)
						difference = difference * -1m;
					if (difference < .0001m)
						return;
				}


				base[fieldNumber] = value;
			}
		}

	}
}
