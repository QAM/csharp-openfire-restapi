using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class RosterEntity
    {
        public string jid { get; set; }
        public string nickname { get; set; }
        public string subscribtionType { get; set; }
        public List<RosterGroup> groups { get; set; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            if (jid != null) sb.Append(jid + " ");
            if (nickname != null) sb.Append(nickname + " ");
            if (subscribtionType != null) sb.Append(nickname + " ");
            if (groups != null) {
                sb.Append("gropus: ");
                foreach (RosterGroup group in groups) sb.Append(group.ToString() + " ,");
            }
            return sb.ToString();
            //return String.Format("jid: {0}, nickname:{1}, subtype:{2}, goups:{3}", jid, nickname, subscribtionType, groups.ToString());
        }
    }
}
