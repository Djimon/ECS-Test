using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct Price : IComponentData { public int Value; }
    public class PriceComponent : ComponentDataWrapper<Price> { };
}
