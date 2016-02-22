using UnityEngine;
using System.Collections;

[AddComponentMenu("Control/Raycast Interaction")]

public class RaycastInteraction : MonoBehaviour {

    private GameObject objectHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray activationRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            if (!this.GetComponent<ContextMenu>().menuOpen) {
                if (Physics.Raycast(activationRay, out hit)) {
                    Debug.Log("Raycast hit " + hit.transform.tag);
                    if (hit.transform.tag == "Computer") {
                        Debug.Log("Hit " + hit.transform.tag);
                        this.GetComponent<ContextMenu>().ActivateMenu(hit.transform.gameObject);
                    }
                }
            }
        }
	}
}
