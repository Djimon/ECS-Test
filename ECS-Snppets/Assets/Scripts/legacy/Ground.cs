using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public bool isSnapped;
    public bool isPlaced;
    public bool isPlaceable;
    private float positionCorrection;

    public Vector2 mousePos;

    private void Update()
    {
        if (isSnapped && !isPlaced && (Mathf.Abs(mousePos.x - Input.GetAxis("Mouse X")) > 0.1f || Mathf.Abs(mousePos.y - Input.GetAxis("Mouse Y")) > 0.1f))
        {
            isSnapped = false;
        }
    }

    public void Place()
    {
        isPlaced = true;
        SnapCollider[] sc = gameObject.GetComponentsInChildren<SnapCollider>();
        for (int i = 0; i < sc.Length; i++)
        {
            sc[i].DeactivateSnapping();
        }
        isSnapped = false;
        isPlaceable = false;
    }

}
