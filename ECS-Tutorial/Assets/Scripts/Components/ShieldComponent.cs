using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct ShieldComponent : IComponentData
{
    public float Energy { get; set; }
    public float ReloadTime { get; set; }
}
