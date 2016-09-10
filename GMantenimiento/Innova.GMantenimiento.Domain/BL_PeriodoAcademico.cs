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
   public class BL_PeriodoAcademico
    {

        DA_PeriodoAcademico data = new DA_PeriodoAcademico();

        public tb_Periodo_Academico ObtenerActual() {
            return data.ObtenerActual();
        }

        public List<tb_Periodo_Academico> Lista() {
            return data.Listar();
        }

    }
}
