using AutoMapper;
using HostelManagement.Models.Domain;
using HostelManagement.Models.DTO;

namespace HostelManagement.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          



            // allocation crud
            CreateMap<Allocation, AllocationDto>().ReverseMap();
            CreateMap<AddAllocationRequestDto, Allocation>().ReverseMap();
            CreateMap<UpdateAllocationDto, Allocation>().ReverseMap();


            // Building crud
            CreateMap<Building, BuildingDto>().ReverseMap();
           CreateMap<AddBuildingRequestDto, Building>().ReverseMap();
            CreateMap<UpdateBuildingDto, Building>().ReverseMap();

            // FeePlan crud
            CreateMap<FeePlan, FeePlanDto>().ReverseMap();
             CreateMap<AddFeePlanRequestDto, FeePlan>().ReverseMap();
            CreateMap<UpdateFeePlanDto, FeePlan>().ReverseMap();


            //for Hostel crud
            CreateMap<Hostel, HostelDto>().ReverseMap();
             CreateMap<AddHostelRequestDto, Hostel>().ReverseMap();
            CreateMap<UpdateHostelsDto, Hostel>().ReverseMap();


            //for flat crud
            CreateMap<Flat, FlatDto>().ReverseMap();
            CreateMap<AddFlatRequestDto, Flat>().ReverseMap();
            CreateMap<UpdateFlatDto, Flat>().ReverseMap();

            // Invoice crud
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<AddInvoiceRequestDto, Invoice>().ReverseMap();
            CreateMap<UpdateInvoiceDto, Invoice>().ReverseMap();



            // LeaveRequest crud
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
             CreateMap<AddLeaveRequestDto, LeaveRequest>().ReverseMap();
            CreateMap<UpdateLeaveRequestDto, LeaveRequest>().ReverseMap();



            // Payment crud
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<AddPaymentRequestDto, Payment>().ReverseMap();
            CreateMap<UpdatePaymentDto, Payment>().ReverseMap();

            // Resident crud
            CreateMap<Resident, ResidentDto>().ReverseMap();
             CreateMap<AddResidentRequestDto, Resident>().ReverseMap();
            CreateMap<UpdateResidentDto, Resident>().ReverseMap();


            // Room crud
            CreateMap<Room, RoomDto>().ReverseMap();
             CreateMap<AddRoomRequestDto, Room>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
