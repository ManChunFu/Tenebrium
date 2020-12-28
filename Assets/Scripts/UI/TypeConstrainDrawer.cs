using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(TypeConstrain))]
public class TypeConstrainDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property.propertyType != SerializedPropertyType.ObjectReference)
        {

        }

        var constraint = attribute as TypeConstrain;

        if (DragAndDrop.objectReferences.Length > 0)
        {
            var draggedObject = DragAndDrop.objectReferences[0] as GameObject;


            if (draggedObject == null || (draggedObject != null && draggedObject.GetComponent(constraint.TypeThing) == null))
                DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
        }


        if (property.objectReferenceValue != null)
        {

            GameObject go = property.objectReferenceValue as GameObject;
            if (go != null && go.GetComponent(constraint.TypeThing) == null)
            {

                property.objectReferenceValue = null;
            }
        }

        property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(GameObject), true);
    }

}
#endif
