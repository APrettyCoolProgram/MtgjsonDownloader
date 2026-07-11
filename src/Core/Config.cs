// 260711_code
// 260711_documentation

using System.Text.Json;

namespace MtgjsonDownloader.Core;

internal class Config
{
    /// <summary>JSON serializer options for pretty printing.</summary>
    private static readonly JsonSerializerOptions _prettyJson = new()
    {
        WriteIndented = true
    };

    /// <summary>Required framework directories.</summary>
    public List<string> FrameworkDirectories =
    [
        "MTGJSON",
        "Database"
    ];

    /// <summary>Root URL for the MTGJSON API.</summary>
    public string MtgjsonRootUrl { get; set; } = "https://mtgjson.com/api/v5";

    /// <summary>The list of MTGJSON files to download.</summary>
    public List<string> MtgjsonFiles { get; set; } =
    [
        "Keywords.json",
        "CardTypes.json",
        "AllPrintings.json",
        "AllDeckFiles",
        "AllIdentifiers.json",
        "AllPrices.json",
        "AllPricesToday.json",
        "AllSetFiles",
        "AtomicCards.json",
        "DeckList.json",
        "Legacy.json",
        "LegacyAtomic.json",
        "Modern.json",
        "ModernAtomic.json",
        "PauperAtomic.json",
        "Pioneer.json",
        "PioneerAtomic.json",
        "SetList.json",
        "Standard.json",
        "StandardAtomic.json",
        "Vintage.json"
    ];

    /// <summary>Indicates whether to verify the hashes of the downloaded files.</summary>
    public bool VerifyHashes { get; set; } = true;

    /// <summary> Load the configuration settings.</summary>
    /// <param name="configFilePath">Path to the configuration file.</param>
    /// <returns>The configuration settings.</returns>
    internal static Config Load(string configFilePath)
    {
        Verify(configFilePath);

        try
        {
            var configJson = File.ReadAllText(configFilePath);

            return JsonSerializer.Deserialize<Config>(configJson)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(Catalog.msg_ConfigError(e));

            Environment.Exit(0);
        }

        // Required to satisfy the compiler.
        return null;
    }

    /// <summary>Verify the existence of the configuration file.</summary>
    /// <remarks>If the configuration file does not exist, a default configuration file will be created.</remarks>
    /// <param name="configFilePath">Path to the configuration file.</param>
    private static void Verify(string configFilePath)
    {
        if (!File.Exists(configFilePath))
        {
            Create(configFilePath);
        }
    }

    /// <summary>Create a default configuration file.</summary>
    /// <param name="configFilePath">Path to the configuration file.</param>
    private static void Create(string configFilePath) =>
        File.WriteAllText(configFilePath, JsonSerializer.Serialize(new Config(), _prettyJson));
}