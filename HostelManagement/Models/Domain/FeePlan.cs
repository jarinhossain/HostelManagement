namespace HostelManagement.Models.Domain
{
    public class FeePlan
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public double Amount { set; get; }
        public string Periodicity { set; get; }
    }
}
