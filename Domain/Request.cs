using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Request
    {
        public int requestId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal InitialPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }



    }
}
