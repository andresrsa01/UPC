namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Articulo()
        {
            tb_SolCotizacionDet = new HashSet<tb_SolCotizacionDet>();
            tb_Proveedor = new HashSet<tb_Proveedor>();
        }

        [Key]
        public int CodArticulo { get; set; }

        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(2)]
        public string CodUnidMedida { get; set; }

        [StringLength(100)]
        public string Marca { get; set; }

        [StringLength(100)]
        public string Modelo { get; set; }

        [StringLength(255)]
        public string Observacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_SolCotizacionDet> tb_SolCotizacionDet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Proveedor> tb_Proveedor { get; set; }
    }
}
