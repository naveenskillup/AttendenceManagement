using AttendenceManagementDefinitions;

namespace AttendenceManagementApi.Data.Interfaces
{
    public interface IClassInfoDataProvider
    {
        ClassInfo Get(int id);
        IEnumerable<ClassInfo> Get();
        void Save(ClassInfo classInfo);
        bool TryDelete(int id);
    }
}
