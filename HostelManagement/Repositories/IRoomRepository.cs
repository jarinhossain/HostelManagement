using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room> CreateAsync(Room room);
        Task<Room?> UpdateAsync(Guid id, Room room);
    }
}
