namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_NotDespacho
    {
        [Key]
        public int CodNotDespacho { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaEntrega { get; set; }

        [Required]
        [StringLength(1)]
        public string CodEstado { get; set; }

        public int CodEmpleado { get; set; }

        public int CodNotIngreso { get; set; }
    }
}
