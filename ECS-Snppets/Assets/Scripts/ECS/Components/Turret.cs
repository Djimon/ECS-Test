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

    public class Turret : MonoBehaviour
    {
        public int ID;
        public TurretType turretType;
        public float Range;
    }
}
