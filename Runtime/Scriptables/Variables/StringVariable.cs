using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{    
    /// <summary>
    /// Scriptable used for string <see cref="SOVariable"/>
    /// </summary>
    [CreateAssetMenu(fileName = "StringVariable", menuName = "ZangdorGames/SOVariables/StringVariable", order = 0)]
    public sealed class StringVariable : SOVariable<string> { }
}