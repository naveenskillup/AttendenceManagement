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
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherClassSubject> TeacherClassSubjects { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassInfo>()
                .HasAlternateKey(x => x.Class);

            modelBuilder.Entity<ClassInfo>()
                .Property(x => x.Limit)
                .HasDefaultValue(50);

            /*many to many relationship*/
            modelBuilder.Entity<TeacherClassSubject>()
                .HasOne(x => x.Teacher)
                .WithMany(x => x.TeacherClassSubjects)
                .HasForeignKey(x => x.TeacherId);

            modelBuilder.Entity<TeacherClassSubject>()
                .HasOne(x => x.ClassInfo)
                .WithMany(x => x.TeacherClassSubjects)
                .HasForeignKey(x => x.ClassInfoId);

            modelBuilder.Entity<TeacherClassSubject>()
                .HasOne(x => x.Subject)
                .WithMany(x => x.TeacherClassSubjects)
                .HasForeignKey(x => x.SubjectId);

            modelBuilder.Entity<Student>()
                .HasOne(x => x.ClassInfo)
                .WithMany(x => x.Students)
                .HasPrincipalKey(x => x.Class)
                .HasForeignKey(x => x.Class);
        }

    }
}
