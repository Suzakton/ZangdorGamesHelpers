using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable event with a string argument.
    /// </summary>
    [CreateAssetMenu(fileName = "StringEvent", menuName = "ZangdorGames/SOEvents/StringEvent", order = 0)]
    public class StringEvent : SOEvent<string> { }
}