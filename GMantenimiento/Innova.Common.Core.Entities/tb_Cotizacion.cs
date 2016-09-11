namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Cotizacion
    {
        [Key]
        public int CodCotizacion { get; set; }

        public DateTime? FechaCotizacion { get; set; }

        public int? CodSolCotizacion { get; set; }

        public int? CodProveedor { get; set; }

        [StringLength(1)]
        public string CodEstado { get; set; }
    }
}
