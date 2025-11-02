using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLResidentRepository : IResidentRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLResidentRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Resident>> GetAllAsync()
        {
            return await dbContext.Resident.ToListAsync();
        }

        

        public async Task<Resident> CreateAsync(Resident resident)
        {
            await dbContext.Resident.AddAsync(resident);
            await dbContext.SaveChangesAsync();
            return resident;

        }


        public async Task<Resident?> UpdateAsync(Guid id, Resident resident)
        {
            var existingResident = await dbContext.Resident.FirstOrDefaultAsync(x => x.Id == id);
            if (existingResident == null)
            {
                return null;
            }

            existingResident.RegNo = resident.RegNo;
            existingResident.FullName = resident.FullName;
            existingResident.Phone = resident.Phone;
            existingResident.Emal = resident.Emal;
            existingResident.GuardianName = resident.GuardianName;
            existingResident.GuardianPhone = resident.GuardianPhone;
            existingResident.ArrivalDate = resident.ArrivalDate;
            existingResident.IsActive = resident.IsActive;


            await dbContext.SaveChangesAsync();
            return existingResident;

        }
    }
}
