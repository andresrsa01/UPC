using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.GMantenimiento.Infraestructure.Data;
using Innova.Common.Core.Entities;
using Innova.Common.Utilities;
using System.Data;

namespace Innova.GMantenimiento.Domain
{
    public class BL_Programacion
    {
        public DA_Programacion data = new DA_Programacion();

        public tb_Programacion Registrar(tb_Programacion entidad)
        {
            return data.Registrar(entidad);
        }

        public tb_Programacion Modificar(tb_Programacion entidad)
        {
            return data.Modificar(entidad);
        }

        public List<tb_Programacion> Detalle_por_Planner(int codigo)
        {
            return data.Detalle_por_Planner(codigo);
        }

    }
}
