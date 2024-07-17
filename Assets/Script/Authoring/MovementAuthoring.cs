using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;
public class MovementAuthoring : MonoBehaviour
{
    public List<MovementTask> movementList = new();

    private class Baker : Baker<MovementAuthoring>
    {
        public override void Bake(MovementAuthoring authoring)
        {

            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            DynamicBuffer<MovementTask> buffer = AddBuffer<MovementTask>(entity);
            foreach (var task in authoring.movementList)
            {
                buffer.Add(task);
            }

        }


    }
}