using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable event with a Vector2 argument.
    /// </summary>
    [CreateAssetMenu(fileName = "Vector2Event", menuName = "ZangdorGames/SOEvents/Vector2Event", order = 0)]
    public class Vector2Event : SOEvent<Vector2> { }
}