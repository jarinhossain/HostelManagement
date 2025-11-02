using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;
using HostelManagement.Repositories;

namespace HostelManagement.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IMapper mapper;

        public PaymentService(IPaymentRepository paymentRepository,IMapper mapper)
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        public async Task<List<PaymentDto>> GetAllAsync()
        {
            //get data from database domain models
            var paymentDomain = await paymentRepository.GetAllAsync();



            return mapper.Map<List<PaymentDto>>(paymentDomain); // mapping here
        }


        public async Task<ApiResponse> Create(AddPaymentRequestDto addPaymentRequestDto)
        {
            ////convert dto to domain model
            var paymentDomain = mapper.Map<Payment>(addPaymentRequestDto);


            ////domain model to create allocation
            paymentDomain = await paymentRepository.CreateAsync(paymentDomain);


            ////domain model to dto
            var data = mapper.Map<PaymentDto>(paymentDomain);

            // return new ApiResponse { IsSuccess = true, Data = data, Message = "Allocation data fetched successfully" };
            return new ApiResponse { IsSuccess = true, Data = data, Message = "Payment data fetched successfully" };
        }




        //update
        public async Task<ApiResponse> UpdateAsync(Guid id, UpdatePaymentDto updatePaymentDto)
        {

            // dto to domain model
            var paymentDomainModel = mapper.Map<Payment>(updatePaymentDto);


            //domain to update allocation details from database 
            paymentDomainModel = await paymentRepository.UpdateAsync(id, paymentDomainModel);

            if (paymentDomainModel == null)
            {

                return new ApiResponse { Message = "paymentDomainModel data fetched failed" };

            }


            //domain to dto
            var data = mapper.Map<PaymentDto>(paymentDomainModel);

            return new ApiResponse { IsSuccess = true, Data = data, Message = "payment data fetched successfully" };


        }
    }
}
