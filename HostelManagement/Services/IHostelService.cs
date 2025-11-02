using HostelManagement.Models.DTO;

namespace HostelManagement.Services
{
    public interface IHostelService
    {
        Task<List<HostelDto>> GetAllAsync();
        Task<ApiResponse> Create(AddHostelRequestDto addHostelRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id, UpdateHostelsDto updateHostelsDto);
    }
}
