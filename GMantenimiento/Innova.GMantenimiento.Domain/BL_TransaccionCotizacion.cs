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
    public class BL_TransaccionCotizacion
    {
        public void TransaccionCotizacion(tb_Cotizacion cotizacion, List<tb_CotizacionDet> cotizaciondet)
        {
            using (var trn = new TransactionScope())
            {
                var idcotizacion = new DA_Cotizacion().RegistrarCotizacion(cotizacion);
                foreach (var item in cotizaciondet)
                {
                    tb_CotizacionDet obj = new tb_CotizacionDet()
                    {
                        CodCotizacion = idcotizacion,
                        CodArticulo = Convert.ToInt32(item.CodArticulo),
                        Cantidad = Convert.ToInt32(item.Cantidad),
                        Precio = Convert.ToDecimal(item.Precio)
                    };

                    new DA_CotizacionDet().RegistrarCotizacionDet(obj);
                }
                trn.Complete();
            }
        }

        public List<tb_BuscarSolCotizacion> BusquedaSolcotizacion(int codigo)
        {
            return new DA_Cotizacion().BusquedaSolcotizacion(codigo);
        }

        public List<tb_Cotizacion> BuscarCotizacion()
        {
            return new DA_Cotizacion().BuscarCotizacion();
        }

        public List<tb_SolCotizacion> TraerTodoSolCotizacion()
        {
            return new DA_Cotizacion().TraerTodoSolCotizacion();
        }

        public void EliminarCotizacion(int id)
        {
            new DA_Cotizacion().EliminarCotizacion(id);
        }

        public List<tb_BuscarCotizacion> VerCotizacion(int codigo)
        {
            return new DA_Cotizacion().VerCotizacion(codigo);
        }
    }
}
