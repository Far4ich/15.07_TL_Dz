using Microsoft.AspNetCore.Mvc;
using MedicineApi.Services;
using MedicineApi.Dto;

namespace MedicineApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService hospitalService)
        {
            _doctorService = hospitalService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetTodos()
        {
            try
            {
                return Ok(_doctorService.GetDoctors()
                    .ConvertAll(t => t.ConvertToDoctorDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{doctorId}")]
        public IActionResult GetDoctor(int doctorId)
        {
            try
            {
                return Ok(_doctorService.GetDoctor(doctorId).ConvertToDoctorDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateDoctor([FromBody] DoctorDto doctor)
        {
            try
            {
                return Ok(_doctorService.CreateDoctor(doctor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{doctorId}/delete")]
        public IActionResult DeleteDoctor(int doctorId)
        {
            try
            {
                _doctorService.DeleteDoctor(doctorId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateDoctor([FromBody] DoctorDto doctor)
        {
            try
            {
                _doctorService.UpdateDoctor(doctor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
