using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;
public class ControllerAuthoring : MonoBehaviour
{
    public InputSignal inputSignal = new();

    private class Baker : Baker<ControllerAuthoring>
    {
        public override void Bake(ControllerAuthoring authoring)
        {

            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new Controller
            {
               inputSignal = authoring.inputSignal
            });
        }


    }
}