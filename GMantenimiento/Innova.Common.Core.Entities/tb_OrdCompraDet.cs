namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_OrdCompraDet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodOrdCompra { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodArticulo { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? PreUnitario { get; set; }

        public decimal? Descuento { get; set; }

    }
}
