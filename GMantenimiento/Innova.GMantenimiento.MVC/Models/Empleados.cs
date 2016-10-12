using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Innova.GMantenimiento.MVC.Models
{
    public class Empleados
    {
        public int CodEmpleado { get; set; }
        public int CodDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public int CodDepartamento { get; set; }
    }
}