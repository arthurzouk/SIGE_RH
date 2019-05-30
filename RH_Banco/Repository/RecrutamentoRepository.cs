using RH_Banco.Context;
using RH_Dominio.Models;

namespace RH_Banco.Repository
{
    public class RecrutamentoRepository : Repository<Recrutamento>
    {
        public RecrutamentoRepository(RecursosHumanosContext context) : base(context)
        {

        }
    }
}
