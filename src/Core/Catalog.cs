// 260710_code
// 260710_documentation

namespace MtgjsonDownloader.Core;

internal class Catalog
{
    internal static string msg_StartApp() =>
        $"[Starting MTGJSON Downloader]{Environment.NewLine}";

    internal static string msg_Complete() =>
        $"{Environment.NewLine}" +
        $"[Downloads complete]{Environment.NewLine}" +
        $"{Environment.NewLine}";
}
