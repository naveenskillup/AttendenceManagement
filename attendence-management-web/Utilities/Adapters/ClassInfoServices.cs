using AttendenceManagementDefinitions;
using AttendenceManagementWeb.ExternalServices;
using AttendenceManagementWeb.Utilities.Adapters.Interfaces;

namespace AttendenceManagementWeb.ExternalServices
{
    public class ClassInfoServices : IClassInfoServices
    {
        private readonly ExternalApiClient _apiClient;

        public ClassInfoServices(ExternalApiClient apiClient)
             => _apiClient = apiClient;

        public async Task<ClassInfo> GetClassInfoAsync(int id)
           => await _apiClient.SendRequestAsync<ClassInfo>(HttpMethod.Get, $"classinfo?id={id}", null);

        public async Task<IEnumerable<ClassInfo>> GetClassInfosAsync()
         => await _apiClient.SendRequestAsync<IEnumerable<ClassInfo>>(HttpMethod.Get, "classinfo/all", null);

        public async Task<ClassInfo> AddClassInfoAsync(ClassInfo student)
           => await _apiClient.SendRequestAsync<ClassInfo>(HttpMethod.Post, "classinfo", student);

    }
}
