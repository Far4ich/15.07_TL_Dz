using Microsoft.AspNetCore.Mvc;
using MedicineApi.Services;
using MedicineApi.Dto;

namespace MedicineApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class PatientController:Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetPatients()
        {
            try
            {
                return Ok(_patientService.GetPatients()
                    .ConvertAll(t => t.ConvertToPatientDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{patientId}")]
        public IActionResult GetPatient(int patientId)
        {
            try
            {
                return Ok(_patientService.GetPatient(patientId).ConvertToPatientDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateHospital([FromBody] PatientDto patient)
        {
            try
            {
                return Ok(_patientService.CreatePatient(patient));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{patientId}/delete")]
        public IActionResult DeletePatient(int patientId)
        {
            try
            {
                _patientService.DeletePatient(patientId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdatePatient([FromBody] PatientDto patient)
        {
            try
            {
                _patientService.UpdatePatient(patient);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
