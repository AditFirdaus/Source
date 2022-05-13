using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComponentGroup", menuName = "ComponentGroup")]
public class ComponentGroup : ScriptableObject
{
    public int groupCode = 0;
    public Sprite sprite;
    public AssemblyComponent[] components;
}

