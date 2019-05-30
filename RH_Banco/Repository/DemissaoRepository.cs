using RH_Banco.Context;
using RH_Dominio.Models;

namespace RH_Banco.Repository
{
    public class DemissaoRepository : Repository<Demissao>
    {
        public DemissaoRepository(RecursosHumanosContext context) : base(context)
        {

        }
    }
}
