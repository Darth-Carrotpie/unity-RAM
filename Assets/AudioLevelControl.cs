using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLevelControl : MonoBehaviour {
    List<AudioMixerGroup> groups = new List<AudioMixerGroup>();
    public AudioMixer mixer;

    public float timeToFade;
    public float timeToStay;
    //public float intermediateLevelA;
    //public float intermediateLevelB;
    public float finalLevelA;
    public float finalLevelB;
    public int[] groupsToIgnore;

    IEnumerator fadeInProcess;
    IEnumerator fadeOutProcess;
    public float counter = 0f;
    AudioMixerGroup current;
    float nextLevel;
    float previousLevel;
    AudioMixerGroup previous;
    List<AudioMixerGroup> activeGroups = new List<AudioMixerGroup>();
    bool fade;
    void Start () {
        groups.AddRange(mixer.FindMatchingGroups("Master"));
    }

    void Update () {
        /*if(fade)
            Fade();*/
    }

    public void MixerFadeToGroup(AudioMixerGroup targetGroup)
    {

        current = targetGroup;
        nextLevel = GetGroupLevel(current);
        previous = GetPreviousGroup();
        //fade = true;
        if (!activeGroups.Contains(targetGroup))
        {
            //Debug.Log("adding and starting:" + targetGroup);
            activeGroups.Add(targetGroup);

            fadeInProcess = FinalFade(current, timeToStay, false, nextLevel);
            StartCoroutine(fadeInProcess);
        }

        if (previous)
        {
            if (!activeGroups.Contains(previous))
            {
                //Debug.Log("adding and starting:" + previous);
                activeGroups.Add(previous);
                previousLevel = GetGroupLevel(previous);
                fadeOutProcess = FinalFade(previous, 0, true, previousLevel);
                StartCoroutine(fadeOutProcess);
            }
        }
    }

    /*void Fade()
    {
        if (counter < timeToFade)
        {
            if (previous != null)
            {
                float levelA = Mathf.Lerp(previousLevel, finalLevelA, counter / timeToFade);
                mixer.SetFloat(previous.name, levelA);
            }

            float levelB = Mathf.Lerp(nextLevel, finalLevelB, counter / timeToFade);
            mixer.SetFloat(current.name, levelB);

            counter += Time.deltaTime;
        }
        else
        {
            fade = false;
            counter = 0;
        }
    }*/

    IEnumerator FinalFade(AudioMixerGroup targetGroup, float progress, bool fade, float startingLevel)
    {
        while (progress <= timeToFade + timeToStay)
        {
            if (targetGroup != current && !fade)
            {
                //Debug.Log("turn to fade out : " + targetGroup.name);

                fade = true;
                startingLevel = GetGroupLevel(targetGroup);
                progress = 0;
            }
            if (targetGroup == current && fade)
            {
                //Debug.Log("turn to fade In  : " + targetGroup.name);

                fade = false;
                startingLevel = GetGroupLevel(targetGroup);
                progress = 0;
            }

            if (progress < timeToStay && fade)
            {
                //Debug.Log("normal fade out: " + targetGroup.name);
                progress += Time.deltaTime;
                yield return 0;
                continue;
            }

            float level = 0;
            if (fade)
            {
                level = Mathf.Lerp(startingLevel, finalLevelA, (progress - timeToStay) / timeToFade);
                //Debug.Log((progress - timeToStay) / timeToFade);
            }
            else
            {
                level = Mathf.Lerp(startingLevel, finalLevelB, (progress - timeToStay) / timeToFade);
            }
            mixer.SetFloat(targetGroup.name, level);
            progress += Time.deltaTime;
            yield return 0;
        }
        if(activeGroups.Contains(targetGroup))
        {
            //Debug.Log("removing" + targetGroup);
            activeGroups.Remove(targetGroup);
        }
    }

    public void MixerSetToGroup(AudioMixerGroup targetGroup)
    {
        for (int i = 1; i < groups.Count; i++)
        {
            groups[i].audioMixer.SetFloat(groups[i].name, -80);
        }
        targetGroup.audioMixer.SetFloat(targetGroup.name, 1);
    }

    AudioMixerGroup GetPreviousGroup()
    {
        AudioMixerGroup group = null;
        for (int i = 0; i < groups.Count; i++)
        {
            bool cont = false;
            foreach (int a in groupsToIgnore)
            {
                if (a == i)
                    cont = true;
            }
            if (cont) continue;

            float level;
            groups[i].audioMixer.GetFloat(groups[i].name, out level);
            if (level > finalLevelB-5)
                group = groups[i];
        }
        return group;
    }
    float GetGroupLevel(AudioMixerGroup group)
    {
        float level = 0;
        for (int i = 1; i < groups.Count; i++)
        {
            if(group.name == groups[i].name)
                groups[i].audioMixer.GetFloat(groups[i].name, out level);          
        }
        return level;
    }
}
