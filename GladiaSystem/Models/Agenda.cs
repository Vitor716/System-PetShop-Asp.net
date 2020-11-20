using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GladiaSystem.Models
{
    public class Agenda
    {
        [Required(ErrorMessage = "O campo nome do cliente é obrigatório")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "O campo pet é obrigatório")]
        public string Pet { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Desc { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "O campo de Data é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? Day { get; set; }

        [Required(ErrorMessage = "O campo hora é obrigatório")]
        [DataType(DataType.Time)]
        public DateTime Hour { get; set; }
    }
}