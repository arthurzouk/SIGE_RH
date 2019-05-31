using RH_Banco.Context;
using RH_Banco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH_Application.AppServices
{
    public class DemissaoAppService
    {
        private DemissaoRepository _demissaoRepository;

        public DemissaoAppService(RecursosHumanosContext context)
        {
            _demissaoRepository = new DemissaoRepository(context);
        }
    }
}
