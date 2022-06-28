using Microsoft.EntityFrameworkCore;
using ZTM.Infrastructure.Entities;

namespace ZTM.Infrastructure.Context;

public class MainContext:DbContext
{
    public DbSet<Driver> Driver { get; set; }
    public DbSet<Stop> Stop { get; set; }
    public DbSet<Timetable> Timetable { get; set; }
    public DbSet<Bus> Bus { get; set; }

    public MainContext()
    {
    }
    
    public MainContext(DbContextOptions options) : base(options)
    {
    }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.ZTM.db");
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Stop>()
    //         .HasOne(x =>x.Timetables)
    //         .WithMany()
    //         .OnDelete(DeleteBehavior.Cascade);
    //
    //
    // }
    
}