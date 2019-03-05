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
                if (cmbtipouser.Text == "Administrador")
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from usua_sesion inner join tipo_usua on tipo_usua_id_tipo_user = id_tipo_user where usuario = '" + txtuser.Text + "' and contraseña = '" + txtpass.Text + "' and tipo_usuario = '" + cmbtipouser.Text + "' and tipo_usua_id_tipo_user = 1", cnx);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {


                        principal frm = new principal { IsAdmin = true };
                        this.AddOwnedForm(frm);
                        this.Hide();
                        frm.ShowDialog(this);
                        this.Show();
                        txtpass.Clear();
                        txtuser.Clear();
                        cmbtipouser.Text = "";



                    }


                    else
                    {
                        MessageBox.Show("Usuario on Contraseña incorrectos!");
                    }
                }


                

                else if(cmbtipouser.Text == "Empleado")
                
                    
                    {
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from usua_sesion inner join tipo_usua on tipo_usua_id_tipo_user = id_tipo_user where usuario = '" + txtuser.Text + "' and contraseña = '" + txtpass.Text + "' and tipo_usuario = '" + cmbtipouser.Text + "' and tipo_usua_id_tipo_user = 2", cnx);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        principal frm = new principal();
                        this.Hide();
                        frm.ShowDialog();
                        this.Show();
                        txtpass.Clear();
                        txtuser.Clear();
                        cmbtipouser.Text = "";
                    }

                    else
                    {
                        MessageBox.Show("Usuario o Contraseña incorrectos!");
                    }

                }


            }

            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);

            }

            finally
            {

            }


            }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();
            cmbtipouser.Text = ("");
        }
    }
    }

