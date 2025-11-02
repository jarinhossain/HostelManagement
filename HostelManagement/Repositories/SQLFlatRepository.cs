using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLFlatRepository : IFlatRepositroy
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLFlatRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Flat>> GetAllAsync()
        {
            return await dbContext.Flat.ToListAsync();
        }

        public async Task<Flat> CreateAsync(Flat flat)
        {
            await dbContext.Flat.AddAsync(flat);
            await dbContext.SaveChangesAsync();
            return flat;

        }





        public async Task<Flat?> UpdateAsync(Guid id, Flat flat)
        {
            var existingFlat = await dbContext.Flat.FirstOrDefaultAsync(x => x.Id == id);
            if (existingFlat == null)
            {
                return null;
            }

            existingFlat.Name = flat.Name;
            existingFlat.Code = flat.Code;
            existingFlat.FlatNo = flat.FlatNo;
            existingFlat.LocationText = flat.LocationText;
            existingFlat.RoomsCount = flat.RoomsCount;
            existingFlat.Rent = flat.Rent;
            existingFlat.AdvancePolicy = flat.AdvancePolicy;
            existingFlat.Status = flat.Status;

            await dbContext.SaveChangesAsync();
            return existingFlat;

        }


    }
}
