using ECS;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[UpdateAfter(typeof(ProjectileSpawnSystem))]
[UpdateAfter(typeof(MoveSystem))]
public class ShotDestroySystem : ComponentSystem
{
    struct Data
    {
        public Projectile Projectile;
    }

    protected override void OnUpdate()
    {
        float dt = Time.deltaTime;

        var toDestroy = new List<GameObject>();
        foreach (var entity in GetEntities<Data>())
        {
            var s = entity.Projectile;
            s.TimeToLive -= dt;
            if (s.TimeToLive <= 0.0f )
            {
                toDestroy.Add(s.gameObject);
            }
        }

        foreach (var go in toDestroy)
        {
            Object.Destroy(go);
        }
    }
}