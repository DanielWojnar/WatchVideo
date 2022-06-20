using AutoMapper;
using WatchVideo.DTO;
using WatchVideo.Models;

namespace WatchVideo.Profiles;

public class VideoProfile : Profile
{
    public VideoProfile()
    {
        CreateMap<VideoDto, Video>();
    }
}
