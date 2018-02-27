using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SnapshotTestButtons : MonoBehaviour {

    List<AudioMixerSnapshot> snapshots = new List<AudioMixerSnapshot>();
    public GameObject buttonPrefab;
    public AudioMixer mixer;
    void Start () {
        SnapShotFill();
    }
	

    void SnapShotFill()
    {
        //snapshots.AddRange(FindObjectsOfType<AudioMixerSnapshot>());
        snapshots.AddRange((AudioMixerSnapshot[])mixer.GetType().GetProperty("snapshots").GetValue(mixer, null));

        //Debug.Log(snapshots.Count);
        foreach(AudioMixerSnapshot snapshot in snapshots)
        {
            GameObject btn = Instantiate(buttonPrefab, transform);
            btn.GetComponentInChildren<Text>().text = snapshot.name;
            btn.name = "Button: "+ snapshot.name;
            btn.GetComponent<Button>().onClick.AddListener(() => MixerFadeToSnapshot(snapshot));
        }
    }
    void MixerFadeToSnapshot(AudioMixerSnapshot snapshot)
    {
        AudioMixerSnapshot[] input = new AudioMixerSnapshot[1];
        input[0] = snapshot;
        float[] weights = new float[1] { 1 };
        snapshot.audioMixer.TransitionToSnapshots(input, weights, 1);
    }
}
