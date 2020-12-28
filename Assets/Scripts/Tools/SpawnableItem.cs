using UnityEngine;


[CreateAssetMenu(menuName = "SpawnableItem")]
public class SpawnableItem : ScriptableObject
{
    [SerializeField] GameObject prefab;
   
    [HideInInspector]public ObjectPool pool = null;
   

    
    public void InstantiatePool(Transform parent = null)
    {
        pool = new ObjectPool(prefab, parent);
        Debug.Log("New Pool");
    }
}
