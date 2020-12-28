using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[ExecuteAlways]
public class PostProcessingFix : MonoBehaviour
{
    public PostProcessResources postProcessResources;
   
    private void Start()
    {
        PostProcessLayer postProcessLayer = Camera.main.gameObject.GetComponent<PostProcessLayer>();
        postProcessLayer.Init(postProcessResources);
        postProcessLayer.volumeTrigger = Camera.main.transform;
        postProcessLayer.volumeLayer = LayerMask.GetMask("PostProcessing");
    }
}
