using UnityEngine;

namespace SpaceGame.Dog
{
    public class DogFloating : MonoBehaviour
    {
        [SerializeField] private float floatingScale = 0.03f;
        [SerializeField] private float floatingMaxRange = 0.1f;
        [SerializeField] private float floatingSpeed = 3f;

        private bool isFloatingUp = true;

        private void Update()
        {
            transform.position = Vector3.Slerp(transform.position, GetDesirePosition(transform.position.y), floatingSpeed * Time.deltaTime);
        }

        private Vector3 GetDesirePosition(float currentY)
        {
            if (isFloatingUp)
            {
                currentY += floatingScale;
                if (currentY >= floatingMaxRange)
                    isFloatingUp = false;
            }
            else
            {
                currentY -= floatingScale;
                if (currentY <= -floatingMaxRange)
                    isFloatingUp = true;
            }
            return new Vector3(transform.position.x, currentY, transform.position.z);
        }
    }
}
