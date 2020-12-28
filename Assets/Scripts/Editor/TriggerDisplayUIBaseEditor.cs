using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TriggerDisplayUIBase), true)]
public class TriggerEventBaseEditor : Editor
{
    private SerializedObject so;
    private SerializedProperty propIsDisplay;
    private SerializedProperty propUIManager;
    private SerializedProperty propDisplayInfo;
    private SerializedProperty propFont;
    private SerializedProperty propFontSize;
    private SerializedProperty propFontStyle;
    private SerializedProperty propTextColor;
    private SerializedProperty propSecondsToClear;
    private SerializedProperty propTriggerOnce;

    private SerializedProperty propCameraShake;
    private SerializedProperty propShakeDuration;
    private SerializedProperty propShakeForce;
    private SerializedProperty propShakeRange;
    private SerializedProperty propCurve;

    private SerializedProperty propTriggerDoorActivate;
    private void OnEnable()
    {
        so = serializedObject;
        propIsDisplay = so.FindProperty("displayMessage");
        propUIManager = so.FindProperty("uiManager");
        propDisplayInfo = so.FindProperty("displayInfo");
        propFont = so.FindProperty("textFont");
        propFontSize = so.FindProperty("fontSize");
        propFontStyle = so.FindProperty("fontStyle");
        propTextColor = so.FindProperty("textColor");
        propSecondsToClear = so.FindProperty("secondsToClearText");
        propTriggerOnce = so.FindProperty("triggerOnce");

        propCameraShake = so.FindProperty("cameraShake");
        propShakeDuration = so.FindProperty("shakeDuration");
        propShakeForce = so.FindProperty("shakeForce");
        propShakeRange = so.FindProperty("shakeRange");
        propCurve = so.FindProperty("curve");

        propTriggerDoorActivate = so.FindProperty("onTriggerActivate");
    }

    public override void OnInspectorGUI()
    {
        so.Update();
        
        propIsDisplay.boolValue = EditorGUILayout.Toggle("Display Message", propIsDisplay.boolValue);
        if (propIsDisplay.boolValue)
        {
            GUILayout.Space(5);
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(propUIManager, new GUIContent("UIManager"));
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(propDisplayInfo, new GUIContent("Message Display"));
                GUILayout.Space(5);
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Label("Text Font", GUILayout.Width(100));
                    EditorGUILayout.PropertyField(propFont, new GUIContent(""));
                }
                GUILayout.Space(5);
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Label("Font Sytle", GUILayout.Width(100));
                    EditorGUILayout.PropertyField(propFontStyle, new GUIContent(""));
                    GUILayout.Space(10);
                    GUILayout.Label("Font Size", GUILayout.Width(60));
                    EditorGUILayout.PropertyField(propFontSize, new GUIContent(""), GUILayout.Width(60));
                }
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(propTextColor, new GUIContent("Text Color"));
                GUILayout.Space(5);
                using (new GUILayout.HorizontalScope())
                {
                    EditorGUILayout.PropertyField(propSecondsToClear, new GUIContent("Clear Text After"));
                    GUILayout.Label("Seconds");
                }
                GUILayout.Space(5);
            }
        }

        GUILayout.Space(5);
        EditorGUILayout.PropertyField(propTriggerOnce);

        if (this.target.GetType() == typeof(CameraShakeTriggerEvent))
        {
            GUILayout.Space(5);
            using (new GUILayout.VerticalScope(EditorStyles.helpBox))
            {
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(propCameraShake);
                GUILayout.Space(5);
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Label("Shake Duration", GUILayout.Width(100));
                    EditorGUILayout.PropertyField(propShakeDuration, new GUIContent(""));
                    GUILayout.Space(10);
                    GUILayout.Label("Shake Force", GUILayout.Width(100));
                    EditorGUILayout.PropertyField(propShakeForce, new GUIContent(""));
                }
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(propShakeRange);
                GUILayout.Space(5);
                EditorGUILayout.PropertyField(propCurve);
                GUILayout.Space(5);
            }
        }

        if (this.target.GetType() == typeof(TriggerCollision))
        {
            GUILayout.Space(5);
            EditorGUILayout.LabelField("Choose always [OpenCloseDoor] function if you want to trigger a door.", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(propTriggerDoorActivate);
        }

        so.ApplyModifiedProperties();
    }
}
