using AutoMapper;
using HostelManagement.Data;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
      
        private readonly IHostelService hostelService;

        public HostelsController(IHostelService hostelService)
        {
            this.hostelService = hostelService;
          
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var hostelDto = await hostelService.GetAllAsync();

           
            return Ok(hostelDto);
        }


        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddHostelRequestDto addHostelRequestDto)
        {
            if (ModelState.IsValid)
            {
                //get data from dto
                var hostelDto = await hostelService.Create(addHostelRequestDto);


                return Ok(hostelDto);
            }
            else
                return BadRequest(ModelState);

        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateHostelsDto updateHostelsDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var hostelDto = await hostelService.UpdateAsync(id, updateHostelsDto);


                //dto
                return Ok(hostelDto);
            }

            else
                return BadRequest(ModelState);

        }
    }
}
