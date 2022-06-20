using System.Net.Http.Headers;

namespace WatchVideo.Services;

public interface IHttpClient
{
    Uri? GetBaseAddress();
    void SetBaseAddress(Uri? baseAddressUri);
    void ClearAcceptRequestHeaders();
    void AddAcceptRequestHeaders(string mediaType);
    Task<HttpResponseMessage> GetAsync(string? requestUri);
}
