using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Services_API.Financeiro.ApiService
{
    public class ExemploApiService
    {
        protected Financeiro financeiro;

        public ExemploApiService()
        {
            financeiro = new Financeiro();
        }

        // Trocar object pela classe de retorno
        public object ObterExemplo()
        {
            // Recurso ofericido pela API
            var resource = "/exemplo/exemplo";

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
                var objetoAnonimo = JsonConvert.DeserializeAnonymousType(resposta.Content, new
                {
                    id = new long(),
                    nickName = "",
                    registration_date = new DateTime(),
                    first_name = "",
                    last_name = "",
                    gender = "",
                    contry_Id = "",
                    email = ""
                });

                var objetoDeRetorno = new object()
                {
                    // Preencher aqui o objeto de retorno com as informações deserializadas no objeto anônimo
                    // Ex: objetoDeRetorno.atributo = objetoAnonimo.informacao;
                };
                return objetoDeRetorno;
            }
            else if (resposta.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                if (resposta.Content.Contains("Blablabla"))
                {
                    return new object();
                }
            }

            throw new Exception("Não foi possível fazer a chamada na API do Financeiro");
        }
    }
}
