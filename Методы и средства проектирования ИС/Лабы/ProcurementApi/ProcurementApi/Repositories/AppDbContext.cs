using Microsoft.EntityFrameworkCore;
using ProcurementApi.Core.Domains;

namespace ProcurementApi.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Material> RawMaterials => Set<Material>();
    public DbSet<Product> EndProducts => Set<Product>();
    public DbSet<Issue> GoodsIssueDocuments => Set<Issue>();
    public DbSet<Purchase> PurchaseReceipts => Set<Purchase>();
    public DbSet<Composition> ProductCompositions => Set<Composition>();
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Composition>()
            .HasOne(c => c.Product)
            .WithMany(p => p.Compositions);
    }
}