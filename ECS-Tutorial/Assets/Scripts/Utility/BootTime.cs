using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using System;

public class NewBehaviourScript {

    static SkinnedMeshRenderer playerLookSM; //when using animations alter
    static MeshInstanceRenderer playerLookMI;
    static SkinnedMeshRenderer EnemyLookSM; //when using animations alter
    static MeshInstanceRenderer EnemyLookMI;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Init()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();

        var playerArchetype = entityManager.CreateArchetype(typeof(Player), typeof(Rigidbody), typeof(TransformMatrix), typeof(Position), typeof(Rotation), typeof(FirstSteps));

        var enemyArchetype = entityManager.CreateArchetype(typeof(Enemy), typeof(Rigidbody), typeof(TransformMatrix), typeof(Position), typeof(Rotation), typeof(HealthComponent));

        //playerLookSM = GetLookFromPrototypeSM("PlayerLook"); //for alter when using animations
        playerLookMI = GetLookFromPrototypeMI("PlayerLook");
        EnemyLookMI = GetLookFromPrototypeMI("EnemyLook"); // do this later for every Enemy-type


        var player = entityManager.CreateEntity(playerArchetype);
        entityManager.AddSharedComponentData(player, playerLookMI);

        HealthComponent standartEnemy = new HealthComponent(50);

        for (int i = 0; i < 5; i++)
        {
            var enem = entityManager.CreateEntity(enemyArchetype);
            entityManager.AddSharedComponentData(enem, EnemyLookMI);
            entityManager.SetComponentData<HealthComponent>(enem, standartEnemy);
        }


        World.Active.GetOrCreateManager<KillEnemySystem>().SetUI();
        World.Active.GetOrCreateManager<PlayerMoveSystem>().FindCameraTransform();
    }

    private static SkinnedMeshRenderer GetLookFromPrototypeSM(string ProtoName)
    {
        var proto = GameObject.Find(ProtoName);
        Debug.Log(proto.name + " SkinnedMesh");
        var result = proto.GetComponent<SkinnedMeshRenderer>();
        UnityEngine.Object.Destroy(proto);
        return result;
    }

    private static MeshInstanceRenderer GetLookFromPrototypeMI(string protoName)
    {
        var proto = GameObject.Find(protoName);
        Debug.Log(proto.name + " MeshInstance");
        var result = proto.GetComponent<MeshInstanceRendererComponent>().Value;
        UnityEngine.Object.Destroy(proto);
        return result;
    }
}
