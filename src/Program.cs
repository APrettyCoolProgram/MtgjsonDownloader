// 260709_code
// 260709_documentation

using MtgjsonDownloader.Core;

namespace MtgjsonDownloader;

internal class Program
{
    private static readonly string _configFilePath = Path.Combine(AppContext.BaseDirectory, "MtgjsonDownloader.config");

    private static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine(Catalog.msg_StartApp());

        Config config = Config.Load(_configFilePath);

        Framework.Verify(config.FrameworkDirectories);

        Download.MtgjsonJson(config);

        Console.WriteLine(Catalog.msg_Complete());
    }
}