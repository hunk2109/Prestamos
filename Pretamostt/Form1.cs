using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pretamostt
{
    
    public partial class Form1 : Form
    {
        SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prestamos; integrated security = true;");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("server = HECTOJO; database = prestamos; integrated security = true;");
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from usuario where usuario = '" + txtuser.Text + "' and contraseña = '" + txtpass.Text + "'", cnx);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    principal frm = new principal();
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                    txtpass.Clear();

                }

                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrectos!");
                }
            }

            catch(SqlException ex)
            {

                MessageBox.Show(ex.Message);

            }

            finally
            {

            }


            }

        }
    }

