namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Guia
    {
        [Key]
        public int CodGuia { get; set; }

        [StringLength(20)]
        public string CorrelativoGuia { get; set; }

        [StringLength(10)]
        public string SerGuia { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
