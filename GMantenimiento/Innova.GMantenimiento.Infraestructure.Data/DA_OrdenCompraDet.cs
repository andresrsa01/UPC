using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.ORM;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_OrdenCompraDet
    {
        DataModel db = new DataModel();
        public void RegistrarOrdenCompraDet(tb_OrdCompraDet entidad)
        {
            db.tb_OrdCompraDet.Add(entidad);
            db.SaveChanges();
        }
    }
}
