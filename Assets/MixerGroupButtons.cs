using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerGroupButtons : MonoBehaviour {
    List<AudioMixerGroup> groups = new List<AudioMixerGroup>();
    public AudioMixer mixer;
    public GameObject buttonPrefab;
    IEnumerator fadeAfterIntermedate;
    AudioLevelControl audioLevelControl;

    void Start () {
        audioLevelControl = FindObjectOfType<AudioLevelControl>();
        CreateButtons();
    }


void CreateButtons()
    {
        groups.AddRange( mixer.FindMatchingGroups("Master"));

        //groups.AddRange((AudioMixerGroup[])mixer.GetType().GetProperty("groups").GetValue(mixer, null));
        foreach (AudioMixerGroup group in groups)
        {
            GameObject btn = Instantiate(buttonPrefab, transform);
            btn.GetComponentInChildren<Text>().text = group.name;
            btn.name = group.name;

            btn.GetComponent<Button>().onClick.AddListener(() => audioLevelControl.MixerFadeToGroup(group));
        }
    }
}
