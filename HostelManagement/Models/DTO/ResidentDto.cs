namespace HostelManagement.Models.DTO
{
    public class ResidentDto
    {
        public Guid Id { set; get; }
        public string RegNo { set; get; }
        public string FullName { set; get; }
        public string Phone { set; get; }
        public string Emal { set; get; }
        public string GuardianName { set; get; }
        public string GuardianPhone { set; get; }
        public DateTime ArrivalDate { set; get; }
        public bool IsActive { set; get; }
    }
}
