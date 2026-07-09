// 260709_code
// 260709_documentation


using System.Security.Cryptography;

namespace MtgjsonDownloader;

internal class Program
{
    private static readonly string _configFilePath = Path.Combine(AppContext.BaseDirectory, "MtgjsonDownloader.config");

    private static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine("Starting MTGJSON Downloader...");

        Config config = Config.Load(_configFilePath);

        Framework.Verify(config.FrameworkDirectories);

        DisplaySettings(config.VerifyHashes);

        Download.MtgjsonJson(config);
    }

    private static void DisplaySettings(bool verifyHashes)
    {
        Console.WriteLine($"{Environment.NewLine}Verify hashes: {verifyHashes}");
    }


    private static HttpClient Downloader(string downloadUrl, string msg, string compressedFilePath)
    {
        Console.WriteLine($"  Downloading {msg}...");

        var client = new HttpClient();
        var response = client.GetAsync(downloadUrl).Result;

        if (response.IsSuccessStatusCode)
        {
            var content = response.Content.ReadAsByteArrayAsync().Result;
            File.WriteAllBytes(compressedFilePath, content);
        }
        else
        {
            Console.WriteLine($"  Failed to download {msg} - Status code: {response.StatusCode}");
        }

        return client;
    }

    private static void VerifyHash(string mtgjsonfile, string compressedFilePath, string hashFilePath)
    {
        if (!File.Exists(compressedFilePath) || !File.Exists(hashFilePath))
        {
            Console.WriteLine($"  Either {mtgjsonfile} or {hashFilePath} does not exist.");
        }

        var computedHash = GetFileHash(compressedFilePath);
        var expectedHash = File.ReadAllText(hashFilePath).Trim();

        if (computedHash.Equals(expectedHash, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"  Hash verification successful for {mtgjsonfile}.");
        }
        else
        {
            Console.WriteLine($"  Hash verification failed for {mtgjsonfile}. Expected: {expectedHash}, Computed: {computedHash}");

        }
    }

    private static string GetFileHash(string filePath)
    {
        using var sha256 = SHA256.Create();
        using var stream = File.OpenRead(filePath);
        var hash = sha256.ComputeHash(stream);

        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }

    private static void UnzipFile(string mtgjsonfile, string zipFilePath, string extractPath)
    {
        Console.WriteLine($"  Extracting {mtgjsonfile}...");

        if (!Directory.Exists(extractPath))
        {
            Directory.CreateDirectory(extractPath);
        }
        System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, extractPath, true);
    }
}