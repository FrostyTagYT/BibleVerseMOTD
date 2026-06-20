# Installation Guide

Two ways to install **Bible Verse MOTD**.

---

## Option A — Full install package (recommended for new users)

Download **`BibleVerseMOTD-FullInstall-v1.2.1.zip`** from the [latest release](https://github.com/FrostyTagYT/BibleVerseMOTD/releases/latest).

This zip includes everything that is already working on the author's PC:

| Included | Version |
|----------|---------|
| BepInEx | 5.4.23.5 |
| Utilla | 1.7.0 |
| Doorstop | 4.5.0 |
| Bible Verse MOTD | 1.2.1 |

### Steps

1. **Close Gorilla Tag** completely
2. Open your Gorilla Tag folder:
   - Steam → Gorilla Tag → Manage → Browse local files
   - Default: `C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag`
3. **Extract the zip contents into the Gorilla Tag folder** (merge/overwrite when asked)
   - You should end up with:
     - `winhttp.dll`
     - `doorstop_config.ini`
     - `BepInEx/core/` (BepInEx core files)
     - `BepInEx/plugins/BibleVerseMOTD.dll`
     - `BepInEx/plugins/Utilla.dll`
     - `BepInEx/config/` (default configs)
4. Launch Gorilla Tag through Steam
5. Go to the **stump** — the MOTD board should show a Bible verse

### First launch check

Open `BepInEx/LogOutput.log` and look for:

```
[Info   :   BepInEx] Loading [Bible Verse MOTD 1.2.1]
[Info   :   BepInEx] Loading [Utilla 1.7.0]
```

---

## Option B — Mod only (you already have BepInEx)

Download only **`BibleVerseMOTD.dll`** from the release.

1. Put it in `Gorilla Tag/BepInEx/plugins/`
2. Launch the game

**Note:** Utilla is not required for Bible Verse MOTD to work, but it is included in the full package because that is the tested setup.

---

## Configuration

`BepInEx/config/com.frostytagyt.bibleversemotd.cfg`

| Setting | Default | What it does |
|---------|---------|--------------|
| `Enabled` | `true` | Turn mod on/off |
| `ShowHeader` | `true` | Show "Verse of the Day" header |
| `HeaderText` | `Verse of the Day` | Change the header |
| `TitleDataKeys` | `*` | Which boards to replace |
| `DebugLogging` | `false` | Log board replacements |

---

## Uninstall

- **Mod only:** delete `BepInEx/plugins/BibleVerseMOTD.dll`
- **Full BepInEx:** remove `winhttp.dll`, `doorstop_config.ini`, and the `BepInEx` folder (this removes all BepInEx mods)

---

## Troubleshooting

**Board still shows the weekly update?**
- Make sure `BepInEx/plugins/BibleVerseMOTD.dll` exists
- Check `BepInEx/LogOutput.log` for errors
- Fully quit and relaunch the game

**Game won't start after install?**
- Verify files were extracted to the Gorilla Tag root, not a subfolder
- Make sure `winhttp.dll` and `doorstop_config.ini` are next to `Gorilla Tag.exe`