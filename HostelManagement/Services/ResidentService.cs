using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public class ResidentService : IResidentService
    {
        private readonly IResidentRepository residentRepository;
        private readonly IMapper mapper;

        public ResidentService(IResidentRepository residentRepository,IMapper mapper)
        {
            this.residentRepository = residentRepository;
            this.mapper = mapper;
        }

        public async Task<List<ResidentDto>> GetAllAsync()
        {
            //get data from database domain models
            var residentDomain = await residentRepository.GetAllAsync();



            return mapper.Map<List<ResidentDto>>(residentDomain); // mapping here
        }



        //create
        public async Task<ApiResponse> Create(AddResidentRequestDto addResidentRequestDto)
        {
            ////convert dto to domain model
            var residentDomain = mapper.Map<Resident>(addResidentRequestDto);


            ////domain model to create allocation
            residentDomain = await residentRepository.CreateAsync(residentDomain);


            ////domain model to dto
            var data = mapper.Map<ResidentDto>(residentDomain);

            // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
        }





        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateResidentDto updateResidentDto)
        {

            // dto to domain model
            var residentDomainModel = mapper.Map<Resident>(updateResidentDto);


            //domain to update allocation details from database 
            residentDomainModel = await residentRepository.UpdateAsync(id, residentDomainModel);

            if (residentDomainModel == null)
            {

                return new ApiResponse { Message = "resident data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<ResidentDto>(residentDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "Resident data fetched successfully" };


        }
    }
}
