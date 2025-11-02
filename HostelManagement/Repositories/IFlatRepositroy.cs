using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IFlatRepositroy
    {
        //  Task<List<Flat>> GetAllAsync();

        Task<Flat> CreateAsync(Flat flat);
        Task<List<Flat>> GetAllAsync();
        Task<Flat?> UpdateAsync(Guid id, Flat flat);
    }
}
