using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IBuildingRepository
    {
        Task<List<Building>> GetAllAsync();
        Task<Building> CreateAsync(Building building);
        Task<Building?> UpdateAsync(Guid id, Building building);
    }
}
