using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace GMSTp2.WebSite.Models
{
    public class CommonViewModel
    {

        public ICollection<System.Web.Mvc.SelectListItem> DataCombo { get; set; }
    }

}