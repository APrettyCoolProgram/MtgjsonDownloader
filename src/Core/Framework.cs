// 260711_code
// 260711_documentation

using Du;

namespace MtgjsonDownloader.Core;

/// <summary>Logic related to the framework.</summary>
internal class Framework
{
    /// <summary>Verifies that the directories exist, and creates them if they do not.</summary>
    /// <param name="directories">The list of directories to verify.</param>
    internal static void Verify(List<string> directories)
    {
        DuDirectory.ForceCreate(directories);
    }
}