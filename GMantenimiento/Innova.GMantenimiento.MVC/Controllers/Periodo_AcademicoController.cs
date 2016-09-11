using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Innova.GMantenimiento.Domain;
using Innova.Common.Core.Entities;

namespace Innova.GMantenimiento.MVC.Controllers
{
    public class Periodo_AcademicoController : Controller
    { 
       

        public IEnumerable<SelectListItem> Combo()
        {
            BL_PeriodoAcademico periodo = new BL_PeriodoAcademico();
            var data_list = periodo.Lista()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CodPeriodo.ToString(),
                                    Text = x.Nombre
                                });

            return new SelectList(data_list, "Value", "Text");
        }


        public tb_Periodo_Academico ObtenerActual()
        {
            BL_PeriodoAcademico periodo = new BL_PeriodoAcademico();
            return periodo.ObtenerActual();
        }
      
    }
}
