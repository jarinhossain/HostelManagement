using AutoMapper;
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var invoiceDto = await invoiceService.GetAllAsync();


            return Ok(invoiceDto);
        }

        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddInvoiceRequestDto addInvoiceRequestDto)
        {
            if (ModelState.IsValid)
            {
                //get data from dto
                var invoiceDto = await invoiceService.Create(addInvoiceRequestDto);

                return Ok(invoiceDto);
            }

            else
                return BadRequest(ModelState);

        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateInvoiceDto updateInvoiceDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var invoiceDto = await invoiceService.UpdateAsync(id, updateInvoiceDto);


                //dto
                return Ok(invoiceDto);
            }

            else
                return BadRequest(ModelState);

        }
    }
}
