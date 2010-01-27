using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EM
{
    public partial class BatchAddInvoice : Form
    {
        EMDataSet m_emDataSet;
        public BatchAddInvoice(EMDataSet emDataSet,List<EMDataSet.POHeaderTblRow> notYetInvoicedRows)
        {
            m_emDataSet = emDataSet;
            InitializeComponent();
            foreach (EMDataSet.POHeaderTblRow row in 
                notYetInvoicedRows)
            {
                TaggedItem tagged = 
                    new TaggedItem(row.POID,row.PONumber);
                poList.Items.Add(tagged);
            }
            System.DateTime dateTime = System.DateTime.Today;
            invoiceDateEdt.Text = HelperFunctions.ToDateText(dateTime);
        }
        private void dateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                System.DateTime dateTime = DateTime.Parse(invoiceDateEdt.Text);
                if (DialogResult.OK == DateTimeSelector.RequestTime(ref dateTime))
                {
                    invoiceDateEdt.Text = HelperFunctions.ToDateText(dateTime);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        string FindNextName()
        {
            string name = "m:\\invoiceCommit";
            string fullName = null;
            for (int i = 0; ; i++)
            {
                fullName = name;
                fullName += i.ToString();
                fullName += ".txt";
                if (!System.IO.File.Exists(fullName))
                    break;
            }
            return fullName;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (poList.Items.Count == 0)
                return; // don't apply anything

            if (invoiceEdt.Text == "")
            {
                MessageBox.Show("Error: you must fill out the invoice number before clicking OK.");
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            
            
            try
            {
                DateTime invoiceDate = DateTime.Parse(invoiceDateEdt.Text);

            using (TextWriter tw = new StreamWriter(FindNextName()))
            foreach (TaggedItem tagged in poList.Items)
            {
                EMDataSet.POHeaderTblRow row = 
                    m_emDataSet.POHeaderTbl.FindByPOID(tagged.key);
                row.InvoiceNumber = invoiceEdt.Text;
                row.InvoiceDate = invoiceDate;
                foreach (EMDataSet.POItemTblRow itemRow in row.GetPOItemTblRows())
                {
                    if (itemRow.IsInvoiceNumberNull() ||
                        itemRow.InvoiceNumber == "")
                    {
                        itemRow.InvoiceNumber = invoiceEdt.Text;
                        itemRow.InvoiceDate = invoiceDate;
                        tw.Write(tagged.key.ToString() + "|" + row.PONumber + "|" + 
                             itemRow.POItemNumber.ToString() + "|" + invoiceEdt.Text + tw.NewLine);

                    }
                }
                tw.Write(tagged.key.ToString() + "|" + row.PONumber + "|" + invoiceEdt.Text + tw.NewLine);
            }
            using (new OpenConnection(IsWrite.Yes, AdapterHelper.Connection))
            {
                AdapterHelper.CommitAllPOHeaders(m_emDataSet);
                AdapterHelper.CommitAllPOItems(m_emDataSet);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.Cancel;

            }
        }


    }
}