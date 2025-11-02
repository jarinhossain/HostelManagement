using HostelManagement.Models.DTO;

namespace HostelManagement.Services
{
    public interface IResidentService
    {
        Task<List<ResidentDto>> GetAllAsync();
        Task<ApiResponse> Create(AddResidentRequestDto addResidentRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id, UpdateResidentDto updateResidentDto);
    }
}
