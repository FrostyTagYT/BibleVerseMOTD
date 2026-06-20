# Bible Verse MOTD

A client-side **BepInEx** mod for **Gorilla Tag (Steam/PC)** that replaces the stump **Message of the Day** board with a random Bible verse.

The physical board stays in the forest stump — only the content changes.

## Features

- Replaces weekly update text **and** update images on the MOTD board
- Shows a **new random verse** when you launch the game
- Shows another **new verse** when you join a room
- **65 included verses** (NIV-style wording)
- Fully **client-side** — only you see the verses
- Configurable header text and board targeting

## Requirements

- Gorilla Tag on **Steam (PC)**
- [BepInEx 5.x](https://docs.bepinex.dev/) installed for Gorilla Tag

## Installation

See **[INSTALL.md](INSTALL.md)** for the full guide.

### Full package (recommended — includes BepInEx + Utilla)

Download **`BibleVerseMOTD-FullInstall-v1.2.0.zip`** from the [latest release](https://github.com/FrostyTagYT/BibleVerseMOTD/releases/latest).

Extract everything into your **Gorilla Tag folder** (where `Gorilla Tag.exe` is). This bundle includes the tested working setup:

| Component | Version |
|-----------|---------|
| BepInEx | 5.4.23.5 |
| Utilla | 1.7.0 |
| Bible Verse MOTD | 1.2.0 |

### Mod only (if you already have BepInEx)

1. Download `BibleVerseMOTD.dll` from the [latest release](https://github.com/FrostyTagYT/BibleVerseMOTD/releases/latest)
2. Drop it into `Gorilla Tag/BepInEx/plugins/`
3. Launch Gorilla Tag and check the stump MOTD board

### Build from source

1. Clone this repo
2. Set your Gorilla Tag path (if not the default Steam location):
   ```powershell
   $env:GORILLA_TAG_PATH = "C:\Path\To\Gorilla Tag"
   ```
3. Build and install:
   ```powershell
   .\build-and-install.ps1
   ```

## Configuration

After first launch, edit:

`BepInEx/config/com.luked.bibleversemotd.cfg`

| Setting | Default | Description |
|---------|---------|-------------|
| `Enabled` | `true` | Turn the mod on/off |
| `ShowHeader` | `true` | Show a header above the verse |
| `HeaderText` | `Verse of the Day` | Header text |
| `TitleDataKeys` | `*` | Which PlayFab boards to replace (`*` = all MOTD boards) |
| `DebugLogging` | `true` | Log when boards are replaced |

## Example

```
Verse of the Day

"For God so loved the world that he gave his one and only Son..."

— John 3:16
```

## How it works

The stump MOTD board normally pulls update info from PlayFab — sometimes as text, sometimes as a downloaded image. This mod intercepts both and renders a Bible verse instead.

## Uninstall

Delete `BepInEx/plugins/BibleVerseMOTD.dll` and optionally `BepInEx/config/com.luked.bibleversemotd.cfg`.

## Disclaimer

This product is not affiliated with Gorilla Tag or Another Axiom LLC and is not endorsed or otherwise sponsored by Another Axiom LLC. Portions of the materials contained herein are property of Another Axiom LLC. ©2021 Another Axiom LLC.

## License

MIT — see [LICENSE](LICENSE)