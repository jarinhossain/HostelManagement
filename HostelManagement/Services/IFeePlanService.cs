using HostelManagement.Models.DTO;

namespace HostelManagement.Services
{
    public interface IFeePlanService
    {
        Task<List<FeePlanDto>> GetAllAsync();
        Task<ApiResponse> Create(AddFeePlanRequestDto addFeePlanRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id, UpdateFeePlanDto updateFeePlanDto);
    }
}
