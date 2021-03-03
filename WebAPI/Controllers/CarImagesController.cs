using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        #region HTTPGet

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        #endregion


        #region HTTPPost

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImages)
        {
            var result = _carImageService.Add(file, carImages);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImages)
        {
            var result = _carImageService.Update(file, carImages);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carImageService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        #endregion
    }
}
