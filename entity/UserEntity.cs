using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class UserEntity
    {
        public string username{ get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<UserProperty> properties { get; set; }
    }
}
