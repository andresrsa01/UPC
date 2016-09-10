namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Planner_Mantenimiento
    {
        [Key]
        [Column(Order = 0)]
        public int CodPlanner { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string codigo { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [Required]
        [StringLength(5)]
        public string CodPeriodo { get; set; }

        [Required]
        [StringLength(1)]
        public string CodEstado { get; set; }
    }
}
