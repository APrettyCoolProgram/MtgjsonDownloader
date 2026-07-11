// 260711_code
// 260711_documentation

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

        Database.Build(config.MtgjsonRootUrl, config.MtgjsonFiles, config.VerifyHashes);

        Console.WriteLine(Catalog.msg_Complete());
    }
}