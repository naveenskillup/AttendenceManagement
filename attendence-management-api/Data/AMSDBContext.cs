using AttendenceManagementData.Definitions;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementData
{
    public class AMSDBContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Teacher>()
            //    .HasIndex(t => t.Id)
            //    .IsClustered()
            //    .HasDatabaseName("IX_Teacher_Id");
        }

        private const string _connectionString = "Data Source=DESKTOP-170UE71\\SQLEXPRESS;Initial Catalog=AMSDB;Integrated Security=True;TrustServerCertificate=True;";
    }
}
