using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{    
    /// <summary>
    /// Abstract class for every Scriptable Variables.
    /// </summary>
    /// <typeparam name="T">The type of variable.</typeparam>
    public abstract class SOVariable<T> : ScriptableObject
    {
        /// <summary>
        /// The default value of the variable.
        /// </summary>
        [SerializeField]
        protected T _defaultValue;

        /// <summary>
        /// The current value of the variable.
        /// </summary>
        protected T _currentValue;

        /// <summary>
        /// Getter of the current value.
        /// </summary>
        public virtual T CurrentValue { get => _currentValue; }

        /// <summary>
        /// Setter for the current variable.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public virtual void SetValue(T value)
        {
            _currentValue = value;
        }

        /// <summary>
        /// Setter for the current variable.
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetValue(SOVariable<T> value)
        {
            _currentValue = value.CurrentValue;
        }

        protected virtual void OnEnable() 
        {
            _currentValue = _defaultValue;
        }
    }
}