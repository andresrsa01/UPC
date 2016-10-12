using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Innova.GMantenimiento.MVC.Models
{
    public class OrdenCompra
    {
        public int CodOrdCompra { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEmision { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }
        public string CodEstado { get; set; }
        public string Moneda { get; set; }
        public decimal TipCambio { get; set; }
        public int CodEmpleado { get; set; }
        public int CodCotizacion { get; set; }
        public int CodProveedor { get; set; }
        public int CodArticulo { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PreUnitario { get; set; }
        public decimal? Descuento { get; set; }

        public decimal? Total { get; set; }
    }
}