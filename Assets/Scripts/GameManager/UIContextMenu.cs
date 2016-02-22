using UnityEngine;
using System.Collections;

[AddComponentMenu("Game Manager/Context Menu")]

public class UIContextMenu : MonoBehaviour {

    public bool menuOpen;
    private GameObject activeObject;
    public Vector2 menuPosition;
    private Vector2 menuDimensions = new Vector2(250, 200);
    private int menuButtons = 1;

    public GameObject bot;

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
            /*if (GUI.Button(new Rect(menuPosition.x, menuPosition.y+20, menuDimensions.x, 50), "Option 1")) {
                menuOpen = false;
            }*/
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
        switch (activeObject.transform.tag) {
            case "Computer":
                Transform t = activeObject.transform;
                t.position.Set(t.position.x, 1, t.position.z);
                bot.GetComponent<AISimpleLerp>().target = t;
                Debug.Log("ObjectContextMenu");
                if (!activeObject.GetComponent<EntityStats>().inspected) {
                    if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + 20, menuDimensions.x, 20), "Inspect")) {
                        Debug.Log("Inspected " + activeObject.transform.tag);
                        activeObject.GetComponent<EntityStats>().InspectObject();
                    }
                }
                break;
        }
        if (GUI.Button(new Rect(menuPosition.x, menuPosition.y + menuDimensions.y - 20, menuDimensions.x, 20), "Back")) {
            menuOpen = false;
        }
    }
}
