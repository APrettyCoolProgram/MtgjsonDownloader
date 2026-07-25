// 260711_code
// 260711_documentation

namespace MtgjsonDownloader.Core;

/// <summary>Catalog.</summary>
internal static class Catalog
{
    /// <summary>Gets the message displayed when the application starts.</summary>
    /// <returns>The start message.</returns>
    internal static string msg_StartApp() =>
        $"[Starting MTGJSON Downloader]{Environment.NewLine}";

    /// <summary>Gets the message displayed when the downloads are complete.</summary>
    /// <returns>The completion message.</returns>
    internal static string msg_Complete() =>
        $"{Environment.NewLine}" +
        $"[Downloads complete]{Environment.NewLine}" +
        $"{Environment.NewLine}";

    /// <summary>Gets the message displayed when there is an error reading the configuration file.</summary>
    /// <param name="ex">The exception that occurred.</param>
    /// <returns>The error message.</returns>
    internal static string msg_ConfigError(Exception ex) =>
        $"{Environment.NewLine}" +
        $"Error reading configuration file:{Environment.NewLine}" +
        $"{ex.Message}{Environment.NewLine}" +
        $"{Environment.NewLine}" +
        $"Press any key to exit.";
}