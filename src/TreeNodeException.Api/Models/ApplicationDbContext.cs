using Microsoft.EntityFrameworkCore;

namespace TreeNodeException.Api.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Tree> Trees { get; set; }
    public DbSet<Node> Nodes { get; set; }
    public DbSet<ExceptionLog> ExceptionLogs { get; set; }
   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tree>()
            .HasKey(t => t.TreeID);
        
        modelBuilder.Entity<Node>()
            .HasKey(n => n.NodeID);

        modelBuilder.Entity<Node>()
            .HasOne(n => n.Tree)
            .WithMany(t => t.Nodes)
            .HasForeignKey(n => n.TreeID);

        modelBuilder.Entity<Node>()
            .HasOne(n => n.ParentNode)
            .WithMany(p => p.ChildNodes)
            .HasForeignKey(n => n.ParentNodeID)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ExceptionLog>()
            .HasKey(e => e.EventID);
    }
}