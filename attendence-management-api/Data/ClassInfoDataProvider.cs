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

        public bool TryDelete(int id)
        {
            var classInfo = _context.ClassInfos.FirstOrDefault(t => t.Id == id);
            if (classInfo == null)
                return false;

            _context.ClassInfos.Remove(classInfo);
            _context.SaveChanges();
            return true;
        }

        private readonly AMSDBContext _context;
    }
}
