using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;

        public RoomService(IRoomRepository roomRepository,IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            //get data from database domain models
            var roomDomain = await roomRepository.GetAllAsync();

            return mapper.Map<List<RoomDto>>(roomDomain);
        }



        public async Task<ApiResponse> Create(AddRoomRequestDto addRoomRequestDto)
        {
            ////convert dto to domain model
            var roomDomain = mapper.Map<Room>(addRoomRequestDto);


            ////domain model to create allocation
            roomDomain = await roomRepository.CreateAsync(roomDomain);


            ////domain model to dto
            var data = mapper.Map<RoomDto>(roomDomain);

            // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Room data fetched successfully" };
        }




        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateRoomDto updateRoomDto)
        {

            // dto to domain model
            var roomDomainModel = mapper.Map<Room>(updateRoomDto);


            //domain to update allocation details from database 
            roomDomainModel = await roomRepository.UpdateAsync(id, roomDomainModel);

            if (roomDomainModel == null)
            {

                return new ApiResponse { Message = "room data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<RoomDto>(roomDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "room data fetched successfully" };


        }
    }
}
