namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Plan_Asignatura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Plan_Asignatura()
        {
            tb_Observacion = new HashSet<tb_Observacion>();
            tb_Plan_Asignatura_Actividades = new HashSet<tb_Plan_Asignatura_Actividades>();
        }

        [Key]
        public int CodPlan_Asignatura { get; set; }

        [StringLength(4000)]
        public string Meta { get; set; }

        [StringLength(4000)]
        public string Metodologia { get; set; }

        [StringLength(255)]
        public string Documento { get; set; }

        [StringLength(30)]
        public string Estado { get; set; }

        public int CodPlan_Area { get; set; }

        public int CodEmpleado { get; set; }

        public int CodAsignatura { get; set; }

        public virtual tb_Asignatura tb_Asignatura { get; set; }

        public virtual tb_Empleado tb_Empleado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Observacion> tb_Observacion { get; set; }

        public virtual tb_Plan_Area tb_Plan_Area { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Plan_Asignatura_Actividades> tb_Plan_Asignatura_Actividades { get; set; }
    }
}
