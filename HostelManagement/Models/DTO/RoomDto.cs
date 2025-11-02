using HostelManagement.Models.Domain;

namespace HostelManagement.Models.DTO
{
    public class RoomDto
    {
        public Guid Id { set; get; }


        public string FloorNo { set; get; }
        public string RoomCategory { set; get; }
        public bool Status { set; get; }

        public Guid HostelId { set; get; }
        public Hostel Hostel { set; get; }

        public Guid? BuildingId { set; get; }
        public Building? Building { set; get; }
    }
}
