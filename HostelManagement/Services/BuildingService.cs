using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository buildingRepository;
        private readonly IMapper mapper;

        public BuildingService(IBuildingRepository buildingRepository,IMapper mapper)
        {
            this.buildingRepository = buildingRepository;
            this.mapper = mapper;
        }

     

        public async Task<List<BuildingDto>> GetAllAsync()
        {
            //get data from database domain models
            var buildingDomain = await buildingRepository.GetAllAsync();

           

            return mapper.Map<List<BuildingDto>>(buildingDomain); // mapping here
        }

       
        public async Task<ApiResponse> Create(AddBuildingRequestDto addBuildingRequestDto)

        {
            ////convert dto to domain model
            var buildingDomain = mapper.Map<Building>(addBuildingRequestDto);


            ////domain model to create allocation
            buildingDomain = await buildingRepository.CreateAsync(buildingDomain);


            ////domain model to dto
            var data = mapper.Map<BuildingDto>(buildingDomain);

            // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Building data fetched successfully" };
        }



        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateBuildingDto updateBuildingDto)
        {

            // dto to domain model
            var buildingDomainModel = mapper.Map<Building>(updateBuildingDto);


            //domain to update building details from database 
            buildingDomainModel = await buildingRepository.UpdateAsync(id, buildingDomainModel);

            if (buildingDomainModel == null)
            {

                return new ApiResponse { Message = "Building data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<BuildingDto>(buildingDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "Building data fetched successfully" };


        }
    }
}
