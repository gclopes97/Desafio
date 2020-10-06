using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioApi.Models
{
    public class DoctorSpecialty
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int SpecialtiesId { get; set; }
        public Specialty Specialty { get; set; }
    }
}
