using System;
using HarmonyLib;
using TMPro;
using UnityEngine.UI;

namespace BibleVerseMOTD;

[HarmonyPatch(typeof(PlayFabTitleDataTextDisplay), "OnTitleDataRequestComplete")]
internal static class PlayFabTitleDataTextDisplay_Complete_Patch
{
    private static void Prefix(PlayFabTitleDataTextDisplay __instance, ref string titleDataResult)
    {
        if (BibleVerseService.ShouldReplaceBoard(__instance))
        {
            titleDataResult = BibleVerseService.GetFormattedVerse();
        }
    }

    private static void Postfix(PlayFabTitleDataTextDisplay __instance)
    {
        BibleVerseService.ApplyToDisplay(__instance);
    }
}

[HarmonyPatch(typeof(PlayFabTitleDataTextDisplay), "OnPlayFabError")]
internal static class PlayFabTitleDataTextDisplay_Error_Patch
{
    private static void Postfix(PlayFabTitleDataTextDisplay __instance)
    {
        BibleVerseService.ApplyToDisplay(__instance);
    }
}

[HarmonyPatch(typeof(PlayFabTitleDataTextDisplay), "OnNewTitleDataAdded")]
internal static class PlayFabTitleDataTextDisplay_UpdateColor_Patch
{
    private static void Postfix(PlayFabTitleDataTextDisplay __instance, string key)
    {
        if (!BibleVerseService.ShouldReplaceBoard(__instance))
        {
            return;
        }

        if (key != __instance.playFabKeyValue)
        {
            return;
        }

        BibleVerseService.ApplyToDisplay(__instance);
    }
}

[HarmonyPatch(typeof(PlayFabTitleDataTextDisplay), "Start")]
internal static class PlayFabTitleDataTextDisplay_Start_Patch
{
    private static void Postfix(PlayFabTitleDataTextDisplay __instance)
    {
        BibleVerseService.ApplyToDisplay(__instance);
    }
}

[HarmonyPatch(typeof(TMP_Text), "set_text", new[] { typeof(string) })]
internal static class TmpText_SetText_Patch
{
    private static void Prefix(TMP_Text __instance, ref string value)
    {
        if (!BibleVerseService.IsMotdTarget(__instance))
        {
            return;
        }

        value = BibleVerseService.GetFormattedVerse();
    }
}

[HarmonyPatch(typeof(Text), "set_text", new[] { typeof(string) })]
internal static class UiText_SetText_Patch
{
    private static void Prefix(Text __instance, ref string value)
    {
        if (!BibleVerseService.IsMotdTarget(__instance))
        {
            return;
        }

        value = BibleVerseService.GetFormattedVerse();
    }
}

[HarmonyPatch(typeof(TextureFromURL), "OnTitleDataRequestComplete")]
internal static class TextureFromUrl_Complete_Patch
{
    private static bool Prefix(TextureFromURL __instance, ref string imageUrl)
    {
        if (!BibleVerseBoardRenderer.IsMotdTextureTarget(__instance))
        {
            return true;
        }

        BibleVerseBoardRenderer.ApplyVerseTexture(__instance);
        return false;
    }
}

[HarmonyPatch(typeof(TextureFromURL), "applyRemoteTexture")]
internal static class TextureFromUrl_ApplyRemote_Patch
{
    private static bool Prefix(TextureFromURL __instance, string imageUrl)
    {
        if (!BibleVerseBoardRenderer.IsMotdTextureTarget(__instance))
        {
            return true;
        }

        BibleVerseBoardRenderer.ApplyVerseTexture(__instance);
        return false;
    }
}

[HarmonyPatch(typeof(TextureFromURL), "OnEnable")]
internal static class TextureFromUrl_Enable_Patch
{
    private static void Postfix(TextureFromURL __instance)
    {
        if (BibleVerseBoardRenderer.IsMotdTextureTarget(__instance))
        {
            BibleVerseBoardRenderer.ApplyVerseTexture(__instance);
        }
    }
}