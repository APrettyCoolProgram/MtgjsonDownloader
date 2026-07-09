// 260709_code
// 260709_documentation

namespace MtgjsonDownloader;

internal static class Download
{
    internal static void MtgjsonJson(Config config)
    {
        Console.WriteLine("Downloading MTGJSON files...");

        foreach (var mtgjsonfile in config.MtgjsonFiles)
        {
            var compressedUrl      = $"{config.MtgjsonRootUrl}/{mtgjsonfile}.zip";
            var compressedFilePath = Path.Combine(AppContext.BaseDirectory, "MTGJSON", $"{mtgjsonfile}.zip");

            using HttpClient downloadCompressed = Download(compressedUrl, mtgjsonfile, compressedFilePath);

            if (config.VerifyHashes)
            {
                var hashUrl      = $"{config.MtgjsonRootUrl}/{mtgjsonfile}.zip.sha256";
                var hashFilePath = $"{compressedFilePath}.sha256";

                using HttpClient downloadHash = Download(hashUrl, $"{mtgjsonfile} hash", hashFilePath);

                VerifyHash(mtgjsonfile, compressedFilePath, hashFilePath);
            }

            var justFileName= Path.GetFileNameWithoutExtension(mtgjsonfile);

            var extractPath = Path.Combine(AppContext.BaseDirectory, "Database", justFileName);
            UnzipFile(mtgjsonfile, compressedFilePath, extractPath);
        }
    }

}
