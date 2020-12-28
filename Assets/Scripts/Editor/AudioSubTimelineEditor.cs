using UnityEngine;
using UnityEditor;
using Timeline;

[CustomEditor(typeof(AudioSubTimeline))]
public class AudioSubTimelineEditor : Editor
{
    private SerializedObject so = null;
    private SerializedProperty voiceTypePropperty = null;

    private void OnEnable()
    {
        so = serializedObject;
        voiceTypePropperty = so.FindProperty("voiceType");
    }
    public override void OnInspectorGUI()
    {
        so.Update();

        GUILayout.Space(5);
        EditorGUILayout.LabelField("Open Timeline window and create a playable asset by pressing the button under.", EditorStyles.wordWrappedLabel); ;
        GUILayout.Space(5);
        if (GUILayout.Button("Open and Create Timeline"))
            OpenTimeline();

        GUILayout.Space(10);
        EditorGUILayout.PropertyField(voiceTypePropperty);
        so.ApplyModifiedProperties();
    }

    private void OpenTimeline()
    {
        if (!EditorApplication.ExecuteMenuItem("Window/Sequencing/Timeline"))
            EditorApplication.ExecuteMenuItem("Window/Sequencing/Timeline");

    }
}
