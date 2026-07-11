using Du;

namespace MtgjsonDownloader.Core;

internal class Extract
{
    internal static void JsonFile(string mtgjsonFile, string zipLocalPath)
    {
        switch (mtgjsonFile)
        {
            case "AllDeckFiles":
            case "AllSetFiles":
                DuZip.UnzipFile(zipLocalPath, Path.Combine(AppContext.BaseDirectory, "Database"));

                break;

            default:
            {
                var subPath = Path.GetFileNameWithoutExtension(mtgjsonFile);

                DuZip.UnzipFile(zipLocalPath, Path.Combine(AppContext.BaseDirectory, "Database", subPath));

                break;
            }
        }
    }
}