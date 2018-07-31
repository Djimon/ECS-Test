using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class xInitEnemyPositionSystem : ComponentSystem {

    private bool isFirstTime = true;
    private float offset = 8f;

    public struct EnemyPosData
    {
        public ComponentDataArray<Enemy> Enemies;
        public ComponentDataArray<Position> Positions;
        public readonly int Length;
    }
    [Inject] EnemyPosData StartEnemies;

    protected override void OnUpdate()
    {
        if (isFirstTime)
        {
            for (int i=0; i< StartEnemies.Length; i++)
            {
                var coeff = (360 / (StartEnemies.Length % 359 + 0.0001f)) * i / 57.3f; //Vodoo-Magic
                var positions = StartEnemies.Positions[i];

                positions.Value = new float3(math.cos(coeff) * offset, 5, math.sin(coeff) * offset);

                StartEnemies.Positions[i] = positions;
                Debug.Log("Enemy placed @ " + positions.Value);
            }   
        }

        isFirstTime = false;
    }
}
