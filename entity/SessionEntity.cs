using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class SessionEntity
    {
        public string sessionId { get; set; }
        public string username { get; set; }
        public string ressource { get; set; }
        public string node { get; set; }
        public string sessionStatus { get; set; }
        public string presenceStatus { get; set; }
        public string presenceMessage { get; set; }
        public string priority { get; set; }
        public string hostAddress { get; set; }
        public string hostName { get; set; }
        public string creationDate { get; set; }
        public string lastActionDate { get; set; }
        public string secure { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb.Append(sessionId + " ").Append(username + " ").Append(ressource + " ").Append(node + " ")
                .Append(sessionStatus + " ").Append(presenceStatus + " ").Append(presenceMessage + " ")
                .Append(priority + " ").Append(hostAddress + " ").Append(hostName + " ").Append(creationDate + " ")
                .Append(lastActionDate + " ").Append(secure+"\n").ToString();
        }
    }
}
