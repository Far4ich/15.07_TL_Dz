using Microsoft.AspNetCore.Mvc;
using MedicineApi.Services;
using MedicineApi.Dto;

namespace MedicineApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class HospitalController : Controller
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetHospitals()
        {
            try
            {
                return Ok(_hospitalService.GetHospitals()
                    .ConvertAll(t => t.ConvertToHospitalDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{hospitalId}")]
        public IActionResult GetHospital(int hospitalId)
        {
            try
            {
                return Ok(_hospitalService.GetHospital(hospitalId).ConvertToHospitalDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateHospital([FromBody] HospitalDto hospital)
        {
            try
            {
                return Ok(_hospitalService.CreateHospital(hospital));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{hospitalId}/delete")]
        public IActionResult DeleteHospital(int hospitalId)
        {
            try
            {
                _hospitalService.DeleteHospital(hospitalId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateHospital([FromBody] HospitalDto hospital)
        {
            try
            {
                return Ok(_hospitalService.UpdateHospital(hospital));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
