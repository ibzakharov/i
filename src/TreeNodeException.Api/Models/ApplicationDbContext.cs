using Microsoft.EntityFrameworkCore;

namespace TreeNodeException.Api.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Node> Nodes { get; set; }
    
    public DbSet<ExceptionLog> ExceptionLogs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>()
            .HasOne(n => n.Parent)
            .WithMany(p => p.Child)
            .HasForeignKey(n => n.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ExceptionLog>()
            .HasKey(e => e.EventID);
    }
}