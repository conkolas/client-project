using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/String Variable")]
public class StringVariable : ScriptableObject
{
    public string Description = "";

    public string Value;

    public void SetValue(string value)
    {
        Value = value;
    }

    public void SetValue(StringVariable value)
    {
        Value = value.Value;
    }

    public static implicit operator string(StringVariable reference)
    {
        return reference.Value;
    }
}
