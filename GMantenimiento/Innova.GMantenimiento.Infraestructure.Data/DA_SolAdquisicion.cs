using Innova.Common.Core.ORM;
using Innova.GMantenimiento.Infraestructure.Data.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_SolAdquisicion
    {
        DataModel db = new DataModel();

        public List<ItemSolAdquisicion> Lista() 
        {
            List<ItemSolAdquisicion> lista = new List<ItemSolAdquisicion>();

            var oQuery = (from oAdquisicion in db.tb_SolAdquisicion.ToList()
                          join oEmpleado in db.tb_Empleado.ToList() on
                                oAdquisicion.CodSolicitante equals oEmpleado.CodEmpleado
                          join oEstado in db.tb_Estado.ToList() on
                                oAdquisicion.CodEstado equals oEstado.CodEstado

                          select new
                          {
                              oAdquisicion.CodSolAdquisicion,
                              Solicitante = oEmpleado.ApePaterno + " " + oEmpleado.ApeMaterno + ", " + oEmpleado.Nombres,
                              oAdquisicion.FechaEmision,
                              Estado = oEstado.Nombre
                          }).ToList();

            ItemSolAdquisicion obj;

            foreach (var item in oQuery)
            {
                obj = new ItemSolAdquisicion();
                obj.CodSolAdquisicion = item.CodSolAdquisicion;
                obj.Solicitante = item.Solicitante;
                obj.FechaEmision = item.FechaEmision;
                obj.Estado = item.Estado;
                lista.Add(obj);
            }

            return lista;
        }
    }
}
