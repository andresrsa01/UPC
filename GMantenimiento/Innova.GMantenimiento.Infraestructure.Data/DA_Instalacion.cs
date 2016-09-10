using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.ORM;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_Instalacion
    {
       
        DataModel db = new DataModel();

        public List< tb_Instalacion> Lista() {
            return db.tb_Instalacion.ToList();
        }


        public tb_Instalacion Obtener(int codigo)
        {
            return db.tb_Instalacion.Where(f => f.CodInstalacion == codigo).FirstOrDefault();
        }

    }
}
