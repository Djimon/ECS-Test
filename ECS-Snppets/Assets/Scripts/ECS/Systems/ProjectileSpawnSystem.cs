using ECS;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileSpawnData
{
    public float3 Position;
    public float3 Heading;
    public Mother Mother;
    public TurretType Type;
}

public static class ProjectileSpawnSystem
{
    public static void SpawnProjectile(ProjectileSpawnData data)
    {
        var settings = Bootstrap.Settings;
        GameObject Prefab;
        switch(data.Type)
        {
            case TurretType.Normal:
                Prefab = settings.ProjectileNormal;
                break;
            case TurretType.Slow:
                Prefab = settings.ProjectileSlow;
                break;
            case TurretType.AoE:
                Prefab = settings.ProjectileAoE;
                break;
            case TurretType.Air:
                Prefab = settings.ProjectileAir;
                break;
            default: Prefab = null;
                break;
        }

        var newProjectile = Object.Instantiate(Prefab);
        var ProPos = newProjectile.GetComponent<Position3D>();
        ProPos.Value = data.Position;
        var ProHeading = newProjectile.GetComponent<Heading3D>();
        ProHeading.Value = data.Heading;
        var ProMother = newProjectile.GetComponent<Mother>();
        ProMother.Value = data.Mother.Value;
    }

}