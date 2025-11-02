namespace HostelManagement.Models.DTO
{
    public class UpdateInvoiceDto
    {
        public Guid ResidentId { set; get; }
        public string Period { set; get; }
        public double Total { set; get; }
        public double Due { set; get; }
        public bool Status { set; get; }
        public DateTime IssueOn { set; get; }
        public DateTime DueOn { set; get; }
    }
}
