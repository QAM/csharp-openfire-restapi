using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class SystemProperties
    {
        public List<SystemProperty> property { get; set; }
        public override string ToString()
        {
            if (property == null) return "";
            else {
                StringBuilder sb = new StringBuilder();
                foreach (SystemProperty sp in property) {
                    sb.Append(sp.ToString());
                }
                return sb.ToString();
            }
        }
    }
}
