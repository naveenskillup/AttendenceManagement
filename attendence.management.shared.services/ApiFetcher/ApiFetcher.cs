using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace attendence.management.shared.services.ApiFetcher
{
    public class ApiFetcher<TApiFetchSettings>
        where TApiFetchSettings : ApiFetchSettings
    {

        public ApiFetcher(IHttpClientFactory httpClientFactory, TApiFetchSettings apiFetchSettings, string fetchOperation) 
        { 
            _httpClientFactory = httpClientFactory;
            _apiFetchSettings = apiFetchSettings;
            _fetchOperation = fetchOperation;
        }
        //
        //------------------------ Interfaces ---------------- 
        //
        public async Task<TResponse> Fetch<TResponse>(ApiFetchParameter parameter, Func<HttpContent, ApiFetchParameter, Task<TResponse>> postFetchOperation)
            => await PerformFetchIntervals(parameter, postFetchOperation);
        
        //
        //---------------------- Private Methods ------------------ 
        //
        private static async Task<HttpResponseMessage> PerformRequest(HttpClient client, ApiFetchParameter parameter)
        {
            var uri = parameter.Uri;
            var body = parameter.Body;
            return parameter.HttpMethod.Method switch
            {
                "GET" => await client.GetAsync(uri),
                "POST" => await client.PostAsync(uri, body),
                "PUT" => await client.PutAsync(uri, body),
                "DELETE" => await client.DeleteAsync(uri),
                _ => throw new InvalidOperationException("Unsupported request method")
            };
        }

        private async Task<TResponse> PerformFetch<TResponse>(ApiFetchParameter parameter, Func<HttpContent, ApiFetchParameter, Task<TResponse> postFetchOperation)
        {
            using var client = SetupHttpClient();
            using var httpResponse = await PerformRequest(client, parameter);
            httpResponse.EnsureSuccessStatusCode();
            var content = httpResponse.Content;
            var response = await postFetchOperation(content, parameter);
            return response;
        }

        private HttpClient SetupHttpClient()
        {
            var client = _httpClientFactory.CreateClient();
            if(_apiFetchSettings.RequestTimeout > 0)
                client.Timeout = TimeSpan.FromSeconds(_apiFetchSettings.RequestTimeout);
            return client;
        }

        private async Task<TResponse> PerformFetchIntervals<TResponse>(ApiFetchParameter parameter, Func<HttpContent, ApiFetchParameter, Task<TResponse>> postFetchOperation)
        {
            foreach(var attempt in Enumerable.Range(0, _apiFetchSettings.Retries))
            {
                try
                {
                    return await PerformFetch<TResponse>(parameter, postFetchOperation);
                }
                catch(Exception genericException)
                {
                    var errorMessage = genericException.Message;
                    await Task.Delay(TimeSpan.FromSeconds(_apiFetchSettings.Interval));
                }
            }
            throw new WebException("External Web API fetch failure. Exceeded all retries.");
        }

        //
        //------------------------ Attributes & Fields ---------------- 
        // 

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TApiFetchSettings _apiFetchSettings;
        private readonly string _fetchOperation;
    }
}
