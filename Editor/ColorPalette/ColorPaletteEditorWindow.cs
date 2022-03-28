#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using ZangdorGames.Helpers.Extensions;

namespace ZangdorGames.EditorHelpers.Tools
{
    /// <summary>
    /// Editor window to configure the color palette tool
    /// </summary>
    public class ColorPaletteEditorWindow : EditorWindow 
    {
        /// <summary>
        /// Text of the button to refresh the color palette settings
        /// </summary>
        private const string REFRESH_BUTTON_TEXT = "Refresh color palette asset";

        /// <summary>
        /// Text of the button to create a color palette scriptable
        /// </summary>
        private const string CREATE_BUTTON_TEXT = "Create new color palette asset";

        /// <summary>
        /// Text shown when there is no color palette scriptable 
        /// </summary>
        private const string COLOR_PALETTE_NULL_ERROR_MESSAGE = "No color palette scriptable asset found";

        /// <summary>
        /// Path of the color palette tool in the package
        /// </summary>
        private const string PACKAGE_PATH = "Packages/com.zangdorgames.helpers/Editor/ColorPalette";

        /// <summary>
        /// Unity function OnEnable
        /// </summary>
        private void OnEnable() 
        {
            ColorHierarchy.InitializeColorPalette();
        }

        /// <summary>
        /// Unity function OnGUI
        /// </summary>
        private void OnGUI() 
        {
            if(GUILayout.Button(REFRESH_BUTTON_TEXT))
                ColorHierarchy.InitializeColorPalette();
            if(!ColorHierarchy.IsColorPaletteLoaded())
            {
                GUIStyle style = new GUIStyle(GUI.skin.label);
                style.richText = true;
                GUILayout.Label(COLOR_PALETTE_NULL_ERROR_MESSAGE.Bold().Color(Color.red), style);
                
                if(GUILayout.Button(CREATE_BUTTON_TEXT))
                    ColorHierarchy.CreateColorPaletteAtPath(PACKAGE_PATH);
                return;
            }

            EditorGUILayout.PropertyField(new SerializedObject(ColorHierarchy.GetCurrentColorPalette()).FindProperty(nameof(ColorPalette.ColorDesigns)));
        }
    }
}
#endif