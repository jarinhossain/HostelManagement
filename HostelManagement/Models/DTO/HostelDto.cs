namespace HostelManagement.Models.DTO
{
    public class HostelDto
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string Address { set; get; }
        public string Description { set; get; }
        public bool IsActive { set; get; }
    }
}
