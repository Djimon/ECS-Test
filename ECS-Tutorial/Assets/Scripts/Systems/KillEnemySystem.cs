using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;

public class KillEnemySystem : ComponentSystem
{

    public Text scoreText;
    private int score = 0;

    public void SetUI()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    public struct EnemyData
    {
        public ComponentDataArray<HealthComponent> Healths;
        public ComponentDataArray<Enemy> Enemies;
        public EntityArray entityArray;

        public readonly int Length;
    }
    [Inject] EnemyData enemies;

    protected override void OnUpdate()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies.Healths[i].Health <= 0)
            {
                PostUpdateCommands.DestroyEntity(enemies.entityArray[i]);

                if (scoreText != null)
                {
                    score++;
                    scoreText.text = score.ToString();
                }
            }
        }


    }

}
