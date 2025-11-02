using AutoMapper;
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService residentService;
        private readonly IMapper mapper;

        public ResidentController(IResidentService residentService,IMapper mapper)
        {
            this.residentService = residentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var residentDto = await residentService.GetAllAsync();


            return Ok(residentDto);
        }


        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddResidentRequestDto addResidentRequestDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto
                var residentDto = await residentService.Create(addResidentRequestDto);


                return Ok(residentDto);
            }
            else
                return BadRequest(ModelState);

        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateResidentDto updateResidentDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var residentDto = await residentService.UpdateAsync(id, updateResidentDto);


                //dto
                return Ok(residentDto);
            }

            else
                return BadRequest(ModelState);

        }
    }
}
