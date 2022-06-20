using System.Text.Json.Serialization;

namespace WatchVideo.DTO;

public class VideoPageDto
{
    [JsonPropertyName("nextPage")]
    public bool NextPage { get; set; }
    [JsonPropertyName("videos")]
    public IList<VideoDto> Videos { get; set; }
}
