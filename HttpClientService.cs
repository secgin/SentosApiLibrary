using SentosApiLibrary.Abstracts;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SentosApiLibrary
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IConfig _config;

        public HttpClientService(IConfig config)
        {
            _config = config;
        }

        public async Task<IResult<T>> GetAsync<T>(string uri, List<KeyValuePair<string, string>>? parameters = null)
        {
            try
            {
                using HttpClient httpClient = new();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_config.GetApiKey()}:{_config.GetApiSecret()}")));

                if (parameters != null && parameters.Any())
                {
                    var query = string.Join("&", parameters.Select(p =>
                        $"{WebUtility.UrlEncode(p.Key)}={WebUtility.UrlEncode(p.Value)}"));
                    uri = uri.Contains("?") ? $"{uri}&{query}" : $"{uri}?{query}";
                }

                var httpResponse = await httpClient.GetAsync(_config.GetApiUrl() + uri);

                string content = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var response = JsonSerializer.Deserialize<Response>(content);
                    var message = response?.Message ?? content;
                    return Result<T>.Fail(httpResponse.StatusCode.ToString(), message);
                }

                var data = JsonSerializer.Deserialize<T>(content);
                if (data == null)
                    return Result<T>.Fail(httpResponse.StatusCode.ToString(), "Response is null");

                return Result<T>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(null, $"Hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult> PostAsync(string uri, object body)
        {
            try
            {
                using HttpClient httpClient = new();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_config.GetApiKey()}:{_config.GetApiSecret()}")));

                var json = JsonSerializer.Serialize(body);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var httpResponse = await httpClient.PostAsync(_config.GetApiUrl() + uri, httpContent);

                string content = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var message = "";
                    try
                    {
                        var response = JsonSerializer.Deserialize<Response>(content);
                        message = response?.Message ?? content;
                    }
                    catch
                    {
                        message = "Response could not be deserialized";
                    }
                    return Result.Fail(httpResponse.StatusCode.ToString(), message);
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(null, $"Hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult<T>> PostAsync<T>(string uri, object body)
        {
            try
            {
                using HttpClient httpClient = new();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_config.GetApiKey()}:{_config.GetApiSecret()}")));

                var json = JsonSerializer.Serialize(body);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var httpResponse = await httpClient.PostAsync(_config.GetApiUrl() + uri, httpContent);

                string content = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var response = JsonSerializer.Deserialize<Response>(content);
                    var message = response?.Message ?? content;
                    return Result<T>.Fail(httpResponse.StatusCode.ToString(), message);
                }

                var data = JsonSerializer.Deserialize<T>(content);
                if (data == null)
                    return Result<T>.Fail(httpResponse.StatusCode.ToString(), "Response is null");

                return Result<T>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(null, $"Hata oluştu: {ex.Message}");
            }
        }

        public async Task<IResult<T>> PutAsync<T>(string uri, object body)
        {
            try
            {
                using HttpClient httpClient = new();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_config.GetApiKey()}:{_config.GetApiSecret()}")));

                var json = JsonSerializer.Serialize(body);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var httpResponse = await httpClient.PutAsync(_config.GetApiUrl() + uri, httpContent);

                string content = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var response = JsonSerializer.Deserialize<Response>(content);
                    var message = response?.Message ?? content;
                    return Result<T>.Fail(httpResponse.StatusCode.ToString(), message);
                }

                var data = JsonSerializer.Deserialize<T>(content);
                if (data == null)
                    return Result<T>.Fail(httpResponse.StatusCode.ToString(), "Response is null");

                return Result<T>.Success(data);
            }
            catch (Exception ex)
            {
                return Result<T>.Fail(null, $"Hata oluştu: {ex.Message}");
            }
        }
    }
}
