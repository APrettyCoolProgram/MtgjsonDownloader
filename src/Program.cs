// 260709_code
// 260709_documentation

namespace MtgjsonDownloader;

internal class Program
{
    private static readonly string _configFilePath = Path.Combine(AppContext.BaseDirectory, "MtgjsonDownloader.config");

    private static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine($"[Starting MTGJSON Downloader]{Environment.NewLine}");

        Config config = Config.Load(_configFilePath);

        Framework.Verify(config.FrameworkDirectories);

        Download.MtgjsonJson(config);

        Console.WriteLine($"{Environment.NewLine}" +
                          $"[Downloads complete]{Environment.NewLine}");
    }
}