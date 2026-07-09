namespace MtgjsonDownloader;

internal class Compressor
{
    internal static void UnzipFile(string mtgjsonfile, string zipFilePath, string extractPath)
    {
        if (!Directory.Exists(extractPath))
        {
            Directory.CreateDirectory(extractPath);
        }

        System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, extractPath, true);
    }
}
