using System.Net.Http.Headers;

namespace WatchVideo.Services.Implementations
{
    public class HttpClientWrapper : IHttpClient
    {
        private static HttpClient client = new HttpClient();

        public HttpClientWrapper()
        {

        }

        public Uri? GetBaseAddress()
        {
            return client.BaseAddress;
        }

        public void SetBaseAddress(Uri? baseAddressUri)
        {
            client.BaseAddress = baseAddressUri;
        }

        public void ClearAcceptRequestHeaders()
        {
            client.DefaultRequestHeaders.Accept.Clear();
        }
        public void AddAcceptRequestHeaders(string mediaType)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
        }

        public async Task<HttpResponseMessage> GetAsync(string? requestUri)
        {
            return await client.GetAsync(requestUri);
        }
    }
}
