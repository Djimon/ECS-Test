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

    public class Projectile : MonoBehaviour
    {
        public float TimeToLive;
        public float Energy;
        public ProjectileType Type;
    }
}

