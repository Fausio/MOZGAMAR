using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MOZGAMAR.Models
{
    public class Shipping
    {
        public int ShippingDetaisId { get; set; }
        [Required]
        public Nullable<int> MemberId { get; set; }
        [Required]
        public string Addres { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Sate { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<decimal> AmoutPaId { get; set; }
        [Required]
        public string PaymentType { get; set; }
    }
}