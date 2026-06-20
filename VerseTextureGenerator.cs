using TMPro;
using UnityEngine;

namespace BibleVerseMOTD;

internal static class VerseTextureGenerator
{
    private static TMP_FontAsset? _cachedFont;

    internal static Texture2D Create(string text, int width = 1024, int height = 512)
    {
        EnsureFont();

        var renderTexture = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGB32);
        var previousActive = RenderTexture.active;
        var root = new GameObject("BibleVerseTextureGen");

        try
        {
            var cameraObject = new GameObject("Cam");
            cameraObject.transform.SetParent(root.transform, false);
            cameraObject.transform.localPosition = new Vector3(0f, 0f, -5f);

            var camera = cameraObject.AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color(0.14f, 0.09f, 0.05f, 1f);
            camera.orthographic = true;
            camera.orthographicSize = 4f;
            camera.nearClipPlane = 0.1f;
            camera.farClipPlane = 20f;
            camera.targetTexture = renderTexture;

            var textObject = new GameObject("Text");
            textObject.transform.SetParent(root.transform, false);
            textObject.transform.localPosition = Vector3.zero;

            var textMesh = textObject.AddComponent<TextMeshPro>();
            if (_cachedFont != null)
            {
                textMesh.font = _cachedFont;
            }

            textMesh.fontSize = 3.5f;
            textMesh.alignment = TextAlignmentOptions.Center;
            textMesh.color = Color.white;
            textMesh.enableWordWrapping = true;
            textMesh.rectTransform.sizeDelta = new Vector2(16f, 8f);
            textMesh.margin = new Vector4(0.5f, 0.5f, 0.5f, 0.5f);
            textMesh.text = text;

            camera.Render();

            var texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
            texture.Apply();
            return texture;
        }
        finally
        {
            RenderTexture.active = previousActive;
            RenderTexture.ReleaseTemporary(renderTexture);
            Object.Destroy(root);
        }
    }

    private static void EnsureFont()
    {
        if (_cachedFont != null)
        {
            return;
        }

        var existingText = Object.FindObjectOfType<TextMeshPro>();
        if (existingText != null)
        {
            _cachedFont = existingText.font;
            return;
        }

        var fontAssets = Resources.FindObjectsOfTypeAll<TMP_FontAsset>();
        if (fontAssets.Length > 0)
        {
            _cachedFont = fontAssets[0];
        }
    }
}