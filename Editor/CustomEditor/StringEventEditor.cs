#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using ZangdorGames.Helpers.Scriptables;

/// <summary>
/// Custom editor for a StringEvent with a button to trigger the event.
/// </summary>
[CustomEditor(typeof(StringEvent))]
public class StringEventEditor : Editor 
{
    /// <summary>
    /// Test variable send with the event.
    /// </summary>
    private string _debugVariable = "";

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        _debugVariable = EditorGUILayout.TextField("Test value", _debugVariable);
        if(GUILayout.Button("Invoke Event"))
            (target as StringEvent).Invoke(_debugVariable);
    }
}
#endif