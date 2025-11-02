namespace HostelManagement.Models.Domain
{
    public class Building
    {
        public Guid Id { set; get;}
        public string Name { set; get; }
        public Guid HostelId { set; get; }
        public Hostel Hostel { set; get; }
    }
}
