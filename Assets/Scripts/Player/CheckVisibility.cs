using System.Net.NetworkInformation;
using UnityEngine;

public class CheckVisibility : MonoBehaviour
{
    [SerializeField] private Transform dog = null;
    [SerializeField] private Camera currentCam = null;
    public bool CanSee { get; private set; }

    private void Awake()
    {
        if (dog == null)
            dog = GameObject.FindGameObjectWithTag("Dog").transform;
        if (currentCam == null)
            currentCam = GetComponent<Camera>();
    }


    public bool CanSeeDog()
    {
        Vector3 viewPos = currentCam.WorldToViewportPoint(dog.position);
        if (viewPos.x >= 0f && viewPos.x <= 1f && viewPos.y >= -0.5f && viewPos.y <= 1f)
            return true;
        else
            return false;
    }
}
