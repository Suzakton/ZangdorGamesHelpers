#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using ZangdorGames.Helpers.Scriptables;

/// <summary>
/// Custom editor for a Vector3Event with a button to trigger the event.
/// </summary>
[CustomEditor(typeof(Vector3Event))]
public class Vector3EventEditor : Editor 
{
    /// <summary>
    /// Test variable send with the event.
    /// </summary>
    private Vector3 _debugVariable = Vector3.zero;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        _debugVariable = EditorGUILayout.Vector3Field("Test value", _debugVariable);
        if(GUILayout.Button("Invoke Event"))
            (target as Vector3Event).Invoke(_debugVariable);
    }
}
#endif