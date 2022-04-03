using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable event with a bool argument.
    /// </summary>
    [CreateAssetMenu(fileName = "BoolEvent", menuName = "ZangdorGames/SOEvents/BoolEvent", order = 0)]
    public class BoolEvent : SOEvent<bool> { }
}