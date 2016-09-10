using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.Common.Core.Entities;
using Innova.Common.Core.ORM;

namespace Innova.GMantenimiento.Infraestructure.Data
{
    public class DA_PeriodoAcademico
    {

        DataModel db = new DataModel();

        public tb_Periodo_Academico ObtenerActual()
        {

            return db.tb_Periodo_Academico.Where(f => ((DateTime)f.FechaInicio).Year == DateTime.Today.Year).FirstOrDefault();
        }

        public List<tb_Periodo_Academico> Listar() {
            return db.tb_Periodo_Academico.ToList();
        }
    


    }
}
