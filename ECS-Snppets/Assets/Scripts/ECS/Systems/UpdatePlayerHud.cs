using ECS;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

[AlwaysUpdateSystem]
public class UpdatePlayerHud : ComponentSystem
{
    public struct PlayerData
    {
        public readonly int Length;
        public EntityArray Entities;
        //public ComponentArray<PlaerInput> Input;
        public ComponentArray<Health> Health;
    }
    [Inject] PlayerData m_Players;

    private int m_CachedHealth = Int32.MinValue;
    public Button NewGame;
    public Text HealthText;

    public void SetupGameObjects()
    {
        NewGame = GameObject.Find("btnNewGame").GetComponent<Button>();
        HealthText = GameObject.Find("HealthText").GetComponent<Text>();
        NewGame.onClick.AddListener(Bootstrap.NewGame);
    }

    protected override void OnUpdate()
    {
        if(m_Players.Length > 0)
        {
            UpdateAlive();
        }
        else
        {
            UpdateDead();
        }
    }

    private void UpdateDead()
    {
        if(HealthText != null)
        {
            HealthText.gameObject.SetActive(false);
        }
        if (NewGame != null)
        {
            NewGame.gameObject.SetActive(true);
        }
    }

    private void UpdateAlive()
    {
        HealthText.gameObject.SetActive(true);
        NewGame.gameObject.SetActive(false);

        int displayHealth = (int)m_Players.Health[0].Value;

        if(m_CachedHealth != displayHealth)
        {
            HealthText.text = $"Health: {displayHealth}";
            m_CachedHealth = displayHealth;
        }
    }
}
