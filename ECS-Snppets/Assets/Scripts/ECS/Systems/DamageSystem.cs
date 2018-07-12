using ECS;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class DamageSystem : ComponentSystem
{
    public struct ReceiverData
    {
        public readonly int Length;
        public ComponentArray<Health> Health;
        public ComponentArray<Position3D> Position;
        public ComponentArray<Mother> Mother;
    }

    [Inject] ReceiverData m_Receivers;

    public struct ShotData
    {
        public readonly int Length;
        public ComponentArray<Projectile> Shot;
        public ComponentArray<Position3D> Position;
        public ComponentArray<Mother> Mother;
    }
    [Inject] ShotData m_Shots;

    protected override void OnUpdate()
    {
        if (0 == m_Receivers.Length || 0 == m_Shots.Length)
            return;

        var settings = Bootstrap.Settings;

        for (int pi = 0; pi < m_Receivers.Length; ++pi)
        {
            float damage = 0.0f;
            float collisionRadius = settings.enemyCollisionRadius;
            float collisionRadiusSquared = collisionRadius * collisionRadius;

            float3 receiverPos = m_Receivers.Position[pi].Value;
            Mother.Type receiversMother = m_Receivers.Mother[pi].Value;

            for (int si = 0; si < m_Shots.Length; ++si)
            {
                if (m_Shots.Mother[si].Value != receiversMother)
                {
                    float3 shotPos = m_Shots.Position[si].Value;
                    float3 delta = shotPos - receiverPos;
                    float distSquared = math.dot(delta, delta);
                    if (distSquared <= collisionRadiusSquared)
                    {
                        var shot = m_Shots.Shot[si];
                        damage += shot.Energy;
                        // Set the shot's time to live to zero, so it will be collected by the shot destroy system
                        shot.TimeToLive = 0.0f;
                    }
                }
            }

            var h = m_Receivers.Health[pi];
            h.Value = math.max(h.Value - damage, 0.0f);
        }
    }
}
