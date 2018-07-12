using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace ECS
{
    [SerializeField]
    public struct MoveSpeed : IComponentData {public float Value; }
    public class MoveSpeedComponent : ComponentDataWrapper<MoveSpeed>{ };
}
