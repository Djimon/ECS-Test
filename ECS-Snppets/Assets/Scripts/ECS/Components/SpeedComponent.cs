using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct Speed : IComponentData { public float Value; }
    public class SpeedComponent : ComponentDataWrapper<Speed> { };
}
