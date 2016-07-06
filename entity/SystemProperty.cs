using Newtonsoft.Json;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class SystemProperty
    {
        [JsonProperty("@key")]
        [DeserializeAs(Name = "@key")]
        public string key { get; set; }
        [JsonProperty("@value")]
        [DeserializeAs(Name = "@value")]
        public string value { get; set; }

        public override string ToString()
        {
            return "key: " + key + " ,value: " + value + "\n";
        }
    }
}
