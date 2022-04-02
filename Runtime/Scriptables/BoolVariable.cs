using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable used for bool <see cref="SOVariable"/>
    /// </summary>    
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "ZangdorGames/SOVariables/BoolVariable", order = 0)]
    public sealed class BoolVariable : SOVariable<bool> { }
}