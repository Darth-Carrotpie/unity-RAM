using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerGroupButtons : MonoBehaviour {
    List<AudioMixerGroup> snapshots = new List<AudioMixerGroup>();
    public AudioMixer mixer;
    public GameObject buttonPrefab;
    IEnumerator fadeAfterIntermedate;


    void Start () {
        snapshots.AddRange((AudioMixerGroup[])mixer.GetType().GetProperty("snapshots").GetValue(mixer, null));

    }


    void Update () {
		
	}
}
