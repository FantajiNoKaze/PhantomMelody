using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


public partial class RenderingSystem : SystemBase
{

    protected override void OnUpdate()
    {

        foreach ((RefRW<TransformData> transformData, RefRW<LocalTransform> localTransform) in SystemAPI.Query<RefRW<TransformData>, RefRW<LocalTransform>>())
        {
            transformData.ValueRW.fixedDeltaTime += SystemAPI.Time.DeltaTime;
            float e = transformData.ValueRW.fixedDeltaTime;
            float x = Math.Abs(transformData.ValueRO.position.x - transformData.ValueRO.past_position.x);
            float t = e/x;
            t = math.clamp(t, 0f, 1f);
            localTransform.ValueRW.Position.x = math.lerp(transformData.ValueRO.past_position.x,transformData.ValueRO.position.x,t);
        }
    }


}
