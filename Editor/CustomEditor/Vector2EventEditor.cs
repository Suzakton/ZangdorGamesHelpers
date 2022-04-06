using UnityEngine;
using UnityEditor;
using ZangdorGames.Helpers.Scriptables;

/// <summary>
/// Custom editor for a Vector2Event with a button to trigger the event.
/// </summary>
[CustomEditor(typeof(Vector2Event))]
public class Vector2EventEditor : Editor 
{
    /// <summary>
    /// Test variable send with the event.
    /// </summary>
    private Vector2 _debugVariable = Vector2.zero;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        _debugVariable = EditorGUILayout.Vector2Field("Test value", _debugVariable);
        if(GUILayout.Button("Invoke Event"))
            (target as Vector2Event).Invoke(_debugVariable);
    }
}