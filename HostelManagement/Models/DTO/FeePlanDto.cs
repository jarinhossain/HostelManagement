namespace HostelManagement.Models.DTO
{
    public class FeePlanDto
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public double Amount { set; get; }
        public string Periodicity { set; get; }
    }
}
