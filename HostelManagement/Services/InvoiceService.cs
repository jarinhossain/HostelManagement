using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository,IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }
        public async Task<List<InvoiceDto>> GetAllAsync()
        {
            //get data from database domain models
            var invoiceDomain = await invoiceRepository.GetAllAsync();

           

            return mapper.Map<List<InvoiceDto>>(invoiceDomain); // mapping here
        }


        public async Task<ApiResponse> Create(AddInvoiceRequestDto addInvoiceRequestDto)
        {
            ////convert dto to domain model
            var invoiceDomain = mapper.Map<Invoice>(addInvoiceRequestDto);


            ////domain model to create allocation
            invoiceDomain = await invoiceRepository.CreateAsync(invoiceDomain);


            ////domain model to dto
            var data = mapper.Map<InvoiceDto>(invoiceDomain);

            // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Invoice data fetched successfully" };
        }







        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdateInvoiceDto updateInvoiceDto)
        {

            // dto to domain model
            var invoiceDomainModel = mapper.Map<Invoice>(updateInvoiceDto);


            //domain to update allocation details from database 
            invoiceDomainModel = await invoiceRepository.UpdateAsync(id, invoiceDomainModel);

            if (invoiceDomainModel == null)
            {

                return new ApiResponse { Message = "invoice  data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<InvoiceDto>(invoiceDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "Invoice data fetched successfully" };


        }
    }
}
