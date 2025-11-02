using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;

        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository,IMapper mapper)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
        }

        public async Task<List<LeaveRequestDto>> GetAllAsync()
        {
            //get data from database domain models
            var leaveRequestDomain = await leaveRequestRepository.GetAllAsync();

           

            return mapper.Map<List<LeaveRequestDto>>(leaveRequestDomain); // mapping here
        }



        public async Task<ApiResponse> Create(AddLeaveRequestDto addLeaveRequestDto)
        {
            ////convert dto to domain model
            var leaveRequestDomain = mapper.Map<LeaveRequest>(addLeaveRequestDto);


            ////domain model to create allocation
            leaveRequestDomain = await leaveRequestRepository.CreateAsync(leaveRequestDomain);


            ////domain model to dto
            var data = mapper.Map<LeaveRequestDto>(leaveRequestDomain);

            // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Leave Request data fetched successfully" };
        }





        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateLeaveRequestDto updateLeaveRequestDto)
        {

            // dto to domain model
            var leaveDomainModel = mapper.Map<LeaveRequest>(updateLeaveRequestDto);


            //domain to update allocation details from database 
            leaveDomainModel = await leaveRequestRepository.UpdateAsync(id, leaveDomainModel);

            if (leaveDomainModel == null)
            {

                return new ApiResponse { Message = "leaveDomainModel data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<LeaveRequestDto>(leaveDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "leaveDomainModel data fetched successfully" };


        }
    }
}
