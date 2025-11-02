using HostelManagement.Models.Domain;

namespace HostelManagement.Models.DTO
{
    public class BuildingDto
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public Guid HostelId { set; get; }
        public Hostel Hostel { set; get; }
    }
}
