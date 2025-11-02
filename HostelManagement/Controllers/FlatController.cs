using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly IFlatService flatService;

        public FlatController(IFlatService flatService)
        {
            this.flatService = flatService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var flatDto = await flatService.GetAllAsync();


            return Ok(flatDto);
        }

        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddFlatRequestDto addFlatRequestDto)
        {
            if (ModelState.IsValid)
            {
                //get data from dto
                var flatDto = await flatService.Create(addFlatRequestDto);

                return Ok(flatDto);
            }

            else
                return BadRequest(ModelState);

        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateFlatDto updateFlatDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var flatDto = await flatService.UpdateAsync(id, updateFlatDto);


                //dto
                return Ok(flatDto);
            }

            else
                return BadRequest(ModelState);

        }
    }
}
