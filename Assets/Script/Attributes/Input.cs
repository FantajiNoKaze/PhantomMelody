

using System;
using Unity.Entities;
[Flags]
public enum InputSignal
{
    None = 0,
    Up = 1,
    Dowm = 2,
    Left = 4,
    Right = 8
}


public struct Controller : IComponentData
{
    public InputSignal inputSignal;

}
