using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline = null;
    [SerializeField] private bool triggerOnce = true;

    private void Awake()
    {
        if (timeline == null)
            throw new MissingReferenceException("Missing reference of PlayableDirector of Timeline.playable");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.Play();

            if (triggerOnce)
                gameObject.SetActive(false);
        }
    }

}
