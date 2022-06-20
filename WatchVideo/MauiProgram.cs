using WatchVideo.Services;
using WatchVideo.Services.Implementations;

namespace WatchVideo;
public static class MauiProgram
{
#if NOT_CLEAN_BUILD
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});
		builder.Services.AddTransient<IVideoService, VideoService>();
		builder.Services.AddTransient<IDemoService, DemoService>();
		builder.Services.AddTransient<IHttpClient, HttpClientWrapper>();
		builder.Services.AddAutoMapper(typeof(MauiProgram).Assembly);
		builder.Services.AddMauiBlazorWebView();
#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		return builder.Build();
	}
#else
	public static void Main(string[] args)
    {

    }
#endif
}
