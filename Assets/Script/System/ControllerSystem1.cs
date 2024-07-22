
using Unity.Entities;
using UnityEngine;


public partial struct ControllerSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach (RefRW<Controller> controller in SystemAPI.Query<RefRW<Controller>>())
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                controller.ValueRW.inputSignal &= InputSignal.Right;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                controller.ValueRW.inputSignal ^= InputSignal.Right;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                controller.ValueRW.inputSignal &= InputSignal.Left;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                controller.ValueRW.inputSignal ^= InputSignal.Left;
            }

        }
    }

}
