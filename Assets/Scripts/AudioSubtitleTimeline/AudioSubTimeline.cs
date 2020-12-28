using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;

namespace Timeline
{
    public enum VoiceType
    {
        AI = 0,
        Humain = 1
    }

    [RequireComponent(typeof(PlayableDirector))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Animator))]
    public class AudioSubTimeline : MonoBehaviour 
    {
        public VoiceType voiceType = VoiceType.AI;
    }
}
