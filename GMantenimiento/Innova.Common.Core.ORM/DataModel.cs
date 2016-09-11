namespace Innova.Common.Core.ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Innova.Common.Core.Entities;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModelo")
        {
        }

        public virtual DbSet<tb_Area> tb_Area { get; set; }
        public virtual DbSet<tb_Articulo> tb_Articulo { get; set; }
        public virtual DbSet<tb_Asignatura> tb_Asignatura { get; set; }
        public virtual DbSet<tb_Calidad_Mantenimiento> tb_Calidad_Mantenimiento { get; set; }
        public virtual DbSet<tb_Cotizacion> tb_Cotizacion { get; set; }
        public virtual DbSet<tb_CotizacionDet> tb_CotizacionDet { get; set; }
        public virtual DbSet<tb_Departamento> tb_Departamento { get; set; }
        public virtual DbSet<tb_Documento> tb_Documento { get; set; }
        public virtual DbSet<tb_Empleado> tb_Empleado { get; set; }
        public virtual DbSet<tb_Empleado_Asignatura> tb_Empleado_Asignatura { get; set; }
        public virtual DbSet<tb_Estado> tb_Estado { get; set; }
        public virtual DbSet<tb_Grado> tb_Grado { get; set; }
        public virtual DbSet<tb_Guia> tb_Guia { get; set; }
        public virtual DbSet<tb_Instalacion> tb_Instalacion { get; set; }
        public virtual DbSet<tb_Observacion> tb_Observacion { get; set; }
        public virtual DbSet<tb_Periodo_Academico> tb_Periodo_Academico { get; set; }
        public virtual DbSet<tb_Plan_Area> tb_Plan_Area { get; set; }
        public virtual DbSet<tb_Plan_Asignatura> tb_Plan_Asignatura { get; set; }
        public virtual DbSet<tb_Plan_Asignatura_Actividades> tb_Plan_Asignatura_Actividades { get; set; }
        public virtual DbSet<tb_Planner_Mantenimiento> tb_Planner_Mantenimiento { get; set; }
        public virtual DbSet<tb_Proveedor> tb_Proveedor { get; set; }
        public virtual DbSet<tb_SolAdquisicion> tb_SolAdquisicion { get; set; }
        public virtual DbSet<tb_SolAdquisicionDet> tb_SolAdquisicionDet { get; set; }
        public virtual DbSet<tb_SolCotizacion> tb_SolCotizacion { get; set; }
        public virtual DbSet<tb_SolCotizacionDet> tb_SolCotizacionDet { get; set; }
        public virtual DbSet<tb_Tarea> tb_Tarea { get; set; }
        public virtual DbSet<tb_UnidadMedida> tb_UnidadMedida { get; set; }
        public virtual DbSet<tb_Programacion> tb_Programacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Area>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Area>()
                .HasMany(e => e.tb_Asignatura)
                .WithRequired(e => e.tb_Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Area>()
                .HasMany(e => e.tb_Plan_Area)
                .WithRequired(e => e.tb_Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Articulo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Articulo>()
                .Property(e => e.CodUnidMedida)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Articulo>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Articulo>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Articulo>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Articulo>()
                .HasMany(e => e.tb_SolCotizacionDet)
                .WithRequired(e => e.tb_Articulo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Articulo>()
                .HasMany(e => e.tb_Proveedor)
                .WithMany(e => e.tb_Articulo)
                .Map(m => m.ToTable("tb_ProveedorArticulo").MapLeftKey("CodArticulo").MapRightKey("CodProveedor"));

            modelBuilder.Entity<tb_Asignatura>()
                .Property(e => e.Curso)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Asignatura>()
                .HasMany(e => e.tb_Plan_Asignatura)
                .WithRequired(e => e.tb_Asignatura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Asignatura>()
                .HasMany(e => e.tb_Empleado_Asignatura)
                .WithRequired(e => e.tb_Asignatura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Calidad_Mantenimiento>()
                .Property(e => e.CodEstado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Cotizacion>()
                .Property(e => e.CodEstado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Departamento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Departamento>()
                .HasMany(e => e.tb_Empleado)
                .WithRequired(e => e.tb_Departamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Documento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Documento>()
                .HasMany(e => e.tb_Empleado)
                .WithRequired(e => e.tb_Documento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Empleado>()
                .Property(e => e.NroDocumento)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Empleado>()
                .Property(e => e.ApePaterno)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Empleado>()
                .Property(e => e.ApeMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Empleado>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Empleado>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Empleado>()
                .HasMany(e => e.tb_Empleado_Asignatura)
                .WithRequired(e => e.tb_Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Empleado>()
                .HasMany(e => e.tb_Plan_Asignatura_Actividades)
                .WithRequired(e => e.tb_Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Empleado>()
                .HasMany(e => e.tb_Plan_Asignatura)
                .WithRequired(e => e.tb_Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Empleado>()
                .HasMany(e => e.tb_SolAdquisicion)
                .WithRequired(e => e.tb_Empleado)
                .HasForeignKey(e => e.CodEmpleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Empleado>()
                .HasMany(e => e.tb_SolAdquisicion1)
                .WithRequired(e => e.tb_Empleado1)
                .HasForeignKey(e => e.CodSolicitante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Estado>()
                .Property(e => e.CodEstado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Estado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Estado>()
                .HasMany(e => e.tb_SolAdquisicion)
                .WithRequired(e => e.tb_Estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Grado>()
                .Property(e => e.Grado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Grado>()
                .HasMany(e => e.tb_Plan_Area)
                .WithRequired(e => e.tb_Grado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Guia>()
                .Property(e => e.CorrelativoGuia)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Guia>()
                .Property(e => e.SerGuia)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Instalacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Instalacion>()
                .Property(e => e.AbrevInstalacion)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Observacion>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Observacion>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Periodo_Academico>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Periodo_Academico>()
                .Property(e => e.NomActividad)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Periodo_Academico>()
                .HasMany(e => e.tb_Plan_Area)
                .WithRequired(e => e.tb_Periodo_Academico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Plan_Area>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Area>()
                .Property(e => e.Objetivos)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Area>()
                .Property(e => e.Criterios)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Area>()
                .Property(e => e.Requisitos)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Area>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Area>()
                .Property(e => e.Documento)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Area>()
                .HasMany(e => e.tb_Plan_Asignatura)
                .WithRequired(e => e.tb_Plan_Area)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Plan_Asignatura>()
                .Property(e => e.Meta)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Asignatura>()
                .Property(e => e.Metodologia)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Asignatura>()
                .Property(e => e.Documento)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Asignatura>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Asignatura>()
                .HasMany(e => e.tb_Observacion)
                .WithRequired(e => e.tb_Plan_Asignatura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Plan_Asignatura>()
                .HasMany(e => e.tb_Plan_Asignatura_Actividades)
                .WithRequired(e => e.tb_Plan_Asignatura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Plan_Asignatura_Actividades>()
                .Property(e => e.Actividad)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Plan_Asignatura_Actividades>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Planner_Mantenimiento>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Planner_Mantenimiento>()
                .Property(e => e.CodPeriodo)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Planner_Mantenimiento>()
                .Property(e => e.CodEstado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Proveedor>()
                .Property(e => e.RazonSocial)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Proveedor>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SolAdquisicion>()
                .Property(e => e.CodEstado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SolAdquisicion>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SolAdquisicion>()
                .Property(e => e.NroInforme)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SolAdquisicion>()
                .HasMany(e => e.tb_SolAdquisicionDet)
                .WithRequired(e => e.tb_SolAdquisicion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_SolCotizacion>()
                .Property(e => e.CodEstado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_SolCotizacion>()
                .HasMany(e => e.tb_SolCotizacionDet)
                .WithRequired(e => e.tb_SolCotizacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_Tarea>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Tarea>()
                .Property(e => e.AbrevTarea)
                .IsUnicode(false);

            modelBuilder.Entity<tb_UnidadMedida>()
                .Property(e => e.CodUnidMedida)
                .IsUnicode(false);

            modelBuilder.Entity<tb_UnidadMedida>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Programacion>()
                .Property(e => e.CodEstado)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Programacion>()
                .Property(e => e.Observacion)
                .IsUnicode(false);
        }
    }
}
