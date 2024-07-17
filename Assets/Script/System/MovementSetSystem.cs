
using Unity.Entities;



public partial struct MovementSetSystem : ISystem
{
    public void OnClick(ref SystemState state)
    {

        foreach (var (movementTaskData, movementTasks) in SystemAPI.Query<RefRO<MovementTaskData>, DynamicBuffer<MovementTask>>())
        {
            for (int i = 0; i < movementTasks.Length; i++)
            {
                MovementTask movement = movementTasks[i];
                if (!movement.lift)
                {
                    movement.lift = movementTaskData.ValueRO.lift;
                    movement.moveSpeed = movementTaskData.ValueRO.moveSpeed;
                    movement.moveAngle = movementTaskData.ValueRO.moveAngle;
                    movement.moveDuration = movementTaskData.ValueRO.moveDuration;   
                    break;
                }
            }

        }

    }
}
