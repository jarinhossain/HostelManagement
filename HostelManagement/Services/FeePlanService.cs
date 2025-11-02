using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public class FeePlanService : IFeePlanService
    {
        private readonly IFeePlanRepository feePlanRepository;
        private readonly IMapper mapper;

        public FeePlanService(IFeePlanRepository feePlanRepository,IMapper mapper)
        {
            this.feePlanRepository = feePlanRepository;
            this.mapper = mapper;
        }

        // Task<List<FeePlanDto>> GetAllAsync();

        public async Task<List<FeePlanDto>> GetAllAsync()
        {
            //get data from database domain models
            var feePlanDomain = await feePlanRepository.GetAllAsync();

            //domain model to dto
            // return Ok(mapper.Map<List<HostelDto>>(hostelDomain));

            return mapper.Map<List<FeePlanDto>>(feePlanDomain); // mapping here
        }



        public async Task<ApiResponse> Create(AddFeePlanRequestDto addFeePlanRequestDto)
        {
            ////convert dto to domain model
            var feePlanDomain = mapper.Map<FeePlan>(addFeePlanRequestDto);


            ////domain model to create allocation
            feePlanDomain = await feePlanRepository.CreateAsync(feePlanDomain);


            ////domain model to dto
            var data = mapper.Map<FeePlanDto>(feePlanDomain);

           
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Fee Plan data fetched successfully" };
        }




        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateFeePlanDto updateFeePlanDto)
        {

            // dto to domain model
            var feePlanDomainModel = mapper.Map<FeePlan>(updateFeePlanDto);


            //domain to update allocation details from database 
            feePlanDomainModel = await feePlanRepository.UpdateAsync(id, feePlanDomainModel);

            if (feePlanDomainModel == null)
            {

                return new ApiResponse { Message = "fee plan data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<FeePlanDto>(feePlanDomainModel);

            return new ApiResponse {Data = data, Message = "fee plan data fetched successfully" };


        }
    }
}
