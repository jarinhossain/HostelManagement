using HostelManagement.Data;
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Repositories
{
    public class SQLInvoiceRepository : IInvoiceRepository
    {
        private readonly HostelManagementDbContext dbContext;

        public SQLInvoiceRepository(HostelManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<Invoice>> GetAllAsync()
        {
            return await dbContext.Invoice.ToListAsync();
        }

        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            await dbContext.Invoice.AddAsync(invoice);
            await dbContext.SaveChangesAsync();
            return invoice;

        }




        public async Task<Invoice?> UpdateAsync(Guid id, Invoice invoice)
        {
            var existingInvoice = await dbContext.Invoice.FirstOrDefaultAsync(x => x.Id == id);
            if (existingInvoice == null)
            {
                return null;
            }

            existingInvoice.ResidentId = invoice.ResidentId;
            existingInvoice.Period = invoice.Period;
            existingInvoice.Total = invoice.Total;
            existingInvoice.Due = invoice.Due;
            existingInvoice.Status = invoice.Status;
            existingInvoice.IssueOn = invoice.IssueOn;
            existingInvoice.DueOn = invoice.DueOn;
          

            await dbContext.SaveChangesAsync();
            return existingInvoice;

        }
    }
}
