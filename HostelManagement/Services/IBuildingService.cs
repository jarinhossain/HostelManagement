using HostelManagement.Models.DTO;

namespace HostelManagement.Services
{
    public interface IBuildingService
    {
        Task<List<BuildingDto>> GetAllAsync();
        Task<ApiResponse> Create(AddBuildingRequestDto addBuildingRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id, UpdateBuildingDto updateBuildingDto);
    }
}
