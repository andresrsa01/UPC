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
    public class BL_TransaccionOrdenCompra
    {
        public void TransaccionCompra(tb_OrdCompra ordencompra, List<tb_OrdCompraDet> detallecompra)
        {
            using (var trn = new TransactionScope())
            {
                var idcompra = new DA_OrdenCompra().RegistarComprar(ordencompra);
                foreach (var item in detallecompra)
                {
                    tb_OrdCompraDet det = new tb_OrdCompraDet()
                    {
                        CodOrdCompra = idcompra,
                        CodArticulo = item.CodArticulo,
                        Cantidad = item.Cantidad,
                        PreUnitario = item.PreUnitario,
                        Descuento = item.Descuento
                    };

                    new DA_OrdenCompraDet().RegistrarOrdenCompraDet(det);
                }
                trn.Complete();
            }
        }


    }
}
