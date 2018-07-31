using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;


public struct Turret : IComponentData { }

public struct Enemy : IComponentData { }

public struct FirstSteps : IComponentData { }

public struct Player : IComponentData { }

public struct PlayerInput : IComponentData { public float2 Move; }

public struct Die : IComponentData { }