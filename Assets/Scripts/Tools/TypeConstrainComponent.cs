using System;
using UnityEngine;
#if UNITY_EDITOR
public class TypeConstrainComponent : PropertyAttribute
{
    private Type typeThing;
    public Type TypeThing { get { return typeThing; } }
    public TypeConstrainComponent(Type typeToIgnore)
    {
        typeThing = typeToIgnore;
    }

}
#endif
