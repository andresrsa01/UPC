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
   public class BL_Instalacion
    {

        DA_Instalacion data = new DA_Instalacion();
        public List<tb_Instalacion> Lista()
        {
            return data.Lista();
        }


        public tb_Instalacion Obtener(int codigo)
        {
            return data.Obtener(codigo);
        }
    }
}
