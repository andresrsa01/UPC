namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_UnidadMedida
    {
        [Key]
        [StringLength(2)]
        public string CodUnidMedida { get; set; }

        [StringLength(25)]
        public string Nombre { get; set; }
    }
}
