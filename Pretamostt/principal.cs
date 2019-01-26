using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pretamostt
{
    public partial class principal : Form
    {
        operacionessql oper = new operacionessql();

        public principal()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            
            oper.consultasinreaultado("insert into Usuarios (nombres,Apellidos,cedula,direccion,telefono,tipo_usua_id_tipo_user)values('" + txtnombre.Text+"','"+txtapellido.Text+"','"+txtcedula.Text+"','"+txtdireccion.Text+"','"+txttel.Text+"','3')");
            MessageBox.Show("Datos Guardados");
            dgvverclie.DataSource = oper.cosnsultaconresultado("Select * from usuarios where tipo_usua_id_tipo_user = 3 ");
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void principal_Load(object sender, EventArgs e)
        {
            dgvverclie.DataSource = oper.cosnsultaconresultado("Select * from usuarios where tipo_usua_id_tipo_user = 3 ");
            dgvclienp.DataSource = oper.cosnsultaconresultado("Select * from usuarios where tipo_usua_id_tipo_user = 3 ");

        }

        private void txtbuscclienv_TextChanged(object sender, EventArgs e)
        {
            if(rbid.Checked == true)
            {
                dgvverclie.DataSource = oper.cosnsultaconresultado("Select * from usuarios  where id_cliente like '%" + txtbuscclienv.Text+"%'");
            }

            else if(rbnomb.Checked == true)
            {
                dgvverclie.DataSource = oper.cosnsultaconresultado("Select * from usuarios  where nombres like '%" + txtbuscclienv.Text + "%'");
            }

            else if(rbcedu.Checked == true)
            {
                dgvverclie.DataSource = oper.cosnsultaconresultado("Select * from usuarios where cedula like '%" + txtbuscclienv.Text + "%'");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(rbidp.Checked == true)
            {
                dgvclienp.DataSource = oper.cosnsultaconresultado("Select * from usuarios  where id_cliente like '%" + txtbusccp.Text + "%'");
            }

            else if(rbnombp.Checked == true)
            {
                dgvclienp.DataSource = oper.cosnsultaconresultado("Select * from usuarios  where nombres like '%" + txtbusccp.Text + "%'");
            }


            else if(rbcedulap.Checked == true)
            {
                dgvclienp.DataSource = oper.cosnsultaconresultado("Select * from usuarios  where cedula like '%" + txtbusccp.Text + "%'");
            }
        }

        private void dgvclienp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvclienp.Rows[e.RowIndex];
            txtidcliep.Text = act.Cells["id_cliente"].Value.ToString();
            txtnomsol.Text = act.Cells["nombres"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnguarp_Click(object sender, EventArgs e)
        {
            oper.consultasinreaultado(" insert into prestamo (cantidad,meses,fecha,garantia,Usuarios_id_cliente) values('" + txtcant.Text + "','" + txtfina.Text + "','" + dtppres.Text + "','" + txtgaran.Text + "','" + txtidcliep.Text + "')");
            dgvprestamos.DataSource = oper.cosnsultaconresultado("select* from prestamo");
            txtcant.Clear();
            txtidcliep.Clear();
            txtnomsol.Clear();
            txtgaran.Clear();
        }
    }
}
