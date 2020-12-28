using UnityEngine;
using UnityEngine.Events;

namespace GameEvent
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent thingy;
        public UnityEvent Response;

        private void OnEnable()
        {
            thingy.Register(this);
        }
        private void OnDisable()
        {
            thingy.Unregister(this);
        }
        public void onHello()
        {
            Response.Invoke();
        }
    }
}
