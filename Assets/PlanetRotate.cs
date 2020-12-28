using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    [SerializeField] private float rotationY = 0.1f;
    [SerializeField] private float rotationX = -0.05f;

    private void Update()
    {
        transform.Rotate(rotationX, rotationY, 0);

    }
}
