using System;
using System.Reflection;
using BepInEx.Configuration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BibleVerseMOTD;

internal static class BibleVerseService
{
    private static readonly System.Random Random = new();
    private static readonly FieldInfo TextBoxField =
        typeof(PlayFabTitleDataTextDisplay).GetField("textBox", BindingFlags.Instance | BindingFlags.NonPublic)!;

    internal static ConfigEntry<bool> Enabled = null!;
    internal static ConfigEntry<string> TitleDataKeys = null!;
    internal static ConfigEntry<string> HeaderText = null!;
    internal static ConfigEntry<bool> ShowHeader = null!;
    internal static ConfigEntry<bool> DebugLogging = null!;

    private static BibleVerseDatabase.Verse _currentVerse;
    private static bool _hasCurrentVerse;
    private static bool _loggedMotdHit;

    internal static void Initialize(ConfigFile config)
    {
        Enabled = config.Bind(
            "General",
            "Enabled",
            true,
            "Replace the stump Message of the Day board with Bible verses.");

        TitleDataKeys = config.Bind(
            "General",
            "TitleDataKeys",
            "*",
            "Comma-separated PlayFab title data keys to replace. Use * for all MOTD boards.");

        ShowHeader = config.Bind(
            "Display",
            "ShowHeader",
            true,
            "Show a small header above each verse.");

        HeaderText = config.Bind(
            "Display",
            "HeaderText",
            "Verse of the Day",
            "Header text shown above the Bible verse.");

        DebugLogging = config.Bind(
            "General",
            "DebugLogging",
            true,
            "Log when the mod finds and replaces MOTD board text.");
    }

    internal static void PickNewVerse()
    {
        var previous = _hasCurrentVerse ? _currentVerse : (BibleVerseDatabase.Verse?)null;
        _currentVerse = BibleVerseDatabase.PickRandom(Random, previous);
        _hasCurrentVerse = true;
        BibleVerseBoardRenderer.ClearCache();
    }

    internal static string GetFormattedVerse()
    {
        if (!_hasCurrentVerse)
        {
            PickNewVerse();
        }

        if (ShowHeader.Value)
        {
            return $"{HeaderText.Value}\n\n\"{_currentVerse.Text}\"\n\n— {_currentVerse.Reference}";
        }

        return $"\"{_currentVerse.Text}\"\n\n— {_currentVerse.Reference}";
    }

    internal static bool IsMotdTarget(Component? textComponent)
    {
        if (!Enabled.Value || textComponent == null)
        {
            return false;
        }

        if (MotdHierarchy.Matches(textComponent.transform))
        {
            return true;
        }

        return textComponent.GetComponentInParent<PlayFabTitleDataTextDisplay>() != null
            || textComponent.GetComponent<PlayFabTitleDataTextDisplay>() != null;
    }

    internal static bool ShouldReplaceBoard(PlayFabTitleDataTextDisplay display)
    {
        if (!Enabled.Value)
        {
            return false;
        }

        var configuredKeys = TitleDataKeys.Value;
        if (string.IsNullOrWhiteSpace(configuredKeys) || configuredKeys.Trim() == "*")
        {
            return true;
        }

        var key = display.playFabKeyValue;
        if (string.IsNullOrWhiteSpace(key))
        {
            return false;
        }

        foreach (var part in configuredKeys.Split(','))
        {
            if (string.Equals(part.Trim(), key, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    internal static void ApplyToDisplay(PlayFabTitleDataTextDisplay display)
    {
        if (!ShouldReplaceBoard(display))
        {
            return;
        }

        var textBox = TextBoxField.GetValue(display) as TextMeshPro;
        ApplyToText(textBox, $"PlayFabTitleDataTextDisplay ({display.playFabKeyValue})");
    }

    internal static void ApplyToText(Component? textBox, string source)
    {
        if (textBox == null || !IsMotdTarget(textBox))
        {
            return;
        }

        switch (textBox)
        {
            case TMP_Text tmp:
                tmp.text = GetFormattedVerse();
                tmp.color = Color.white;
                break;
            case Text uiText:
                uiText.text = GetFormattedVerse();
                uiText.color = Color.white;
                break;
            default:
                return;
        }

        if (DebugLogging.Value && !_loggedMotdHit)
        {
            _loggedMotdHit = true;
            Plugin.Log.LogInfo($"Replaced MOTD text via {source} on '{textBox.gameObject.name}'.");
        }
    }

    internal static void RefreshAllBoards()
    {
        var displays = UnityEngine.Object.FindObjectsOfType<PlayFabTitleDataTextDisplay>(true);
        foreach (var display in displays)
        {
            ApplyToDisplay(display);
        }

        var textComponents = UnityEngine.Object.FindObjectsOfType<TMP_Text>(true);
        foreach (var textComponent in textComponents)
        {
            ApplyToText(textComponent, "scene scan");
        }

        var uiTexts = UnityEngine.Object.FindObjectsOfType<Text>(true);
        foreach (var uiText in uiTexts)
        {
            ApplyToText(uiText, "scene scan");
        }

        BibleVerseBoardRenderer.RefreshAllImageBoards();
    }
}