using Microsoft.EntityFrameworkCore;

namespace backend;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Property> Properties { get; set; }
    public DbSet<Lease> Leases { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Owner> Owners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lease>()
            .HasOne(l => l.Tenant)
            .WithOne(t => t.Lease)
            .HasForeignKey<Tenant>(t => t.LeaseId);

        modelBuilder.Entity<Lease>()
            .HasMany(l => l.Payments)
            .WithOne(p => p.Lease)
            .HasForeignKey(p => p.LeaseId)
            .HasPrincipalKey(l => l.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lease>()
            .HasOne(l => l.Property)
            .WithMany(p => p.Leases)
            .HasForeignKey(l => l.PropertyId)
            .HasPrincipalKey(p => p.Id);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Lease)
            .WithMany(l => l.Payments)
            .HasForeignKey(p => p.LeaseId)
            .HasPrincipalKey(l => l.Id);

        modelBuilder.Entity<Property>()
            .HasOne(p => p.Owner)
            .WithMany(o => o.Properties)
            .HasForeignKey(p => p.OwnerId)
            .HasPrincipalKey(o => o.Id);

        modelBuilder.Entity<Tenant>()
            .HasOne(t => t.Lease)
            .WithOne(l => l.Tenant)
            .HasForeignKey<Tenant>(t => t.LeaseId);


    }
}
