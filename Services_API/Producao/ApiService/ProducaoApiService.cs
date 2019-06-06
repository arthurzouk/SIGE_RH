using Newtonsoft.Json;
using RestSharp;
using RH_Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Net;

namespace Services_API.Producao.ApiService
{
    public class ProducaoApiService
    {
        protected Producao producao;

        public ProducaoApiService()
        {
            producao = new Producao();
        }

        // Trocar object pela classe de retorno
        public List<ItemProducaoDTO> ObterListaProdutos()
        {
            // Recurso ofericido pela API
            var resource = "/api/item";

            // Parâmetros a serem adicionados no recurso
            var p = new Parameter { Name = "nomeDoParametro", Value = "valorDoParametro" };

            // Podemos adicionar quanntos parâmetros forem necessários nessa lista
            List<Parameter> param = new List<Parameter>
            {
                p
            };

            // Uso do SDK para chamadas HTTP
            var resposta = producao.Get(resource);

            if (resposta.StatusCode.Equals(HttpStatusCode.OK))
            {
                // O segundo parâmetro deve ser criado usando os mesmos nomes que são retornados pelo JSON. Resposta.Content é o JSON que é retornado da API.
                var objetoDeRetorno = JsonConvert.DeserializeObject<List<ItemProducaoDTO>>(resposta.Content);
                
                return objetoDeRetorno;
            }

            throw new Exception("Não foi possível fazer a chamada na API do Producao para item do produto");
        }

        public List<VendaProducaoDTO> ObterListaVendas()
        {
            // Recurso ofericido pela API
            var resource = "/api/vendas";

            // Parâmetros a serem adicionados no recurso
            var p = new Parameter { Name = "nomeDoParametro", Value = "valorDoParametro" };

            // Podemos adicionar quanntos parâmetros forem necessários nessa lista
            List<Parameter> param = new List<Parameter>
            {
                p
            };

            // Uso do SDK para chamadas HTTP
            var resposta = producao.Get(resource);

            if (resposta.StatusCode.Equals(HttpStatusCode.OK))
            {
                // O segundo parâmetro deve ser criado usando os mesmos nomes que são retornados pelo JSON. Resposta.Content é o JSON que é retornado da API.
                var objetoDeRetorno = JsonConvert.DeserializeObject<List<VendaProducaoDTO>>(resposta.Content);

                return objetoDeRetorno;
            }

            throw new Exception("Não foi possível fazer a chamada na API do Producao para vendas");
        }
    }
}
