using UnityEngine;
using System.Collections;

[AddComponentMenu("Entities/Stats")]

public class EntityStats : MonoBehaviour {

    // Public
    public bool contextable = true;
    public bool inspected = false;
    public bool seized = false;
    public bool takenEvidence = false;
    public bool disconnected = false;
    public bool poweredOff = false;

	public bool tasked = false;

    public float evidencePoints = 0.0f;

    // Private

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

    public void SeizeObject() {
        Debug.Log("Seized the object");
        seized = true;
    }

    public void TakeObjectEvidence() {
        Debug.Log("Took object evidence");
        takenEvidence = true;
    }

    public void DisconnectFromInternet() {
        Debug.Log("Disconnected device from internet");
        disconnected = true;
    }

    public void PowerOff() {
        Debug.Log("Powered device off");
        poweredOff = true;
    }

    public int GetNumberOfContextOptions() {
        return 4;
    }
}
