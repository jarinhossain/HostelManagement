using AutoMapper;
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }


        //for getAll method

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var buildingDto = await buildingService.GetAllAsync();


            return Ok(buildingDto);
        }


        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddBuildingRequestDto addBuildingRequestDto)
        {
            if (ModelState.IsValid)
            {


                //get data from dto
                var buildingDto = await buildingService.Create(addBuildingRequestDto);





                return Ok(buildingDto);
            }
            else
                return BadRequest(ModelState);

        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBuildingDto updateBuildingDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var buildingDto = await buildingService.UpdateAsync(id, updateBuildingDto);


                //dto
                return Ok(buildingDto);
            }

            else
                return BadRequest(ModelState);

        }

    }
}
