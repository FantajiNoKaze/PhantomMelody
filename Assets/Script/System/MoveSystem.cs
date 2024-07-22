using Unity.Entities;
using Unity.Transforms;

public partial class MoveSystem : SystemBase
{

    protected override void OnUpdate()
    {

        foreach ((RefRW<TransformData> transform, RefRO<MoveData> moveData) in SystemAPI.Query<RefRW<TransformData>, RefRO<MoveData>>())
        {

            if (moveData.ValueRO.direction.HasFlag(Direction.Forward))
            {
                transform.ValueRW.position.x += moveData.ValueRO.moveSpeed* SystemAPI.Time.DeltaTime;
         
            }
            if (moveData.ValueRO.direction.HasFlag(Direction.Backward))
            {
                transform.ValueRW.position.x -= moveData.ValueRO.moveSpeed * SystemAPI.Time.DeltaTime;
            }
        }
    }
}
