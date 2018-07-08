using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
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
