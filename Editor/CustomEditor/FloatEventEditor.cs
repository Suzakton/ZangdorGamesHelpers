#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using ZangdorGames.Helpers.Scriptables;

/// <summary>
/// Custom editor for a FloatEvent with a button to trigger the event.
/// </summary>
[CustomEditor(typeof(FloatEvent))]
public class FloatEventEditor : Editor 
{
    /// <summary>
    /// Test variable send with the event.
    /// </summary>
    private float _debugVariable = 0;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        _debugVariable = EditorGUILayout.FloatField("Test value", _debugVariable);
        if(GUILayout.Button("Invoke Event"))
            (target as FloatEvent).Invoke(_debugVariable);
    }
}
#endif