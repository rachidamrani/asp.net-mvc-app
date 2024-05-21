using Microsoft.EntityFrameworkCore;
using MvcCrudApp.Models;

public class AppContext : DbContext
{
    public DbSet<Driver> Drivers { get; set; }
    
    public AppContext(DbContextOptions<AppContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>()
            .HasData(
                new Driver {FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com"},
                new Driver {FirstName = "Jane", LastName = "Doe", Email = "janedoe@gmail.com"}
                );
    }
}