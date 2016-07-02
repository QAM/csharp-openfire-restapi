using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireTest.OpenfireAPI
{
    class OpenfireClient
    {
        private RestClient restClient;
        private string openfirePlugin;
        public OpenfireClient(string url, int port, HttpBasicAuthenticator authenticator = null, string sharedKey = "")
        {
            restClient = new RestClient(url+":"+port.ToString());
            if (authenticator == null) restClient.Authenticator = new OpenfireAuthenticator(sharedKey);
            else restClient.Authenticator = authenticator;

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

        public IRestResponse delete(string restPath, Dictionary<string, string> queryParams)
        {
            return call(Method.DELETE, restPath, null, queryParams);
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
                request.AddJsonBody(payload);
            }
            return restClient.Execute(request);
        }

        public bool isStatusCodeOK(IRestResponse response)
        {
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }


    }

}
