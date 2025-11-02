using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLHostelRepository : IHostelRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLHostelRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Hostel>> GetAllAsync()
        {
            return await dbContext.Hostel.ToListAsync();
        }

        

        public async Task<Hostel> CreateAsync(Hostel hostel)
        {
            await dbContext.Hostel.AddAsync(hostel);
            await dbContext.SaveChangesAsync();
            return hostel;

        }


        public async Task<Hostel?> UpdateAsync(Guid id, Hostel hostel)
        {
            var existingHostel = await dbContext.Hostel.FirstOrDefaultAsync(x => x.Id == id);
            if (existingHostel == null)
            {
                return null;
            }

            existingHostel.Name = hostel.Name;
            existingHostel.Code = hostel.Code;
            existingHostel.Address = hostel.Address;
            existingHostel.Description = hostel.Description;
            existingHostel.IsActive = hostel.IsActive;

            await dbContext.SaveChangesAsync();
            return existingHostel;

        }
    }
}
