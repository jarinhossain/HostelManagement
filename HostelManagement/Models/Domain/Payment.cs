namespace HostelManagement.Models.Domain
{
    public class Payment
    {
        public Guid Id { set; get; }
        public Guid InvoiceId { set; get; }
        public Invoice Invoice { set; get; }
        public double Amount { set; get; }
        public string Method { set; get; }
        public DateTime PaidOn { set; get; }
        public string TaxRef { set; get; }
        public bool Status { set; get; }
    }
}
