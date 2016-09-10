using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data.CompositeEntities
{
    public class ItemAtencionProgramacionPlanner
    {

      public  string tarea { get; set; }
       public string instalacion { get; set; }
       public int cantidad { get; set; }
        public string articulo { get; set; }

    }
}
