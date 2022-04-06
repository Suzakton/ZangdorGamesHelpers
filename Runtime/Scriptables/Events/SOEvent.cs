using System;
using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Abstract scriptable event with one argument.
    /// </summary>
    /// <typeparam name="T">Type of the event's argument.</typeparam>
    public abstract class SOEvent<T> : ScriptableObject 
    {
        private Action<T> _event;

        public void Invoke(T arg)
        {
            _event?.Invoke(arg);
        }

        public void Subscribe(Action<T> function)
        {
            _event += function;
        }

        public void Unsubscribe(Action<T> function)
        {
            _event -= function;
        }
    }

    /// <summary>
    /// Abstract scriptable event with two argument.
    /// </summary>
    /// <typeparam name="T1">Type of the event's first argument.</typeparam>
    /// <typeparam name="T2">Type of the event's second argument.</typeparam>
    public abstract class SOEvent<T1, T2> : ScriptableObject 
    {
        private Action<T1, T2> _event;

        public void Invoke(T1 arg1, T2 arg2)
        {
            _event?.Invoke(arg1, arg2);
        }

        public void Subscribe(Action<T1, T2> function)
        {
            _event += function;
        }

        public void Unsubscribe(Action<T1, T2> function)
        {
            _event -= function;
        }
    }
}