#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine;

namespace ZangdorGames.EditorHelpers.Tools
{
    /// <summary>
    /// Details for the custom design
    /// </summary>
    [System.Serializable]
    public class ColorDesign
    {
        /// <summary>
        /// Characters used to define that an object will be
        /// stylised in the hierarchy.
        /// </summary>
        [Tooltip("GameObject that begin with this keychar will be stylised")]
        public string KeyChar;
        /// <summary>
        /// The text color to apply of the object name in the hierarchy
        /// </summary>
        [Tooltip("Don't forget to change alpha to 255")]
        public Color TextColor;
        /// <summary>
        /// The background color to apply of the object name in the hierarchy
        /// </summary>
        [Tooltip("Don't forget to change alpha to 255")]
        public Color BackgroundColor;
        /// <summary>
        /// The alignment of the text in the hierarchy
        /// </summary>
        public TextAnchor TextAlignment;
        /// <summary>
        /// Font style used for text in the hierarchy
        /// </summary>
        public FontStyle FontStyle;
        /// <summary>
        /// Define if the text will be in uppercase 
        /// or will stay the same as in the heirarchy
        /// </summary>
        public bool AllUppercase;

    }

    /// <summary>
    /// The scriptable holder of the list of <typeparamref name="ColorDesign"/>
    /// </summary>
    public class ColorPalette : ScriptableObject
    {
        /// <summary>
        /// List of designs
        /// </summary>
        public List<ColorDesign> ColorDesigns = new List<ColorDesign>();
    }
}
#endif