using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Events;

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
public partial class PositionRenderingSystem : SystemBase
{


    protected override void OnUpdate()
    {

        foreach (RefRW<TransformData> transformData in SystemAPI.Query<RefRW<TransformData>>())
        {
            transformData.ValueRW.past_position = new Vector3(transformData.ValueRO.position.x, transformData.ValueRO.position.y, transformData.ValueRO.position.z);
            transformData.ValueRW.past_rotation = transformData.ValueRO.rotation;
            transformData.ValueRW.past_scale = transformData.ValueRO.scale;
            transformData.ValueRW.fixedDeltaTime = 0;
        }
    }


}
