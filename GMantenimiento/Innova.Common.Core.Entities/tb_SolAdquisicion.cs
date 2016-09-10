namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_SolAdquisicion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_SolAdquisicion()
        {
            tb_SolCotizacion = new HashSet<tb_SolCotizacion>();
            tb_SolAdquisicionDet = new HashSet<tb_SolAdquisicionDet>();
        }

        [Key]
        public int CodSolAdquisicion { get; set; }

        public DateTime FechaEmision { get; set; }

        [Required]
        [StringLength(1)]
        public string CodEstado { get; set; }

        public int CodEmpleado { get; set; }

        public int CodSolicitante { get; set; }

        [StringLength(200)]
        public string Observacion { get; set; }

        [StringLength(25)]
        public string NroInforme { get; set; }

        public int CodProveedor { get; set; }

        public virtual tb_Empleado tb_Empleado { get; set; }

        public virtual tb_Empleado tb_Empleado1 { get; set; }

        public virtual tb_Estado tb_Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SolCotizacion> tb_SolCotizacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SolAdquisicionDet> tb_SolAdquisicionDet { get; set; }
    }
}
