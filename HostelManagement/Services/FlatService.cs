using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public class FlatService : IFlatService
    {
        private readonly IFlatRepositroy flatRepositroy;
        private readonly IMapper mapper;

        public FlatService(IFlatRepositroy flatRepositroy,IMapper mapper)
        {
            this.flatRepositroy = flatRepositroy;
            this.mapper = mapper;
        }






        public async Task<List<FlatDto>> GetAllAsync()
        {
            //get data from database domain models
            var flatDomain = await flatRepositroy.GetAllAsync();

            return mapper.Map<List<FlatDto>>(flatDomain);
        }




        //create

        public async Task<ApiResponse> Create(AddFlatRequestDto addFlatRequestDto)
        {
            ////convert dto to domain model
            var flatDomain = mapper.Map<Flat>(addFlatRequestDto);


            ////domain model to create allocation
            flatDomain = await flatRepositroy.CreateAsync(flatDomain);


            ////domain model to dto
            var data = mapper.Map<FlatDto>(flatDomain);

            // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Flat data fetched successfully" };
        }




        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateFlatDto updateFlatDto)
        {

            // dto to domain model
            var flatDomainModel = mapper.Map<Flat>(updateFlatDto);


            //domain to update allocation details from database 
            flatDomainModel = await flatRepositroy.UpdateAsync(id, flatDomainModel);

            if (flatDomainModel == null)
            {

                return new ApiResponse { Message = "flat data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<FlatDto>(flatDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "Flat data fetched successfully" };


        }
    }
}
