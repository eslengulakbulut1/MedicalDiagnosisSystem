using MedicalDiagnosis.Application.DTOs;
using MedicalDiagnosis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDiagnosis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosisController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public DiagnosisController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public IActionResult Diagnose([FromBody] DiagnosisRequestDto input)
        {
            if (input is null) return BadRequest("Request body is required.");
            var result = _patientService.Diagnose(input);
            return Ok(result);
        }
    }
}
    