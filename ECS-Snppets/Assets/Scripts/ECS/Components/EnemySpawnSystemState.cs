using System;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    public class EnemySpawnSystemState : MonoBehaviour
    {
        public int SpawnedEnemyCount;
        public float Cooldown;
        public UnityEngine.Random.State RandomState;
    }
}
