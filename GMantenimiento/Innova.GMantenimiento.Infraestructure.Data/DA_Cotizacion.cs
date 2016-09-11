using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.ORM;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_Cotizacion
    {
        DataModel db = new DataModel();
        public int RegistrarCotizacion(tb_Cotizacion entidad)
        {
            db.tb_Cotizacion.Add(entidad);
            db.SaveChanges();
            return entidad.CodCotizacion;
        }

        public List<tb_BuscarSolCotizacion> BusquedaSolcotizacion(int codigo)
        {
            var query = from x in db.tb_SolCotizacion
                        join q in db.tb_SolCotizacionDet
                        on x.CodSolCotizacion equals q.CodSolCotizacion
                        join w in db.tb_Estado
                        on x.CodEstado equals w.CodEstado
                        join p in db.tb_Proveedor
                        on x.CodProveedor equals p.CodProveedor
                        join a in db.tb_Articulo
                        on q.CodArticulo equals a.CodArticulo
                        where x.CodSolCotizacion == codigo
                        select new tb_BuscarSolCotizacion()
                        {
                            FechaCotizacion = x.FechaCotizacion,
                            CodProveedor = p.CodProveedor,
                            CodEstado = w.CodEstado,
                            CodArticulo = a.CodArticulo,
                            Cantidad = q.Cantidad,
                            NombreProveedor = p.RazonSocial,
                            NombreEstado = w.Nombre,
                            NombreArticulo = a.Nombre,
                            CodSolCotizacion = x.CodSolCotizacion
                        };
            return query.ToList();
        }

        public List<tb_Cotizacion> BuscarCotizacion()
        {
            return db.tb_Cotizacion.ToList();
        }
        public List<tb_SolCotizacion> TraerTodoSolCotizacion()
        {
            return db.tb_SolCotizacion.ToList();
        }

        public void EliminarCotizacion(int id)
        {
            tb_Cotizacion data = db.tb_Cotizacion.Where(x => x.CodCotizacion == id).FirstOrDefault();
            data.CodEstado = "2";

            if (db.Entry<tb_Cotizacion>(data).State == System.Data.Entity.EntityState.Detached)
                db.Set<tb_Cotizacion>().Attach(data);
            db.Entry<tb_Cotizacion>(data).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<tb_BuscarCotizacion> VerCotizacion(int codigo)
        {
            var query = from x in db.tb_Cotizacion
                        join q in db.tb_CotizacionDet
                        on x.CodCotizacion equals q.CodCotizacion
                        join w in db.tb_Estado
                        on x.CodEstado equals w.CodEstado
                        join p in db.tb_Proveedor
                        on x.CodProveedor equals p.CodProveedor
                        join a in db.tb_Articulo
                        on q.CodArticulo equals a.CodArticulo
                        where x.CodCotizacion == codigo
                        select new tb_BuscarCotizacion()
                        {
                            FechaCotizacion = x.FechaCotizacion,
                            CodProveedor = p.CodProveedor,
                            CodEstado = w.CodEstado,
                            CodArticulo = a.CodArticulo,
                            Cantidad = q.Cantidad,
                            NombreProveedor = p.RazonSocial,
                            NombreEstado = w.Nombre,
                            NombreArticulo = a.Nombre,
                            CodCotizacion = x.CodCotizacion,
                            Precio = q.Precio
                        };
            return query.ToList();
        }
    }
}
