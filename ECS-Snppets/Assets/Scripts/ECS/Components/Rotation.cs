using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct Rotation : IComponentData { public Quaternion Value; }
    public class RotationComponent : ComponentDataWrapper<Rotation> { };
}
