using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLevelControl : MonoBehaviour {
    List<AudioMixerGroup> groups = new List<AudioMixerGroup>();
    public AudioMixer mixer;


    void Start () {
        groups.AddRange(mixer.FindMatchingGroups("Master"));
    }

    void Update () {
		
	}

    public void MixerFadeToGroup(AudioMixerGroup targetGroup)
    {
        Debug.Log(targetGroup.name);
        foreach (AudioMixerGroup group in groups)
        {
            group.audioMixer.SetFloat(group.name, -80);
            //Debug.Log(group.name);
        }
        targetGroup.audioMixer.SetFloat(targetGroup.name, 1);
    }
}
