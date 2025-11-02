namespace HostelManagement.Models.DTO
{
    public class ApiResponse
    {
        public bool IsSuccess = true;
        public object? Data { get; set; }
        public string? Message { get; set; }
    }
}
