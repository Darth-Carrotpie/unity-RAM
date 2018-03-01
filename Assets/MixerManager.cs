using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class MixerManager : MonoBehaviour {
    public SnapshotForEvent.SnapshotsState snapshotState;
    public AudioMixer mixer;
    public bool triggerGoBack = false;
    public float delayToGoBack = 5;
    float counter;
    private void Update()
    {
        if(triggerGoBack)
            counter += Time.deltaTime;
        if(counter > delayToGoBack)
        {
            counter = 0f;
            triggerGoBack = false;
            mixer.TransitionToSnapshots(snapshotState.snapshots, snapshotState.weights, snapshotState.timeToReach);
        }
    }
    void Freq()
    {
        
    }

}
