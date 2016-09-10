using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Innova.GMantenimiento.Infraestructure.Data;
using Innova.Common.Core.Entities;
using Innova.Common.Utilities;
using System.Data;
using Innova.GMantenimiento.Infraestructure.Data.CompositeEntities;

namespace Innova.GMantenimiento.Domain
{
   public class BL_PlannerMantenimiento
    {


        public DA_PlannerMantenimiento data = new DA_PlannerMantenimiento();

        public tb_Planner_Mantenimiento Registrar(tb_Planner_Mantenimiento entidad)
        {
            return data.Registrar(entidad);
        }

        public tb_Planner_Mantenimiento Modificar(tb_Planner_Mantenimiento entidad)
        {
            return data.Modificar(entidad);
        }

        public List<tb_Planner_Mantenimiento> Listar()
        { 
            return data.Listar();
        }

        public tb_Planner_Mantenimiento CambiarEstado(int codigoplanner, int CodEstado) {
            tb_Planner_Mantenimiento planner_mantenimiento = Obtener(codigoplanner);
            planner_mantenimiento.CodEstado = CodEstado.ToString();
            return Modificar(planner_mantenimiento);
        }

        public List<tb_Planner_Mantenimiento> ListarFiltro(tb_Planner_Mantenimiento entidad)
        {
            return data.Listar();
        }
         
        public tb_Planner_Mantenimiento Obtener(int codigo)
        {
            return data.Obtener(codigo);
        }

        public string ImprimirReporte(int id)
        {
            System.Data.DataSet dst = new DataSet();

            System.Data.DataTable dtbCabecera = new DataTable();
            System.Data.DataTable dtbDetalle = new DataTable();

            PDFExport pdf = new PDFExport();
            DataUtils datautils = new DataUtils();

            try
            {
                List<tb_Planner_Mantenimiento> lp = new List<tb_Planner_Mantenimiento>();
                lp.Add(Obtener(Convert.ToInt32(id)));

                List<ItemAtencionProgramacionPlanner> li = new List<ItemAtencionProgramacionPlanner>();
                li = ListadoDetallePlanner(Convert.ToInt32(id));

                dtbCabecera = datautils.ToDataTable<tb_Planner_Mantenimiento>(lp);

                dtbDetalle = datautils.ToDataTable<ItemAtencionProgramacionPlanner>(li);

            }
            catch (Exception ex)
            {
                EventLogger.EscribirLog(ex.ToString());
            }

            dtbCabecera.TableName = "cabecera";
            dtbDetalle.TableName = "detalle";
            dst.Tables.Add(dtbCabecera);
            dst.Tables.Add(dtbDetalle);

            string filename = pdf.SavePDF(dst, "Planner de Mantenimiento", null);
            return filename;
        }

        public List<ItemAtencionProgramacionPlanner> ListadoDetallePlanner(int codigo)
        {
            List<ItemAtencionProgramacionPlanner> lista = new List<ItemAtencionProgramacionPlanner>();

            BL_Programacion programacion = new BL_Programacion();
            List<tb_Programacion> prg = programacion.Detalle_por_Planner(codigo);

            //Clases auxiliares
            DA_Articulo articulo = new DA_Articulo();
            DA_Instalacion instalacion = new DA_Instalacion();
            DA_Tarea tarea = new DA_Tarea();

            foreach (tb_Programacion p in prg)
            {
                ItemAtencionProgramacionPlanner i = new ItemAtencionProgramacionPlanner();
                i.cantidad = Convert.ToInt32(p.Cantidad);
                i.articulo = articulo.Lista().Where(f => f.CodArticulo == p.CodArticulo).FirstOrDefault().Nombre;
                i.instalacion = instalacion.Lista().Where(f => f.CodInstalacion == p.CodInstalacion).FirstOrDefault().Nombre;
                i.tarea = tarea.Lista().Where(f => f.CodTarea == p.CodTarea).FirstOrDefault().Nombre;
                lista.Add(i);
            }

            return lista;
        }

    }
}
