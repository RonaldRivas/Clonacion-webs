using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace CapaAccesoaDatos
{
    public class ClsParametros
    {
        private SqlDbType varChar;
        private ParameterDirection output;
        private int v;

        //Parametros
        public string Nombre  {get;set;}
        public object Valor { get; set; }
        public SqlDbType TipoDato { get; set; }
        public Int32 Tamaño { get; set; }
        public ParameterDirection Direccion { get; set; }


   

        //Contructores
        //C.Entrada
        public ClsParametros(string ObjNombre,object ObjValor)
        {
            Nombre = ObjNombre;
            Valor = ObjValor;
            Direccion = ParameterDirection.Input;
        }

        //C.Salidad
        public ClsParametros (string ObjNombre,SqlDbType ObjTipoDato,Int32 ObjTamaño)
        {
            Nombre = ObjNombre;
            TipoDato = ObjTipoDato;
            Tamaño = ObjTamaño;
            Direccion = ParameterDirection.Output;
        }

        public ClsParametros(string ObjNombre, object ObjValor, SqlDbType varChar, ParameterDirection output, int v) : this(ObjNombre, ObjValor)
        {
            this.varChar = varChar;
            this.output = output;
            this.v = v;
        }
    }
}
