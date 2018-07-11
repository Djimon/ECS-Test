using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct MyRotation : IComponentData { public Quaternion Value; }
    public class MyRotationComponent : ComponentDataWrapper<MyRotation> { };
}
