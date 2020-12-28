using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector AITestTimeline = null;

    private void Start()
    {
        if (AITestTimeline == null)
            AITestTimeline = FindObjectOfType<PlayableDirector>();
    }

    public void PlayTimeline()
    {
        AITestTimeline.Play();
    }
}
