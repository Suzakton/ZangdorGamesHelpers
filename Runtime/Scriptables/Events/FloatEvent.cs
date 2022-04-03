using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable event with a float argument.
    /// </summary>
    [CreateAssetMenu(fileName = "FloatEvent", menuName = "ZangdorGames/SOEvents/FloatEvent", order = 0)]
    public class FloatEvent : SOEvent<float> { }
}