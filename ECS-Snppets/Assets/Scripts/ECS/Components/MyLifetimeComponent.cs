using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct MyLifetime : IComponentData { public float Value; }
    public class MyLifetimeComponent : ComponentDataWrapper<MyLifetime> { };
}
