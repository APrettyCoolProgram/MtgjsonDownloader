// 260711_code
// 260725_documentation

using MtgjsonDownloader.Core;

namespace MtgjsonDownloader;

/// <summary>The main entry point for the MTGJSON Downloader application.</summary>
internal class Program
{
    /// <summary> The main entry point for the MTGJSON Downloader application.</summary>
    /// <param name="args">The command-line arguments (currently not used).</param>
    private static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine(Catalog.msg_StartApp());

        Config config = Config.Load("MtgjsonDownloader.config");

        Framework.Verify(config.FrameworkDirectories);

        Database.Build(config.MtgjsonRootUrl, config.MtgjsonFiles, config.VerifyHashes);

        Console.WriteLine(Catalog.msg_Complete());
    }
}