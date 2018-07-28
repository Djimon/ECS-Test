using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[Serializable]
public struct HealthComponent : IComponentData  
{
    public float Health { get; set; }
    public float MaxHealth { get; set; }
    public float DamageReceived { get; set; }
}
