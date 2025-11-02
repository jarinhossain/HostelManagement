using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLAllocationRepository : IAllocationRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLAllocationRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Allocation>> GetAllAsync()
        {
            return await dbContext.Allocation.ToListAsync();
        }


        public async Task<Allocation> CreateAsync(Allocation allocation)
        {
            await dbContext.Allocation.AddAsync(allocation);
            await dbContext.SaveChangesAsync();
            return allocation;

        }



        public async Task<Allocation?> UpdateAsync(Guid id, Allocation allocation)
        {
            var existingAllocation = await dbContext.Allocation.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAllocation == null)
            {
                return null;
            }

            existingAllocation.RegNo = allocation.RegNo;
            existingAllocation.ResidentId = allocation.ResidentId;
            existingAllocation.RoomId = allocation.RoomId;
            existingAllocation.FlatId = allocation.FlatId;
            existingAllocation.StartDate = allocation.StartDate;
            existingAllocation.EndDate = allocation.EndDate;
            existingAllocation.Status = allocation.Status;

            await dbContext.SaveChangesAsync();
            return existingAllocation;

        }



        public async Task<Allocation?> DeleteAsync(Guid id)
        {
            var existAllocation = await dbContext.Allocation.FirstOrDefaultAsync(x => x.Id == id);
            if (existAllocation == null)
            {
                return null;
            }

            dbContext.Allocation.Remove(existAllocation);
            await dbContext.SaveChangesAsync();
            return existAllocation;

        }
    }
}
