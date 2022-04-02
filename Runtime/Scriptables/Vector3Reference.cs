using System;
using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Reference class for variable. Allow to chose between a constant Vector3 value or a shared Vector3
    /// Variable.
    /// </summary>
    [Serializable]    
    public class Vector3Reference
    {
        public bool UseConstant = true;
        public Vector3 ConstantValue;
        public Vector3Variable Variable;

        public Vector3Reference() { }

        public Vector3Reference(Vector3 value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public Vector3 Value
        {
            get { return UseConstant ? ConstantValue : Variable.CurrentValue; }
        }

        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}