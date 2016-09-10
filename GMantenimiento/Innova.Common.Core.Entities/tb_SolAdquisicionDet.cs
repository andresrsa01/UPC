namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_SolAdquisicionDet
    {
        [Key]
        [Column(Order = 0)]
        public int CodSolAdquisicionDet { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodSolAdquisicion { get; set; }

        public int CodArticulo { get; set; }

        public int? Cantidad { get; set; }

        public virtual tb_SolAdquisicion tb_SolAdquisicion { get; set; }
    }
}
