namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Observacion
    {
        [Key]
        public int CodObservacion { get; set; }

        [StringLength(255)]
        public string Observacion { get; set; }

        [StringLength(30)]
        public string Tipo { get; set; }

        public int CodPlan_Asignatura { get; set; }

        public virtual tb_Plan_Asignatura tb_Plan_Asignatura { get; set; }
    }
}
