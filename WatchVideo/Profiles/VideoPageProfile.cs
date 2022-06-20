using AutoMapper;
using WatchVideo.DTO;
using WatchVideo.Models;

namespace WatchVideo.Profiles;

public class VideoPageProfile : Profile
{
    public VideoPageProfile()
    {
        CreateMap<VideoPageDto, VideoPage>();
    }
}
