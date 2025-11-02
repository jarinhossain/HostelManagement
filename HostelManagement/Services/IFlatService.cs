using HostelManagement.Models.DTO;

namespace HostelManagement.Services
{
    public interface IFlatService
    {
      //  Task<List<FlatDto>> GetAllAsync();
        Task<ApiResponse> Create(AddFlatRequestDto addFlatRequestDto);
        Task<List<FlatDto>> GetAllAsync();
        Task<ApiResponse> UpdateAsync(Guid id, UpdateFlatDto updateFlatDto);
    }
}
