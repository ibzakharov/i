using Microsoft.EntityFrameworkCore;

namespace TreeNodeException.Api.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Node> Nodes { get; set; }
    public DbSet<Tree> Trees { get; set; }
    public DbSet<ExceptionLog> ExceptionLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>()
            .HasKey(e => e.NodeId);
        
        modelBuilder.Entity<Node>()
            .HasOne(n => n.Parent)
            .WithMany(p => p.Children)
            .HasForeignKey(n => n.ParentId)
            .OnDelete(DeleteBehavior.Restrict); // Опционально: чтобы предотвратить каскадное удаление

        modelBuilder.Entity<Node>()
            .HasOne(n => n.Tree)
            .WithMany(t => t.Nodes)
            .HasForeignKey(n => n.TreeId);
        
        modelBuilder.Entity<Tree>()
            .HasKey(n => n.TreeId);
        
        modelBuilder.Entity<ExceptionLog>()
            .HasKey(e => e.EventId);
    }
}