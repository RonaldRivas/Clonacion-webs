using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoaDatos;
using System.Data;



namespace CapaLogicadeNegocio
{
    public class ClsAlumnos
    {
        //Atributos de la Tabla
        public string m_Dni { get; set; }
        public string m_Apellidos { get; set; }
        public string m_Nombres { get; set; }
        public char m_Sexo { get; set; }
        public DateTime m_FechaNac { get; set; }
        public string m_Direccion { get; set; }

        ClsManejador M = new ClsManejador(); //Agregamos la REferencia de CLSMANEJADOR

        //Metodo para Registrar Alumnos
        public string Registrar_Alumnos()
        {
            string msj = "";
            List<ClsParametros> LST = new List<ClsParametros>();
            try
            {
                //Pasamos los Parametros de Entrada
                LST.Add(new ClsParametros("@dni",m_Dni));
                LST.Add(new ClsParametros("@apellidos", m_Apellidos));
                LST.Add(new ClsParametros("@Nombres", m_Nombres));
                LST.Add(new ClsParametros("@Sexo", m_Sexo));
                LST.Add(new ClsParametros("@FechaNac", m_FechaNac));
                LST.Add(new ClsParametros("@Direccion", m_Direccion));

                //Pasamos los Parametros de Salida
                LST.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar,100));

                M.Ejecutar_SP("RegistrarAlumnos", LST);
                msj = LST[6].Valor.ToString();


            }
            catch (Exception Ex)
            {

                throw Ex;
            }

            return msj;
        }

        //Metodo para Listado de Alumnos
        public DataTable ListadoAlumnos()
        {
            return M.Listado("ListarALumnos", null);
        }


        //Actualizar Alumnos
        public String ActualizarDatos()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            String Mensaje = "";
            try
            {
                lst.Add(new ClsParametros("@Dni", m_Dni));
                lst.Add(new ClsParametros("@Apellidos", m_Apellidos));
                lst.Add(new ClsParametros("@Nombres", m_Nombres));
                lst.Add(new ClsParametros("@Sexo", m_Sexo));
                lst.Add(new ClsParametros("@FechaNac", m_FechaNac));
                lst.Add(new ClsParametros("@Direccion", m_Direccion));
                lst.Add(new ClsParametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                M.Ejecutar_SP("ActualizarDatos", lst);
                Mensaje = lst[6].Valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Mensaje;
        }

    }

}
