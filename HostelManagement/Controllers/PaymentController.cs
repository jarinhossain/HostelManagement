using AutoMapper;
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
      

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var paymenttDto = await paymentService.GetAllAsync();


            return Ok(paymenttDto);
        }


        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPaymentRequestDto addPaymentRequestDto)
        {
            if (ModelState.IsValid)
            {


                //get data from dto
                var paymentDto = await paymentService.Create(addPaymentRequestDto);





                return Ok(paymentDto);
            }
            else
                return BadRequest(ModelState);

        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePaymentDto updatePaymentDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var paymentDto = await paymentService.UpdateAsync(id, updatePaymentDto);


                //dto
                return Ok(paymentDto);
            }

            else
                return BadRequest(ModelState);

        }
    }
}
