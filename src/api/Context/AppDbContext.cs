using Microsoft.EntityFrameworkCore;
using ru_pert0_back.api.Models;
using Task = ru_pert0_back.api.Models.Task;

namespace ru_pert0_back.api.Context;



public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Node> Nodes { get; set; }
    public DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>()
            .HasMany(n => n.Children)
            .WithOne(n => n.Parent)
            .HasForeignKey(n => n.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Projects)
            .WithOne(u => u.User)
            .HasForeignKey(p => p.UserId);
        
        modelBuilder.Entity<Project>()
            .HasMany(p=>p.Nodes)
            .WithOne(n=>n.Project)
            .HasForeignKey(n=>n.ProjectId);
            
        modelBuilder.Entity<Node>()
            .HasOne(n=>n.Task)
            .WithOne()
            .HasForeignKey<Node>(n=>n.TaskId);
    }
    
    
}