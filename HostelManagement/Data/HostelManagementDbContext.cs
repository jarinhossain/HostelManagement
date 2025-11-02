
using HostelManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Data
{
    public class HostelManagementDbContext : DbContext
    {
        public HostelManagementDbContext(DbContextOptions<HostelManagementDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Room> Room { get; set; }
        public DbSet<Resident> Resident { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<LeaveRequest> LeaveRequest { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Hostel> Hostel { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<FeePlan> Feeplan { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<Allocation> Allocation { get; set; }

    }

   
 }
