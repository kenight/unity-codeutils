using UnityEngine;
using UnityEngine.Events;

namespace CodeUtils
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent onEventRaised;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnRegisterListener(this);
        }

        public void OnEventRaised()
        {
            onEventRaised?.Invoke();
        }
    }
}
