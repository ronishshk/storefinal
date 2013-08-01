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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlGetData obj = new SqlGetData();
        private void Form3_Load(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable(); 
                dt=obj.GetData("Select * from tblcustomer");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBoxCustomer.Items.Add(dt.Rows[i][0].ToString());
            }

            DataTable dt1 = new DataTable();
            dt1 = obj.GetData("Select * from tblproduct");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                comboBoxProduct.Items.Add(dt1.Rows[i][0].ToString());
            }

            DataTable dt2 = new DataTable();
            dt2 = obj.GetData("Select * from tblorder");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                comboBoxdelete.Items.Add(dt2.Rows[i][0].ToString());
            }
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxCustomerName.DataBindings.Clear();
            DataTable dt2 = new DataTable();
            dt2 = obj.GetData("Select * from tblcustomer where customerid='" + comboBoxCustomer.SelectedItem + "'");
            textBoxCustomerName.DataBindings.Add("text", dt2, "customername");
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxProductName.DataBindings.Clear();
            textBoxUnitPrice.DataBindings.Clear();
            DataTable dt2 = new DataTable();
            dt2 = obj.GetData("Select * from tblproduct where productid='" + comboBoxProduct.SelectedItem + "'");
            textBoxProductName.DataBindings.Add("text", dt2, "productname");
            textBoxUnitPrice.DataBindings.Add("text", dt2, "unitprice");
        }

       

        private void textchange(object sender, EventArgs e)
        
        {
            
                textBoxTotalAmount.Text = (Convert.ToDouble(textBoxQuantity.Text) * Convert.ToDouble(textBoxUnitPrice.Text)).ToString();
            
        }

        private void btnOrderSave_Click(object sender, EventArgs e)
        {

            bool x;
            x = SqlGetData.InserData("Insert into tblorder values('"+textBoxTotalAmount.Text+"','"+comboBoxCustomer.SelectedItem+"','"+comboBoxProduct.SelectedItem+"')");
            if (x == true)
            {
                MessageBox.Show("Data Successfully inserted.");
                
               comboBoxCustomer.SelectedItem = null;
                comboBoxProduct.SelectedItem = null;
                textBoxProductName.Text = null;
                textBoxCustomerName.Text = null;
               /* textBoxUnitPrice.Text = null;
                textBoxQuantity.Text = null;
                textBoxTotalAmount.Text = null;
               */


               
            }
            else
            {
                MessageBox.Show("Error occurred while inserting data.");
            }

           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = obj.GetData("select * from tblorder");
            dataGridView1.DataSource = dt;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            obj.QryCommand("Delete from tblorder where orderid='" + comboBoxdelete.SelectedItem + "'");
            MessageBox.Show("Record deleted!!");
            comboBoxdelete.SelectedItem = null;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void enterpress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOrderSave_Click(sender, e);
            }
        }

        private void comboEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDelete_Click(sender, e);
            }
        }

        




    
        
    }
}
