using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class IntermediateSnapshotButtons : MonoBehaviour
{

    List<AudioMixerSnapshot> snapshots = new List<AudioMixerSnapshot>();
    public float weight_OldAtIntermediate;
    public float weight_NewAtIntermediate;
    public float time_OldToIntermediate;
    public float timeToHold;
    public float time_IntermediateToNew;

    public GameObject buttonPrefab;
    public AudioMixer mixer;
    public AudioMixerSnapshot startingSnapshot;
    AudioMixerSnapshot currentSnapshot;

    IEnumerator fadeAfterIntermedate;

    void Start()
    {
        SnapShotFill();
        currentSnapshot = startingSnapshot;
    }


    void SnapShotFill()
    {
        snapshots.AddRange((AudioMixerSnapshot[])mixer.GetType().GetProperty("snapshots").GetValue(mixer, null));

        foreach (AudioMixerSnapshot snapshot in snapshots)
        {
            GameObject btn = Instantiate(buttonPrefab, transform);
            btn.GetComponentInChildren<Text>().text = snapshot.name;
            btn.name = "Button: " + snapshot.name;

            btn.GetComponent<Button>().onClick.AddListener(() => MixerFadeToSnapshot(snapshot));
        }
    }
    void MixerFadeToSnapshot(AudioMixerSnapshot snapshot)
    {
        AudioMixerSnapshot[] input = new AudioMixerSnapshot[2];
        input[0] = snapshot;
        input[1] = currentSnapshot;
        float[] weights = new float[2] { weight_NewAtIntermediate , weight_OldAtIntermediate };
        //Debug.Log("current: " + currentSnapshot+ "   new: " + snapshot + " weights: " + weights[0]+"  "+ weights[1]);
        snapshot.audioMixer.TransitionToSnapshots(input, weights, time_OldToIntermediate);
        currentSnapshot = snapshot;
        fadeAfterIntermedate = FinalFade(snapshot);
        StartCoroutine(fadeAfterIntermedate);
    }

    IEnumerator FinalFade(AudioMixerSnapshot snapshot)
    {
        yield return new WaitForSeconds(timeToHold);

        AudioMixerSnapshot[] input = new AudioMixerSnapshot[1];
        input[0] = snapshot;
        float[] weights = new float[1] { 1 };

        snapshot.audioMixer.TransitionToSnapshots(input, weights, time_IntermediateToNew);
    }
}
