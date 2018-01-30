using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace MusiCoLab2.Models
{
    //public class UserContext : IDesignTimeDbContextFactory<UserContext>
    //{
    //    public UserContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
    //        optionsBuilder.UseSqlite("Data Source=blog.db");

    //        return new UserContext(optionsBuilder.Options);
    //    }
    //}
    public class UserContext : DbContext
    {


        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
    }
}
