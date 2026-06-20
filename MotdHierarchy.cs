using UnityEngine;

namespace BibleVerseMOTD;

internal static class MotdHierarchy
{
    internal static bool Matches(Transform? transform)
    {
        while (transform != null)
        {
            var objectName = transform.gameObject.name.ToLowerInvariant();
            if (objectName.Contains("motdtext")
                || objectName == "motd"
                || objectName.Contains("motdscreen")
                || objectName.Contains("message of the day")
                || objectName.Contains("blockssignstump")
                || objectName.Contains("monkeboard")
                || objectName.Contains("bemoneke")
                || objectName.Contains("messageoftheday"))
            {
                return true;
            }

            transform = transform.parent;
        }

        return false;
    }
}