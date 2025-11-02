using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Services
{
    public class AllocationService : IAllocationService
    {
        private readonly IAllocationRepository allocationRepository;
        private readonly IMapper mapper;

        public AllocationService(IAllocationRepository allocationRepository,IMapper mapper)
        {
            this.allocationRepository = allocationRepository;
            this.mapper = mapper;
        }

        public async Task<List<AllocationDto>> GetAllAsync()
        {
            //get data from database domain models
            var allocationDomain = await allocationRepository.GetAllAsync();

            return mapper.Map<List<AllocationDto>>(allocationDomain);
        }


        public async Task<ApiResponse> Create(AddAllocationRequestDto addAllocationRequestDto)
        {
            ////convert dto to domain model
            var allocationDomain = mapper.Map<Allocation>(addAllocationRequestDto);


            ////domain model to create allocation
            allocationDomain = await allocationRepository.CreateAsync(allocationDomain);


            ////domain model to dto
            var data = mapper.Map<AllocationDto>(allocationDomain);
            
           // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
        }


        //



        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateAllocationDto updateAllocationDto)
        {
           
                // dto to domain model
                var allocationDomainModel = mapper.Map<Allocation>(updateAllocationDto);


               //domain to update allocation details from database 
               allocationDomainModel = await allocationRepository.UpdateAsync(id, allocationDomainModel);

                if (allocationDomainModel == null)
                {

                     return new ApiResponse { Message = "Allocation data fetched failed" };

                }


            //domain to dto
            var data = mapper.Map<AllocationDto>(allocationDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };


        }




      
        public async Task<ApiResponse> DeleteAsync(Guid id)
        {
            var allocationDomainModel = await allocationRepository.DeleteAsync(id);

            if (allocationDomainModel != null)
            {
                return new ApiResponse { Message = "Allocation data  not deleted" };
            }

            //domain to dto
            var data = mapper.Map<AllocationDto>(allocationDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data deleted successfully" };
        }

    }
}
