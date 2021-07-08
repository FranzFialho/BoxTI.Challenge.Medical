using System;
using System.ComponentModel.DataAnnotations;

namespace BoxTI.Challenge.Medical.API.Models.Entities
{
    public class Medico
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Especialidade { get; set; }

        [Required]
        public string CRM { get; set; }


    }
}
