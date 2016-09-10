namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Programacion
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodPlanner { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodPeriodo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodInstalacion { get; set; }

        public DateTime? FechaProg { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string CodEstado { get; set; }

        public int? CodTarea { get; set; }

        public int? CodArticulo { get; set; }

        public int? Cantidad { get; set; }

        [StringLength(100)]
        public string Observacion { get; set; }
    }
}
