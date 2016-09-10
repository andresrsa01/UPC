using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.ORM;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_CotizacionDet
    {
        DataModel db = new DataModel();
        public void RegistrarCotizacionDet(tb_SolCotizacionDet entidad)
        {
            db.tb_SolCotizacionDet.Add(entidad);
            db.SaveChanges();
        }
    }
}
