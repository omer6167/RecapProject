using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [HttpGet]
        public IActionResult GetALl()
        {
            var result = _paymentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        
        [HttpPost("pay")]
        public IActionResult MakePayment(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success) return Ok(result);

            return BadRequest();
        }
        
       
    }

}

