using OpenfireTest.OpenfireAPI.entity;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace OpenfireTest.OpenfireAPI
{
    class OpenfireAPIClient
    {
        private OpenfireClient client;
        private JsonDeserializer deserial;
        public OpenfireAPIClient(string url, int port, HttpBasicAuthenticator authenticator = null, string sharedKey="") {
            client = new OpenfireClient(url, port, authenticator, sharedKey);
            deserial = new JsonDeserializer();
        }

        public UserEntities getUsers()
        {
            IRestResponse response = client.get("users", new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<UserEntities>(response) : null;
        }

        public UserEntity getUser(string username) {
            IRestResponse response = client.get("users/"+username, new Dictionary<string, string>());
            return client.isStatusCodeOK(response) ? deserial.Deserialize<UserEntity>(response) : null;
        }

        public bool createUser(UserEntity userEntity)
        {
            return client.isStatusCodeOK(client.post("users", userEntity, new Dictionary<string, string>()));
        }
    }
}
