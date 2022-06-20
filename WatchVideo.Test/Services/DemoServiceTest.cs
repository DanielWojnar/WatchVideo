using WatchVideo.Models;
using WatchVideo.Services;
using WatchVideo.Services.Implementations;
using NUnit.Framework;

namespace WatchVideo.Test.Services;

public class DemoServiceTest
{
    private IVideoService _demoService;

    [SetUp]
    public void Setup()
    {
        _demoService = new DemoService();
    }

    [TestCaseSource(nameof(GetVideosAsyncShouldReturnCorrectVideos_Source))]
    public async Task GetVideosAsyncShouldReturnProperVideos(int page, string search, VideoPage expected)
    {
        var actual = await _demoService.GetVideosAsync(page, search);

        Assert.AreEqual(expected.videos.Count, actual.videos.Count);
        Assert.AreEqual(expected.NextPage, actual.NextPage);
        var i = 0;
        foreach (var video in actual.videos)
        {
            AreVideosEqual(expected.videos[i], video);
            i++;
        }
    }

    [Test]
    public async Task GetVideoAsyncShouldReturnProperVideo()
    {
        var expected = MockedVideo;

        var actual = await _demoService.GetVideoAsync(MockedVideoId);

        AreVideosEqual(expected, actual);
    }

    [Test]
    public async Task GetVideoAsyncShouldReturnNull()
    {
        var actual = await _demoService.GetVideoAsync(MockedInvalidVideoId);

        Assert.IsNull(actual);
    }

    private void AreVideosEqual(Video expected, Video actual)
    {
        Assert.AreEqual(expected.Id, actual.Id);
        Assert.AreEqual(expected.Title, actual.Title);
        Assert.AreEqual(expected.Description, actual.Description);
        Assert.AreEqual(expected.UploadDate, actual.UploadDate);
        Assert.AreEqual(expected.VideoSrc, actual.VideoSrc);
        Assert.AreEqual(expected.VideoThumbnail, actual.VideoThumbnail);
    }

    static IEnumerable<TestCaseData> GetVideosAsyncShouldReturnCorrectVideos_Source()
    {
        yield return new TestCaseData(0, "", new VideoPage { NextPage = true, videos = DemoService.videos.ToList().GetRange(0, DemoService.perPage) });
        yield return new TestCaseData(1, "", new VideoPage { NextPage = false, videos = DemoService.videos.ToList().GetRange(DemoService.perPage, 3) });
        yield return new TestCaseData(0, "Example Video 1", new VideoPage { NextPage = false, videos = new List<Video> { DemoService.videos[13], DemoService.videos[22] } });
    }

    public static int MockedVideoId = 3;
    public static int MockedInvalidVideoId = -1;
    public static Video MockedVideo = DemoService.videos[2];
}
