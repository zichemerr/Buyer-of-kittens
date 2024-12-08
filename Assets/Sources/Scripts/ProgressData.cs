using System;

[Serializable]
public class ProgressData
{
    public int Value;
    public int Level;

    public ProgressData SetValues(int value, int level)
    {
        Value = value;
        Level = level;

        return this;
    }
}