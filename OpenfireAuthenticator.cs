using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace OpenfireTest.OpenfireAPI
{
    class OpenfireAuthenticator : IAuthenticator
    {
        private string _sharedKey;

        public OpenfireAuthenticator(string sharedKey) {
            _sharedKey = sharedKey;
        }
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader("Authorization", _sharedKey);
        }
    }
}
