using System;
using UnityEngine;
#if UNITY_EDITOR
public class TypeConstrain : PropertyAttribute
{
    private Type typeThing;
    public Type TypeThing { get { return typeThing; } }
    public TypeConstrain(Type typeToIgnore)
    {
        typeThing = typeToIgnore;
    }

    
}
#endif

