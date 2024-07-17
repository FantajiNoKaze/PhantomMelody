

using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;


public partial struct MovementSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach (var (localTransform, movementTasks) in SystemAPI.Query<RefRW<LocalTransform>, DynamicBuffer<MovementTask>>())
        {

            LocalTransform transform = localTransform.ValueRW;

            foreach (var task in movementTasks)
            {
                if(task.lift){
                     transform.Position += Move(task.moveSpeed, task.moveAngle);   
                   
                }
                  
            }
            localTransform.ValueRW = transform;
        }
    }
    float3 Move(float speed,float angle)
    {
        float radians = angle * Mathf.Deg2Rad;
        float moveX = Mathf.Cos(radians) * speed * Time.deltaTime;
        float moveY = Mathf.Sin(radians) * speed * Time.deltaTime;
        return new float3(moveX, moveY, 0);
    }
}
