using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCollider : MonoBehaviour {


    private PlaceObject Placer;
    private bool snapON = false;

    private Vector3 baseSize;
    // Use this for initialization
    void Start ()
    {
        Placer = FindObjectOfType<PlaceObject>();
        if (Placer == null)
            Debug.LogWarning("no Placer found!");
        baseSize = transform.parent.GetComponent<Collider>().bounds.size;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void DeactivateSnapping()
    {
        snapON = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (snapON)
        {
            //Debug.Log("Collision with " + other.name);

            Ground G = other.GetComponentInParent<Ground>();
            
            if (G!=null && Placer.isPlacing && other.tag == "Building" && !G.isSnapped)
            {
                float offset = other.transform.parent.GetComponent<Collider>().bounds.size.y / 2;
                G.mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

                switch (transform.tag)
                {
                    case "West":
                        other.transform.parent.position = new Vector3(transform.parent.position.x, offset, transform.position.z - baseSize.z);
                        break;
                    case "North": 
                        other.transform.parent.position = new Vector3(transform.parent.position.x - baseSize.x, offset, transform.position.z);
                        break;
                    case "East":
                        other.transform.parent.position = new Vector3(transform.parent.position.x, offset, transform.position.z + baseSize.z);
                        break;
                    case "South":
                        other.transform.parent.position = new Vector3(transform.parent.position.x + baseSize.x, offset, transform.position.z);
                        break;
                }

                G.isSnapped = true;
            }
        }  
    }
}
