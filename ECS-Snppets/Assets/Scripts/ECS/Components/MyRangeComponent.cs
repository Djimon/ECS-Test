using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct MyRange : IComponentData { public float Value; }
    public class MyRangeComponent : ComponentDataWrapper<MyRange> { } // make visible in Editor
}
