using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaAccesoaDatos
{
   public class ClsManejador
    {
        SqlConnection Conexion = new SqlConnection("Data Source=.;Initial Catalog=DemoNCapas2;Integrated Security=true;uid=sa;password=snake21");

        //Metodo para abrir Conexio
        void Abrir_Conexion()
        {
            if (Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
        }

        //Metodo para Cerrar Conexion
        void Cerrar_Conexion()
        {
            if (Conexion.State== ConnectionState.Open)
            {
                Conexion.Close();
            }

        }
        //Metodo para Ejecutar StoreProcedure(INSERT,DELETE,UPDATE)
        public void Ejecutar_SP(string NombreSP,List<ClsParametros>LST)
        {
            SqlCommand Cmd;
            try
            {
                Abrir_Conexion();
                Cmd = new SqlCommand(NombreSP, Conexion);
                Cmd.CommandType = CommandType.StoredProcedure;
                if (LST != null)
                {
                    for (int i = 0; i < LST.Count; i++)
                    {
                        if (LST[i].Direccion == ParameterDirection.Input)
                        {
                            Cmd.Parameters.AddWithValue(LST[i].Nombre, LST[i].Valor);
                        }
                        if (LST[i].Direccion == ParameterDirection.Output)
                        {
                            Cmd.Parameters.Add(LST[i].Nombre,LST[i].TipoDato,LST[i].Tamaño).Direction=ParameterDirection.Output;
                        }
                    }

                    Cmd.ExecuteNonQuery();
                    for (int i = 0; i < LST.Count; i++)
                    {
                        if (Cmd.Parameters[i].Direction == ParameterDirection.Output)
                        { 
                            LST[i].Valor = Cmd.Parameters[i].Value.ToString();
                        }
                    }
                }
                
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            Cerrar_Conexion();
        }



        //Metodo para los Listados o Consultas(SELECT)
        public DataTable Listado(string NombreSP, List<ClsParametros> LST)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter(NombreSP, Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (LST!=null)
                {
                    for (int i = 0; i < LST.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(LST[i].Nombre, LST[i].Valor);
                    }
                }
                da.Fill(dt);
                return dt;
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            
        }


    }
}
