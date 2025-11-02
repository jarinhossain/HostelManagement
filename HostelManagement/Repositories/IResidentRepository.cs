using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IResidentRepository
    {
        Task<List<Resident>> GetAllAsync();
        Task<Resident> CreateAsync(Resident resident);
        Task<Resident?> UpdateAsync(Guid id, Resident resident);
    }
}
