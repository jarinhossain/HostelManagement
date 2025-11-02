using HostelManagement.Models.DTO;

namespace HostelManagement.Services
{
    public interface IInvoiceService
    {
        Task<List<InvoiceDto>> GetAllAsync();
        Task<ApiResponse> Create(AddInvoiceRequestDto addInvoiceRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id, UpdateInvoiceDto updateInvoiceDto);
    }
}
