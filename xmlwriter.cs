using System;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using EM;
/// <summary>
/// Summary description for Class1
/// </summary>
public class EMXMLOutput
{	
    static public void WriteXMLOfAllRows(string title,string[] fieldList, string[] originalTitles,
			string[] friendlyTitles,string[] dataTypes,DataRowCollection rows)
       {

          StringBuilder xmlHeader = new StringBuilder(EM.Resources.XMLHeader);
        // First output all the titles
        xmlHeader.Append("<Worksheet ss:Name=\"full\">");
        xmlHeader.Append("<Table ss:ExpandedColumnCount=\"" + fieldList.Length.ToString() + "\"");
        xmlHeader.Append(" ss:ExpandedRowCount=\"" + rows.Count.ToString() + "366\" x:FullColumns=\"1\"");
        xmlHeader.Append("   x:FullRows=\"1\" ss:DefaultRowHeight=\"15\">\r\n");
        
        for (int i = 0; i < friendlyTitles.Length; i++)
        {
             xmlHeader.Append("<Column ss:Index=\"" + (i+1).ToString() + 
                 "\" ");
            if (dataTypes[i] == "DateTime")
                xmlHeader.Append("ss:StyleID=\"s62\""); 
            else if (dataTypes[i] == "Number" ||
                     dataTypes[i] == "Formula")
                xmlHeader.Append("ss:StyleID=\"s64\"");
            xmlHeader.Append("/>\r\n");
        }
        xmlHeader.Append("<Row><Cell><Data ss:Type=\"String\">");
        xmlHeader.Append(title);
        xmlHeader.Append("</Data></Cell></Row>\r\n");
        xmlHeader.Append("  <Row>");
        for (int i = 0; i < friendlyTitles.Length; i++)
          {
              xmlHeader.Append("<Cell><Data ss:Type=\"String\">" + friendlyTitles[i] + 
                  "</Data></Cell>" + "\r\n");
          }

          xmlHeader.Append("</Row>");
          foreach (DataRow row in rows)
          {
              if (!DataInterface.IsRowAlive(row))
                  continue;
              xmlHeader.Append("<Row>");
              for (int i = 0; i < fieldList.Length; i++)
              {
                  string f = fieldList[i];
                  xmlHeader.Append("<Cell");
                  if (dataTypes[i] == "Formula")
                      xmlHeader.Append(" ss:Formula=\"" + f + "\"><Data ss:Type=\"Number\">");
                  else
                  {
                      xmlHeader.Append("><Data ss:Type=\"" + dataTypes[i] + "\">");
                      object o = FieldExtractor.GetField(f, row);
                      StringBuilder oAsString = new StringBuilder(o.ToString());
                      xmlHeader.Append(oAsString);
                  }
                  xmlHeader.Append("</Data></Cell>\r\n");
              }
              xmlHeader.Append("</Row>\r\n");
          }

          xmlHeader.Append(EM.Resources.XMLFooter);
          string filename = Path.GetTempPath() + "\\full.xml";
          try
          {
              using (TextWriter tw = new StreamWriter(filename))
              {
                  tw.Write(xmlHeader);
                  tw.Close();
              }
              ExcelHelper.OpenExcel(filename);
          }
          catch (Exception )
          {
              System.Windows.Forms.MessageBox.Show("Could not create report - please save/close the previous report?");
          }

        }
}
