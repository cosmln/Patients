using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientApp.Application.DTOs;
using PatientApp.Application.Interfaces;

namespace PatientApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients(int page = 1, int pageSize = 10)
        {
            var (patients, totalCount) = await _patientService.GetPatientsAsync(page, pageSize);
            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PatientDto>>> SearchPatients(string query)
        {
            var patients = await _patientService.SearchPatientsAsync(query);
            return Ok(patients);
        }
    }
}
