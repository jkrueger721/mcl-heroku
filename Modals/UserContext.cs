using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusiCoLab2.Modals;

namespace MusiCoLab2.Models
{
    
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<IProject> Projects { get; set; }
        public DbSet<ProjectContributor> ProjectContributors { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IProject>()
                .HasOne(po => po.ProjectOwner);

            modelBuilder.Entity<ProjectContributor>()
             .HasKey(t => new { t.ProjectId, t.UserId });

            modelBuilder.Entity<ProjectContributor>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.ProjectContributors)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<ProjectContributor>()
                .HasOne(pt => pt.Project)
                .WithMany(t => t.ProjectContributors)
                .HasForeignKey(pt => pt.ProjectId);




        }
    }
}
