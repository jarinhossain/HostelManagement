using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment?> UpdateAsync(Guid id, Payment payment);
    }
}
