using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.GMantenimiento.Infraestructure.Data;
using Innova.Common.Core.Entities;
using Innova.Common.Utilities;
using System.Data;

namespace Innova.GMantenimiento.Domain
{
   public class BL_Articulo
    {
        DA_Articulo data = new DA_Articulo();
        public List<tb_Articulo> Lista()
        {
            return data.Lista();
        }

        public tb_Articulo Obtener(int codigo)
        {
            return data.Obtener(codigo);
        }


    }
}
