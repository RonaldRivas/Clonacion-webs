using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;
using System.Data;



namespace Capa_Negocio
{
    public class N_Empleado
    {
        D_Empleados objdato = new D_Empleados();

        public DataTable N_listado()
        {
            return objdato.D_listado();
        }

    public int ListarEmpleados(E_Empleados LEn)
        {
            return objdato.ListarEmpleados(LEn);
        }

    }
}
