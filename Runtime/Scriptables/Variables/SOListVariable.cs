using System.Collections.Generic;
using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{   
    /// <summary>
    /// Abstract class for List Scriptable Variables.
    /// <typeparam name="T">The type of variable in the list.</typeparam>
    /// </summary>
    public abstract class SOListVariable<T> : ScriptableObject
    {
        /// <summary>
        /// The default value of the variable.
        /// </summary>
        [SerializeField]
        protected List<T> _defaultValue = null;

        /// <summary>
        /// The current value of the variable.
        /// </summary>
        protected List<T> _currentValue = null;

        /// <summary>
        /// Getter of the current value.
        /// </summary>
        public virtual List<T> CurrentValue
        { 
            get 
            { 
                if(_currentValue == null)
                    _currentValue = new List<T>();
                return _currentValue;
            }
        }

        /// <summary>
        /// Setter for the current variable.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public virtual void SetValue(List<T> value)
        {
            _currentValue = value;
        }

        /// <summary>
        /// Setter for the current variable.
        /// </summary>
        /// <param name="value"></param>
        public virtual void SetValue(SOListVariable<T> value)
        {
            _currentValue = value.CurrentValue;
        }

        protected virtual void OnEnable() 
        {
            _currentValue = _defaultValue;
            if(_currentValue == null)
                    _currentValue = new List<T>();
        }
    }
}