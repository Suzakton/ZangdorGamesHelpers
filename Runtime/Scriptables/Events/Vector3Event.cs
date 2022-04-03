using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable event with a Vector3 argument.
    /// </summary>
    [CreateAssetMenu(fileName = "Vector3Event", menuName = "ZangdorGames/SOEvents/Vector3Event", order = 0)]
    public class Vector3Event : SOEvent<Vector3> { }
}