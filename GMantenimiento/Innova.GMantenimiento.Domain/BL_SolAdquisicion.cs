using Innova.GMantenimiento.Infraestructure.Data;
using Innova.GMantenimiento.Infraestructure.Data.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innova.GMantenimiento.Domain
{
    public class BL_SolAdquisicion
    {
        public List<ItemSolAdquisicion> Lista(int? CodigoSolicitudAdquision = null, string Solicitante = null, string Area = null,
                                  string Estado = null, string FechaInicio = null, string FechaFin = null) 
        {
            List<ItemSolAdquisicion> lista = new List<ItemSolAdquisicion>();

            if (CodigoSolicitudAdquision == null && Solicitante == null && Area == null && Estado == null
                && FechaInicio == null && FechaFin == null)
            {
                lista = new List<ItemSolAdquisicion>();
            }
            else
            {
                lista = new DA_SolAdquisicion().Lista();

                List<ItemSolAdquisicion> listaResponse = new List<ItemSolAdquisicion>();

                if (!string.IsNullOrEmpty(FechaInicio))
                {
                    DateTime FecIni = (string.IsNullOrEmpty(FechaInicio) ? DateTime.Now : Convert.ToDateTime(FechaInicio));
                    lista = lista.Where(x => x.FechaEmision >= FecIni).ToList();
                }
                if (!string.IsNullOrEmpty(FechaFin))
                {
                    DateTime FecFin = (string.IsNullOrEmpty(FechaFin) ? DateTime.Now : Convert.ToDateTime(FechaFin));
                    lista = lista.Where(x => x.FechaEmision <= FecFin).ToList();
                }
                if (CodigoSolicitudAdquision != null && CodigoSolicitudAdquision > 0)
                {
                    lista = lista.Where(x => x.CodSolAdquisicion == CodigoSolicitudAdquision).ToList();
                }
                if (!string.IsNullOrEmpty(Solicitante))
                {
                    lista = lista.Where(x => x.Solicitante == Solicitante).ToList();
                }
                if (!string.IsNullOrEmpty(Estado))
                {
                    lista = lista.Where(x => x.Estado == Estado).ToList();
                }
            }

            return lista;
        }
    }
}
