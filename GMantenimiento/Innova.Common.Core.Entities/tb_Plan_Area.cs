namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Plan_Area
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Plan_Area()
        {
            tb_Plan_Asignatura = new HashSet<tb_Plan_Asignatura>();
        }

        [Key]
        public int CodPlan_Area { get; set; }

        [StringLength(80)]
        public string Nombre { get; set; }

        [StringLength(4000)]
        public string Objetivos { get; set; }

        [StringLength(4000)]
        public string Criterios { get; set; }

        [StringLength(4000)]
        public string Requisitos { get; set; }

        [StringLength(30)]
        public string Estado { get; set; }

        [StringLength(255)]
        public string Documento { get; set; }

        public int CodPeriodo { get; set; }

        public int CodArea { get; set; }

        public int CodGrado { get; set; }

        public virtual tb_Area tb_Area { get; set; }

        public virtual tb_Grado tb_Grado { get; set; }

        public virtual tb_Periodo_Academico tb_Periodo_Academico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Plan_Asignatura> tb_Plan_Asignatura { get; set; }
    }
}
