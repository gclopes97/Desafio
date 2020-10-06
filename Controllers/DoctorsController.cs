using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioApi.Data;
using DesafioApi.Models;

namespace DesafioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorContext _context;

        public DoctorsController(DoctorContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var result = await _context.Doctors
                .Select(d => new { d.DoctorId, d.Nome, d.Cpf, d.Crm, Sname = d.DoctorSpecialties.Select(s => s.Specialty)})
                .ToListAsync();
            return Ok(result);
        }

        // GET: api/Doctors/ginicologista
        [HttpGet("{Especialidades}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Doctor>> GetDoctor(string Especialidades)
        {
            var doctor = await _context.Doctors
                .Include(s => s.DoctorSpecialties.Select(s => s.Specialty)
                    .Where(x => x.Nome == Especialidades))
                .ToListAsync();

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        
        //// POST: api/Doctors
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Doctors.Add(doctor);
        //    await _context.SaveChangesAsync();
        //    var doctors = _context.DoctorSpecialties.Select(d => d.Doctor);
        //    CreatedAtAction(nameof(GetDoctor), new { id = doctor.DoctorSpecialties }, doctor);

        //    return Ok(doctor.Id);
        //}

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
