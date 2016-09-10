namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Plan_Asignatura_Actividades
    {
        [Key]
        public int CodActividad { get; set; }

        [StringLength(120)]
        public string Actividad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Fin { get; set; }

        public int? Porcentaje_Avance { get; set; }

        [StringLength(30)]
        public string Estado { get; set; }

        public int CodPlan_Asignatura { get; set; }

        public int CodEmpleado { get; set; }

        public virtual tb_Empleado tb_Empleado { get; set; }

        public virtual tb_Plan_Asignatura tb_Plan_Asignatura { get; set; }
    }
}
