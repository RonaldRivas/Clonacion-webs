using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Datos
{
    public class DatosSistema
    {
        //metodo para llenar un DataTable
        public DataTable getDatosTabla(string nomprocedimiento, string[] nomparametros, params object[]valparametros)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            Conexion con = new Conexion();
            
        }
        
        

    }
       
}
