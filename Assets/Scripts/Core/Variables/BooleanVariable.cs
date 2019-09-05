using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Boolean Variable")]
public class BooleanVariable : ScriptableObject
{
    public string Description = "";

    public bool Value;

    public void SetValue(bool value)
    {
        Value = value;
    }

    public void SetValue(BooleanVariable value)
    {
        Value = value.Value;
    }

    public static implicit operator bool(BooleanVariable reference)
    {
        return reference.Value;
    }
}
