using Innova.Common.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.GMantenimiento.Infraestructure.Data.CompositeEntities
{
    public class ItemSolAdquisicion : tb_SolAdquisicion
    {
        public string Solicitante { get; set; }
        public string Estado { get; set; }
    }
}
