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
    public class ArticuloesController : Controller
    { 

       
        public IEnumerable<SelectListItem> Combo()
        {
            BL_Articulo articulo = new BL_Articulo();
            var data_list = articulo.Lista()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.CodArticulo.ToString(),
                                    Text = x.Nombre
                                });

            return new SelectList(data_list, "Value", "Text");
        }
        

    }
}
