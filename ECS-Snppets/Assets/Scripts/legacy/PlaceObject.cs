using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour {

    [SerializeField]
    private GameObject placeableObjetPrefab;

    [SerializeField]
    private KeyCode newObjectkey = KeyCode.N;

    private GameObject currentObject;
    private Ground currentGround;
    private float positionCorrection;
    private Color resetColor;
    private Color forbidColor = Color.red;

    //[HideInInspector]
    public bool isPlacing;

	// Update is called once per frame
	private void Update ()
    {
        HandleNewObjectKey();

        if (currentObject != null)
        {
            MoveObjectwithMouse();
            ReleaseIfClicked();
        }
	}

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentGround.isPlaceable)
            {
                Color c = currentObject.GetComponent<Renderer>().material.color;
                currentObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, 1f);
                currentGround.Place();
                currentObject = null;
                isPlacing = false;
            }
            else
            {
                currentObject.GetComponent<Renderer>().material.color = new Color(1,0,0,resetColor.a);
            }
            
        }
    }

    private void MoveObjectwithMouse()
    {
        if (!currentGround.isPlaceable)
            currentObject.GetComponent<Renderer>().material.color = new Color(1,0,0,resetColor.a);
        else
            currentObject.GetComponent<Renderer>().material.color = resetColor;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;        

        if (Physics.Raycast(ray, out hit) && !currentGround.isSnapped)
        {
            currentObject.transform.position = new Vector3(hit.point.x, positionCorrection, hit.point.z);

            //Objekt lehnt sich an schrägen an
            currentObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }

    }

    private void HandleNewObjectKey()
    {
        if (Input.GetKeyDown(newObjectkey))
        {
            ObjectPlacing(placeableObjetPrefab);
        }
        

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(currentObject);
            isPlacing = false;
        }
    }

    public void ObjectPlacing(GameObject prefab)
    {
        if (currentObject == null)
        {
            isPlacing = true;
            currentObject = Instantiate(prefab);
            resetColor = currentObject.GetComponent<Renderer>().material.color;
            positionCorrection = currentObject.GetComponent<Collider>().bounds.size.y / 2;
            Color c = currentObject.GetComponent<Renderer>().material.color;
            currentObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, 0.5f);
            currentGround = currentObject.GetComponentInChildren<Ground>();
            currentGround.isPlaceable = true;
        }
    }
}
