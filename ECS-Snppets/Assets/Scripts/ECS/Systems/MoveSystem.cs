using ECS;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class MoveSystem : ComponentSystem {

    struct Data
    {
        public Position3D Position;
        public Heading3D Heading;
        public MovingSpeed MoveSpeed;
    }

    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;
        Debug.Log("movesystem @ "+dt+"s");
        foreach(var entity in GetEntities<Data>())
        {
            Debug.Log(".." + entity.Position + " + " + entity.MoveSpeed + " -> " + entity.Heading);
            var pos = entity.Position;
            pos.Value += entity.Heading.Value * entity.MoveSpeed.Value * dt;
        }
    }

}
