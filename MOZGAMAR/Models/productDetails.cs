using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOZGAMAR.Models
{
    public class productDetails
    {
        public int PoductId { get; set; }
        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter no maximo 100 caracteres e no minimo 3", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [Range(1, 50)]
        public Nullable<int> CategoryId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> ISDelete { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [Required(ErrorMessage = "A descrição do produto é obrigatório")]
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public Nullable<bool> IsFeatured { get; set; }
        [Range(typeof(decimal), "1", "500", ErrorMessage = "Quantidade invalida")]
        public Nullable<int> Quantity { get; set; }
        [Range(typeof(decimal), "1", "200000", ErrorMessage = "Preço invalido")]
        public Nullable<decimal> Price { get; set; }
        public SelectList Categories { get; set; }
    }

}