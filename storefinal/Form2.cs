using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace storefinal
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnOrderEntry_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        //test
        private void btnProductSave_Click(object sender, EventArgs e)
        {
            bool x = SqlGetData.InsertData("Insert into tblproduct values( '" + txtProductName.Text + "','" + txtUnitPrice.Text + "')");
            if (x == true)
            {
                MessageBox.Show("Data Successfully inserted.");
                txtProductName.Text = null;
                txtUnitPrice.Text = null;
            }
            else
            {
                MessageBox.Show("Error occurred while inserting data.");
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        

       
    }
}
