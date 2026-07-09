// 260709_code
// 260709_documentation

namespace MtgjsonDownloader;

internal static class Download
{
    internal static void MtgjsonJson(Config config)
    {
        foreach (var mtgjsonfile in config.MtgjsonFiles)
        {
            var zipUrl       = $"{config.MtgjsonRootUrl}/{mtgjsonfile}.zip";
            var zipLocalPath = Path.Combine(AppContext.BaseDirectory, "MTGJSON", $"{mtgjsonfile}.zip");

            _ = ToLocalFile(zipUrl, zipLocalPath, $"Downloading {mtgjsonfile}");

            if (config.VerifyHashes)
            {
                var hashUrl       = $"{config.MtgjsonRootUrl}/{mtgjsonfile}.zip.sha256";
                var hashLocalPath = $"{zipLocalPath}.sha256";

                _ = ToLocalFile(hashUrl, hashLocalPath);

                Hash.Verify(mtgjsonfile, zipLocalPath, hashLocalPath);
            }

            var justFileName= Path.GetFileNameWithoutExtension(mtgjsonfile);

            var extractPath = Path.Combine(AppContext.BaseDirectory, "Database", justFileName);

            Compressor.UnzipFile(mtgjsonfile, zipLocalPath, extractPath);
        }
    }

    private static HttpClient ToLocalFile(string downloadUrl, string compressedFilePath, string msg = null)
    {
        if (msg != null)
        {
            Console.WriteLine(msg);
        }

        var client = new HttpClient();
        var response = client.GetAsync(downloadUrl).Result;

        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsByteArrayAsync().Result;
            File.WriteAllBytes(compressedFilePath, content);
        }
        else
        {
            if (msg != null)
            {
                Console.WriteLine($"{Environment.NewLine}" +
                                  $"Failed to download {msg}{Environment.NewLine}" +
                                  $"Status code:{Environment.NewLine}" +
                                  $"{response.StatusCode}");
            }
        }

        return client;
    }
}