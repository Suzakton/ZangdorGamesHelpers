#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using ZangdorGames.Helpers.Scriptables;

[CustomEditor(typeof(EmptyEvent))]
public class EmptyEventEditor : Editor 
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if(GUILayout.Button("Invoke Event"))
            (target as EmptyEvent).Invoke();
    }
}
#endif