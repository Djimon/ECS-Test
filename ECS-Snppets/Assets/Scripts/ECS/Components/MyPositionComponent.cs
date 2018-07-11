using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct MyPosition : IComponentData
    {
        public float3 Value;
    }
    public class MyPositionComponent : ComponentDataWrapper<MyPosition> { };
}
