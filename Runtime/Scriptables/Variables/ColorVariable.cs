using UnityEngine;

namespace ZangdorGames.Helpers.Scriptables
{
    /// <summary>
    /// Scriptable used for Color <see cref="SOVariable"/>
    /// </summary>    
    [CreateAssetMenu(fileName = "ColorVariable", menuName = "ZangdorGames/SOVariables/ColorVariable", order = 0)]
    public sealed class ColorVariable : SOVariable<Color> { }
}