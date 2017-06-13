using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    #region Consulta a la BD

    public class D_Empleados
    {
        SqlConnection cn =
            new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconexion"].ConnectionString);

        public DataTable D_listado()
        {
            SqlCommand cmd = new SqlCommand("sp_listar", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public int AgregarEmpleado(E_Empleados pEN)
        {
            SqlCommand cmd = new SqlCommand("agregar_empleado", cn as SqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@CodEmp", pEN.Cod));
            cmd.Parameters.Add(new SqlParameter("@NomEmp", pEN.Nom));
            cmd.Parameters.Add(new SqlParameter("@EdadEmp", pEN.Edad));
            cmd.Parameters.Add(new SqlParameter("@SexoEmp", pEN.Sexo));
            cmd.Parameters.Add(new SqlParameter("@SueldoEmp", pEN.Sueldo));
            int Resultado = cmd.ExecuteNonQuery();
            cn.Close();
            return Resultado;

        }

        public int ListarEmpleados(E_Empleados LEn)
        {
            SqlCommand cmd = new SqlCommand("sp_listar", cn as SqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@NomEmp", LEn.Nom));
            IDataReader _reader = cmd.ExecuteReader();
            List<E_Empleados> Lista = new List<E_Empleados>();
            while (_reader.Read())
            {
                E_Empleados empleado = new E_Empleados();
                empleado.Cod = _reader.GetInt32(0);
                empleado.Nom = _reader.GetString(1);
                empleado.Edad = _reader.GetInt32(2);
                empleado.Sexo = _reader.GetString(3);
                empleado.Sueldo = _reader.GetInt32(4);
            }
            cn.Close();
            return Convert.ToInt32(Lista);



        }

    }
    #endregion


}
