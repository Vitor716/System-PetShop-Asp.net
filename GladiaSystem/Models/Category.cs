using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;

namespace GladiaSystem.Models
{
    public class Category
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Insira um nome válido")]
        public string name { get; set; }
    }
}