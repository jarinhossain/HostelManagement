using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IHostelRepository
    {
        Task<List<Hostel>> GetAllAsync();
        Task<Hostel> CreateAsync(Hostel hostel);
        Task<Hostel?> UpdateAsync(Guid id, Hostel hostel);
    }
}
