using System;
using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Reference class for variable. Allow to chose between a constant Color value or a shared ColorVariable.
    /// </summary>
    [Serializable]    
    public class ColorReference
    {
        public bool UseConstant = true;
        public Color ConstantValue;
        public ColorVariable Variable;

        public ColorReference() { }

        public ColorReference(Color value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public Color Value
        {
            get { return UseConstant ? ConstantValue : Variable.CurrentValue; }
        }

        public static implicit operator Color(ColorReference reference)
        {
            return reference.Value;
        }
    }
}