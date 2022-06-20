using WatchVideo.Models;

namespace WatchVideo.Services.Implementations
{
    public class DemoService : IDemoService
    {
        public const int perPage = 20;
        public static readonly List<Video> videos = new List<Video>
        {
            new Video {
                Id = 1,
                Title = "Big Buck Bunny",
                Description = "Big Buck Bunny tells the story of a giant rabbit with a heart bigger than himself. When one sunny day three rodents rudely harass him, something snaps... and the rabbit ain't no bunny anymore! In the typical cartoon tradition he prepares the nasty rodents a comical revenge.\n\nLicensed under the Creative Commons Attribution license\nhttp://www.bigbuckbunny.org",
                UploadDate = DateTime.Now,
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/BigBuckBunny.jpg",
            },
            new Video
            {
                Id = 2,
                Title = "Elephant Dream",
                Description = "The first Blender Open Movie from 2006",
                UploadDate = DateTime.Now.AddDays(-1),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ElephantsDream.jpg",
            },
            new Video
            {
                Id = 3,
                Title = "For Bigger Blazes",
                Description = "HBO GO now works with Chromecast -- the easiest way to enjoy online video on your TV. For when you want to settle into your Iron Throne to watch the latest episodes. For $35.\nLearn how to use Chromecast with HBO GO and more at google.com/chromecast.",
                UploadDate = DateTime.Now.AddDays(-5),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ForBiggerBlazes.jpg",
            },
            new Video
            {
                Id = 4,
                Title = "For Bigger Escape",
                Description = "Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for when Batman's escapes aren't quite big enough. For $35. Learn how to use Chromecast with Google Play Movies and more at google.com/chromecast.",
                UploadDate = DateTime.Now.AddDays(-10),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ForBiggerEscapes.jpg",
            },
            new Video
            {
                Id = 5,
                Title = "For Bigger Fun",
                Description = "Introducing Chromecast. The easiest way to enjoy online video and music on your TV. For $35.  Find out more at google.com/chromecast.",
                UploadDate = DateTime.Now.AddDays(-8),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ForBiggerFun.jpg",
            },
            new Video
            {
                Id = 6,
                Title = "For Bigger Joyrides",
                Description = "Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for the times that call for bigger joyrides. For $35. Learn how to use Chromecast with YouTube and more at google.com/chromecast.",
                UploadDate = DateTime.Now.AddDays(-12),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ForBiggerJoyrides.jpg",
            },
            new Video
            {
                Id = 7,
                Title = "For Bigger Meltdowns",
                Description = "Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for when you want to make Buster's big meltdowns even bigger. For $35. Learn how to use Chromecast with Netflix and more at google.com/chromecast.",
                UploadDate = DateTime.Now.AddDays(-4),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ForBiggerMeltdowns.jpg",
            },
            new Video
            {
                Id = 8,
                Title = "Sintel",
                Description = "Sintel is an independently produced short film, initiated by the Blender Foundation as a means to further improve and validate the free/open source 3D creation suite Blender. With initial funding provided by 1000s of donations via the internet community, it has again proven to be a viable development model for both open 3D technology as for independent animation film.\nThis 15 minute film has been realized in the studio of the Amsterdam Blender Institute, by an international team of artists and developers. In addition to that, several crucial technical and creative targets have been realized online, by developers and artists and teams all over the world.\nwww.sintel.org",
                UploadDate = DateTime.Now.AddDays(-6),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/Sintel.jpg",
            },
            new Video
            {
                Id = 9,
                Title = "Subaru Outback On Street And Dirt",
                Description = "Smoking Tire takes the all-new Subaru Outback to the highest point we can find in hopes our customer-appreciation Balloon Launch will get some free T-shirts into the hands of our viewers.",
                UploadDate = DateTime.Now.AddDays(-11),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/SubaruOutbackOnStreetAndDirt.jpg",
            },
            new Video
            {
                Id = 10,
                Title = "Tears of Steel",
                Description = "Tears of Steel was realized with crowd-funding by users of the open source 3D creation tool Blender. Target was to improve and test a complete open and free pipeline for visual effects in film - and to make a compelling sci-fi film in Amsterdam, the Netherlands.  The film itself, and all raw material used for making it, have been released under the Creatieve Commons 3.0 Attribution license. Visit the tearsofsteel.org website to find out more about this, or to purchase the 4-DVD box with a lot of extras.  (CC) Blender Foundation - http://www.tearsofsteel.org",
                UploadDate = DateTime.Now.AddDays(-20),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/TearsOfSteel.jpg",
            },
            new Video
            {
                Id = 11,
                Title = "Volkswagen GTI Review",
                Description = "The Smoking Tire heads out to Adams Motorsports Park in Riverside, CA to test the most requested car of 2010, the Volkswagen GTI. Will it beat the Mazdaspeed3's standard-setting lap time? Watch and see...",
                UploadDate = DateTime.Now.AddDays(-19),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/VolkswagenGTIReview.jpg",
            },
            new Video
            {
                Id = 12,
                Title = "We Are Going On Bullrun",
                Description = "The Smoking Tire is going on the 2010 Bullrun Live Rally in a 2011 Shelby GT500, and posting a video from the road every single day! The only place to watch them is by subscribing to The Smoking Tire or watching at BlackMagicShine.com",
                UploadDate = DateTime.Now.AddDays(-24),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/WeAreGoingOnBullrun.jpg",
            },
            new Video
            {
                Id = 13,
                Title = "What care can you get for a grand?",
                Description = "The Smoking Tire meets up with Chris and Jorge from CarsForAGrand.com to see just how far $1,000 can go when looking for a car.The Smoking Tire meets up with Chris and Jorge from CarsForAGrand.com to see just how far $1,000 can go when looking for a car.",
                UploadDate = DateTime.Now.AddDays(-15),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/WhatCarCanYouGetForAGrand.jpg",
            },
            new Video
            {
                Id = 14,
                Title = "Example Video 1",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-13),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/TearsOfSteel.jpg",
            },
            new Video
            {
                Id = 15,
                Title = "Example Video 2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-11),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/BigBuckBunny.jpg",
            },
            new Video
            {
                Id = 16,
                Title = "Example Video 3",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-9),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ElephantsDream.jpg",
            },
            new Video
            {
                Id = 17,
                Title = "Example Video 4",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-3),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/WeAreGoingOnBullrun.jpg",
            },
            new Video
            {
                Id = 18,
                Title = "Example Video 5",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-43),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/Sintel.jpg",
            },
            new Video
            {
                Id = 19,
                Title = "Example Video 6",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-18),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ForBiggerMeltdowns.jpg",
            },
            new Video
            {
                Id = 20,
                Title = "Example Video 7",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-3),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/ForBiggerFun.jpg",
            },
            new Video
            {
                Id = 21,
                Title = "Example Video 8",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-2),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/WeAreGoingOnBullrun.jpg",
            },
            new Video
            {
                Id = 22,
                Title = "Example Video 9",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-31),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/SubaruOutbackOnStreetAndDirt.jpg",
            },
            new Video
            {
                Id = 23,
                Title = "Example Video 10",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer et elit nulla. Proin tellus ex, maximus vel mauris vitae, malesuada sagittis erat.",
                UploadDate = DateTime.Now.AddDays(-17),
                VideoSrc = "https://upload.wikimedia.org/wikipedia/commons/transcoded/c/c0/Big_Buck_Bunny_4K.webm/Big_Buck_Bunny_4K.webm.720p.webm",
                VideoThumbnail = "/img/Sintel.jpg",
            },
        };

        public DemoService()
        {

        }

        public async Task<VideoPage> GetVideosAsync(int page, string? search = null)
        {
            VideoPage videoPage = new VideoPage();
            IEnumerable<Video> vids = from v in videos
                                      select v; 
            if(search != null)
            {
                vids = from v in videos
                       where v.Title.ToLower().Contains(search.ToLower())
                       select v;
            }
            vids = vids.Skip(page * perPage).Take(perPage + 1);
            videoPage.NextPage = vids.Count() > perPage ? true : false;
            videoPage.videos = vids.Take(perPage).ToList();
            return videoPage;
        }

        public async Task<Video> GetVideoAsync(int id)
        {
            Video video = (from v in videos
                           where v.Id == id
                           select v).FirstOrDefault();
            return video;
        }
    }
}
