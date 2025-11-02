using HostelManagement.Models.Domain;

namespace HostelManagement.Repositories
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllAsync();
        Task<Invoice> CreateAsync(Invoice invoice);
        Task<Invoice?> UpdateAsync(Guid id, Invoice invoice);
    }
}
