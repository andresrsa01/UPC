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
    public class InstalacionsController : Controller
    { 
         

        public IEnumerable<SelectListItem> Combo()
        {
            BL_Instalacion instalacion = new BL_Instalacion();
            var data_list =instalacion.Lista()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CodInstalacion.ToString(),
                                    Text = x.Nombre
                                });

            return new SelectList(data_list, "Value", "Text");
        }
        


    }
}
