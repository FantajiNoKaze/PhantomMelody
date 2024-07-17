
using Unity.Entities;
using UnityEngine;


public partial struct ControllerSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        foreach (var controller in SystemAPI.Query<RefRW<Controller>>())
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                controller.ValueRW.inputSignal &= InputSignal.Up;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                controller.ValueRW.inputSignal ^= InputSignal.Up;
            }

        }
    }

}
