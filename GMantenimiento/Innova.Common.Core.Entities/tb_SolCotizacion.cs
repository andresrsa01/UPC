namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_SolCotizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_SolCotizacion()
        {
            tb_SolCotizacionDet = new HashSet<tb_SolCotizacionDet>();
        }

        [Key]
        public int CodSolCotizacion { get; set; }

        public DateTime? FechaCotizacion { get; set; }

        public int? CodSolAdquisicion { get; set; }

        public int? CodProveedor { get; set; }

        [StringLength(1)]
        public string CodEstado { get; set; }

        public virtual tb_SolAdquisicion tb_SolAdquisicion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SolCotizacionDet> tb_SolCotizacionDet { get; set; }
    }
}
