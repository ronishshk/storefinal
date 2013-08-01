using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace storefinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //hello world!!
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool x = SqlGetData.InserData("Insert into tblcustomer values( '" + Nametxt.Text + "','" + Addresstxt.Text + "','"+ Phonetxt+"')");
            if (x == true)
            {
                MessageBox.Show("Data Successfully inserted.");
                Nametxt.Text = null;
                Addresstxt.Text = null;
                Phonetxt.Text = null;
            }
            else
            {
                MessageBox.Show("Error occurred while inserting data.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2= new Form2();
            f2.ShowDialog();

        }
    }
}
