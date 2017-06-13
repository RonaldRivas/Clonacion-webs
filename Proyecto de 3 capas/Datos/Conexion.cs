using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        private SqlConnection Con { get; set; }

        private string CadenaConexion()
        {
            return @"Data Source=localhost;Initial Catalog=TutorialCShar;user Id=sa;password=snake21";
        }

        //Metodo obtener Conexion
        public SqlConnection getConexion()
        {
            try
            {
                Con = new SqlConnection(CadenaConexion());
                this.Con.Open();
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        //Metodo para Cerrar Conexion
        public void CerrarConexion()
        {
            if (this.Con!=null)
            {
                this.Con.Close();
            }
        }

    }
}
