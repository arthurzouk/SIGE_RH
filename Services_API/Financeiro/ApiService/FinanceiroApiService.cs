using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using RH_Dominio.DTO;

namespace Services_API.Financeiro.ApiService
{
    public class FinanceiroApiService
    {
        protected Financeiro financeiro;

        public FinanceiroApiService()
        {
            financeiro = new Financeiro();
        }

        // Trocar object pela classe de retorno
        public List<LucroPorProdutoFinanceiroDTO> ObterLucroPorProduto()
        {
            // Recurso ofericido pela API
            var resource = "/Financeiro/LucroPorProduto";

            // Parâmetros a serem adicionados no recurso
            var p = new Parameter { Name = "nomeDoParametro", Value = "valorDoParametro" };

            // Podemos adicionar quanntos parâmetros forem necessários nessa lista
            List<Parameter> param = new List<Parameter>
            {
                p
            };

            // Uso do SDK para chamadas HTTP
            var resposta = financeiro.Get(resource, param);

            if (resposta.StatusCode.Equals(HttpStatusCode.OK))
            {
                // O segundo parâmetro deve ser criado usando os mesmos nomes que são retornados pelo JSON. Resposta.Content é o JSON que é retornado da API.
                var objetoDeRetorno = JsonConvert.DeserializeObject<List<LucroPorProdutoFinanceiroDTO>>(resposta.Content);

                return objetoDeRetorno;
            }

            throw new Exception("Não foi possível fazer a chamada na API do Financeiro");
        }
    }
}
