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
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        string user = null;
        string password = null;
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        public Form1()
        {
         
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null && textBox2.Text != null)
            {
                user = textBox1.Text;
                password = textBox2.Text;
                builder.DataSource = @"COMP801\SQLEXPRESS";
                builder.InitialCatalog = "MyDB";
                builder.UserID = user;
                builder.Password = password;
                SqlConnection connect = new SqlConnection(builder.ConnectionString);

                try
                {
                    connect.Open();

                    if (connect.State == ConnectionState.Open)
                        MessageBox.Show("Идентификация прошла успешно.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connect?.Close();
                }
            }
        }
    }
}
