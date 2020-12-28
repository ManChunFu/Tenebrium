using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PhysicsForceAdjuster))]
public class EditorPhysicsForceAdjuster : Editor
{
    private SerializedObject so;
    private SerializedProperty units;
    GameObject prefab;

    private void OnEnable()
    {
        so = serializedObject;
        units = so.FindProperty("units");
    }
    public override void OnInspectorGUI()
    {
        so.Update();
        EditorGUILayout.PropertyField(units);
        so.ApplyModifiedProperties();

        if (GUILayout.Button("Add Box"))
        {
            
            GameObject test = new GameObject();
            test.name = "ForceAdjusterBox";
            BoxCollider box= test.AddComponent<BoxCollider>();
            box.isTrigger = true;
            Rigidbody rb = test.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            test.AddComponent<ForceAdjusterBox>();
        }
    }
}
