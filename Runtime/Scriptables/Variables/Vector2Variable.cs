using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{    
    /// <summary>
    /// Scriptable used for Vector2 <see cref="SOVariable"/>
    /// </summary>
    [CreateAssetMenu(fileName = "Vector2Variable", menuName = "ZangdorGames/SOVariables/Vector2Variable", order = 0)]
    public sealed class Vector2Variable : SOVariable<Vector2> { }
}