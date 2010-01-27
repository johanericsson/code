
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace EM
{
    public partial class NumberSelectorControl : UserControl
    {
        public string Title
        {
            set
            {
                groupBox1.Text = value;
            }
            get
            {
                return groupBox1.Text;
            }
        }
        public bool IsConstraintOn
        {
            get
            {
                if (invoiceStatusCombo.SelectedIndex == 0)
                    return false;
                return true;
            }
        }
        public string fieldName;
        public string FieldName
        {
            get
            {
                return fieldName;
            }
            set
            {
                fieldName = value;
            }
        }
        public string FriendlyFieldName
        {
            get
            {
                return friendlyFieldName;
            }
            set
            {
                friendlyFieldName = value;
            }
        }
        public string friendlyFieldName;
        string GetConstraints()
        {
            if (invoiceStatusCombo.SelectedIndex == 0)
                return null;
            if (invoiceStatusCombo.SelectedIndex == 1)
            {
                return "("+fieldName +" IS NULL OR " +
                    fieldName + " = '')";
            }
            if (invoiceStatusCombo.SelectedIndex == 2)
            {
                if (invoiceNumberEdt.Text == "All")
                    return fieldName + " IS NOT NULL";
                else
                {
                    string[] invoices = invoiceNumberEdt.Text.Split(',');
                    string query = "(";
                    for (int i = 0; i < invoices.Length; i++)
                    {
                        query += fieldName + " = '" + invoices[i] + "'";
                        if (i < invoices.Length - 1)
                            query += " OR ";
                    }
                    query += ")";
                    return query;
                }
            }
            throw new Exception("Invalid selection");
        }
        public void GetConstraints(System.Collections.ArrayList list)
        {
            string str = GetConstraints();
            if (str != null)
                list.Add(str);
        }
        string GetFriendlyConstraints()
        {
            if (invoiceStatusCombo.SelectedIndex == 0)
                return null;
            if (invoiceStatusCombo.SelectedIndex == 1)
                return "Only show with no " + friendlyFieldName + "\n";
            if (invoiceStatusCombo.SelectedIndex == 2)
            {
                if (invoiceNumberEdt.Text == "All")
                {
                    return "Must have " + friendlyFieldName + "\n";
                }
                else
                {
                    string[] invoices = invoiceNumberEdt.Text.Split(',');
                    string query = "(";
                    for (int i = 0; i < invoices.Length; i++)
                    {
                        query += friendlyFieldName + " = " + invoices[i];
                        if (i < invoices.Length - 1)
                            query += " OR ";
                    }
                    query += ")";
                    return query;
                }
            }
            throw new Exception("Invalid selection");
        }
        public string GetFriendlyConstraints(ref string total)
        {
            string str = GetFriendlyConstraints();
            if (str != null)
            {
                total += str;
            }
            return total;
        }

        public NumberSelectorControl()
        {
            InitializeComponent();
            invoiceStatusCombo.SelectedIndex = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void OnStatusChanged(object sender, EventArgs e)
        {
            invoiceNumberEdt.Enabled = (invoiceStatusCombo.SelectedIndex == 2);
            editBtn.Enabled = invoiceNumberEdt.Enabled;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            NumberListEditor edt = new NumberListEditor(invoiceNumberEdt.Text);
            DialogResult res = edt.ShowDialog();
            if (res == DialogResult.OK)
            {
                invoiceNumberEdt.Text = edt.ReturnVal;
            }
        }
    }
}
