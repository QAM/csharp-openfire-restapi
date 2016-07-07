using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class MessageEntity
    {
        public string body { get; set; }
        public override string ToString()
        {
            return body;
        }
    }
}
