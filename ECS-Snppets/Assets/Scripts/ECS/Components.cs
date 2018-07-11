using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace ECS
{
    [Serializable]
    public struct Damage : IComponentData { public int Value; }
    public class DamageComponent : ComponentDataWrapper<Damage> { };

    [Serializable]
    public struct Frequence : IComponentData { public float Value; }
    public class FrequenceComponent : ComponentDataWrapper<Frequence> { };

    [Serializable]
    public struct Health : IComponentData { public int Value; }
    public class HealthComponent : ComponentDataWrapper<Health> { };

    [Serializable]
    public struct Lifetime : IComponentData { public float Value; }
    public class LifetimeComponent : ComponentDataWrapper<Lifetime> { };

    [Serializable]
    public struct Position : IComponentData { public float3 Value; }
    public class PositionComponent : ComponentDataWrapper<Position> { };

    [Serializable]
    public struct Price : IComponentData { public int Value; }
    public class PriceComponent : ComponentDataWrapper<Price> { };

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
    public struct Projectile : IComponentData
    {
        public int ID;
        public ProjectileType turretType;
    }
    public class ProjectileComponent : ComponentDataWrapper<Projectile> { };

    [Serializable]
    public struct Range : IComponentData { public float Value; }
    public class RangeComponent : ComponentDataWrapper<Range> { } // make visible in Editor

    [Serializable]
    public struct Rotation : IComponentData { public Quaternion Value; }
    public class RotationComponent : ComponentDataWrapper<Rotation> { };

    [Serializable]
    public struct Speed : IComponentData { public float Value; }
    public class SpeedComponent : ComponentDataWrapper<Speed> { };

    public enum TurretType
    {
        none = -1,
        Normal,
        Slow,
        AoE,
        Air
    }
    [Serializable]
    public struct Turret : IComponentData
    {
        public int ID;
        public TurretType turretType;
        [Range(1, 3)]
        public int Level;
    }
    public class TurretComponent : ComponentDataWrapper<Turret> { };

}
