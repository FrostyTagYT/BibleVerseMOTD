using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BibleVerseMOTD;

internal static class BibleVerseBoardRenderer
{
    private static readonly FieldInfo RendererField =
        typeof(TextureFromURL).GetField("_renderer", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo DataField =
        typeof(TextureFromURL).GetField("data", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo TextureField =
        typeof(TextureFromURL).GetField("texture", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly Dictionary<int, Texture2D> AppliedTextures = new();

    internal static bool IsMotdTextureTarget(TextureFromURL textureFromUrl)
    {
        if (!BibleVerseService.Enabled.Value)
        {
            return false;
        }

        if (MotdHierarchy.Matches(textureFromUrl.transform))
        {
            return true;
        }

        var data = DataField.GetValue(textureFromUrl) as string ?? string.Empty;
        var dataLower = data.ToLowerInvariant();
        return dataLower.Contains("motd")
            || dataLower.Contains("message")
            || dataLower.Contains("update");
    }

    internal static void ApplyVerseTexture(TextureFromURL textureFromUrl)
    {
        if (!IsMotdTextureTarget(textureFromUrl))
        {
            return;
        }

        var renderer = RendererField.GetValue(textureFromUrl) as Renderer;
        if (renderer == null)
        {
            Plugin.Log.LogWarning("Bible Verse MOTD: TextureFromURL has no renderer.");
            return;
        }

        var instanceId = textureFromUrl.GetInstanceID();
        if (AppliedTextures.TryGetValue(instanceId, out var existing))
        {
            Object.Destroy(existing);
            AppliedTextures.Remove(instanceId);
        }

        var verseTexture = VerseTextureGenerator.Create(BibleVerseService.GetFormattedVerse());
        AppliedTextures[instanceId] = verseTexture;
        TextureField.SetValue(textureFromUrl, verseTexture);
        renderer.material.mainTexture = verseTexture;

        if (BibleVerseService.DebugLogging.Value)
        {
            var data = DataField.GetValue(textureFromUrl) as string ?? "unknown";
            Plugin.Log.LogInfo($"Replaced MOTD image board on '{textureFromUrl.gameObject.name}' (key: {data}).");
        }
    }

    internal static void RefreshAllImageBoards()
    {
        var boards = Object.FindObjectsOfType<TextureFromURL>(true);
        foreach (var board in boards)
        {
            ApplyVerseTexture(board);
        }
    }

    internal static void ClearCache()
    {
        foreach (var texture in AppliedTextures.Values)
        {
            if (texture != null)
            {
                Object.Destroy(texture);
            }
        }

        AppliedTextures.Clear();
    }
}