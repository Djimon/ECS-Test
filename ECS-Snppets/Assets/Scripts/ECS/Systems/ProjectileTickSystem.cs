using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace ECS
{

    public class ProjectileDespawnSystem : JobComponentSystem
    {
        [BurstCompile]
        struct ProjectileLifetimeJob : IJobProcessComponentData<MyProjectile, MyLifetime>
        {
            // define public variables to get from outside (e.g. deltaTime
            public float deltaTime;

            public void Execute([ReadOnly]ref MyProjectile proj, ref MyLifetime lifetime)
            {
                float time = lifetime.Value;
                float lifeTimeTick = GameManager.LifeTimeTick;
                time -= lifeTimeTick;
                lifetime.Value = time;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            ProjectileLifetimeJob PMJ = new ProjectileLifetimeJob { deltaTime = Time.deltaTime };
            JobHandle moveHandle = PMJ.Schedule(this, 64, inputDeps); //64 for low performance, for high cost calculation lower tihs number
            return moveHandle;
        }

    }

}
