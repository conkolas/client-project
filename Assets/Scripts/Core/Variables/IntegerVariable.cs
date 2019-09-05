using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Integer Variable")]
public class IntegerVariable : ScriptableObject
{
    public string Description = "";

    public int Value;

    public void SetValue(int value)
    {
        Value = value;
    }

    public void ApplyChange(int amount)
    {
        Value += amount;
    }

    public void ApplyChange(IntegerVariable amount)
    {
        Value += amount.Value;
    }

    public static implicit operator int(IntegerVariable reference)
    {
        return reference.Value;
    }
}
