#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using ZangdorGames.EditorHelpers.Utilities;
using Object = UnityEngine.Object;

namespace ZangdorGames.EditorHelpers.Tools
{
    /// <summary>
    /// Editor class used to color object name in hierarchy.
    /// </summary>
    [InitializeOnLoad]
    public class ColorHierarchy
    {
        /// <summary>
        /// Color palette containing data for color change
        /// </summary>
        private static ColorPalette _colorPalette;

        /// <summary>
        /// Constructor used by the editor with the InitializeOnLoad attribut
        /// </summary>
        static ColorHierarchy()
        {
            InitializeColorPalette();
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyWindow;
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindow;
        }

        /// <summary>
        /// Load the color palette from the assets
        /// </summary>
        public static void InitializeColorPalette()
        {
            _colorPalette = AssetDatabaseUtility.LoadAsset<ColorPalette>();
        }

        /// <summary>
        /// Return true if a ColorPalette scriptable asset was found in the project
        /// </summary>
        /// <returns>If a ColorPalette was found</returns>
        public static bool IsColorPaletteLoaded()
        {
            return _colorPalette != null;
        }

        /// <summary>
        /// Return the current color palette used
        /// </summary>
        /// <returns>The color palette</returns>
        public static ColorPalette GetCurrentColorPalette()
        {
            return _colorPalette;
        }

        /// <summary>
        /// Create a <see cref="ColorPalette"/> at the given path
        /// </summary>
        /// <param name="path">The path where we need to create the asset</param>
        public static void CreateColorPaletteAtPath(string path)
        {
            AssetDatabaseUtility.GetOrCreateScriptableObjectAsset<ColorPalette>($"{path}/Color palette.asset");
            AssetDatabase.Refresh();
            InitializeColorPalette();
        }

        /// <summary>
        /// Function used to customize the name of a gameobject in the hierarchy
        /// </summary>
        /// <param name="instanceID">Id of the object to change style</param>
        /// <param name="selectionRect"><typeparamref name="Rect"/> where to customize style and background</param>
        private static void OnHierarchyWindow(int instanceID, Rect selectionRect)
        {
            //To make sure there is no error if no ColorPalette scriptable is found
            if (_colorPalette == null) return;

            Object instance = EditorUtility.InstanceIDToObject(instanceID);

            if (instance != null)
            {
                for (int i = 0; i < _colorPalette.ColorDesigns.Count; i++)
                {
                    var design = _colorPalette.ColorDesigns[i];

                    //Check if the name of each gameObject is begin with keyChar in colorDesigns list.
                    if (instance.name.StartsWith(design.KeyChar))
                    {
                        //Remove the symbol(KeyChar) from the name.
                        string newName = instance.name.Substring(design.KeyChar.Length);
                        //Draw a rectangle as a background, and set the color.
                        EditorGUI.DrawRect(selectionRect, design.BackgroundColor);

                        //Create a new GUIStyle to match the desing in colorDesigns list.
                        GUIStyle newStyle = new GUIStyle
                        {
                            alignment = design.TextAlignment,
                            fontStyle = design.FontStyle,
                            normal = new GUIStyleState()
                            {
                                textColor = design.TextColor,
                            }
                        };

                        //Draw a label to show the name in newStyle.
                        EditorGUI.LabelField(selectionRect, design.AllUppercase ? newName.ToUpper() : newName, newStyle);
                    }
                }
            }
        }
    }
}
#endif