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
using System.Text;
namespace EM
{
    class FieldExtractor
    {
        public static string ExtractField(ref string path)
        {
            return ExtractTextUntil(ref path, ">");
        }
        public static string ExtractTextUntil(ref string path, string stopChars)
        {
            StringBuilder builder = new StringBuilder(path);
            string field = "";
            int i = 0;
            for (; i < path.Length && -1 == stopChars.IndexOf(path[i]); i++)
            {
                field += path[i];
            }
            if (i != path.Length)
                ++i;
            builder.Remove(0, i);
            path = builder.ToString();
            return field;
        }
        public static string ExtractTable(ref string path)
        {
            return ExtractTextUntil(ref path, ".");
        }
        public static string GetField(string path, DataRow row)
        {
            string firstField = ExtractField(ref path);
            if (row.IsNull(firstField))
                return "";
            string nextTable = ExtractTable(ref path);
            object val = row[firstField];
            if (nextTable == "")
            {
                string fieldAsString;
                if (val.GetType() == typeof(DateTime))
                    fieldAsString = ((DateTime)val).ToString("s");
                else
                    fieldAsString = val.ToString();
                if (nextTable == "")
                    return fieldAsString;
            }
            DataTable tab = row.Table.DataSet.Tables[nextTable];
            return GetField(path, tab.Rows.Find(val));
        }
        public static string GetFieldText(string path)
        {
            string firstField = ExtractField(ref path);
            string nextTable = ExtractTable(ref path);
            if (nextTable == "")
                return firstField;
            return GetFieldText(path);
        }

    }
}
