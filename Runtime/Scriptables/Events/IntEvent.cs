using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable event with an int argument.
    /// </summary>
    [CreateAssetMenu(fileName = "IntEvent", menuName = "ZangdorGames/SOEvents/IntEvent", order = 0)]
    public class IntEvent : SOEvent<int> { }
}