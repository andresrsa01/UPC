using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.ORM;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_OrdenCompra
    {
        DataModel db = new DataModel();
        public List<tb_Cotizacion> BuscarCotizacion()
        {
            return db.tb_Cotizacion.ToList();
        }

        public int RegistarComprar(tb_OrdCompra entidad)
        {
            db.tb_OrdCompra.Add(entidad);
            db.SaveChanges();
            return entidad.CodOrdCompra;
        }

        public List<tb_OrdCompra> listarodencompra()
        {
            return db.tb_OrdCompra.ToList();
        }

        public void AnularCompra(int id)
        {
            tb_OrdCompra data = db.tb_OrdCompra.Where(x => x.CodOrdCompra == id).FirstOrDefault();
            data.CodEstado = "2";

            if (db.Entry<tb_OrdCompra>(data).State == System.Data.Entity.EntityState.Detached)
                db.Set<tb_OrdCompra>().Attach(data);
            db.Entry<tb_OrdCompra>(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    } 
}
