using ECS;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject TurretPrefab;
    public GameObject ProjectilePrefab;
    public int turretSpawnCount = 3;

    public static float LifeTimeTick { get; internal set; }
    public static float ProjectileSpeed { get; internal set; }
    public EntityManager EntManager { get; private set; }

    
    private int nextTurret = 0;
    // Use this for initialization
    void Start ()
    {
        EntManager = World.Active.GetOrCreateManager<EntityManager>();
        AddTurrets();
	}

    private void AddTurrets()
    {
        NativeArray<Entity> ents = new NativeArray<Entity>(turretSpawnCount, Allocator.Temp);
        EntManager.Instantiate(TurretPrefab, ents);
        for (int i = 0; i < turretSpawnCount; i++)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-10f, 10f);
            EntManager.SetComponentData(ents[i], new MyPosition { Value = new float3(x, y, 0) });
            //EntManager.SetComponentData(ents[i], new Frequence { Value = 3f });
            EntManager.SetComponentData(ents[i], new MyRange { Value = 5f });
            EntManager.SetComponentData(ents[i], new MyTurret { ID = nextTurret, Level = 0, turretType = 0 });
            nextTurret++;
        }
        ents.Dispose();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("pressed F");
            AddTurrets();
        }
            

        JobHandle.ScheduleBatchedJobs();
	}
}
