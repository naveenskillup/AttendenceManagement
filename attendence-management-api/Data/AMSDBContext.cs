using AttendenceManagementDefinitions;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementData
{
    public class AMSDBContext : DbContext
    {
        public AMSDBContext(DbContextOptions<AMSDBContext> options) : base(options)
        { }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Teacher>()
            //    .HasIndex(t => t.Id)
            //    .IsClustered()
            //    .HasDatabaseName("IX_Teacher_Id");
        }

    }
}
