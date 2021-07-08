using System;
using System.ComponentModel.DataAnnotations;

namespace BoxTI.Challenge.Medical.API.Models.Entities
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Idade { get; set; }

        [Required]     
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Required]
        [Display(Name ="Tipo Sanguínio")]
        [MaxLength(3)]
        public string TipoSanguinio { get; set; }

    }
}
