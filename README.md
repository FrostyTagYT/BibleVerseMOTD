# Bible Verse MOTD

**Made by [FrostyTagYT](https://github.com/FrostyTagYT)**

A client-side mod for **Gorilla Tag (Steam/PC)** that replaces the stump **Message of the Day** board with a random Bible verse.

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

## Installation

See **[INSTALL.md](INSTALL.md)** for the full guide.

### Mod only

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

`BepInEx/config/com.frostytagyt.bibleversemotd.cfg`

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

Delete `BepInEx/plugins/BibleVerseMOTD.dll` and optionally `BepInEx/config/com.frostytagyt.bibleversemotd.cfg`.

## Disclaimer

This product is not affiliated with Gorilla Tag or Another Axiom LLC and is not endorsed or otherwise sponsored by Another Axiom LLC. Portions of the materials contained herein are property of Another Axiom LLC.

## License

MIT — see [LICENSE](LICENSE)
