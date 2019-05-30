using RH_Banco.Context;
using RH_Dominio.Models;

namespace RH_Banco.Repository
{
    public class PessoaCurriculoRepository : Repository<PessoaCurriculo>
    {
        public PessoaCurriculoRepository(RecursosHumanosContext context) : base(context)
        {

        }

        public PessoaCurriculo ObterPorCpf(string cpf)
        {
            return ObterPrimeiroOuPadrao(x => x.CPF == cpf);
        }
    }
}
