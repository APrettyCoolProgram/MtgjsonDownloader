using System.Security.Cryptography;

namespace MtgjsonDownloader;

internal class Hash
{
    internal static void Verify(string mtgjsonfile, string compressedFilePath, string hashFilePath)
    {
        if (!File.Exists(compressedFilePath) || !File.Exists(hashFilePath))
        {
            Console.WriteLine($"Either {mtgjsonfile} or {hashFilePath} does not exist.");
        }

        var computedHash = GetFileHash(compressedFilePath);
        var expectedHash = File.ReadAllText(hashFilePath).Trim();

        if (!computedHash.Equals(expectedHash, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Hash verification failed for {mtgjsonfile}. Expected: {expectedHash}, Computed: {computedHash}");

        }
    }

    private static string GetFileHash(string filePath)
    {
        using var sha256 = SHA256.Create();
        using var stream = File.OpenRead(filePath);
        var hash = sha256.ComputeHash(stream);

        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}
