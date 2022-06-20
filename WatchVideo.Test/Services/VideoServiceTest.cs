using Moq;
using WatchVideo.Models;
using WatchVideo.DTO;
using WatchVideo.Services;
using WatchVideo.Services.Implementations;
using NUnit.Framework;
using AutoMapper;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WatchVideo.Test.Services;

public class VideoServiceTest
{
    private Mock<IHttpClient> _clientMock;
    private Mock<IMapper> _mapperMock;
    private IVideoService _videoService;

    [SetUp]
    public void Setup()
    {
        _mapperMock = new Mock<IMapper>();
        _clientMock = new Mock<IHttpClient>();
        _clientMock.Setup(x => x.GetBaseAddress()).Returns((Uri)null).Verifiable();
        _clientMock.Setup(x => x.ClearAcceptRequestHeaders()).Verifiable();
        _clientMock.Setup(x => x.AddAcceptRequestHeaders(It.Is<string>(a => a.Equals("application/json")))).Verifiable();
        _clientMock.Setup(x => x.SetBaseAddress(It.Is<Uri>(a => a.Equals(AppSettings.HttpClient.BaseAddress)))).Verifiable();
        _videoService = new VideoService(_mapperMock.Object, _clientMock.Object);
        _clientMock.Verify();

        MockedVideoPageResponse = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent("{ " +
                "\"nextPage\":" + MockedNextPage.ToString().ToLower() + "," +
                "\"videos\": [" +
                        "{ " +
                            "\"id\": " + MockedVideoId + "," +
                            "\"title\": \"" + MockedVideoTitle + "\"," +
                            "\"description\": \"" + MockedVideoDescription + "\"," +
                            "\"videoSrc\": \"" + MockedVideoBaseVideoSrc + "\"," +
                            "\"uploadDate\": \"" + MockedVideoUploadDateJson + "\"," +
                            "\"videoThumbnail\": \"" + MockedVideoBaseVideoThumbnail + "\"" +
                        "}" +
                    "]" +
            "}"),
        };
        MockedVideoResponse = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Content = new StringContent("{ " +
                "\"id\": " + MockedVideoId + "," +
                "\"title\": \"" + MockedVideoTitle + "\"," +
                "\"description\": \"" + MockedVideoDescription + "\"," +
                "\"videoSrc\": \"" + MockedVideoBaseVideoSrc + "\"," +
                "\"uploadDate\": \"" + MockedVideoUploadDateJson + "\"," +
                "\"videoThumbnail\": \"" + MockedVideoBaseVideoThumbnail + "\"" +
            "}"),
        };
        MockedErrorResponse = new HttpResponseMessage
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
        };
    }

    [TearDown]
    public void TearDown()
    {
        _clientMock.VerifyNoOtherCalls();
        _mapperMock.VerifyNoOtherCalls();
    }


    [Test]
    public async Task GetVideosShouldReturnCorrectVideosWithSearch()
    {
        var expected = MockedVideoPage;
        _clientMock.Setup(x => x.GetAsync(It.Is<string>(x => x.Equals(MockedVideosSearchUri)))).Returns(Task.FromResult(MockedVideoPageResponse)).Verifiable();
        _mapperMock.Setup(x => x.Map<VideoPage>(It.Is<VideoPageDto>(x => ObjectEquals(x, MockedVideoPageDto)))).Returns(MockedVideoPage).Verifiable();

        var actual = await _videoService.GetVideosAsync(MockedVideoId, MockedSearch);

        Assert.AreEqual(expected.videos.Count, actual.videos.Count);
        Assert.AreEqual(expected.NextPage, actual.NextPage);
        var i = 0;
        foreach (var video in actual.videos)
        {
            AreVideosEqual(expected.videos[i], video);
            i++;
        }
        _clientMock.Verify();
        _mapperMock.Verify();
    }

    [Test]
    public async Task GetVideosShouldReturnCorrectVideos()
    {
        var expected = MockedVideoPage;
        _clientMock.Setup(x => x.GetAsync(It.Is<string>(x => x.Equals(MockedVideosUri)))).Returns(Task.FromResult(MockedVideoPageResponse)).Verifiable();
        _mapperMock.Setup(x => x.Map<VideoPage>(It.Is<VideoPageDto>(x => ObjectEquals(x, MockedVideoPageDto)))).Returns(MockedVideoPage).Verifiable();

        var actual = await _videoService.GetVideosAsync(MockedVideoId);

        Assert.AreEqual(expected.videos.Count, actual.videos.Count);
        Assert.AreEqual(expected.NextPage, actual.NextPage);
        var i = 0;
        foreach (var video in actual.videos)
        {
            AreVideosEqual(expected.videos[i], video);
            i++;
        }
        _clientMock.Verify();
        _mapperMock.Verify();
    }

    [Test]
    public async Task GetVideosShouldReturnNull()
    {
        var expected = MockedVideoPage;
        _clientMock.Setup(x => x.GetAsync(It.Is<string>(x => x.Equals(MockedVideosUri)))).Returns(Task.FromResult(MockedErrorResponse)).Verifiable();

        var actual = await _videoService.GetVideosAsync(MockedVideoId);

        Assert.IsNull(actual);
        _clientMock.Verify();
        _mapperMock.Verify();
    }

    [Test]
    public async Task GetVideoShouldReturnCorrectVideo()
    {
        var expected = MockedVideo;
        _clientMock.Setup(x => x.GetAsync(It.Is<string>(x => x.Equals(MockedVideoUri)))).Returns(Task.FromResult(MockedVideoResponse)).Verifiable();
        _mapperMock.Setup(x => x.Map<Video>(It.Is<VideoDto>(x => ObjectEquals(x, MockedVideoDto)))).Returns(MockedVideo).Verifiable();

        var actual = await _videoService.GetVideoAsync(MockedVideoId);

        AreVideosEqual(expected, actual);
        _clientMock.Verify();
        _mapperMock.Verify();
    }

    [Test]
    public async Task GetVideoShouldReturnNull()
    {
        var expected = MockedVideo;
        _clientMock.Setup(x => x.GetAsync(It.Is<string>(x => x.Equals(MockedVideoUri)))).Returns(Task.FromResult(MockedErrorResponse)).Verifiable();

        var actual = await _videoService.GetVideoAsync(MockedVideoId);

        Assert.IsNull(actual);
        _clientMock.Verify();
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

    public static bool ObjectEquals(object a, object b)
    {
        string aSer = JsonSerializer.Serialize(a);
        string bSer = JsonSerializer.Serialize(b);

        return aSer == bSer;
    }

    public static int MockedVideoId = 2;
    public static int MockedPageId = 2;
    public static bool MockedNextPage = true;
    public static string MockedVideoUri => AppSettings.HttpClient.GetVideoUri + MockedVideoId;
    public static string MockedVideosUri => AppSettings.HttpClient.GetVideosUri + MockedPageId;
    public static string MockedSearch = "title";
    public static string MockedVideosSearchUri => MockedVideosUri + "?" + AppSettings.HttpClient.GetVideosSearchParam + "=" + MockedSearch;
    public static string MockedVideoTitle = "Example Title";
    public static string MockedVideoDescription = "Example description";
    public static string MockedVideoBaseVideoSrc = "vid/example.webm";
    public static string MockedVideoVideoSrc => AppSettings.HttpClient.BaseAddress + MockedVideoBaseVideoSrc;
    public static string MockedVideoBaseVideoThumbnail = "img/example.jpg";
    public static string MockedVideoVideoThumbnail => AppSettings.HttpClient.BaseAddress + MockedVideoBaseVideoThumbnail;
    public static DateTime MockedVideoUploadDate = DateTime.Parse("10 Jun 2002");
    public static string MockedVideoUploadDateJson = "2002-06-10T00:00:00";
    public static Video MockedVideo = new Video
    {
        Id = MockedVideoId,
        Description = MockedVideoDescription,
        Title = MockedVideoTitle,
        UploadDate = MockedVideoUploadDate,
        VideoSrc = MockedVideoVideoSrc,
        VideoThumbnail = MockedVideoVideoThumbnail
    };
    public static VideoDto MockedVideoDto = new VideoDto
    {
        Id = MockedVideoId,
        Description = MockedVideoDescription,
        Title = MockedVideoTitle,
        UploadDate = MockedVideoUploadDate,
        VideoSrc = MockedVideoBaseVideoSrc,
        VideoThumbnail = MockedVideoBaseVideoThumbnail
    };
    public static HttpResponseMessage MockedVideoResponse;
    public static HttpResponseMessage MockedVideoPageResponse;
    public static HttpResponseMessage MockedErrorResponse;
    public static VideoPageDto MockedVideoPageDto = new VideoPageDto
    {
        NextPage = true,
        Videos = new List<VideoDto>
        {
            MockedVideoDto
        }
    };
    public static VideoPage MockedVideoPage = new VideoPage
    {
        NextPage = true,
        videos = new List<Video>
        {
            MockedVideo
        }
    };
}
