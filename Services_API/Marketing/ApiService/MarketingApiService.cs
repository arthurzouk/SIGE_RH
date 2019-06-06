using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using RH_Dominio.DTO;

namespace Services_API.Marketing.ApiService
{
    public class MarketingApiService
    {
        protected Marketing marketing;

        public MarketingApiService()
        {
            marketing = new Marketing();
        }

        // Trocar object pela classe de retorno
        public List<ItemPromocaoMarketingDTO> ObterListaProdutos()
        {
            // Recurso ofericido pela API
            var resource = "/api/integracoes";

            // Parâmetros a serem adicionados no recurso
            var p = new Parameter { Name = "nomeDoParametro", Value = "valorDoParametro" };

            // Podemos adicionar quanntos parâmetros forem necessários nessa lista
            List<Parameter> param = new List<Parameter>
            {
                p
            };

            // Uso do SDK para chamadas HTTP
            var resposta = marketing.Get(resource);

            if (resposta.StatusCode.Equals(HttpStatusCode.OK))
            {
                // O segundo parâmetro deve ser criado usando os mesmos nomes que são retornados pelo JSON. Resposta.Content é o JSON que é retornado da API.
                var objetoDeRetorno = JsonConvert.DeserializeObject<List<ItemPromocaoMarketingDTO>>(resposta.Content);

                return objetoDeRetorno;
            }

            throw new Exception("Não foi possível fazer a chamada na API do Marketing para item em promoção");
        }
    }
}
