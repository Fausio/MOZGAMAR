using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="Nome" )]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> ISDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(150)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Imagem")]
        public string ProductImage { get; set; }

        [Display(Name = "Esta disponivel ?")]
        public bool IsAvailable { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }
        public Nullable<int> Quantity { get; set; }

        [Display(Name = "É  novo ?")]
        public bool IsNew { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual Category Category { get; set; }
    }
}
