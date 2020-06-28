using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ShippingDetails
    {
        public int ShippingDetailsId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string Addres { get; set; }
        public string City { get; set; }
        public string Sate { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> AmoutPaId { get; set; }
        public string PaymentType { get; set; }

        public virtual Member Member { get; set; }
    }
}
