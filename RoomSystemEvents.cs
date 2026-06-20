using System;
using System.Reflection;

namespace BibleVerseMOTD;

internal static class RoomSystemEvents
{
    private static FieldInfo? _joinedRoomEventField;
    private static bool _resolved;

    internal static void SubscribeJoinedRoom(Action handler)
    {
        var field = ResolveField();
        if (field == null)
        {
            return;
        }

        var current = field.GetValue(null) as Action;
        field.SetValue(null, current + handler);
    }

    internal static void UnsubscribeJoinedRoom(Action handler)
    {
        var field = ResolveField();
        if (field == null)
        {
            return;
        }

        var current = field.GetValue(null) as Action;
        field.SetValue(null, current - handler);
    }

    private static FieldInfo? ResolveField()
    {
        if (_resolved)
        {
            return _joinedRoomEventField;
        }

        var roomSystemType = typeof(PlayFabTitleDataTextDisplay).Assembly.GetType("RoomSystem");
        _joinedRoomEventField = roomSystemType?.GetField(
            "JoinedRoomEvent",
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        _resolved = true;
        return _joinedRoomEventField;
    }
}