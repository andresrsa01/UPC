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
        public int RegistrarCotizacion(tb_SolCotizacion entidad)
        {
            db.tb_SolCotizacion.Add(entidad);
            db.SaveChanges();
            return entidad.CodSolCotizacion;
        }

        public List<tb_BuscarAdquisicion> BusquedaAdquisicion(int codigo)
        {
            var query = from x in db.tb_SolAdquisicion
                        join q in db.tb_SolAdquisicionDet
                        on x.CodSolAdquisicion equals q.CodSolAdquisicion
                        join w in db.tb_Estado
                        on x.CodEstado equals w.CodEstado
                        join e in db.tb_Empleado
                        on x.CodEmpleado equals e.CodEmpleado
                        join p in db.tb_Proveedor
                        on x.CodEmpleado equals p.CodProveedor
                        join a in db.tb_Articulo
                        on q.CodArticulo equals a.CodArticulo
                        where x.CodEmpleado == codigo
                        select new tb_BuscarAdquisicion()
                        {
                            FechaCotizacion = x.FechaEmision,
                            CodSolAdquisicion = x.CodSolAdquisicion,
                            CodProveedor = p.CodProveedor,
                            CodEstado = w.CodEstado,
                            CodArticulo = a.CodArticulo,
                            Cantidad = q.Cantidad,
                            NombreProveedor = p.RazonSocial,
                            NombreEstado = w.Nombre,
                            NombreArticulo = a.Nombre
                        };
            return query.ToList();


        }
    }
}
