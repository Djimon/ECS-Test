using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class HealthSystem : ComponentSystem {

    public struct Group_1
    {
        public ComponentDataArray<HealthComponent> Healths;

        public ComponentArray<Rigidbody> Rigids;

        public EntityArray Entities;
        public GameObjectArray GameObjects;

        public int Length;
    }
    [Inject] private Group_1 g_NoShields;

    public struct Group_2
    {
        public ComponentDataArray<HealthComponent> Healths;
        public ComponentDataArray<ShieldComponent> Shields;

        public ComponentArray<Rigidbody> Rigids;

        public EntityArray Entities;
        public GameObjectArray GameObjects;

        public int Length;
    }
    [Inject] private Group_2 g_HaveShields;

    protected override void OnUpdate()
    {
        for (int i = 0; i != g_NoShields.Length; i++)
        {
            HealthComponent health = g_NoShields.Healths[i];
            health.Health -= health.DamageReceived ;
            health.DamageReceived = 0;
            g_NoShields.Healths[i] = health; 
        }

        for (int i = 0; i != g_HaveShields.Length; i++)
        {
            float shieldTaken = 0;
            HealthComponent health = g_NoShields.Healths[i];
            ShieldComponent shield = g_HaveShields.Shields[i];
            shieldTaken = Mathf.Min(health.DamageReceived, shield.Energy);
            shield.Energy -= shieldTaken;
            health.Health -= (health.DamageReceived - shieldTaken);
            health.DamageReceived = 0;
            g_NoShields.Healths[i] = health;
            g_HaveShields.Shields[i] = shield;
        }

    }

}
