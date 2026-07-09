// 260709_code
// 260709_documentation

using System.Text.Json;

namespace MtgjsonDownloader;

internal class Config
{
    private static readonly JsonSerializerOptions _prettyJson = new()
    {
        WriteIndented = true
    };

    public List<string> FrameworkDirectories =
    [
        "MTGJSON",
        "Database"
    ];

    public string MtgjsonRootUrl { get; set; } = "https://mtgjson.com/api/v5";

    public List<string> MtgjsonFiles { get; set; } =
    [
        "Keywords.json",
        "CardTypes.json"
    ];

    public bool VerifyHashes { get; set; } = true;

    internal static Config Load(string configFilePath)
    {
        Console.WriteLine("Verifying configuration file...");

        if (!File.Exists(configFilePath))
        {
            Console.WriteLine("Configuration file does not exist.");

            Create(configFilePath);
        }

        Console.WriteLine("Loading configuration file...");

        var configJson = File.ReadAllText(configFilePath);

        return JsonSerializer.Deserialize<Config>(configJson)!;
    }

    /// <summary>Create a default configuration file.</summary>
    /// <param name="configFilePath">Path to the configuration file.</param>
    private static void Create(string configFilePath)
    {
        Console.WriteLine("Creating default configuration file...");

        var config = new Config();

        File.WriteAllText(configFilePath, JsonSerializer.Serialize(config, _prettyJson));
    }
}

/*
,
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
 */