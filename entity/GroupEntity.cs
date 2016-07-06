using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class GroupEntity
    {
        public string name { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return "name: " + name + ", description: " + description+"\n";
        }
    }
}
