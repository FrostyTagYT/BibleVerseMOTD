# Installation Guide

Install **Bible Verse MOTD**.

---

## Installation

Download **`BibleVerseMOTD.dll`** from the [latest release](https://github.com/FrostyTagYT/BibleVerseMOTD/releases/latest).

1. **Close Gorilla Tag** completely
2. Open your Gorilla Tag folder:
   - Steam → Gorilla Tag → Manage → Browse local files
   - Default: `C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag`
3. **Navigate to the `BepInEx/plugins/` folder**
4. **Drop `BibleVerseMOTD.dll` into this folder**
5. Launch Gorilla Tag through Steam
6. Go to the **stump** — the MOTD board should show a Bible verse

### First launch check

Open `BepInEx/LogOutput.log` and look for:

```
[Info   :   BepInEx] Loading [Bible Verse MOTD 1.2.1]
```

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

- Delete `BepInEx/plugins/BibleVerseMOTD.dll`

---

## Troubleshooting

**Board still shows the weekly update?**
- Make sure `BepInEx/plugins/BibleVerseMOTD.dll` exists
- Check `BepInEx/LogOutput.log` for errors
- Fully quit and relaunch the game

**Game won't start after install?**
- Verify the dll was placed in `BepInEx/plugins/` and not a subfolder
