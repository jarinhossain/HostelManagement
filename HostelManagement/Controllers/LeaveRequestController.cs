using AutoMapper;
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            this.leaveRequestService = leaveRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var leaveRequestDto = await leaveRequestService.GetAllAsync();


            return Ok(leaveRequestDto);
        }

        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddLeaveRequestDto addLeaveRequestDto)
        {
            if (ModelState.IsValid)
            {


                //get data from dto
                var leaveRequestDto = await leaveRequestService.Create(addLeaveRequestDto);





                return Ok(leaveRequestDto);
            }
            else
                return BadRequest(ModelState);

        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var leaveDto = await leaveRequestService.UpdateAsync(id, updateLeaveRequestDto);


                //dto
                return Ok(leaveDto);
            }

            else
                return BadRequest(ModelState);

        }
    }
}
