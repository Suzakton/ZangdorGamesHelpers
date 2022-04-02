using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable used for int <see cref="SOVariable"/>
    /// </summary>   
    [CreateAssetMenu(fileName = "IntVariable", menuName = "ZangdorGames/SOVariables/IntVariable", order = 0)]
    public sealed class IntVariable : SOVariable<int> { }
}