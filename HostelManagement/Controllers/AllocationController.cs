using AutoMapper;
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationController : ControllerBase
    {
        private readonly IAllocationService allocationService;

        public AllocationController(IAllocationService allocationService)
        {
            this.allocationService = allocationService;
        }




        //for getAll method

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from dto
            var allocationDto = await allocationService.GetAllAsync();


            return Ok(allocationDto);
        }


        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddAllocationRequestDto addAllocationRequestDto)
        {
            if (ModelState.IsValid)
            {


                //get data from dto
                var allocationDto = await allocationService.Create(addAllocationRequestDto);


               
                return Ok(allocationDto);
            }
            else
                return BadRequest(ModelState);

        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAllocationDto updateAllocationDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var allocationDto = await allocationService.UpdateAsync(id, updateAllocationDto);


                //dto
                return Ok(allocationDto);
            }

            else
                return BadRequest(ModelState);

        }



        //delete
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var allocationDto = await allocationService.DeleteAsync(id);

            if (allocationDto == null)
            {
                return NotFound();
            }

            return Ok(allocationDto);
        }

    }
}
