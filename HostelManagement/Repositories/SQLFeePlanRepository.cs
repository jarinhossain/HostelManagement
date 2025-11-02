using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLFeePlanRepository : IFeePlanRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLFeePlanRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       


        public async Task<List<FeePlan>> GetAllAsync()
        {
            return await dbContext.Feeplan.ToListAsync();
        }


      

        public async Task<FeePlan> CreateAsync(FeePlan feePlan)
        {
            await dbContext.Feeplan.AddAsync(feePlan);
            await dbContext.SaveChangesAsync();
            return feePlan;

        }



        public async Task<FeePlan?> UpdateAsync(Guid id, FeePlan feePlan)
        {
            var existingFeePlan = await dbContext.Feeplan.FirstOrDefaultAsync(x => x.Id == id);
            if (existingFeePlan == null)
            {
                return null;
            }

            existingFeePlan.Name = feePlan.Name;
            existingFeePlan.Amount = feePlan.Amount;
            existingFeePlan.Periodicity = feePlan.Periodicity;

            await dbContext.SaveChangesAsync();
            return existingFeePlan;

        }
    }
}
