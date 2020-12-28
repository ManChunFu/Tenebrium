using System.Collections.Generic;
using UnityEngine;
namespace GameEvent
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();
        public void Hello()
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].onHello();
            }
        }
        public void Register(GameEventListener listener)
        {
            listeners.Add(listener);
        }
        public void Unregister(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}

