using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public interface ILeaveRequestRepository
    {
       Task<List<LeaveRequest>> GetAllAsync();
        Task<LeaveRequest> CreateAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest?> UpdateAsync(Guid id, LeaveRequest leaveRequest);

    }
}
