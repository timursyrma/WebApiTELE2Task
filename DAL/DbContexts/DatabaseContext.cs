using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.DbContexts;
public sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<CitizenModel> Citizens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitizenModel>().ToTable("Citinzens");
        base.OnModelCreating(modelBuilder);
    }
}