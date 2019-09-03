using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Ranged Float Variable")]
public class RangedFloatVariable : ScriptableObject
{
    public RangedFloat Value;

    public float MinValue
    {
        get { return Value.MinValue; }
        set { Value.MinValue = value; }
    }

    public float MaxValue
    {
        get { return Value.MaxValue; }
        set { Value.MaxValue = value; }
    }
}
