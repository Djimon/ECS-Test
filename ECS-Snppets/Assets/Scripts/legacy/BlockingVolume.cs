using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingVolume : MonoBehaviour {

	public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            Debug.Log("Collider " + other.name);
            try { other.GetComponentInChildren<Ground>().isPlaceable = false; }
            catch (Exception e) { }
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            Debug.Log("Collider " + other.name);
            try { other.GetComponentInChildren<Ground>().isPlaceable = true; }
            catch (Exception e) { }
        }
    }
}
