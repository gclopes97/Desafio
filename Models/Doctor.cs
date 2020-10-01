using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioApi.Models
{
    public class Doctor
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio.")]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatorio.")]
        [DisplayFormat(DataFormatString = "{0:000\\.000\\.000-00}", ApplyFormatInEditMode = true)]
        public string Cpf { get; set; }

        [Required]
        public string Crm { get; set; }

        [MinLength(1)]
        public string[] Especialidades { get; set; }
    }
}
