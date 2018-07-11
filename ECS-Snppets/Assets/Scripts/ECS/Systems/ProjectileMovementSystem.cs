using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace ECS
{

    public class PrjectileMovementSystem : JobComponentSystem
    {
        [BurstCompile]
        struct ProjectileMoveJob : IJobProcessComponentData <MyProjectile, MyPosition, MyRotation>
        {
            // define public variables to get from outside (e.g. deltaTime
            public float deltaTime;

            public void Execute([ReadOnly]ref MyProjectile proj, ref MyPosition pos, [ReadOnly]ref MyRotation rot)
            {
                float3 position = pos.Value;
                float lifeTimeTick = GameManager.LifeTimeTick;
                position += deltaTime * GameManager.ProjectileSpeed * math.forward(rot.Value);
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            ProjectileMoveJob PMJ = new ProjectileMoveJob { deltaTime = Time.deltaTime };
            JobHandle moveHandle = PMJ.Schedule(this, 64, inputDeps); //64 for low performance, for high cost calculation lower tihs number
            return moveHandle;
        }

    }

}

