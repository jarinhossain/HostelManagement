using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLRoomRepository : IRoomRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLRoomRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Room>> GetAllAsync()
        {
            return await dbContext.Room.ToListAsync();
        }

        public async Task<Room> CreateAsync(Room room)
        {
            await dbContext.Room.AddAsync(room);
            await dbContext.SaveChangesAsync();
            return room;

        }



        public async Task<Room?> UpdateAsync(Guid id, Room room)
        {
            var existingRoom = await dbContext.Room.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRoom == null)
            {
                return null;
            }

            existingRoom.FloorNo = room.FloorNo;
            existingRoom.RoomCategory = room.RoomCategory;
            existingRoom.Status = room.Status;
            existingRoom.HostelId = room.HostelId;
            existingRoom.BuildingId = room.BuildingId;

            await dbContext.SaveChangesAsync();
            return existingRoom;

        }
    }
}
