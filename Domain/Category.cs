using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> ISDelete { get; set; }
    }
}
