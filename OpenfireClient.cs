using OpenfireAPI.util;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI
{
    class OpenfireClient
    {
        private RestClient restClient;
        private string openfirePlugin;
        public OpenfireClient(string url, int port, OpenfireAuthenticator authenticator)
        {
            restClient = new RestClient(url+":"+port.ToString());
            restClient.Authenticator = authenticator;
            openfirePlugin = "/plugins/restapi/v1/";
        }

        public IRestResponse get(string restPath, Dictionary<string, string> queryParams)
        {
            return call(Method.GET, restPath, null, queryParams);
        }

        public IRestResponse post(string restPath, object payload, Dictionary<string, string> queryParams)
        {
            return call(Method.POST, restPath, payload, queryParams);
        }

        public IRestResponse put(string restPath, object payload, Dictionary<string, string> queryParams)
        {
            return call(Method.PUT, restPath, payload, queryParams);
        }

        public IRestResponse delete(string restPath, object payload, Dictionary<string, string> queryParams)
        {
            return call(Method.DELETE, restPath, payload, queryParams);
        }

        private IRestResponse call(Method method, string restPath, object payload, Dictionary<string, string> queryParams)
        {
            var request = new RestRequest(openfirePlugin+restPath, method);
            foreach (KeyValuePair<string, string> entry in queryParams)
            {
                request.AddParameter(entry.Key, entry.Value);
            }
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");

            if (payload != null)
            {
                request.AddHeader("Content-Type", "application/json");
                request.JsonSerializer = new RestSharpJsonNetSerializer();
                request.AddJsonBody(payload);
            }
            return restClient.Execute(request);
        }

        public bool isStatusCodeOK(IRestResponse response)
        {
            //Console.WriteLine(response.StatusCode);
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }


    }

}
