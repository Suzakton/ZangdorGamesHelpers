#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using ZangdorGames.EditorHelpers.Tools;
using static UnityEditor.EditorWindow;
using static ZangdorGames.EditorHelpers.Utilities.AssetUtility;

namespace ZangdorGames.EditorHelpers
{
    public static class ToolsMenu
    {
        /// <summary>
        /// Open the Color palette tool window
        /// </summary>
        [MenuItem("ZangdorGames/Tools/Color palette")]
        private static void ShowColorPaletteWindow() 
        {
            var window = GetWindow<ColorPaletteEditorWindow>();
            window.titleContent = new GUIContent("Color Palette");
            window.Show(); 
        }

        /// <summary>
        /// Called when the unity editor preprocessing menu item is clicked,
        /// it will apply unity editor preprocessing on selected assets.
        /// </summary>
        [MenuItem("ZangdorGames/Tools/Preprocess selected/" + UNITY_EDITOR_PREPROCESS_NAME)]
        private static void OnUnityEditorAssetPreProcess()
        {
            string[] assetGuids = Selection.assetGUIDs;
            for (int i = 0; i < assetGuids.Length; i++)
                ApplyPreProcessingOnAsset(assetGuids[i], UNITY_EDITOR_PREPROCESS_NAME);
        }

        /// <summary>
        /// Called when the unity ios preprocessing menu item is clicked,
        /// it will apply unity ios preprocessing on selected assets.
        /// </summary>
        [MenuItem("ZangdorGames/Tools/Preprocess selected/" + IOS_PREPROCESS_NAME)]
        private static void OnIOSAssetPreProcess()
        {
            string[] assetGuids = Selection.assetGUIDs;
            for (int i = 0; i < assetGuids.Length; i++)
                ApplyPreProcessingOnAsset(assetGuids[i], IOS_PREPROCESS_NAME);
        }


        /// <summary>
        /// Called when the unity android preprocessing menu item is clicked,
        /// it will apply unity android preprocessing on selected assets.
        /// </summary>
        [MenuItem("ZangdorGames/Tools/Preprocess selected/" + ANDROID_PREPROCESS_NAME)]
        private static void OnAndroidAssetPreProcess()
        {
            string[] assetGuids = Selection.assetGUIDs;
            for (int i = 0; i < assetGuids.Length; i++)
                ApplyPreProcessingOnAsset(assetGuids[i], ANDROID_PREPROCESS_NAME);
        }
    }
}
#endif