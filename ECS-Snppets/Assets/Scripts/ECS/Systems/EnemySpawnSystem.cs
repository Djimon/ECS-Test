using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using ECS;
using System;
using Unity.Mathematics;

public class EnemySpawnSystem : ComponentSystem
{
    public struct State
    {
        public readonly int Length;
        /// <summary> 
        /// [SpawnedEnemyCount(int), Cooldown(float), RandomState]
        /// </summary>
        public ComponentArray<EnemySpawnSystemState> S;
    }
    [Inject] private State m_State;

    public static void SetupComponentData()
    {
        var oldStatus = UnityEngine.Random.state;
        UnityEngine.Random.InitState(1337);
        var state = Bootstrap.Settings.EnemySpawnState;
        state.Cooldown = 0.0f;
        state.SpawnedEnemyCount = 0;
        state.RandomState = UnityEngine.Random.state;

        UnityEngine.Random.state = oldStatus;
    }

    protected override void OnUpdate()
    {

        foreach(EnemyType et in Bootstrap.Settings.GetEnemyTypes())
        {
            var state = m_State.S[0];
            var oldstate = UnityEngine.Random.state;
            
            state.Cooldown -= Time.deltaTime;

            if (state.Cooldown <= 0.0f)
            {
                var settings = Bootstrap.Settings;
                var enemy = UnityEngine.Object.Instantiate(settings.EnemyPrefab);
                SetSpawnLocation(enemy);
                state.SpawnedEnemyCount++;
                state.Cooldown = ComputeCooldown(state.SpawnedEnemyCount, et);
                Debug.Log("cd = " + state.Cooldown);
            }
        }
    }

    private float ComputeCooldown(int spawnedEnemyCount, EnemyType type)
    {
        //TODO: use EnemyType later for more variation

        if (spawnedEnemyCount >= 20)
        {
            return 30f;
        }
        return 1f;
    }

    private void SetSpawnLocation(GameObject enemy)
    {
        var settings = Bootstrap.Settings;
        enemy.GetComponent<Position3D>().Value = Bootstrap.Settings.EnemySpawnPosition;
        enemy.GetComponent<Heading3D>().Value = new float3(100, 0, -10);
        enemy.GetComponent<MovingSpeed>().Value = Bootstrap.Settings.enemySpeed;
    }
}
