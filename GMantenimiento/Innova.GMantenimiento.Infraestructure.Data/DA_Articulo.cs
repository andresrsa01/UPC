using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.ORM;  
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public  class DA_Articulo
    {

        DataModel db = new DataModel();


        public List<tb_Articulo> Lista()
        {
            return db.tb_Articulo.ToList();
        }

        public tb_Articulo Obtener(int codigo)
        {
            return db.tb_Articulo.Where(f => f.CodArticulo == codigo).FirstOrDefault();
        }

    }
}
