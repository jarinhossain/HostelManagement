using HostelManagement.Models.DTO;

namespace HostelManagement.Services
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequestDto>> GetAllAsync();
        Task<ApiResponse> Create(AddLeaveRequestDto addLeaveRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id, UpdateLeaveRequestDto updateLeaveRequestDto);
    }
}
