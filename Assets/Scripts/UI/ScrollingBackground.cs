using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    private Image backgroundImage = null;
    private Material backgroundMaterial = null;
    private Vector2 offset = Vector2.zero;
    private void Awake()
    {
        backgroundImage = GetComponent<Image>();
        backgroundMaterial = backgroundImage.material;
        offset = backgroundMaterial.mainTextureOffset;
    }

    private void Update()
    {
        offset.x += Time.deltaTime / 10f;
        backgroundMaterial.mainTextureOffset = offset;
    }
}
