namespace HostelManagement.Models.DTO
{
    public class UpdateLeaveRequestDto
    {
        public Guid ResidentId { set; get; }

        public DateTime From { set; get; }
        public DateTime To { set; get; }
        public string Reason { set; get; }
        public string Status { set; get; }//pending,approved,rejected
    }
}
