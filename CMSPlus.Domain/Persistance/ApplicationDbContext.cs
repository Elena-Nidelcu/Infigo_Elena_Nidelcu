using System.Reflection;
using CMSPlus.Domain.Configurations;
using CMSPlus.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMSPlus.Domain.Persistance;

public class ApplicationDbContext : IdentityDbContext
{
    // Constructor for dependency injection
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet properties to map entities to database tables
    public DbSet<TopicEntity> Topics { get; set; } = null!;
    public DbSet<CommentEntity> Comments { get; set; } = null!;

    // Optional: Configuring the database options
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    // Configuring model relationships and constraints
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Apply configurations for entities
        builder.ApplyConfiguration(new TopicEntityConfiguration());
        builder.ApplyConfiguration(new CommentEntityConfiguration()); // Add this if you have a CommentEntityConfiguration

        // Call the base method to ensure Identity tables are configured
        base.OnModelCreating(builder);
    }
}
