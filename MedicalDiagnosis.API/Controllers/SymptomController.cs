using MedicalDiagnosis.Domain.Entities;
using MedicalDiagnosis.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalDiagnosis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomController : ControllerBase
    {
        private readonly MedicalDbContext _context;

        public SymptomController(MedicalDbContext context)
        {
            _context = context;
        }

        // GET: api/Symptom
        [HttpGet("AllSymptoms")]
        public async Task<IActionResult> GetAll()
        {
            var symptoms = await _context.Symptoms.ToListAsync();
            return Ok(symptoms);
        }

        // GET: api/Symptom/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null)
                return NotFound();

            return Ok(symptom);
        }

        // POST: api/Symptom
        [HttpPost]
        public async Task<IActionResult> Create(Symptom symptom)
        {
            if (symptom == null)
                return BadRequest("Symptom cannot be null");

            _context.Symptoms.Add(symptom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = symptom.Id }, symptom);
        }

        // DELETE: api/Symptom/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var symptom = await _context.Symptoms.FindAsync(id);
            if (symptom == null)
                return NotFound();

            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
        