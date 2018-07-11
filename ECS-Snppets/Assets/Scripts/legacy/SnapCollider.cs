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
            Debug.Log("Collision with " + other.name);

            Ground G = other.GetComponentInParent<Ground>();
            
            if (G!=null && Placer.isPlacing && other.tag == "Building" && !G.isSnapped)
            {
                float offset = other.transform.parent.GetComponent<Collider>().bounds.size.y / 2;
                G.mousePos = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

                switch (transform.tag)
                {
                    case "West": Vector3 n1 = new Vector3(transform.parent.position.x, offset, transform.position.z - baseSize.z);
                        Debug.Log("West: " + other.transform.parent.position + " -> " + n1);
                        other.transform.parent.position = n1;
                        break;
                    case "North": Vector3 n2 = new Vector3(transform.parent.position.x - baseSize.x, offset, transform.position.z);
                        Debug.Log("North: " + other.transform.parent.position + " -> " + n2);
                        other.transform.parent.position = n2;
                        break;
                    case "East": Vector3 n3 = new Vector3(transform.parent.position.x, offset, transform.position.z + baseSize.z);
                        Debug.Log("East: " + other.transform.parent.position + " -> " + n3);
                        other.transform.parent.position = n3;
                        break;
                    case "South": Vector3 n4 = new Vector3(transform.parent.position.x + baseSize.x, offset, transform.position.z);
                        Debug.Log("South: " + other.transform.parent.position + " -> " + n4);
                        other.transform.parent.position = n4;
                        break;
                }

                G.isSnapped = true;
            }
        }  
    }
}
