using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalsService;

        public RentalsController(IRentalService rentalsService)
        {
            _rentalsService = rentalsService;
        }

        #region HTTPGet

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("isrentable")]
        public IActionResult IsRentable(int carId)  // Success verisine erişilmek istendiği için BadRequest Döndürülmemeli
        {
            var result = _rentalsService.IsRentable(carId);
            
                
            return Ok(result);
            

            //return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpGet("getdetails")]
        public IActionResult GetRentalsDetails()
        {
            var result = _rentalsService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        #endregion

        [HttpPost("rent")]
        public IActionResult Rent(Rental rentals)
        {
            var result = _rentalsService.Rent(rentals);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("return")]
        public IActionResult UpdateReturn(int carId)
        {
            var result = _rentalsService.UpdateReturnDate(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rentals)
        {
            var result = _rentalsService.Delete(rentals);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
