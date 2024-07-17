using UnityEngine;
using Unity.Entities;

public class MovementTaskAuthoring : MonoBehaviour
{
    public bool lift;
    public float moveSpeed;
    public float moveAngle;
    public float moveDuration;//frame

    private class Baker : Baker<MovementTaskAuthoring>
    {
        public override void Bake(MovementTaskAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new MovementTaskData
            {
                lift = authoring.lift,
                moveSpeed = authoring.moveSpeed,
                moveAngle = authoring.moveAngle,
                moveDuration = authoring.moveDuration
            });

        }


    }
}