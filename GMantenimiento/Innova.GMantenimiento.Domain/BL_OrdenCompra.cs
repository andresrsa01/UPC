using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Innova.GMantenimiento.Infraestructure.Data;
using Innova.Common.Core.Entities;
using Innova.Common.Utilities;
using System.Data;
using System.Transactions;

namespace Innova.GMantenimiento.Domain
{
    public class BL_OrdenCompra
    {
        public List<tb_Cotizacion> BuscarCotizacion()
        {
            return new DA_OrdenCompra().BuscarCotizacion();
        }

        public void AnularCompra(int id)
        {
            new DA_OrdenCompra().AnularCompra(id);
        }

        public List<tb_Empleado> empleados()
        {
            return new DA_Empleado().empleados();
        }

        public List<tb_OrdCompra> listarodencompra()
        {
            return new DA_OrdenCompra().listarodencompra();
        }
    }
}
