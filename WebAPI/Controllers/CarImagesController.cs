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
        private ICarImagesService _carImagesService;

        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }




        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImagesService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, CarImages carImages)
        {
            var result = _carImagesService.Add(file ,carImages);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, CarImages carImages)
        {
            var result = _carImagesService.Update(file,carImages);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carImagesService.Delete(id);
            
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
