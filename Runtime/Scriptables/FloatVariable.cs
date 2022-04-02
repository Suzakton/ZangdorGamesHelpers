using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable used for float <see cref="SOVariable"/>
    /// </summary>
    [CreateAssetMenu(fileName = "FloatVariable", menuName = "ZangdorGames/SOVariables/FloatVariable", order = 0)]
    public sealed class FloatVariable : SOVariable<float> { }
}