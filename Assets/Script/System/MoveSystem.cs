
using System;
using Unity.Entities;
using UnityEngine.EventSystems;

public partial class MoveSystem : SystemBase
{
    public event EventHandler OnMove;

    protected override void OnUpdate()
    {
        foreach ((RefRO<Controller> Controller, RefRW<MovementTaskData> movementTaskData, Entity entity) in SystemAPI.Query<RefRO<Controller>, RefRW<MovementTaskData>>().WithEntityAccess())
        {
            if (Controller.ValueRO.inputSignal.HasFlag(InputSignal.Up))
            {
                movementTaskData.ValueRW.lift = true;
                movementTaskData.ValueRW.moveSpeed = 1;
                movementTaskData.ValueRW.moveAngle = 90;
                movementTaskData.ValueRW.moveDuration = 1;
                OnMove?.Invoke(entity, EventArgs.Empty);
            }

        }
    }
}
