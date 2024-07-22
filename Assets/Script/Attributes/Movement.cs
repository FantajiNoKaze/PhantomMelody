using System;
using System.Collections.Generic;
using Unity.Entities;

[Flags]
public enum Direction{
    None = 0,
    Top = 1,
    Down= 2,
    Forward = 4,
    Backward = 8
}
public struct MoveData :IComponentData
{
    public Direction direction;
    public float moveSpeed;
}
