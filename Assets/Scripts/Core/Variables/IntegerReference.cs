using System;

[Serializable]
public class IntegerReference
{
    public bool UseConstant = true;
    public int ConstantValue;
    public IntegerVariable Variable;

    public IntegerReference() { }

    public IntegerReference(int value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public float Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator int(IntegerReference reference)
    {
        return reference.UseConstant ? reference.ConstantValue : reference.Variable.Value;
    }
}
