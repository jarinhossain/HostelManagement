using HostelManagement.Data;
using HostelManagement.Mappings;
using HostelManagement.Repositories;
using HostelManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HostelManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HostelConnectiongString")));
builder.Services.AddScoped<IHostelRepository, SQLHostelRepository>();
builder.Services.AddScoped<IAllocationRepository, SQLAllocationRepository>();
builder.Services.AddScoped<IBuildingRepository, SQLBuildingRepository>();
builder.Services.AddScoped<IFeePlanRepository, SQLFeePlanRepository>();
builder.Services.AddScoped<IFlatRepositroy, SQLFlatRepository>();
builder.Services.AddScoped<IInvoiceRepository, SQLInvoiceRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, SQLLeaveRequestRepository>();
builder.Services.AddScoped<IPaymentRepository, SQLPaymentRepository>();
builder.Services.AddScoped<IResidentRepository, SQLResidentRepository>();
builder.Services.AddScoped<IRoomRepository, SQLRoomRepository>();


builder.Services.AddScoped<IAllocationService, AllocationService>();
builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IFeePlanService, FeePlanService>();
builder.Services.AddScoped<IFlatService, FlatService>();
builder.Services.AddScoped<IHostelService, HostelService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IResidentService, ResidentService>();
builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
