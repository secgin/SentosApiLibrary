namespace SentosApiLibrary.Abstracts
{
    public interface IHttpClientService
    {
        Task<IResult<T>> GetAsync<T>(string uri, List<KeyValuePair<string, string>>? parameters = null);

        Task<IResult> PostAsync(string uri, object body);

        Task<IResult<T>> PostAsync<T>(string uri, object body);

        Task<IResult<T>> PutAsync<T>(string uri, object body);
    }
}
