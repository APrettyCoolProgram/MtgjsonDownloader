using Du;

namespace MtgjsonDownloader.Core;

/// <summary>Logic related to extracting MTGJSON files from zip archives.</summary>
internal class Extract
{
    /// <summary> Extracts the specified MTGJSON file from the zip archive to the appropriate location in the database directory.</summary>
    /// <param name="mtgjsonFile">The name of the MTGJSON file to extract.</param>
    /// <param name="zipLocalPath">The local path of the zip file containing the MTGJSON file.</param>
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