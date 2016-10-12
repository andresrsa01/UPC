namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_NotIngreso
    {
        [Key]
        public int CodNotIngreso { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaEntrega { get; set; }

        [Required]
        [StringLength(1)]
        public string CodEstado { get; set; }

        [Required]
        [StringLength(1)]
        public string Moneda { get; set; }

        [Required]
        [StringLength(8)]
        public string NroGuiaRemision { get; set; }

        public int CodEmpleado { get; set; }

        public int CodOrdCompra { get; set; }

        public int CodProveedor { get; set; }
    }
}
