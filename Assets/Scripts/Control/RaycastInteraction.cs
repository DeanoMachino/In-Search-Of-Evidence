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
            if (!this.GetComponent<UIContextMenu>().menuOpen) {
                if (Physics.Raycast(activationRay, out hit)) {
                    Debug.Log("Raycast hit " + hit.transform.tag);
                    if (hit.transform.gameObject.GetComponent<EntityStats>().contextable) {
                        Debug.Log("Hit " + hit.transform.gameObject.tag);
                        this.GetComponent<UIContextMenu>().ActivateMenu(hit.transform.gameObject);
                    }
                }
            }
        }
	}
}
