using AttendenceManagementDefinitions;

namespace AttendenceManagementWeb.ExternalServices
{
    public class StudentServices : IStudentServices
    {
        private readonly ExternalApiClient _apiClient;


        public StudentServices(ExternalApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Student?>> GetAllStudentsAsync()
         => await _apiClient.SendRequestAsync<List<Student>>(HttpMethod.Get, "student/all", null);

        public async Task<Student?> GetStudentByIdAsync(int id)
            => await _apiClient.SendRequestAsync<Student>(HttpMethod.Get, $"student?id={id}", null);

        public async Task<Student> AddStudentAsync(Student student)
            => await _apiClient.SendRequestAsync<Student>(HttpMethod.Post, "student", student);

        public async Task<bool> UpdateStudentAsync(int id, Student student)
            => await _apiClient.SendRequestAsync<bool>(HttpMethod.Put, $"student?id={id}", student);

        public async Task<bool> DeleteStudentAsync(int id)
            => await _apiClient.SendRequestAsync<bool>(HttpMethod.Delete, $"student?id={id}", null);
    }
}
