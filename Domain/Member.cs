using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Fistname { get; set; }
        public string lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
         
        public virtual ICollection<ShippingDetails> ShippingDetais { get; set; }
    }
}
