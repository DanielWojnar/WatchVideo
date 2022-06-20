namespace WatchVideo;

public static class AppSettings
{
    public static class HttpClient
    {
        public static string BaseAddress = "https://localhost:5001/";
        public static string GetVideosUri = "Videos/";
        public static string GetVideoUri = "Video/";
        public static string GetVideosSearchParam = "search";
    }
}
