using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace Capa_Presentacion
{
    public partial class P_Empleado : Form
    {
        public P_Empleado()
        {
            InitializeComponent();
        }

        private void P_Empleado_Load(object sender, EventArgs e)
        {
            ListarEmpleado();
        }
        E_Empleados objEntidad = new E_Empleados();
        N_Empleado objdato = new N_Empleado();
       

        void ListarEmpleado()
        {
            DataTable dt = objdato.N_listado();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    

}

