namespace HostelManagement.Models.DTO
{
    public class UpdateFlatDto
    {
        public string Name { set; get; }
        public string Code { set; get; }
        public string FlatNo { set; get; }
        public string LocationText { set; get; }
        public int RoomsCount { set; get; }
        public double Rent { set; get; }
        public double AdvancePolicy { set; get; }
        public bool Status { set; get; }
    }
}
