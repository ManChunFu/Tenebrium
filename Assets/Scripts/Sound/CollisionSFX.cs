
using UnityEngine;

public class CollisionSFX : MonoBehaviour
{
   
    [SerializeField] AK.Wwise.Event SoundEvent;
    public float soundVolumeModifier = 1;
    
    private void OnCollisionEnter(Collision collision)
    {
        PlaySFX(collision);
    }

    void PlaySFX(Collision collision)
    {
       
        AkSoundEngine.SetRTPCValue("Force", collision.relativeVelocity.magnitude * soundVolumeModifier, gameObject);
        SoundEvent.Post(gameObject);
    }
}
