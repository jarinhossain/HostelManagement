using AutoMapper;
using HostelManagement.Models.DTO;
using HostelManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;

        public RoomController(IRoomService roomService,IMapper mapper)
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get data from databae domain models
            var roomDto = await roomService.GetAllAsync();


            return Ok(roomDto);
        }



        ////create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRoomRequestDto addRoomRequestDto)
        {
            if (ModelState.IsValid)
            {


                //get data from dto
                var roomDto = await roomService.Create(addRoomRequestDto);





                return Ok(roomDto);
            }
            else
                return BadRequest(ModelState);



        }





        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRoomDto updateRoomDto)
        {
            if (ModelState.IsValid)
            {

                //get data from dto

                var roomDto = await roomService.UpdateAsync(id, updateRoomDto);


                //dto
                return Ok(roomDto);
            }

            else
                return BadRequest(ModelState);

        }

    }
}
