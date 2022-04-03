using System;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Reference class for variable. Allow to chose between a constant string value or a shared StringVariable.
    /// </summary>
    [Serializable]    
    public class StringReference
    {
        public bool UseConstant = true;
        public string ConstantValue;
        public StringVariable Variable;

        public StringReference() { }

        public StringReference(string value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public string Value
        {
            get { return UseConstant ? ConstantValue : Variable.CurrentValue; }
        }

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}