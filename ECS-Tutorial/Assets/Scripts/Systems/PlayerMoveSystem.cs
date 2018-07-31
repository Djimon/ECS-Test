using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerMoveSystem : ComponentSystem
{
    private Transform cameraTransform;
    private Camera mainCam;

    public void FindCameraTransform()
    {
        if (mainCam == null)
        {
            mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
            Debug.Log("Camera: " + mainCam.name + " @ " + mainCam.transform.position);
        }
    }

    public struct PlayerMoveData
    {
        public ComponentDataArray<Position> Positions;
        public ComponentDataArray<Player> Players;
        //public ComponentDataArray<PlayerInput> Inputs;
        public readonly int Length;
    }
    [Inject] PlayerMoveData player;


    protected override void OnUpdate()
    {
        //for (int i = 0; i < player.Length; i++)
        //{
        //    var pos = player.Positions[i];
        //    //var input = player.Inputs[i];

        //    //pos = new Position(new float3(-Input.mousePosition.x, 0, Input.mousePosition.z));
        //    Vector3 vecpos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //    pos = new Position(new float3(vecpos.x, 5, vecpos.z));

        //    player.Positions[i] = pos;
        //}
    }
}
