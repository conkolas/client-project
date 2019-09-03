using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RangedFloatReference {
    public bool UseConstant = true;
    public float ConstantMinValue;
    public float ConstantMaxValue;
    public RangedFloatVariable Variable;

    public RangedFloatReference() { }

    public RangedFloatReference(float minValue, float maxValue)
    {
        UseConstant = true;
        ConstantMinValue = minValue;
        ConstantMaxValue = maxValue;
    }

    public float MinValue
    {
        get { return UseConstant ? ConstantMinValue : Variable.MinValue; }
    }

    public float MaxValue
    {
        get { return UseConstant ? ConstantMaxValue : Variable.MaxValue; }
    }

    public static implicit operator RangedFloatVariable(RangedFloatReference reference)
    {
        return reference;
    }
}
