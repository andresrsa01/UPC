using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.ORM;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_Empleado
    {
        DataModel db = new DataModel();
        public List<tb_Empleado> empleados()
        {
            return db.tb_Empleado.ToList();
        }
    }
}
