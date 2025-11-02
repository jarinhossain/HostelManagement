using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLLeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLLeaveRequestRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<LeaveRequest>> GetAllAsync()
        {
            return await dbContext.LeaveRequest.ToListAsync();
        }


        public async Task<LeaveRequest> CreateAsync(LeaveRequest leaveRequest)
        {
            await dbContext.LeaveRequest.AddAsync(leaveRequest);
            await dbContext.SaveChangesAsync();
            return leaveRequest;

        }


        public async Task<LeaveRequest?> UpdateAsync(Guid id, LeaveRequest leaveRequest)
        {
            var existingLeave = await dbContext.LeaveRequest.FirstOrDefaultAsync(x => x.Id == id);
            if (existingLeave == null)
            {
                return null;
            }

            existingLeave.ResidentId = leaveRequest.ResidentId;
            existingLeave.From = leaveRequest.From;
            existingLeave.To = leaveRequest.To;
            existingLeave.Reason = leaveRequest.Reason;
            existingLeave.Status = leaveRequest.Status;

            await dbContext.SaveChangesAsync();
            return existingLeave;

        }
    }
}
