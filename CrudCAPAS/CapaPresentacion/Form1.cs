using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicadeNegocio;


namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        ClsAlumnos Al = new ClsAlumnos();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtDni.Text.Length == 0)
            {
                MessageBox.Show("No se permite dejar este campo vacio");
            }
            else if (TxtNombre.Text.Length==0)
            {
                MessageBox.Show("No se permite dejar este campo vacio");
            }

            else if (TxtApellido.Text.Length==0)
            {
                MessageBox.Show("No se permite dejar este campo vacio");
            }

            else
            {
                string msj = "";
                try
                {
                    Al.m_Dni = TxtDni.Text;
                    Al.m_Apellidos = TxtApellido.Text;
                    Al.m_Nombres = TxtNombre.Text;
                    Al.m_Sexo = rbMasculino.Checked == true ? 'M' : 'F';
                    Al.m_FechaNac = datetime.Value;
                    Al.m_Direccion = TxtDireccion.Text;

                    msj = Al.Registrar_Alumnos();
                    MessageBox.Show(msj);
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
                
            

        }
            

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                DataTable dt = Al.ListadoAlumnos();
                dataGridView1.DataSource = dt;
            }
        }
    }
}
