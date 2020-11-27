using System;
using System.ComponentModel.DataAnnotations;

namespace GladiaSystem.Models
{
    public class Agenda
    {

        public int ID { get; set; }

        [Display(Name = "Nome do cliente")]
        [Required(ErrorMessage = "O campo nome do cliente é obrigatório")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "O campo pet é obrigatório")]
        public string Pet { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string DescAgenda { get; set; }

        [Display(Name = "Dia")]
        [Required(ErrorMessage = "O campo de Data é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime? Day { get; set; }

        [Display(Name = "Hora")]
        [Required(ErrorMessage = "O campo hora é obrigatório")]
        [DataType(DataType.Time)]
        public DateTime Hour { get; set; }


    }
}