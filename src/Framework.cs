// 260709_code
// 260709_documentation

namespace MtgjsonDownloader;

internal class Framework
{
    internal static void Verify(List<string> directories)
    {
        Console.WriteLine("Verifying framework...");

        foreach (var directory in directories)
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine($"  Creating directory: {directory}");
                Directory.CreateDirectory(directory);
            }
        }
    }
}
