namespace HostelManagement.Models.Domain
{
    public class LeaveRequest
    {
        public Guid Id { set; get; }
        public Guid ResidentId { set; get; }
        public Resident Resident { set; get; }
        public DateTime From { set; get; }
        public DateTime To { set; get; }
        public string Reason { set; get; }
        public string Status { set; get; }//pending,approved,rejected
    }
}
