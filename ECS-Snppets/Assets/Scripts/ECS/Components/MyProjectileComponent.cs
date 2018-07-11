using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    public enum ProjectileType
    {
        none = -1,
        Normal,
        Fire,
        Poison,
        Ice,
        Magic
    }

    [Serializable]
    public struct MyProjectile : IComponentData
    {
        public int ID;
        public ProjectileType turretType;
    }
    public class MyProjectileComponent : ComponentDataWrapper<MyProjectile> { };
}

