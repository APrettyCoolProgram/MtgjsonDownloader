<div align="center">

  <picture>
    <source media="(prefers-color-scheme: dark)" srcset=".github/logo/dark/MtgjsonDownloader-Logo-Dark-256x256.png">
    <source media="(prefers-color-scheme: light)" srcset=".github/logo/light/MtgjsonDownloader-Logo-Light-256x256.png">
    <img alt="Fallback image description" src=".github/logo/light/MtgjsonDownloader-Logo-Light-256x256.png">
  </picture>

  <h1>MTGJSON Downloader</h1>

  ![RELEASE](https://img.shields.io/badge/R26.7.1-teal)&nbsp;
  ![LICENSE](https://img.shields.io/badge/License-apache-blue)&nbsp;
  ![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20macOS-lightgrey)&nbsp;

<h6 align="center">

 [CHANGELOG](docs/CHANGELOG.md)&nbsp;&bull;&nbsp;[ROADMAP](docs/ROADMAP.md)
  
</h6>

***

</div>

| CONTENTS |
|----------|
| [About MTGJSON Downloader](#about-mtgjsondownloader) |
| [Installing](#installing) |
| [Usage](#usage) |
| [Acknowledgements](#acknowledgements) |
| [Related projects](#related-projects) |
| [License](#license) |

---

## About MTGJSON Downloader

MTGJSON Downloader makes it easy to download - and verify! - [MTGJSON](https://mtgjson.com) data files with a single command.

### Requirements

* [.NET 10 RDK/SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

## Installing

MTGJSON Downloader is a portable application, so to "install":

1. Download the latest release from the [releases page](https://github.com/APCP/MtgjsonDownloader/releases).
2. Extract the downloaded archive to a location of your choice.

## Usage

To use MTGJSON Downloader:

1. Open an terminal or command prompt in the directory where you extracted MTGJSON Downloader.
2. Type `MtgjsonDownloader` and press Enter.

MTGJSON Downloader will then start and begin downloading the latest MTGJSON data files.

## What it does

When you run MTGJSON Downloader, it:

1. Attempts to load the `MtgjsonDownloader.config` file, or creates a default configuration file if one does not exist
2. Downloads the MTGJSON `<filename>.json.zip` files defined in the configuration file to the `./MTGJSON` directory, overwriting any existing files
3. Downloads the `<filename>.json.zip.sha256` files for integrity verification to the `./MTGJSON` directory, overwriting any existing files
4. If verification is enabled, verifies the integrity of the `<filename>.json.zip` files
5. Extracts the `<filename>.json.zip` files to the `./Database` directory

## Configuring

The `MtgjsonDownloader.config` file allows you to customize which MTGJSON data files are downloaded and whether integrity verification is enabled.

By default, the following MTGJSON data files will be downloaded:

* Keywords.json
* CardTypes.json
* AllPrintings.json
* AllDeckFiles
* AllIdentifiers.json
* AllPrices.json
* AllPricesToday.json
* AllSetFiles
* AtomicCards.json
* DeckList.json
* Legacy.json
* LegacyAtomic.json
* Modern.json
* ModernAtomic.json
* PauperAtomic.json
* Pioneer.json
* PioneerAtomic.json
* SetList.json
* Standard.json
* StandardAtomic.json
* Vintage.json

If you want to customize which files are downloaded, you can modify the list in the `MtgjsonDownloader.config` file located in the same directory as the executable.

If you want to disable integrity verification, you can set the `EnableVerification` option to `false` in the `MtgjsonDownloader.config` file.

## Acknowledgements

* [MTGJSON](https://mtgjson.com)

## License

Distributed under the [Apache 2.0 License](LICENSE).  
Copyright &copy; 2026 A Pretty Cool Program

<h6 align="center">

  [FAQ](docs/FAQ.md)&nbsp;&bull;&nbsp;[DEVELOPMENT](docs/DEVELOPMENT.md)&nbsp;&bull;&nbsp;[API](docs/api/README.md)&nbsp;&bull;&nbsp;[TESTING](docs/TESTING.md)&nbsp;&bull;&nbsp;[SUPPORT](docs/SUPPORT.md)&nbsp;&bull;&nbsp;[NOTICES](docs/NOTICES.md)
  
</h6>

---

<sub>Last updated: 260725</sub>
