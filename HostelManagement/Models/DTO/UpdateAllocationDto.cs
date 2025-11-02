using System.ComponentModel.DataAnnotations;

namespace HostelManagement.Models.DTO
{
    public class UpdateAllocationDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "clientname has to be a maximum of hundred characters")]
        public string RegNo { set; get; }

        [Required]
        public Guid ResidentId { set; get; }

        public Guid? RoomId { set; get; }

        public Guid? FlatId { set; get; }

        public DateTime StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public bool Status { set; get; }
    }
}
