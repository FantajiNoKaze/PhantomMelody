

using Unity.Entities;
using UnityEngine;


public partial class ControllerSwitchingSystem : SystemBase
{

    protected override void OnUpdate()
    {

        foreach ((RefRO<Controller> controller, RefRW<MoveData> moveData) in SystemAPI.Query<RefRO<Controller>, RefRW<MoveData>>())
        {

        
        }
    }
}

