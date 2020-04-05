﻿using System.Collections.Generic;
using UnityEngine;

namespace CodeUtils
{
    [CreateAssetMenu(menuName = "Scriptable/Game Event")]
    public class GameEvent : ScriptableObject
    {
        List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            foreach (var listener in listeners)
            {
                listener.OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnRegisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
