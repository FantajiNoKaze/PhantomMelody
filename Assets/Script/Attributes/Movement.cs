using System;
using System.Collections.Generic;
using Unity.Entities;

public struct MovementTask : IBufferElementData
{
    public bool lift;
    public float moveSpeed;
    public float moveAngle;
    public float moveDuration;//frame

}

public struct MovementTaskData :IComponentData
{
    public bool lift;
    public float moveSpeed;
    public float moveAngle;
    public float moveDuration;//frame

}
//public struct Movement : IComponentData
//{
  
//}