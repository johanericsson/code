using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EM
{
    public partial class CurrencyFiller : Form
    {
        EMDataSet m_emDataSet;
        public CurrencyFiller(EMDataSet emDataSet)
        {
            m_emDataSet = emDataSet;
            InitializeComponent();
            // find all the currencies in the dataset and then
            // add each of them to the dataview

            ArrayList listOfCurrencies =
                new ArrayList();
            foreach (EMDataSet.POHeaderTblRow row in emDataSet.POHeaderTbl.Rows)
            {
                if (row.IsCurrencyIDNull())
                    continue;
                if (row.CurrencyID == 0) // U.S.
                    continue;
                listOfCurrencies.Add(row.CurrencyID);
            }
            AdapterHelper.Unique(ref listOfCurrencies);
            foreach (int currencyId in listOfCurrencies)
            {
                EMDataSet.CurrencyTblRow currencyRow =
                    emDataSet.CurrencyTbl.FindByCurrencyID(currencyId);
                string currencyName = currencyRow.CurrencyName;
                string[] values = new string[] { currencyName, ""};
                currencyGrid.Rows.Add(values);
                this.currencyGrid.Rows[currencyGrid.Rows.Count - 1].Tag = currencyId ;
            }
        }

        // onok
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                m_emDataSet.CurrencyTbl.Columns.Add("Rate", typeof(decimal));
                foreach (DataGridViewRow row in currencyGrid.Rows)
                {
                    decimal currencyRate = decimal.Parse((string)row.Cells[1].Value);
                    EMDataSet.CurrencyTblRow currencyRow =
                        m_emDataSet.CurrencyTbl.FindByCurrencyID((int)row.Tag);
                    currencyRow["Rate"] = currencyRate;
                }

                foreach (EMDataSet.POHeaderTblRow row in m_emDataSet.POHeaderTbl)
                {
                    if (row.IsCurrencyIDNull())
                        continue;
                    EMDataSet.CurrencyTblRow currencyRow =
                        m_emDataSet.CurrencyTbl.FindByCurrencyID(row.CurrencyID);
                    if (currencyRow.IsNull("Rate"))
                        continue;
                    row.ExchangeRate = (decimal)currencyRow["Rate"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
    }
}