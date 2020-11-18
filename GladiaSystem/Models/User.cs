using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace GladiaSystem.Models
{
    public class User
    {

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Insira um nome válido")]
        public string name { get; set;}

        [Display(Name = "Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Insira um email válido")]
        [Required(ErrorMessage = "O Email é obrigatório!")]
        [Remote("EmailUnic", "home", ErrorMessage = "Este E-mail já está cadastrado")]
        public string email{ get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A Senha é obrigatória!")]
        [RegularExpression(@"([a-zA-Z]{1,})([@$!%*#?&]{1,})([0-9]{1,})", ErrorMessage = "Insira uma senha válida")]
        public string password{ get; set; }

     
        public string img { get; set; }

        
        public int lvl{ get; set; }
    }
}