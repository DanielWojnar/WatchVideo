namespace WatchVideo.Models;

public class VideoPage
{
    public bool NextPage { get; set; }
    public IList<Video> videos { get; set; }
}
