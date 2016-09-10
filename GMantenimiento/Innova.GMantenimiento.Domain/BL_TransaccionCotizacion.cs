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
        public void TransaccionCotizacion(tb_SolCotizacion cotizacion, List<tb_SolCotizacionDet> cotizaciondet)
        {
            using (var trn = new TransactionScope())
            {
                var idcotizacion = new DA_Cotizacion().RegistrarCotizacion(cotizacion);
                foreach(var item in cotizaciondet)
                {
                    tb_SolCotizacionDet obj = new tb_SolCotizacionDet()
                    {
                        CodSolCotizacion = idcotizacion,
                        CodArticulo = item.CodArticulo,
                        Cantidad = item.Cantidad
                    };

                    new DA_CotizacionDet().RegistrarCotizacionDet(obj);
                }
                trn.Complete();
            }
        }

        public List<tb_BuscarAdquisicion> BusquedaAdquisicion(int codigo)
        {
            return new DA_Cotizacion().BusquedaAdquisicion(codigo);
        }
    }
}
