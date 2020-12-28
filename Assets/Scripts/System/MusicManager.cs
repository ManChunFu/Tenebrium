using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AudioManager.MusicManager
{
    public class MusicManager : MonoBehaviour
    {
        private AudioSource thisSource;

        //Array of AudioClips - assigned in inspector
        public AudioClip[] musicClip;

        public static MusicManager instance = null;

        void Awake()
        {
            Debug.Log(musicClip.Length);
            if (musicClip.Length == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                if (instance != null)
                {
                    Destroy(gameObject);
                }
                else
                {
                    instance = this;
                }
            }
        }

        void Start()
        {
            thisSource = gameObject.AddComponent<AudioSource>();
            PlaySound(0, true); // Just to have something to test, always uses first entry of list of music
        }

        public void PlaySound(int trackID, bool ShouldLoop)
        {

            if (musicClip[trackID] == null)
                return;

            thisSource.Stop();
            thisSource.loop = ShouldLoop;
            thisSource.PlayOneShot(musicClip[trackID]);

            Debug.Log(thisSource.isPlaying);

        }
    }
}
