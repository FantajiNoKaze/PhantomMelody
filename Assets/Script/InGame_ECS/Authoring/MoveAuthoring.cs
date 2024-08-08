using UnityEngine;
using Unity.Entities;

public class MoveAuthoring : MonoBehaviour
{

    public Direction direction;
    public float moveSpeed = 1;
    private class Baker : Baker<MoveAuthoring>
    {
        public override void Bake(MoveAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new MoveData
            {
                direction = authoring.direction,
                moveSpeed = authoring.moveSpeed
            });

        }


    }
}