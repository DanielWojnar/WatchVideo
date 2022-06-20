using WatchVideo.Models;
using AutoMapper;
using WatchVideo.DTO;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WatchVideo.Services.Implementations;

public class VideoService : IVideoService
{
    private readonly IMapper _mapper;
    private readonly IHttpClient _client;

    public VideoService(IMapper mapper, IHttpClient client)
    {
        _mapper = mapper;
        _client = client;
        if (_client.GetBaseAddress() == null)
        {
            _client.SetBaseAddress(new Uri(AppSettings.HttpClient.BaseAddress));
            _client.ClearAcceptRequestHeaders();
            _client.AddAcceptRequestHeaders("application/json");
        }
    }

    public async Task<VideoPage> GetVideosAsync(int page, string? search = null)
    {
        VideoPage videoPage = null;
        string uri = AppSettings.HttpClient.GetVideosUri + page;
        uri = uri + (search != null ? "?" + AppSettings.HttpClient.GetVideosSearchParam + "=" + search : "");
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                VideoPageDto videoPageDto = await JsonSerializer.DeserializeAsync<VideoPageDto>(await response.Content.ReadAsStreamAsync());
                videoPage = _mapper.Map<VideoPage>(videoPageDto);
            }
            foreach (Video vid in videoPage.videos)
            {
                vid.VideoSrc = AppSettings.HttpClient.BaseAddress + vid.VideoSrc;
                vid.VideoThumbnail = AppSettings.HttpClient.BaseAddress + vid.VideoThumbnail;
            }
        }
        catch (Exception e)
        {

        }
        return videoPage;
    }

    public async Task<Video> GetVideoAsync(int id)
    {
        Video video = null;
        string uri = AppSettings.HttpClient.GetVideoUri + id;
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                VideoDto videoDto = await JsonSerializer.DeserializeAsync<VideoDto>(await response.Content.ReadAsStreamAsync());
                video = _mapper.Map<Video>(videoDto);
                video.VideoSrc = AppSettings.HttpClient.BaseAddress + video.VideoSrc;
                video.VideoThumbnail = AppSettings.HttpClient.BaseAddress + video.VideoThumbnail;
            }
        }
        catch (Exception e)
        {

        }
        return video;
    }
}
