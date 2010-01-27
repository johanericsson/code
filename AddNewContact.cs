using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EM
{
    public partial class AddNewContact : Form
    {
        public string ContactName
        {
            get
            {
                return contactNameEdt.Text;
            }
        }
        public AddNewContact()
        {
            InitializeComponent();
        }
    }
}