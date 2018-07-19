using ECS;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Bootstrap
{
    public static Settings Settings;

    public static void NewGame()
    {
        var player = UnityEngine.Object.Instantiate(Settings.PlayerPrefab);
        player.GetComponent<Position3D>().Value = new float3(0, 0, 0);
        player.GetComponent<Heading3D>().Value = new float3(0, 0, 1);
    }
	
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitAfterSceneLoad()
    {
        var SettingObject = GameObject.Find("Settings");
        if (SettingObject == null)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            return;
        }

        InitWithScene();
    }

    private static void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        InitWithScene();
    }

    public static void InitWithScene()
    {
        var SettingObject = GameObject.Find("Settings");
        Settings = SettingObject?.GetComponent<Settings>();
        if (!Settings)
            return;

        EnemySpawnSystem.SetupComponentData();

        World.Active.GetOrCreateManager<UpdatePlayerHud>().SetupGameObjects();
    }
}
