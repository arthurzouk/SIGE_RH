using RestSharp;
using System.Collections.Generic;

namespace Services_API.Producao
{
    public class Producao
    {
        private RestClient client = new RestClient(ApiUrl);

        static private string apiUrl = "https://webapiproducaov3.azurewebsites.net";

        static public string ApiUrl
        {
            get
            {
                return apiUrl;
            }
            set
            {
                apiUrl = value;
            }
        }

        public IRestResponse Get(string resource)
        {
            return Get(resource, new List<Parameter>());
        }

        public IRestResponse Get(string resource, List<Parameter> param)
        {
            var request = new RestRequest(resource, Method.GET);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "=" + p.Value + "");
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + string.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);


            return response;
        }

        public IRestResponse Post(string resource, List<Parameter> param, object body)
        {
            var request = new RestRequest(resource, Method.POST);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "=" + p.Value + "");
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + string.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(body);

            var response = ExecuteRequest(request);



            return response;
        }

        public IRestResponse Put(string resource, List<Parameter> param, object body)
        {
            var request = new RestRequest(resource, Method.PUT);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "=" + p.Value + "");
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + string.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(body);

            var response = ExecuteRequest(request);



            return response;
        }

        public IRestResponse Delete(string resource, List<Parameter> param)
        {
            var request = new RestRequest(resource, Method.DELETE);
            List<string> names = new List<string>();
            foreach (Parameter p in param)
            {
                names.Add(p.Name + "=" + p.Value + "");
                p.Type = ParameterType.UrlSegment;
                request.AddParameter(p);
            }

            request.Resource = resource + "?" + string.Join("&", names.ToArray());

            request.AddHeader("Accept", "application/json");

            var response = ExecuteRequest(request);


            return response;
        }

        private IRestResponse ExecuteRequest(RestRequest request)
        {
            client.UserAgent = "Producao";
            return client.Execute(request);
        }
    }
}
