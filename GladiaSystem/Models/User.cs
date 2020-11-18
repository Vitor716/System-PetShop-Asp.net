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

        [Required(ErrorMessage = "O Nome é obrigatório!")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Insira um nome válido")]
        public string name { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Insira um email válido")]
        [Required(ErrorMessage = "O Email é obrigatório!")]
        public string email{ get; set; }

        [RegularExpression(@"([a-zA-Z]{1,})([@$!%*#?&]{1,})([0-9]{1,})", ErrorMessage = "Insira uma senha válida")]
        [Required(ErrorMessage = "A Senha é obrigatória!")]
        public string password{ get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória!")]
        public string userLvl { get; set; }
    }
}