using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.ORM;
using Innova.Common.Core.Entities;


namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_Programacion
    {
         
        DataModel db = new DataModel();

        public tb_Programacion Registrar(tb_Programacion entidad)
        {
            db.tb_Programacion.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public tb_Programacion Modificar(tb_Programacion entidad)
        {
            db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public List<tb_Programacion> Listar(tb_Programacion entidad)
        {
            List<tb_Programacion> lista =
                db.tb_Programacion.ToList();
            return lista;
        }
         

        public tb_Programacion Obtener(int codigo)
        {
            return db.tb_Programacion.Where(f => f.CodTarea == codigo).FirstOrDefault();
        }

        public List<tb_Programacion> Detalle_por_Planner(int codigo) {
            return db.tb_Programacion.Where(f => f.CodPlanner == codigo).ToList();
        }

    }
}
