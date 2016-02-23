using UnityEngine;
using System.Collections;

[AddComponentMenu("Game Manager/Context Menu")]

public class UIContextMenu : MonoBehaviour {

    public bool menuOpen;
    private GameObject activeObject;
    public Vector2 menuPosition;
    private Vector2 menuDimensions = new Vector2(250, 200);
    private int menuButtons = 1;

    public SquadManager squadManager;

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
		if (!stats.tasked) {
			switch (activeObject.transform.tag) {
				case "Couch":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					break;
				case "Table":
					CheckSeize(stats);
					break;
				case "Chair":
					CheckSeize(stats);
					break;
				case "Fridge":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					break;
				case "TV":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					break;
				case "Bed":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					break;
				case "Ipad":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					CheckDisconnect(stats);
					CheckPowerOff(stats);
					break;
				case "Laptop":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					CheckDisconnect(stats);
					CheckPowerOff(stats);
					break;
				case "Pendrive":
					CheckSeize(stats);
					break;
				case "Disks":
					CheckSeize(stats);
					break;
				case "Toilet":
					CheckInspect(stats);
					break;
				case "Sink":
					CheckInspect(stats);
					break;
				case "Shower":
					CheckInspect(stats);
					break;
				case "Counter":
					CheckInspect(stats);
					break;
				case "GameConsole":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					CheckDisconnect(stats);
					CheckPowerOff(stats);
					break;
				case "Computer":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					CheckDisconnect(stats);
					CheckPowerOff(stats);
					break;
				case "Router":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					CheckDisconnect(stats);
					CheckPowerOff(stats);
					break;
				case "Phone":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					CheckDisconnect(stats);
					CheckPowerOff(stats);
					break;
				case "Camera":
					CheckInspect(stats);
					CheckTakeEvidence(stats);
					CheckSeize(stats);
					CheckPowerOff(stats);
					break;
				case "PostItNotes":
					CheckSeize(stats);
					break;
			}
		} else {
			GUI.Box(new Rect(menuPosition.x, menuPosition.y + 40, menuDimensions.x, 25), "In progress...");
		}
		// Display back button
		BackButton();
    }

    void MoveCharToPoint(Transform t) {
        Debug.Log("MoveCharToPoint");
        //polis.GetComponent<AISimpleLerp>().target = t;
    }

	void CheckInspect(EntityStats stats) {
		// If object hasb't been seized
		if (!stats.seized) {
			// If object hasn't been inspected
			if (!stats.inspected) {
				// Inspect button
				if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
					Debug.Log("Inspected " + activeObject.transform.tag);
					activeObject.GetComponent<EntityStats>().InspectObject();
					squadManager.AddTask(activeObject, TaskType.INSPECT);
					stats.tasked = true;
					menuOpen = false;
				}
			}
		}
	}

	void CheckTakeEvidence(EntityStats stats) {
		// If object hasn't been seized
		if (!stats.seized) {
			// If object evidence hasn't been taken
			if (stats.inspected) {
				if (!stats.takenEvidence) {
					// Take contents button
					if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Take evidence")) {
						Debug.Log("Took evidence " + activeObject.transform.tag);
						activeObject.GetComponent<EntityStats>().TakeObjectEvidence();
						squadManager.AddTask(activeObject, TaskType.TAKE_EVIDENCE);
						stats.tasked = true;
						menuOpen = false;
					}
				}
			}
		}
	}

	void CheckSeize(EntityStats stats) {
		// If object hasn't been seized
		if (!stats.seized) {
			// Seize button
			if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 2, menuDimensions.x, 20), "Seize")) {
				Debug.Log("Seized " + activeObject.transform.tag);
				activeObject.GetComponent<EntityStats>().SeizeObject();
				squadManager.AddTask(activeObject, TaskType.SEIZE);
				stats.tasked = true;
				menuOpen = false;
			}
		}
	}

	void CheckDisconnect(EntityStats stats) {
		// If object hasn't been seized
		if (!stats.seized) {
			// If object hasn't been disconnected
			if (!stats.disconnected) {
				// Disconnect button
				if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 3, menuDimensions.x, 20), "Disconnect")) {
					Debug.Log("Disconnected " + activeObject.transform.tag);
					activeObject.GetComponent<EntityStats>().DisconnectFromInternet();
					squadManager.AddTask(activeObject, TaskType.DISCONNECT);
					stats.tasked = true;
					menuOpen = false;
				}
			}
		}
	}

	void CheckPowerOff(EntityStats stats) {
		// If object hasn't been seized
		if (!stats.seized) {
			// If object hasn't been powered off
			if (!stats.poweredOff) {
				// Powered Off button
				if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20 * 4, menuDimensions.x, 20), "Power off")) {
					Debug.Log("Powered off " + activeObject.transform.tag);
					activeObject.GetComponent<EntityStats>().PowerOff();
					squadManager.AddTask(activeObject, TaskType.POWER_OFF);
					stats.tasked = true;
					menuOpen = false;
				}
			}
		}
	}

	void BackButton() {
		if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + menuDimensions.y - 20, menuDimensions.x, 20), "Back")) {
			menuOpen = false;
		}
	}
}
