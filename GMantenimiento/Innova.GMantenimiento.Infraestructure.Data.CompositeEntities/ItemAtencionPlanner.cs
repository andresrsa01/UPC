using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data.CompositeEntities
{
    public class ItemAtencionPlanner : tb_Programacion  
    {

        public string secuencial { get; set; } 
        public string fecha_tentantiva_programacion { get; set; }
    }
}
