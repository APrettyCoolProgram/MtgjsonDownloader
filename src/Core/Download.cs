// 260711_code
// 260711_documentation

using Du;

namespace MtgjsonDownloader.Core;

internal static class Download
{
    internal static void FromMtgjsonDotCom(Config config)
    {
        JsonFiles(config.MtgjsonRootUrl, config.MtgjsonFiles, config.VerifyHashes);



    }

    internal static void JsonFiles(string mtgjsonRootUrl, List<string> mtgjsonFiles, bool verifyHashes)
    {
        foreach (var mtgjsonfile in mtgjsonFiles)
        {
            // Download the zip file from the URL and save it to the local MTGJSON path
            var zipUrl       = $"{mtgjsonRootUrl}/{mtgjsonfile}.zip";
            var zipLocalPath = Path.Combine(AppContext.BaseDirectory, "MTGJSON", $"{mtgjsonfile}.zip");

            _ = DuInternet.DownloadUrlToLocalFile(zipUrl, zipLocalPath, $"Downloading {mtgjsonfile}");

            if (verifyHashes)
            {
                HashFile(zipUrl, zipLocalPath);
                Console.WriteLine(DuHash.IsMatch(zipLocalPath, $"{zipLocalPath}.sha256", $"Verifying {mtgjsonfile} hash..."));

            }

            var justFileName = Path.GetFileNameWithoutExtension(mtgjsonfile);

            var extractPath = Path.Combine(AppContext.BaseDirectory, "Database", justFileName);

            DuZip.UnzipFile(zipLocalPath, extractPath);
        }
    }

    internal static void HashFile(string zipUrl, string zipLocalPath)
    {
        var hashUrl       = $"{zipUrl}.sha256";
        var hashLocalPath = $"{zipLocalPath}.sha256";

        _ = DuInternet.DownloadUrlToLocalFile(hashUrl, hashLocalPath, $"Downloading hash for {zipLocalPath}");
    }
}