using UnityEngine;
using System.Collections;

[AddComponentMenu("Game Manager/Context Menu")]

public class UIContextMenu : MonoBehaviour {

    public bool menuOpen;
    private GameObject activeObject;
    public Vector2 menuPosition;
    private Vector2 menuDimensions = new Vector2(250, 200);
    private int menuButtons = 1;

    public GameObject polis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //menuPosition = Input.mousePosition;
	}

    void OnGUI() {
        if (menuOpen) {
            GUI.Box(new Rect(menuPosition.x, menuPosition.y, menuDimensions.x, menuDimensions.y), activeObject.transform.tag);
            ObjectContextMenu();
        }
    }

    public void ActivateMenu(GameObject object_) {
        menuOpen = true;

        activeObject = object_;

        menuPosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        // Check number of menu options -Dean
        menuButtons = activeObject.GetComponent<EntityStats>().GetNumberOfContextOptions();
        menuDimensions.y = 20 * (menuButtons + 2);
    }

    void ObjectContextMenu() {
        EntityStats stats = activeObject.GetComponent<EntityStats>();
        switch (activeObject.transform.tag) {
            case "Door":

                break;
            case "Couch":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Table":
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Chair":
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Fridge":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "TV":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Bed":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 *2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Ipad":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.disconnected) {
                    // Disconnect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 3, menuDimensions.x, 20), "Disconnect")) {
                        Debug.Log("Disconnected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().DisconnectFromInternet();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.poweredOff) {
                    // Powered Off button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 4, menuDimensions.x, 20), "Power off")) {
                        Debug.Log("Powered off " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().PowerOff();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Laptop":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.disconnected) {
                    // Disconnect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 3, menuDimensions.x, 20), "Disconnect")) {
                        Debug.Log("Disconnected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().DisconnectFromInternet();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.poweredOff) {
                    // Powered Off button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 4, menuDimensions.x, 20), "Power off")) {
                        Debug.Log("Powered off " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().PowerOff();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Pendrive":
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Disks":
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Toilet":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Sink":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Shower":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Counter":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "GameConsole":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.disconnected) {
                    // Disconnect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 3, menuDimensions.x, 20), "Disconnect")) {
                        Debug.Log("Disconnected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().DisconnectFromInternet();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.poweredOff) {
                    // Powered Off button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 4, menuDimensions.x, 20), "Power off")) {
                        Debug.Log("Powered off " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().PowerOff();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Computer":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.disconnected) {
                    // Disconnect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 3, menuDimensions.x, 20), "Disconnect")) {
                        Debug.Log("Disconnected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().DisconnectFromInternet();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.poweredOff) {
                    // Powered Off button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 4, menuDimensions.x, 20), "Power off")) {
                        Debug.Log("Powered off " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().PowerOff();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Router":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.disconnected) {
                    // Disconnect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 3, menuDimensions.x, 20), "Disconnect")) {
                        Debug.Log("Disconnected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().DisconnectFromInternet();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.poweredOff) {
                    // Powered Off button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 4, menuDimensions.x, 20), "Power off")) {
                        Debug.Log("Powered off " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().PowerOff();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Phone":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.disconnected) {
                    // Disconnect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 3, menuDimensions.x, 20), "Disconnect")) {
                        Debug.Log("Disconnected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().DisconnectFromInternet();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.poweredOff) {
                    // Powered Off button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 4, menuDimensions.x, 20), "Power off")) {
                        Debug.Log("Powered off " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().PowerOff();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "Camera":
                if (!stats.inspected) {
                    // Inspect button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                } else {
                    if (!stats.tookContents) {
                        // Take contents button
                        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take contents")) {
                            Debug.Log("Took contents " + activeObject.transform.tag);
                            activeObject.GetComponent<EntityStats>().TakeObjectContents();
                            MoveCharToPoint(activeObject.transform);
                        }
                    }
                }
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                if (!stats.poweredOff) {
                    // Powered Off button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 4, menuDimensions.x, 20), "Power off")) {
                        Debug.Log("Powered off " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().PowerOff();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
            case "PostItNotes":
                if (!stats.seized) {
                    // Seize button
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
                        Debug.Log("Seized " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().SeizeObject();
                        MoveCharToPoint(activeObject.transform);
                    }
                }
                break;
        }
        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + menuDimensions.y - 20, menuDimensions.x, 20), "Back")) {
            menuOpen = false;
        }
    }

    void MoveCharToPoint(Transform t) {
        Debug.Log("MoveCharToPoint");
        polis.GetComponent<AISimpleLerp>().target = t;
    }
}
