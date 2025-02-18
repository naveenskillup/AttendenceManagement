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
        public DbSet<ClassInfo> ClassInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassInfo>()
                .HasAlternateKey(x => x.Class);

            modelBuilder.Entity<ClassInfo>()
                .Property(x => x.Limit)
                .HasDefaultValue(50);

            //modelBuilder.Entity<Teacher>()
            //    .HasIndex(t => t.Id)
            //    .IsClustered()
            //    .HasDatabaseName("IX_Teacher_Id");
        }

    }
}
