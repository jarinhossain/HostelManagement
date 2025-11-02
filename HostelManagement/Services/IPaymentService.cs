using AutoMapper;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetAllAsync();
        Task<ApiResponse> Create(AddPaymentRequestDto addPaymentRequestDto);
        Task<ApiResponse> UpdateAsync(Guid id, UpdatePaymentDto updatePaymentDto);
    }
}
