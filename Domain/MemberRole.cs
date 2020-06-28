using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MemberRole
    {
        public int MemberRoleId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> RoleId { get; set; }
    }
}
