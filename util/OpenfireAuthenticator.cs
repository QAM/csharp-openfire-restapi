using RestSharp.Authenticators;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace OpenfireAPI.util
{
    class OpenfireAuthenticator : IAuthenticator
    {
        private readonly string _sharedKey;
        private readonly string authHeader;
        private AuthenticationMode mode;

        public OpenfireAuthenticator(string sharedKey) {
            _sharedKey = sharedKey;
            mode = AuthenticationMode.SHARED_SECRET_KEY;
        }

        public OpenfireAuthenticator(string username, string password) {
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password)));
            authHeader = string.Format("Basic {0}", token);
            mode = AuthenticationMode.BASIC_AUTH;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (mode == AuthenticationMode.SHARED_SECRET_KEY)
                request.AddHeader("Authorization", _sharedKey);
            else
            {
                if (!request.Parameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
                {
                    request.AddParameter("Authorization", this.authHeader, ParameterType.HttpHeader);
                }
            }
        }

    }
}
