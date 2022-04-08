#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using ZangdorGames.Helpers.Scriptables;

/// <summary>
/// Custom editor for a BoolEvent with a button to trigger the event.
/// </summary>
[CustomEditor(typeof(BoolEvent))]
public class BoolEventEditor : Editor 
{
    /// <summary>
    /// Test variable send with the event.
    /// </summary>
    private bool _debugVariable = false;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        _debugVariable = EditorGUILayout.Toggle("Test value", _debugVariable);
        if(GUILayout.Button("Invoke Event"))
            (target as BoolEvent).Invoke(_debugVariable);
    }
}
#endif