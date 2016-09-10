namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Asignatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Asignatura()
        {
            tb_Plan_Asignatura = new HashSet<tb_Plan_Asignatura>();
            tb_Empleado_Asignatura = new HashSet<tb_Empleado_Asignatura>();
        }

        [Key]
        public int CodAsignatura { get; set; }

        [StringLength(80)]
        public string Curso { get; set; }

        public int CodArea { get; set; }

        public virtual tb_Area tb_Area { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Plan_Asignatura> tb_Plan_Asignatura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Empleado_Asignatura> tb_Empleado_Asignatura { get; set; }
    }
}
