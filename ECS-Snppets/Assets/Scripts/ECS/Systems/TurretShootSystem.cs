using ECS;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TurretShootSystem : ComponentSystem
{
    public struct Data
    {
        public readonly int Length;
        public ComponentArray<Position3D> Position;
        public ComponentArray<Turret> Turret;
        public ComponentArray<TurretShootState> ShootState;
    }
    [Inject] private Data m_Data;

    public struct EnemyData
    {
        public readonly int Length;
        public ComponentArray<Position3D> Position;
    }
    [Inject] private EnemyData m_Enemy;

    protected override void OnUpdate()
    {
        if (m_Enemy.Length == 0)
            return;
        float dt = Time.deltaTime;
        float shootRate = Bootstrap.Settings.turretShootRate; //may look for different shootrates per turrettype

        var ProjectileSpawndata = new List<ProjectileSpawnData>();

        for (int i = 0; i < m_Data.Length; i++)
        {
            var EnemyPos = FindNearestEnemy(m_Data.Position[i].Value, m_Data.Turret[i].Range);
            

            var state = m_Data.ShootState[i];
            state.Cooldown -= dt;
            if (state.Cooldown <= 0.0f)
            {
                state.Cooldown = shootRate;
                var pos = m_Data.Position[i].Value;

                ProjectileSpawnData spawn = new ProjectileSpawnData()
                {
                    Position = pos,
                    Heading = math.normalize(EnemyPos - pos),
                    Type = m_Data.Turret[i].turretType
                };

                ProjectileSpawndata.Add(spawn);
            }
        }

        foreach (var spawn in ProjectileSpawndata)
        {
            ProjectileSpawnSystem.SpawnProjectile(spawn);
        }
    }

    private float3 FindNearestEnemy(float3 pos, float range)
    {
        // suche nach Enemy im radius

        return new float3(0,0,0);
    }
}
