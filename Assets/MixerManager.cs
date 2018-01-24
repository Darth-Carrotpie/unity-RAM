using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class MixerManager : MonoBehaviour {

    public AudioMixer mixer;
    AudioMixerSnapshot[] snapshots;
    // public Dictionary<EventName, SnapshotStates> snapshotForEvent = new Dictionary<EventName, SnapshotStates>();
   // public SnapshotForEvent[] snapshotsForEvents = new SnapshotForEvent[Enum.GetValues(typeof(EventName)).Length];

    void Start() {
        //mixer.TransitionToSnapshots();
    }

    void Update() {

    }
}
