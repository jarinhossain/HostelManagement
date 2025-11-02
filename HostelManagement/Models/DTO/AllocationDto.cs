using HostelManagement.Models.Domain;

namespace HostelManagement.Models.DTO
{
    public class AllocationDto
    {
        public Guid Id { set; get; }
        public string RegNo { set; get; }

        public Guid ResidentId { set; get; }
        public Resident Resident { set; get; }

        public Guid? RoomId { set; get; }
        public Room? Room { set; get; }

        public Guid? FlatId { set; get; }
        public Flat? Flat { set; get; }

        public DateTime StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public bool Status { set; get; }
    }
}
