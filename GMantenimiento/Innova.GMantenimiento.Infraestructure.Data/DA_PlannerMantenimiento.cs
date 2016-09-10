using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.Entities;
using Innova.Common.Core.ORM;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_PlannerMantenimiento
    {

        DataModel db = new DataModel();

        public tb_Planner_Mantenimiento Registrar(tb_Planner_Mantenimiento entidad)
        {
            db.tb_Planner_Mantenimiento.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public tb_Planner_Mantenimiento Modificar(tb_Planner_Mantenimiento entidad)
        {
            db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public List<tb_Planner_Mantenimiento> Listar()
        {
            List<tb_Planner_Mantenimiento> lista =
                db.tb_Planner_Mantenimiento.ToList();
            return lista;
        }

        public tb_Planner_Mantenimiento Obtener(int codigo)
        {
            return db.tb_Planner_Mantenimiento.Where(f => f.CodPlanner == codigo).FirstOrDefault();
        }


    }
}
