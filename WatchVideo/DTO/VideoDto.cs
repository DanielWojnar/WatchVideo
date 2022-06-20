using System;
using System.Text.Json.Serialization;

namespace WatchVideo.DTO;

public class VideoDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("videoSrc")]
    public string VideoSrc { get; set; }
    [JsonPropertyName("uploadDate")]
    public DateTime UploadDate { get; set; }
    [JsonPropertyName("videoThumbnail")]
    public string VideoThumbnail { get; set; }
}
