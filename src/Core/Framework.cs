// 260709_code
// 260709_documentation

namespace MtgjsonDownloader;

internal class Framework
{
    internal static void Verify(List<string> directories)
    {
        foreach (var directory in directories)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}