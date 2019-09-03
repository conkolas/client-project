using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float Variable")]
public class FloatVariable : ScriptableObject 
{
	public string Description = "";
	
	public float Value;
	
	public void SetValue(float value)
	{
		Value = value;
	}
	
	public void SetValue(FloatVariable value)
	{
		Value = value.Value;
	}
	
	public void ApplyChange(float amount)
	{
		Value += amount;
	}
	
	public void ApplyChange(FloatVariable amount)
	{
		Value += amount.Value;
	}

    public static implicit operator float(FloatVariable reference)
    {
        return reference.Value;
    }
}
