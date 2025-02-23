using AttendenceManagementDefinitions;

namespace AttendenceManagementWeb.Utilities.Adapters.Interfaces
{
    public interface IClassInfoServices
    {
        Task<IEnumerable<ClassInfo>> GetClassInfosAsync();
        Task<ClassInfo> GetClassInfoAsync(int id);
        Task<ClassInfo> AddClassInfoAsync(ClassInfo classInfo);
        Task<bool> DeleteClassInfoAsync(int classId);
    }
}
