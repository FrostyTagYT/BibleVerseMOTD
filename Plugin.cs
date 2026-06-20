using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace BibleVerseMOTD;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public sealed class Plugin : BaseUnityPlugin
{
    internal const string PluginGuid = "com.frostytagyt.bibleversemotd";
    internal const string PluginName = "Bible Verse MOTD";
    internal const string PluginVersion = "1.2.1";
    internal const string PluginAuthor = "FrostyTagYT";

    internal static ManualLogSource Log = null!;

    private void Awake()
    {
        Log = Logger;
        BibleVerseService.Initialize(Config);
        Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

        var updaterObject = new GameObject("BibleVerseMOTD_Updater");
        DontDestroyOnLoad(updaterObject);
        updaterObject.hideFlags = HideFlags.HideAndDontSave;
        updaterObject.AddComponent<BibleVerseUpdater>();

        Log.LogInfo($"Bible Verse MOTD v{PluginVersion} by {PluginAuthor} — replaces text and image update boards with Bible verses.");
    }
}