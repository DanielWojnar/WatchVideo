using WatchVideo.Models;

namespace WatchVideo.Services;

public interface IVideoService
{
    Task<Video> GetVideoAsync(int id);
    Task<VideoPage> GetVideosAsync(int page, string? search = null);
}
