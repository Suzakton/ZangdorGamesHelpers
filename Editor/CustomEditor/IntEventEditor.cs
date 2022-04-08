#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using ZangdorGames.Helpers.Scriptables;

/// <summary>
/// Custom editor for a IntEvent with a button to trigger the event.
/// </summary>
[CustomEditor(typeof(IntEvent))]
public class IntEventEditor : Editor 
{
    /// <summary>
    /// Test variable send with the event.
    /// </summary>
    private int _debugVariable = 0;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        _debugVariable = EditorGUILayout.IntField("Test value", _debugVariable);
        if(GUILayout.Button("Invoke Event"))
            (target as IntEvent).Invoke(_debugVariable);
    }
}
#endif