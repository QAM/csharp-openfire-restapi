using OpenfireAPI.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenfireAPI.entity
{
    class GroupEntities
    {
        public List<GroupEntity> group { get; set; }
        public override string ToString()
        {
            if (group == null) return "";
            else {
                StringBuilder sb = new StringBuilder();
                foreach(GroupEntity ge in group)
                {
                    sb.Append(ge.ToString());
                }
                return sb.ToString();
            }
        }
    }
}
