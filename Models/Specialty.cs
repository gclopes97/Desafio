using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioApi.Models
{
    public class Specialty
    {
        [Required]
        public int SpecialtyId { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        public IEnumerable<DoctorSpecialty> DoctorSpecialties { get; set; }
    }
}
