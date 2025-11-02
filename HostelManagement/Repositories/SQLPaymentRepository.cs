using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLPaymentRepository : IPaymentRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLPaymentRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<Payment>> GetAllAsync()
        {
            return await dbContext.Payment.ToListAsync();
        }


        public async Task<Payment> CreateAsync(Payment payment)
        {
            await dbContext.Payment.AddAsync(payment);
            await dbContext.SaveChangesAsync();
            return payment;

        }


        public async Task<Payment?> UpdateAsync(Guid id, Payment payment)
        {
            var existingPayment = await dbContext.Payment.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPayment == null)
            {
                return null;
            }

            existingPayment.InvoiceId = payment.InvoiceId;
            existingPayment.Amount = payment.Amount;
            existingPayment.Method = payment.Method;
            existingPayment.PaidOn = payment.PaidOn;
            existingPayment.TaxRef = payment.TaxRef;
            existingPayment.Status = payment.Status;

            await dbContext.SaveChangesAsync();
            return existingPayment;

        }
    }
}
