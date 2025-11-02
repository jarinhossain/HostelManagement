using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IFeePlanRepository
    {
        Task<List<FeePlan>> GetAllAsync();
        Task<FeePlan> CreateAsync(FeePlan feePlan);
        Task<FeePlan?> UpdateAsync(Guid id, FeePlan feePlan);
    }
}
