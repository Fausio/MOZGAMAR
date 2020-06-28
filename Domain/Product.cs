using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(30)]
        [Display(Name ="Nome" )]
        public string Name { get; set; }

        [StringLength(30)]
        [Display(Name = "Marca")]
        public string Brand { get; set; }
        public Nullable<int> CategoryId { get; set; }

        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> ISDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Display(Name = "Descrição")]

        [StringLength(150)]
        public string Description { get; set; }
        [Display(Name = "Imagem")]
        public string ProductImage { get; set; }

        [Display(Name = "Esta disponivel ?")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Preço")]
        public decimal Price { get; set; }
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "É  novo ?")]
        public bool IsNew { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual Category Category { get; set; }
    }
}
