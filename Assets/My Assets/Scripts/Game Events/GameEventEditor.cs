using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var myGameEvent = (GameEvent)target;

        if (GUILayout.Button("Raise Event"))
        {
            myGameEvent.Raise();
        }

        GUILayout.Space(10);

        DrawDefaultInspector();
    }
}