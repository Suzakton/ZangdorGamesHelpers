using System;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Reference class for variable. Allow to chose between a constant float value or a shared FloatVariable.
    /// </summary>
    [Serializable]    
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public FloatVariable Variable;

        public FloatReference() { }

        public FloatReference(float value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public float Value
        {
            get { return UseConstant ? ConstantValue : Variable.CurrentValue; }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}