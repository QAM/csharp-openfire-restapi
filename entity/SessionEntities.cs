using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class SessionEntities
    {
        public List<SessionEntity> session { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SessionEntity se in session) {
                sb.Append(se.ToString());
            }
            return sb.ToString();
        }
    }
}
