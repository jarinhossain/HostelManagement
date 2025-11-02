using HostelManagement.Models.Domain;

namespace HostelManagement.Models.DTO
{
    public class AddRoomRequestDto
    {
        public string FloorNo { set; get; }
        public string RoomCategory { set; get; }
        public bool Status { set; get; }

        public Guid HostelId { set; get; }
        public Guid? BuildingId { set; get; }
    }
}
