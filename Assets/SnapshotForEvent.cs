using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class SnapshotForEvent : MonoBehaviour
{
    public EventName whatHappened;
    MixerManager mixerMng;
    public SnapshotsState[] availableStates;

    [System.Serializable]
    public class SnapshotsState
    {
        public AudioMixerSnapshot[] snapshots;
        public float[] weights;
        public float timeToReach;
    }

    private void Start()
    {
        mixerMng = GetComponentInParent<MixerManager>();
        EventManager.StartListening(whatHappened, LaunchSnapshotState);
    }

    void LaunchSnapshotState(BookerMessage msg)
    {
        int i = Random.Range(0, availableStates.Length);
        mixerMng.mixer.TransitionToSnapshots(availableStates[i].snapshots, availableStates[i].weights, availableStates[i].timeToReach);
    }
}
