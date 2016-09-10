namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Empleado()
        {
            tb_Empleado_Asignatura = new HashSet<tb_Empleado_Asignatura>();
            tb_Plan_Asignatura_Actividades = new HashSet<tb_Plan_Asignatura_Actividades>();
            tb_Plan_Asignatura = new HashSet<tb_Plan_Asignatura>();
            tb_SolAdquisicion = new HashSet<tb_SolAdquisicion>();
            tb_SolAdquisicion1 = new HashSet<tb_SolAdquisicion>();
        }

        [Key]
        public int CodEmpleado { get; set; }

        public int CodDocumento { get; set; }

        [Required]
        [StringLength(25)]
        public string NroDocumento { get; set; }

        [StringLength(50)]
        public string ApePaterno { get; set; }

        [StringLength(50)]
        public string ApeMaterno { get; set; }

        [StringLength(50)]
        public string Nombres { get; set; }

        [StringLength(100)]
        public string Correo { get; set; }

        public int CodDepartamento { get; set; }

        public virtual tb_Departamento tb_Departamento { get; set; }

        public virtual tb_Documento tb_Documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Empleado_Asignatura> tb_Empleado_Asignatura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Plan_Asignatura_Actividades> tb_Plan_Asignatura_Actividades { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Plan_Asignatura> tb_Plan_Asignatura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SolAdquisicion> tb_SolAdquisicion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SolAdquisicion> tb_SolAdquisicion1 { get; set; }
    }
}
