// 260711_code
// 260711_documentation

using Du;

namespace MtgjsonDownloader.Core;

internal static class Database
{
    /// <summary>Builds the MTGJSON database by downloading and extracting the specified files from the given root URL. Optionally verifies the hashes of the downloaded files.</summary>
    /// <param name="mtgjsonRootUrl">The root URL for the MTGJSON API.</param>
    /// <param name="mtgjsonFiles">The list of MTGJSON files to download.</param>
    /// <param name="verifyHashes">Indicates whether to verify the hashes of the downloaded files.</param>
    internal static void Build(string mtgjsonRootUrl, List<string> mtgjsonFiles, bool verifyHashes)
    {
        foreach (var mtgjsonFile in mtgjsonFiles)
        {
            // Download the zip file from the URL and save it to the local MTGJSON path
            var zipUrl       = $"{mtgjsonRootUrl}/{mtgjsonFile}.zip";
            var zipLocalPath = Path.Combine(AppContext.BaseDirectory, "MTGJSON", $"{mtgjsonFile}.zip");

            Console.WriteLine(DuInternet.DownloadUrl(zipUrl, zipLocalPath, $"Downloading {mtgjsonFile}"));

            if (verifyHashes)
            {
                HashFile(zipUrl, zipLocalPath);

                Console.WriteLine(DuHash.IsMatch(zipLocalPath, $"{zipLocalPath}.sha256", $"Verifying {mtgjsonFile} hash..."));
            }

            Extract.JsonFile(mtgjsonFile, zipLocalPath); //TODO message user
        }
    }

    /// <summary>Downloads the hash file for the specified zip file from the given URL and saves it to the local path.</summary>
    /// <param name="zipUrl">The URL of the zip file.</param>
    /// <param name="zipLocalPath">The local path where the zip file is saved.</param>
    private static void HashFile(string zipUrl, string zipLocalPath)
    {
        var hashUrl       = $"{zipUrl}.sha256";
        var hashLocalPath = $"{zipLocalPath}.sha256";

        _ = DuInternet.DownloadUrl(hashUrl, hashLocalPath, $"Downloading hash for {zipLocalPath}");
    }
}