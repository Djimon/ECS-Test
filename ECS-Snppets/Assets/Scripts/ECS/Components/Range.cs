using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct Range : IComponentData { public float Value; }
    public class RangeComponent : ComponentDataWrapper<Range> { } // make visible in Editor
}
