using HostelManagement.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HostelManagement.Services
{
    public interface IAllocationService
    {
        Task<List<AllocationDto>> GetAllAsync();
        Task<ApiResponse> Create(AddAllocationRequestDto addAllocationRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id,UpdateAllocationDto updateAllocationDto);
        Task<ApiResponse> DeleteAsync(Guid id);




    }
}
