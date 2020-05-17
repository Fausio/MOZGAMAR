using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MOZGAMAR.Models
{
    public class CategoryDetails
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Nome da categoria é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da categoria deve ter no maximo 100 caracteres e no minimo 3", MinimumLength = 3)]
        public string Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> ISDelete { get; set; }
    }

}