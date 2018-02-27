using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SnapshotTestButtons : MonoBehaviour {

    List<AudioMixerSnapshot> snapshots = new List<AudioMixerSnapshot>();
    public GameObject buttonPrefab;
    public AudioMixer mixer;
    public bool useIntermediate;
    IEnumerator fadeAfterIntermedate;

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
            if (CheckIfIsIntermediate(snapshot))
            {
                continue;
            }
            GameObject btn = Instantiate(buttonPrefab, transform);
            btn.GetComponentInChildren<Text>().text = snapshot.name;
            btn.name = "Button: "+ snapshot.name;
            if(!useIntermediate)
                btn.GetComponent<Button>().onClick.AddListener(() => MixerFadeToSnapshot(snapshot));
            else
                btn.GetComponent<Button>().onClick.AddListener(() => MixerFadeThroughIntermediate(snapshot));
        }
    }
    void MixerFadeToSnapshot(AudioMixerSnapshot snapshot)
    {
        AudioMixerSnapshot[] input = new AudioMixerSnapshot[1];
        input[0] = snapshot;
        float[] weights = new float[1] { 1 };
        snapshot.audioMixer.TransitionToSnapshots(input, weights, 1);
    }

    void MixerFadeThroughIntermediate(AudioMixerSnapshot snapshot)
    {
        if (CheckIfHasIntermediate(snapshot))
        {
            MixerFadeToSnapshot(GetIntermediate(snapshot));
            fadeAfterIntermedate = FinalFade(snapshot);
            StartCoroutine(fadeAfterIntermedate);
        } else
        {
            MixerFadeToSnapshot(snapshot);
        }
    }
    IEnumerator FinalFade(AudioMixerSnapshot snapshot)
    {
        yield return new WaitForSeconds(1);
        MixerFadeToSnapshot(snapshot);
    }

    bool CheckIfIsIntermediate(AudioMixerSnapshot snapshot)
    {
        foreach(AudioMixerSnapshot snap in snapshots)
        {
            if (snapshot.name.Contains(snap.name) && snap.name != snapshot.name)
                return true;
        }
        return false;
    }
    bool CheckIfHasIntermediate(AudioMixerSnapshot snapshot)
    {
        foreach (AudioMixerSnapshot snap in snapshots)
        {
            if (snap.name.Contains(snapshot.name) && snap.name != snapshot.name)
                return true;
        }
        return false;
    }
    AudioMixerSnapshot GetIntermediate(AudioMixerSnapshot snapshot)
    {
        foreach (AudioMixerSnapshot snap in snapshots)
        {
            if (snap.name.Contains(snapshot.name) && snap.name != snapshot.name)
                return snap;
        }
        return null;
    }
}
