using RH_Banco.Context;
using RH_Banco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_Application.AppServices
{
    public class RecrutamentoAppService
    {
        private RecrutamentoRepository _recrutamentoRepository;

        public RecrutamentoAppService(RecursosHumanosContext context)
        {
            _recrutamentoRepository = new RecrutamentoRepository(context);
        }
    }
}
