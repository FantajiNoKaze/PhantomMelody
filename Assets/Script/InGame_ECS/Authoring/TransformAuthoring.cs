using UnityEngine;
using Unity.Entities;

public class TransformAuthoring : MonoBehaviour
{

    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public Vector3 past_position;
    public Vector3 past_rotation;
    public Vector3 past_scale;
    public float fixedDeltaTime;

    void Start()
    {
        position = this.transform.localPosition;
        rotation = new Vector3(0, 0, 0);//看到幫改，我不知用啥;
        scale = this.transform.localScale;
    }

    private class Baker : Baker<TransformAuthoring>
    {
        public override void Bake(TransformAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new TransformData
            {
                position = authoring.position,
                rotation = authoring.rotation,
                scale = authoring.scale,
                past_position = authoring.past_position,
                past_rotation = authoring.past_rotation,
                past_scale = authoring.past_scale,
                fixedDeltaTime = authoring.fixedDeltaTime,

            });

        }


    }
}