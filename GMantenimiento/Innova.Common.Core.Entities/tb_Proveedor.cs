namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Proveedor()
        {
            tb_Articulo = new HashSet<tb_Articulo>();
        }

        [Key]
        public int CodProveedor { get; set; }

        [StringLength(50)]
        public string RazonSocial { get; set; }

        [StringLength(11)]
        public string Ruc { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Articulo> tb_Articulo { get; set; }
    }
}
