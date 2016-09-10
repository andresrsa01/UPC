using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.GMantenimiento.Infraestructure.Data;
using Innova.Common.Core.ORM;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_Tarea
    {

        DataModel db = new DataModel();

        public tb_Tarea Registrar(tb_Tarea entidad) {
            db.tb_Tarea.Add(entidad);
            db.SaveChanges();
            return entidad;
        }

        public tb_Tarea Modificar(tb_Tarea entidad) {
            db.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return entidad;
        }

        public List<tb_Tarea> ListarFiltro(tb_Tarea entidad) {
            List<tb_Tarea> lista =
                db.tb_Tarea.Where(f => (f.Nombre.Contains(entidad.Nombre) || f.AbrevTarea.Contains(entidad.AbrevTarea)) ).ToList();
            return lista;
        }

        public List<tb_Tarea> Lista()
        {
            List<tb_Tarea> lista =
                db.tb_Tarea.ToList();
            return lista;
        }


        //metodo que previene la existencia de una entidad con los mismos atributos
        public bool exists(tb_Tarea tarea)
        {
            bool existe = false;

            var x = db.tb_Tarea.Where(t => t.Nombre == tarea.Nombre || t.AbrevTarea == tarea.AbrevTarea).FirstOrDefault();
            if (x != null)
                existe = true;

            return existe;
        }

        public tb_Tarea Obtener(int codigo) {
            return db.tb_Tarea.Where(f => f.CodTarea == codigo).FirstOrDefault();
        }
        
    }
}
