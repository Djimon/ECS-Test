﻿using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace ECS
{
    
    public class HealthSystem : JobComponentSystem
    {
        [BurstCompile]
        struct HealthJob : IJobProcessComponentData<MyHealth>
        {
            // define public variables to get from outside (e.g. deltaTime
            public void Execute(ref MyHealth health)
            {
                int h = health.Value;
                // do Stuff with health
                health.Value = h;
            }
        }

    }

}
