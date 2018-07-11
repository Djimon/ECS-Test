using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct MyFrequence : IComponentData { public float Value; }
    public class MyFrequenceComponent : ComponentDataWrapper<MyFrequence> { };

}
