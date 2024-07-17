
using Unity.Entities;
using UnityEngine;



public class MovementSetManager : MonoBehaviour
{

    private void Start()
    {
      MoveSystem moveSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<MoveSystem>();
      moveSystem.OnMove += Set_Movement;

    }
    private void Set_Movement(object sender,System.EventArgs e)
    {
        Entity playerEntity = (Entity)sender;
        MovementTaskData movementTaskData = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<MovementTaskData>(playerEntity);
        DynamicBuffer<MovementTask> movementTasks = World.DefaultGameObjectInjectionWorld.EntityManager.GetBuffer<MovementTask>(playerEntity);
        for (int i = 0; i < movementTasks.Length; i++)
        {
            MovementTask movement = movementTasks[i];
            if (!movement.lift)
            {
                movement.lift = movementTaskData.lift;
                movement.moveSpeed = movementTaskData.moveSpeed;
                movement.moveAngle = movementTaskData.moveAngle;
                movement.moveDuration = movementTaskData.moveDuration;
                break;
            }
        }

    }
}
