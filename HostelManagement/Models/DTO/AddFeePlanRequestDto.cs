namespace HostelManagement.Models.DTO
{
    public class AddFeePlanRequestDto
    {
        public string Name { set; get; }
        public double Amount { set; get; }
        public string Periodicity { set; get; }
    }
}
