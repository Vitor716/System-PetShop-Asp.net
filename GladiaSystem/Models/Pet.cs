using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GladiaSystem.Models
{
    public class Pet
    {
        [Required(ErrorMessage = "O campo nome do pet é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo nome do dono é obrigatório")]
        public string Owner { get; set; }

        [Display(Name = "Celular (xx xxxx-xxxx)")]
        [Required(ErrorMessage = "O campo celular é obrigatório")]
        public string Tell { get; set; }

        [Required(ErrorMessage = "O campo tamanho é obrigatório")]
        public string Size { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Desc { get; set; }
    }
}