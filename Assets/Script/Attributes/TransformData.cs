using Unity.Entities;
using UnityEngine;
public struct TransformData : IComponentData
{
    
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public Vector3 past_position;
    public Vector3 past_rotation;
    public Vector3 past_scale;
    public float fixedDeltaTime;//elapsed
   

}
