namespace Innova.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Empleado_Asignatura
    {
        [Key]
        public int CodAsignatura_Empleado { get; set; }

        public int CodAsignatura { get; set; }

        public int CodEmpleado { get; set; }

        public virtual tb_Asignatura tb_Asignatura { get; set; }

        public virtual tb_Empleado tb_Empleado { get; set; }
    }
}
