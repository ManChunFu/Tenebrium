using UnityEngine;

public abstract class LocationSharing : MonoBehaviour
{
    [SerializeField] protected int roomNo = 1;
    [SerializeField] protected LocationDataBoard locationData = null;

    public virtual void Awake()
    {
        if (locationData == null)
            throw new MissingReferenceException("Missing reference of LocataionData ScriptableObject");
    }

}
