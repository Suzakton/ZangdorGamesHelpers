using System;
using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{    
    /// <summary>
    /// Reference class for variable. Allow to chose between a constant bool value or a shared BoolVariable.
    /// </summary>
    [Serializable]    
    public class BoolReference
    {
        public bool UseConstant = true;
        public bool ConstantValue;
        public BoolVariable Variable;

        public BoolReference() { }

        public BoolReference(bool value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public bool Value
        {
            get { return UseConstant ? ConstantValue : Variable.CurrentValue; }
        }

        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }
    }
}