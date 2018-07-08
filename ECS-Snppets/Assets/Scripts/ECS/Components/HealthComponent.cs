using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct Health : IComponentData { public int Value; }
    public class HealthComponent : ComponentDataWrapper<Health> { };
}
