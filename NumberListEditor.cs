using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EM
{
    public partial class NumberListEditor : Form
    {
        public NumberListEditor(string millList)
        {
            InitializeComponent();
            Commit(Split(millList, ","));

        }
        public string ReturnVal
        {
            get
            {
                string val = "";
                foreach (string s in numberList.Items)
                {
                    val += s + ",";
                }
                if (val.Length != 0)
                    val = val.Substring(0, val.Length - 1); // remove last comma
                return val;
            }
        }

        static List<string> Split(string str, string split)
        {
            List<string> l = new List<string>();
            for (; str.Length != 0; )
            {
                int index = str.IndexOf(split);
                int tokenLength = split.Length;
                if (index == -1)
                {
                    tokenLength = 0;
                    index = str.Length;
                }
                string substr = str.Substring(0, index);
                l.Add(substr);
                str = 
                    str.Substring(index + tokenLength, str.Length - (index + tokenLength));
            }
            return l;
        }
        void Commit(List<string> l)
        {
            numberList.Items.Clear();
            foreach (string s in l)
            {
                numberList.Items.Add(s);
            }
            

        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)==false)
                    throw new Exception("The clipboard does not contain any text");

                string str = Clipboard.GetDataObject().
                    GetData(DataFormats.Text).ToString();
                List<string> l = Split(str, "\r\n");
                Commit(l);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (numberEdt.Text != "")
                numberList.Items.Add(numberEdt.Text);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            int index = numberList.SelectedIndex;
            if (index < 0)
                index = 0;
            if (numberList.Items.Count == 0)
                return;
            numberList.Items.RemoveAt(index);
        }
    }
}