using AttendenceManagementApi.Data.Interfaces;
using AttendenceManagementData;
using AttendenceManagementDefinitions;
using AttendenceManagementDefinitions.DTOs;

namespace AttendenceManagementApi.Data
{
    public class ClassInfoDataProvider : IClassInfoDataProvider
    {
        public ClassInfoDataProvider(AMSDBContext context)
          => _context = context;

        public IEnumerable<ClassInfo> Get()
            => _context.ClassInfos;

        public ClassInfo Get(int id)
            => _context.ClassInfos.FirstOrDefault(c => c.Class == id);

        public void Save(ClassInfo classInfo)
        {
            _context.Add(classInfo);
            _context.SaveChanges();
        }

        private readonly AMSDBContext _context;
    }
}
