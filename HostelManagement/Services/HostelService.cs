
using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;
using Microsoft.Extensions.Hosting;

namespace HostelManagement.Services
{
    public class HostelService : IHostelService
    {
        private readonly IHostelRepository hostelRepository;
        private readonly IMapper mapper;

        public HostelService(IHostelRepository hostelRepository,IMapper mapper)
        {
            this.hostelRepository = hostelRepository;
            this.mapper = mapper;
        }

       
        public async Task<List<HostelDto>> GetAllAsync()
        {
            //get data from database domain models
            var hostelDomain = await hostelRepository.GetAllAsync();

          

            return mapper.Map<List<HostelDto>>(hostelDomain);
        }

        public async Task<ApiResponse> Create(AddHostelRequestDto addHostelRequestDto)
        {
            ////convert dto to domain model
            var hostelDomain = mapper.Map<Hostel>(addHostelRequestDto);


            ////domain model to create hostel
            hostelDomain = await hostelRepository.CreateAsync(hostelDomain);


            ////domain model to dto
            var data = mapper.Map<HostelDto>(hostelDomain);

            // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Hostel data fetched successfully" };
        }



        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateHostelsDto updateHostelsDto)
        {

            // dto to domain model
            var hostelDomainModel = mapper.Map<Hostel>(updateHostelsDto);


            //domain to update allocation details from database 
            hostelDomainModel = await hostelRepository.UpdateAsync(id, hostelDomainModel);

            if (hostelDomainModel == null)
            {

                return new ApiResponse { Message = "hostel data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<HostelDto>(hostelDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "Hostel data fetched successfully" };


        }
    }
}
