namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Calidad_Mantenimiento
    {
        [Key]
        public int CodConsolidado { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public int CodPlanner { get; set; }

        public int CodPeriodo { get; set; }

        [Required]
        [StringLength(1)]
        public string CodEstado { get; set; }
    }
}
