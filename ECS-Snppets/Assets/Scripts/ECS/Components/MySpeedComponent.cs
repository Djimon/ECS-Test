using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct MySpeed : IComponentData { public float Value; }
    public class MySpeedComponent : ComponentDataWrapper<MySpeed> { };
}
