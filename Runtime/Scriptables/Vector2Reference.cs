using System;
using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Reference class for variable. Allow to chose between a constant Vector2 value or a shared Vector2Variable.
    /// </summary>
    [Serializable]    
    public class Vector2Reference
    {
        public bool UseConstant = true;
        public Vector2 ConstantValue;
        public Vector2Variable Variable;

        public Vector2Reference() { }

        public Vector2Reference(Vector2 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public Vector2 Value
        {
            get { return UseConstant ? ConstantValue : Variable.CurrentValue; }
        }

        public static implicit operator Vector2(Vector2Reference reference)
        {
            return reference.Value;
        }
    }
}