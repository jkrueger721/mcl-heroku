using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace MusiCoLab2.Models
{
    
    public class UserContext : DbContext
    {


        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
       // public DbSet<ProjectUser> ProjectUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUser>()
                .HasKey(t => new { t.ProjectId, t.UserId });

            //modelBuilder.Entity<ProjectUser>()
            //    .HasOne(pt => pt.Project)
            //    .WithMany(p => p.ProjectUsers)
            //    .HasForeignKey(pt => pt.ProjectId);

            //modelBuilder.Entity<ProjectUser>()
            //    .HasOne(pt => pt.User)
            //    .WithMany(t => t.ProjectUsers)
            //    .HasForeignKey(pt => pt.UserId);
        }
    }
}
