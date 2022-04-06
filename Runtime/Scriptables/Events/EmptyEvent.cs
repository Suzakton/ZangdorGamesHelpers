using System;
using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable event with no argument.
    /// </summary>
    [CreateAssetMenu(fileName = "Event", menuName = "ZangdorGames/SOEvents/EmptyEvent", order = -10000)]
    public class EmptyEvent : ScriptableObject 
    {
        private Action _event;

        public void Invoke()
        {
            _event?.Invoke();
        }

        public void Subscribe(Action function)
        {
            _event += function;
        }

        public void Unsubscribe(Action function)
        {
            _event -= function;
        }
    }
}