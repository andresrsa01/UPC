using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.GMantenimiento.Infraestructure.Data;
using Innova.Common.Core.Entities;
using Innova.Common.Utilities;
using System.Data;

namespace Innova.GMantenimiento.Domain
{

   public class BL_Tarea
    {

        public DA_Tarea data = new DA_Tarea();

        public tb_Tarea Registrar(tb_Tarea entidad)
        {
            return data.Registrar(entidad);
        }

        public tb_Tarea Modificar(tb_Tarea entidad)
        {
            return data.Modificar(entidad);
        }

        public List<tb_Tarea> Listar()
        {
            tb_Tarea t = new tb_Tarea();
            t.AbrevTarea = string.Empty;
            t.Nombre = string.Empty;
            return data.ListarFiltro(t);
        }

        public List<tb_Tarea> ListarFiltro(tb_Tarea entidad)
        {
            return data.ListarFiltro(entidad);
        }

        public bool exists(tb_Tarea tarea) {
            return data.exists(tarea);
        }

        public tb_Tarea Obtener(int codigo)
        {
            return data.Obtener(codigo);
        }

        public string ImprimirReporte() {
            PDFExport pdf = new PDFExport();
            DataUtils datautils = new DataUtils();
            System.Data.DataTable dtbdatos = new DataTable();
            System.Data.DataSet dst = new DataSet();
            dtbdatos.TableName = "Tareas";
            dtbdatos = datautils.ToDataTable<tb_Tarea>(this.Listar());
            dst.Tables.Add(dtbdatos);
            string filename = pdf.SavePDF(dst, "Listado de Tareas", null);
            return filename;
        }

        }
}
