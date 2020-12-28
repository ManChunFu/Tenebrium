using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(TypeConstrainComponent))]
public class TypeConstrainComponentDrawer : PropertyDrawer
{
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var constraint = attribute as TypeConstrainComponent;

        if (DragAndDrop.objectReferences.Length > 0)
        {
            if (position.Contains(Event.current.mousePosition))
            {
                var draggedObject = DragAndDrop.objectReferences[0] as Component;
                if (draggedObject == null || (draggedObject != null && constraint.TypeThing.IsAssignableFrom(draggedObject.GetType()) == false))
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;

                }
            }
        }

        if (property.objectReferenceValue != null)
        {

            Component go = property.objectReferenceValue as Component;
            if (go != null && go.GetComponent(constraint.TypeThing) == null)
            {

                property.objectReferenceValue = null;
            }
        }

        property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(Component), true);   
    }
}
#endif
