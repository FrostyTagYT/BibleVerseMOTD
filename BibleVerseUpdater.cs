using System.Collections;
using UnityEngine;

namespace BibleVerseMOTD;

internal sealed class BibleVerseUpdater : MonoBehaviour
{
    private bool _subscribed;
    private Coroutine? _refreshRoutine;

    private void Start()
    {
        BibleVerseService.PickNewVerse();
        QueueRefresh();
        TrySubscribe();
    }

    private void Update()
    {
        if (!_subscribed)
        {
            TrySubscribe();
        }
    }

    private void OnDestroy()
    {
        if (_subscribed)
        {
            RoomSystemEvents.UnsubscribeJoinedRoom(OnJoinedRoom);
            _subscribed = false;
        }

        if (_refreshRoutine != null)
        {
            StopCoroutine(_refreshRoutine);
            _refreshRoutine = null;
        }
    }

    private void TrySubscribe()
    {
        if (_subscribed)
        {
            return;
        }

        RoomSystemEvents.SubscribeJoinedRoom(OnJoinedRoom);
        _subscribed = true;
    }

    private static void OnJoinedRoom()
    {
        BibleVerseService.PickNewVerse();
        BibleVerseUpdater? updater = FindUpdater();
        updater?.QueueRefresh();
    }

    private void QueueRefresh()
    {
        if (_refreshRoutine != null)
        {
            StopCoroutine(_refreshRoutine);
        }

        _refreshRoutine = StartCoroutine(RefreshRepeatedly());
    }

    private IEnumerator RefreshRepeatedly()
    {
        for (var i = 0; i < 30; i++)
        {
            BibleVerseService.RefreshAllBoards();
            yield return new WaitForSeconds(2f);
        }

        _refreshRoutine = null;
    }

    private static BibleVerseUpdater? FindUpdater()
    {
        var updaters = FindObjectsOfType<BibleVerseUpdater>();
        return updaters.Length > 0 ? updaters[0] : null;
    }
}