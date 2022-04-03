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
        private T _defaultValue;

        /// <summary>
        /// The current value of the variable.
        /// </summary>
        private T _currentValue;

        /// <summary>
        /// Getter of the current value.
        /// </summary>
        public T CurrentValue { get => _currentValue; }

        /// <summary>
        /// Setter for the current variable.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetValue(T value)
        {
            _currentValue = value;
        }

        /// <summary>
        /// Setter for the current variable.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(SOVariable<T> value)
        {
            _currentValue = value.CurrentValue;
        }

        private void OnEnable() 
        {
            _currentValue = _defaultValue;
        }
    }
}