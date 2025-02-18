using System.Text;
using Newtonsoft.Json;

namespace AttendenceManagementWeb.ExternalServices
{
    public class ExternalApiClient
    {
        public ExternalApiClient(HttpClient httpClient, IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration.GetValue<string>(_apiBaseUrlTag) ?? throw new ArgumentNullException("Api base url not found");
        }
        
        public async Task<T?> SendRequestAsync<T>(HttpMethod method, string endpoint, object? data)
        {
            try
            {
                using var request = new HttpRequestMessage(method, new Uri($"{_apiBaseUrl}{endpoint}"));

                if (data == null && (method == HttpMethod.Post || method == HttpMethod.Put))
                    throw new Exception("body required");

                if (method == HttpMethod.Post || method == HttpMethod.Put)
                    request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                using var response = await _httpClient.SendAsync(request);
                var stringResult = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Api exception {response.StatusCode} - {stringResult}");

                
                return JsonConvert.DeserializeObject<T>(stringResult);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error while making API request to {endpoint}: {ex.Message}", ex);
            }
            
        }
        
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private const string _apiBaseUrlTag = "AMSAPI";
    }
}
