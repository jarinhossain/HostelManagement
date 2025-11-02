using HostelManagement.Models.DTO;

namespace HostelManagement.Services
{
    public interface IRoomService
    {

        Task<List<RoomDto>> GetAllAsync();
        Task<ApiResponse> Create(AddRoomRequestDto addRoomRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id, UpdateRoomDto updateRoomDto);
    }
}
