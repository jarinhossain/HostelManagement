
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeePlanController : ControllerBase
    {
        private readonly IFeePlanService feePlanService;

        public FeePlanController(IFeePlanService feePlanService)
        {
            this.feePlanService = feePlanService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var feePlanDto = await feePlanService.GetAllAsync();


            return Ok(feePlanDto);
        }


        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddFeePlanRequestDto addFeePlanRequestDto)
        {
            if (ModelState.IsValid)
            {


                //get data from dto
                var feePlanDto = await feePlanService.Create(addFeePlanRequestDto);





                return Ok(feePlanDto);
            }
            else
                return BadRequest(ModelState);

        }




        //update
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateFeePlanDto updateFeePlanDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var feePlanDto = await feePlanService.UpdateAsync(id, updateFeePlanDto);


                //dto
                return Ok(feePlanDto);
            }

            else
                return BadRequest(ModelState);

        }
    }
}
