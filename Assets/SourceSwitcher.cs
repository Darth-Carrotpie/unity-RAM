using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SourceSwitcher : MonoBehaviour {

    AudioSource[] sources;
    public TrackPack[] trackGroups;
    IEnumerator playNextTrack;
    [System.Serializable]
    public class TrackPack
    {
        public AudioClip clip0;
        public AudioClip clip1;
        public AudioClip clip2;
        public AudioClip clip3;
        public AudioClip clip4;
        public AudioClip clip5;
    }
    public List<int> playlist = new List<int>();
    int currentlyPlayingInPlaylist = 0;
	void Start () {
        sources = GetComponentsInChildren<AudioSource>();
        FillPlaylist();
        playlist.Shuffle();

        playNextTrack = PlayNext();
        StartCoroutine(playNextTrack);
    }

    IEnumerator PlayNext()
    {
        while (true)
        {
            PlayTrack();
            yield return new WaitForSeconds(sources[0].clip.length);
        }
    }

    void PlayTrack()
    {
        Debug.Log(trackGroups[playlist[currentlyPlayingInPlaylist]].clip0);
        sources[0].clip = trackGroups[playlist[currentlyPlayingInPlaylist]].clip0;
        sources[1].clip = trackGroups[playlist[currentlyPlayingInPlaylist]].clip1;
        sources[2].clip = trackGroups[playlist[currentlyPlayingInPlaylist]].clip2;
        sources[3].clip = trackGroups[playlist[currentlyPlayingInPlaylist]].clip3;
        sources[4].clip = trackGroups[playlist[currentlyPlayingInPlaylist]].clip4;
        sources[5].clip = trackGroups[playlist[currentlyPlayingInPlaylist]].clip5;
        if (currentlyPlayingInPlaylist < playlist.Count - 1)
            currentlyPlayingInPlaylist++;

        foreach (AudioSource source in sources)
        {
            source.Play();
        }
    }

    void FillPlaylist()
    {
        for(int i = 0; i < trackGroups.Length; i++)
            playlist.Add(i);
    }

}
