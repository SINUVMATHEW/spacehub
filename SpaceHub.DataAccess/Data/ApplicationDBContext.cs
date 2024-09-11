using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpaceHub.Models;
namespace SpaceHub.DataAccess.Data;





public class ApplicationDBContext :  IdentityDbContext<IdentityUser>
{
    public ApplicationDBContext(DbContextOptions options) : base(options)  { 
    }
    
    public DbSet <Workspace> Workspaces { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Booking> Bookings { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Workspace>().HasData(
            new Workspace { Id=1,SeatNo=001,Module=1,Building="TVRM-Thejaswini"},
            new Workspace { Id=2, SeatNo = 002, Module = 1, Building = "TVRM-Thejaswini"},
            new Workspace { Id = 3, SeatNo = 003, Module = 1, Building = "TVRM-Thejaswini" }
            );
        modelBuilder.Entity<User>().HasData(
           new User { Id=1,Name="Sinu V Mathew", Email="sinu@gmail.com"},
           new User { Id = 2, Name = "Melinda Mary", Email = "melinda@gmail.com" },
           new User { Id = 3, Name = "Kailas S", Email = "kailas@gmail.com" }
           );
        modelBuilder.Entity<Booking>().HasData(
            new Booking { Id=1, BookingDate= new DateOnly(2024, 9, 2), UserId=1, WorkspaceId=1},
            new Booking { Id=2, BookingDate = new DateOnly(2024, 9, 2), UserId = 2, WorkspaceId = 2 }


           );
    }
}
