using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IAllocationRepository
    {
        Task<List<Allocation>> GetAllAsync();
        Task<Allocation> CreateAsync(Allocation allocation);
        Task<Allocation?> UpdateAsync(Guid id, Allocation allocation);
        Task<Allocation?> DeleteAsync(Guid id);
    }
}
