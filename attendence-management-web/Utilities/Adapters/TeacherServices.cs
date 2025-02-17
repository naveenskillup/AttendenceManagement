using AttendenceManagementDefinitions;

namespace AttendenceManagementWeb.ExternalServices
{
    public class TeacherServices : ITeacherServices
    {
        private readonly ExternalApiClient _apiClient;

        public TeacherServices(ExternalApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Teacher?>> GetAllTeachersAsync()
         => await _apiClient.SendRequestAsync<List<Teacher>>(HttpMethod.Get, "teacher/all", null);

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
            => await _apiClient.SendRequestAsync<Teacher>(HttpMethod.Get, $"teacher?id={id}", null);

        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
            => await _apiClient.SendRequestAsync<Teacher>(HttpMethod.Post, "teacher", teacher);

        public async Task<bool> UpdateTeacherAsync(int id, Teacher teacher) 
            =>  await _apiClient.SendRequestAsync<bool>(HttpMethod.Put, $"teacher?id={id}", teacher);

        public async Task<bool> DeleteTeacherAsync(int id)
            => await _apiClient.SendRequestAsync<bool>(HttpMethod.Delete, $"teacher?id={id}", null);
    }
}