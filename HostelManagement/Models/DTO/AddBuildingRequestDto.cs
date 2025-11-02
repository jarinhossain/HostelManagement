using HostelManagement.Models.Domain;

namespace HostelManagement.Models.DTO
{
    public class AddBuildingRequestDto
    {
        public string Name { set; get; }
        public Guid HostelId { set; get; }
       // public Hostel Hostel { set; get; }
    }
}
