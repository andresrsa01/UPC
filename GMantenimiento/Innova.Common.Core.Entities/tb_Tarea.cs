namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Tarea
    {
        [Key]
        public int CodTarea { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(30)]
        public string AbrevTarea { get; set; }
    }
}
