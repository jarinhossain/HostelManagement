using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLBuildingRepository : IBuildingRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLBuildingRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

      

        public async Task<List<Building>> GetAllAsync()
        {
            return await dbContext.Building.ToListAsync();
        }

       

        public async Task<Building> CreateAsync(Building building)
        {
            await dbContext.Building.AddAsync(building);
            await dbContext.SaveChangesAsync();
            return building;

        }


        public async Task<Building?> UpdateAsync(Guid id, Building building)
        {
            var existingBuilding = await dbContext.Building.FirstOrDefaultAsync(x => x.Id == id);
            if (existingBuilding == null)
            {
                return null;
            }

            existingBuilding.Name = building.Name;
            existingBuilding.HostelId = building.HostelId;


            await dbContext.SaveChangesAsync();
            return existingBuilding;

        }
    }
}
