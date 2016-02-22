using UnityEngine;
using System.Collections;

[AddComponentMenu("Entities/Stats")]

public class EntityStats : MonoBehaviour {

    public bool contextable = true;
    public bool inspected = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InspectObject() {
        Debug.Log("Inspected the object");
        inspected = true;
    }

    public int GetNumberOfContextOptions() {
        return 4;
    }
}
