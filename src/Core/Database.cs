// 260711_code
// 260711_documentation

using Du;

namespace MtgjsonDownloader.Core;

internal static class Database
{
    internal static void Build(string mtgjsonRootUrl, List<string> mtgjsonFiles, bool verifyHashes)
    {
        foreach (var mtgjsonFile in mtgjsonFiles)
        {
            // Download the zip file from the URL and save it to the local MTGJSON path
            var zipUrl       = $"{mtgjsonRootUrl}/{mtgjsonFile}.zip";
            var zipLocalPath = Path.Combine(AppContext.BaseDirectory, "MTGJSON", $"{mtgjsonFile}.zip");

            Console.WriteLine(DuInternet.DownloadUrlToLocalFile(zipUrl, zipLocalPath, $"Downloading {mtgjsonFile}"));

            if (verifyHashes)
            {
                HashFile(zipUrl, zipLocalPath);

                Console.WriteLine(DuHash.IsMatch(zipLocalPath, $"{zipLocalPath}.sha256", $"Verifying {mtgjsonFile} hash..."));
            }

            Extract.JsonFile(mtgjsonFile, zipLocalPath); //TODO message user
        }
    }

    private static void HashFile(string zipUrl, string zipLocalPath)
    {
        var hashUrl       = $"{zipUrl}.sha256";
        var hashLocalPath = $"{zipLocalPath}.sha256";

        _ = DuInternet.DownloadUrlToLocalFile(hashUrl, hashLocalPath, $"Downloading hash for {zipLocalPath}");
    }
}