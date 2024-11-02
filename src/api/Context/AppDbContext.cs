using Microsoft.EntityFrameworkCore;
using ru_pert0_back.api.Models;
using Task = ru_pert0_back.api.Models.Task;
namespace ru_pert0_back.api.Context;


public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Node> Nodes { get; set; }
    public virtual DbSet<Task> Tasks { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>(entity =>
        {
            entity.HasKey(n => n.Id).HasName("PK_Node");
            entity.ToTable("Node");
            entity.HasMany(n => n.Children)
                .WithOne(n => n.Parent)
                .HasForeignKey(n => n.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        });
       
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id).HasName("PK_User");
            entity.ToTable("User");
            entity.HasMany(p => p.Projects)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);
        });
        
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(p => p.Id).HasName("PK_Project");
            entity.ToTable("Project");
            entity.HasMany(p => p.Nodes)
                .WithOne(n => n.Project)
                .HasForeignKey(n => n.ProjectId);
                
        });
        modelBuilder.Entity<Node>(entity =>
        {
            entity.HasOne(n => n.Task)
                .WithOne()
                .HasForeignKey<Node>(n => n.TaskId);
        });
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
}