using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct MyPrice : IComponentData { public int Value; }
    public class MyPriceComponent : ComponentDataWrapper<MyPrice> { };
}
