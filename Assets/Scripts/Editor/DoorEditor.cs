using UnityEditor;

[CustomEditor(typeof(Door))]
public class DoorEditor : Editor
{
    private SerializedObject so;
    private SerializedProperty teleportDogProperty;
    private SerializedProperty openedDoorPositionProperty;
    private SerializedProperty openDoorSpeedProperty;
    private SerializedProperty autoCloseProperty;
    private SerializedProperty waitTimeBefroeCloseProperty;
    private SerializedProperty triggerDoorCollisionProperty;
    private SerializedProperty doorStatusProperty;
    private SerializedProperty eventThingy;

    private void OnEnable()
    {
        so = serializedObject;
        teleportDogProperty = so.FindProperty("teleportDog");
        openedDoorPositionProperty = so.FindProperty("openedDoorPosition");
        openDoorSpeedProperty = so.FindProperty("openDoorSpeed");
        autoCloseProperty = so.FindProperty("autoClose");
        waitTimeBefroeCloseProperty = so.FindProperty("waitTimeBeforeClose");
        triggerDoorCollisionProperty = so.FindProperty("triggerDoorCollision");
        doorStatusProperty = so.FindProperty("doorStatus");
        eventThingy = so.FindProperty("Moving");
    }

    public override void OnInspectorGUI()
    {
        so.Update();
        EditorGUILayout.PropertyField(eventThingy);
        EditorGUILayout.PropertyField(teleportDogProperty);
        EditorGUILayout.PropertyField(doorStatusProperty);
        EditorGUILayout.PropertyField(openedDoorPositionProperty);
        EditorGUILayout.PropertyField(openDoorSpeedProperty);
        EditorGUILayout.PropertyField(autoCloseProperty);

        if (autoCloseProperty.boolValue)
        {
            EditorGUILayout.PropertyField(waitTimeBefroeCloseProperty);
            EditorGUILayout.PropertyField(triggerDoorCollisionProperty);
        }
        so.ApplyModifiedProperties();
    }
}
