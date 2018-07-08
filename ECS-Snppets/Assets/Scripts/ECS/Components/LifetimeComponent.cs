using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct Lifetime : IComponentData { public float Value; }
    public class LifetimeComponent : ComponentDataWrapper<Lifetime> { };
}
