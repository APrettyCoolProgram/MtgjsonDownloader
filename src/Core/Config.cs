// 260709_code
// 260709_documentation

using System.Text.Json;

namespace MtgjsonDownloader.Core;

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
        Verify(configFilePath);

        try
        {
            var configJson = File.ReadAllText(configFilePath);

            return JsonSerializer.Deserialize<Config>(configJson)!;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{Environment.NewLine}" +
                              $"Error reading configuration file:{Environment.NewLine}" +
                              $"{ex.Message}{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"Press any key to exit.");

            Environment.Exit(0);
        }

        return null;
    }

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