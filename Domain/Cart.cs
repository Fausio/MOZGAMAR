using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Cart
    {
        public int CartId { get; set; }
        public Nullable<int> PoductId { get; set; }
        public Nullable<int> MemberID { get; set; }
        public Nullable<int> CarStatusId { get; set; }

        public virtual Product Poduct { get; set; }
    }
}
