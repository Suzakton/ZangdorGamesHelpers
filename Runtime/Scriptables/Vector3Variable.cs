using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable used for Vector3 <see cref="SOVariable"/>
    /// </summary>
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "ZangdorGames/SOVariables/Vector3Variable", order = 0)]
    public sealed class Vector3Variable : SOVariable<Vector3> { }
}