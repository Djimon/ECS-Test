using ECS;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public float playerMoveSpeed = 15.0f;
    public float playerFireCoolDown = 0.1f;
    public float enemySpeed = 5.0f;
    public float turretShootRate = 0.5f;
    public float playerCollisionRadius = 1.0f;
    public float enemyCollisionRadius = 1.0f;
    //public Rect playfield = new Rect { x = -30.0f, y = -30.0f, width = 60.0f, height = 60.0f };

//    public Shot PlayerShotPrefab;
//    public Shot EnemyShotPrefab;
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    public GameObject ProjectileNormal;
    public GameObject ProjectileSlow;
    public GameObject ProjectileAoE;
    public GameObject ProjectileAir;

    public EnemySpawnSystemState EnemySpawnState;
    public float3 EnemySpawnPosition = new float3(0,0,0);


    public IEnumerable<EnemyType> GetEnemyTypes()
    {
        //ToDO: list all available enemy types
        List<EnemyType> list = new List<EnemyType>();

        list.Add(new EnemyType(0, "standart")); // standart Mob
        // add more types of mob....
        // ...

        return list;
    }
    //    public Faction EnemyFaction;
}
